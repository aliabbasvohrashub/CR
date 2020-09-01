using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using ErikEJ.SqlCe;

namespace Bajaj.Dinesh.Biller
{
    internal class InterDatabaseDataTransfer
    {
        public static bool TransferData(string sourceDatabasePath, string targetDatabasePath)
        {
            string sourceConnectionString = "Data Source = " + sourceDatabasePath + "; Password = " +
                 Properties.Settings.Default.PASSWORD;
            string targetConnectionString = "Data Source = " + targetDatabasePath + "; Password = " +
                Properties.Settings.Default.PASSWORD;

            SqlCeConnection targetConnection = null;
            SqlCeTransaction transaction = null;

            try
            {
                using (SqlCeConnection sourceConnection = new SqlCeConnection(sourceConnectionString))
                {
                    targetConnection = new SqlCeConnection(targetConnectionString);

                    string[] tableNames = { "FirmDetails", "UnitOfMeasurement", "Items", "Customers" };

                    sourceConnection.Open();
                    targetConnection.Open();

                    foreach (string tableName in tableNames)
                    {
                        transaction = targetConnection.BeginTransaction();
                        transferTableData(sourceConnection, targetConnection, transaction, tableName);
                        transaction.Commit(CommitMode.Immediate);
                        transaction.Dispose();
                    }

                    transaction = targetConnection.BeginTransaction();
                    transferCustomerBalance(sourceConnection, targetConnection, transaction);
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception exception)
                    {
                        ErrorLogger.LogError(exception);
                    }
                }

                string message = "An error occurred in transferring data from the previous financial year to the new " +
                    "financial year.\n The error text is as follows:\n" + Global.getExceptionText(ex);
                System.Media.SystemSounds.Hand.Play();
                System.Windows.Forms.MessageBox.Show(message, "Error Occurred", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }
            finally
            {
                if (transaction != null)
                {
                    transaction.Dispose();
                }
                if (targetConnection != null)
                {
                    targetConnection.Close();
                    targetConnection.Dispose();
                }
            }

            return true;
        }

        private static void transferTableData(SqlCeConnection sourceConnection, SqlCeConnection targetConnection,
            SqlCeTransaction transaction, string tableName)
        {
            using (SqlCeCommand sourceCommand = sourceConnection.CreateCommand())
            {
                sourceCommand.CommandText = "Select * from " + tableName;
                using (SqlCeDataReader sourceReader = sourceCommand.ExecuteReader())
                {
                    SqlCeBulkCopyOptions options = new SqlCeBulkCopyOptions();
                    options = options |= SqlCeBulkCopyOptions.KeepNulls;
                    string[] tableNames = { "FirmDetails" };
                    if (!tableNames.Contains(tableName))
                    {
                        options |= SqlCeBulkCopyOptions.KeepIdentity;
                    }

                    using (SqlCeBulkCopy bc = new SqlCeBulkCopy(targetConnection, options, transaction))
                    {
                        bc.DestinationTableName = tableName;
                        bc.WriteToServer((IDataReader)sourceReader);
                    }

                    if (!tableNames.Contains(tableName))
                    {
                        using (SqlCeCommand command = targetConnection.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandText = "SELECT MAX(ID) FROM " + tableName;
                            object value = command.ExecuteScalar();
                            int id;
                            if (value == null || value == DBNull.Value)
                            {
                                id = 1;
                            }
                            else
                            {
                                id = (int)value;
                            }
                            command.CommandText = "ALTER TABLE " + tableName + " ALTER COLUMN ID IDENTITY (" +
                                (id + 1) + ", 1)";
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private static void transferCustomerBalance(SqlCeConnection sourceConnection, SqlCeConnection targetConnection,
            SqlCeTransaction transaction)
        {
            Dictionary<int, decimal> customerBalance;

            using (SqlCeCommand command = sourceConnection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM Customers";
                int count = (int)command.ExecuteScalar();
                customerBalance = new Dictionary<int, decimal>(count);

                command.CommandText = "SELECT ID FROM Customers";

                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return;
                    }

                    decimal? balance;
                    int customerID;
                    string errorText;

                    do
                    {
                        customerID = reader.GetInt32(0);
                        balance = GlobalMethods.GetCustomerBalance(customerID, out errorText, sourceConnection);
                        if (!balance.HasValue)
                        {
                            throw new Exception("A customer's balance couldn't be read from the source database.");
                        }
                        customerBalance.Add(customerID, balance.Value);
                    } while (reader.Read());
                }
            }

            using (SqlCeCommand command = targetConnection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = "UPDATE Customers SET OpeningBalance = @openingBalance, BalanceType = @balanceType " +
                    "WHERE ID = @id";

                SqlCeParameterCollection parameters = command.Parameters;
                SqlCeParameter openingBalance = parameters.Add("@openingBalance", SqlDbType.Decimal);
                SqlCeParameter balanceType = parameters.Add("@balanceType", SqlDbType.NChar);
                SqlCeParameter customerID = parameters.Add("@id", SqlDbType.Int);

                command.Prepare();

                foreach (KeyValuePair<int, decimal> pair in customerBalance)
                {
                    openingBalance.Value = Math.Abs(pair.Value);
                    if (pair.Value > 0.0M)
                    {
                        balanceType.Value = 'C';
                    }
                    else if (pair.Value < 0.0M)
                    {
                        balanceType.Value = 'D';
                    }
                    else
                    {
                        balanceType.Value = DBNull.Value;
                    }
                    customerID.Value = pair.Key;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}