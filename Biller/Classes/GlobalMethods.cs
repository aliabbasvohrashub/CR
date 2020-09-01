using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.IO;

using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bajaj.Dinesh.Biller
{
    internal static class GlobalMethods
    {
        /// <summary>
        /// Returns customer's account balance.
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>Returns debit balance as negative number and credit balance as positive number</returns>
        public static decimal? GetCustomerBalance(int customerID, out string errorText,
            SqlCeConnection connection = null, DateTime? endDate = null)
        {
            if (connection == null)
            {
                connection = Global.getDatabaseConnection(out errorText);
                if (connection == null)
                {
                    return null;
                }
            }

            decimal? openingBalance = GetCustomerOpeningBalance(customerID, out errorText, connection);
            decimal? invoiceTotal = GetInvoiceTotal(customerID, out errorText, connection, endDate);
            decimal? paymentTotal = GetPaymentTotal(customerID, out errorText, connection, endDate);

            if (openingBalance == null || invoiceTotal == null || paymentTotal == null)
            {
                return null;
            }

            invoiceTotal *= -1;
            return openingBalance + invoiceTotal + paymentTotal;
        }

        public static string GetBalanceAsString(decimal balanceAmount)
        {
            decimal amount = Math.Abs(balanceAmount);
            string result = amount.ToString("N2");

            if (balanceAmount < 0.0M)
            {
                result += " DR.";
            }
            else if (balanceAmount > 0.0M)
            {
                result += " CR.";
            }

            return result;
        }

        public static decimal? GetCustomerOpeningBalance(int customerID,
            out string errorText, SqlCeConnection connection = null)
        {
            if (connection == null)
            {
                connection = Global.getDatabaseConnection(out errorText);
                if (connection == null) return null;
            }

            string sql = "SELECT OpeningBalance, BalanceType FROM Customers " +
                "WHERE ID = " + customerID;

            decimal openingBalance;
            string balanceType = null;

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        openingBalance = reader.GetDecimal(0);
                        if (!reader.IsDBNull(1))
                        {
                            balanceType = reader.GetString(1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorText = Global.getExceptionText(ex);
                ErrorLogger.LogError(ex);
                return null;
            }

            if (balanceType != null && balanceType.ToLower().Equals("d"))
            {
                openingBalance *= -1; //negate the amount to indicate debit balance
            }

            errorText = null;
            return openingBalance;
        }

        public static decimal? GetInvoiceTotal(int customerID, out string errorText,
            SqlCeConnection connection, DateTime? endDate)
        {
            string sql = "SELECT (BD.ItemsTotal + ExpenseAmount - DiscountAmount) as Total "
                + "From BillMaster BM OUTER APPLY (SELECT SUM(Rate * Quantity) as ItemsTotal FROM BillDetails "
                + "WHERE BillID = BM.ID) BD WHERE CustomerID = " + customerID;

            if (endDate.HasValue)
            {
                sql += " And BillDate <= '" + endDate.Value.ToString("yyyyMMdd") + "'";
            }

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    object value = command.ExecuteScalar();
                    errorText = null;
                    if (value != null && value != DBNull.Value)
                    {
                        return (decimal?)value;
                    }
                    else
                    {
                        return 0.0M;
                    }
                }
            }
            catch (Exception ex)
            {
                errorText = Global.getExceptionText(ex);
                ErrorLogger.LogError(ex);
                return null;
            }
        }

        public static decimal? GetPaymentTotal(int customerID, out string errorText,
            SqlCeConnection connection, DateTime? endDate)
        {
            string sql = "SELECT SUM(Amount) AS Total FROM Payments WHERE CustomerID = " + customerID;
            if (endDate.HasValue)
            {
                sql += " AND PaymentDate <= '" + endDate.Value.ToString("yyyyMMdd") + "'";
            }

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    object result = command.ExecuteScalar();

                    errorText = null;
                    if (result == null || result == DBNull.Value)
                    {
                        return 0.0M;
                    }
                    else
                    {
                        return (decimal?)result;
                    }
                }
            }
            catch (Exception ex)
            {
                errorText = Global.getExceptionText(ex);
                ErrorLogger.LogError(ex);
                return null;
            }
        }

        internal class FirmDetails
        {
            public string FirmName { get; set; }

            public string FirmAddress { get; set; }

            public string PhoneNumbers { get; set; }

            public FirmDetails()
            {
                FirmName = FirmAddress = PhoneNumbers = string.Empty;
            }
        }

        public static FirmDetails GetFirmDetails(out string errorText)
        {
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);
            if (connection == null)
            {
                return null;
            }

            using (SqlCeCommand command = connection.CreateCommand())
            {
                command.CommandText = "Select * From FirmDetails";

                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        errorText = null;
                        return null;
                    }

                    FirmDetails firmDetails = new FirmDetails();
                    firmDetails.FirmName = reader.GetString(0);
                    if (reader.IsDBNull(1))
                    {
                        firmDetails.FirmAddress = string.Empty;
                    }
                    else
                    {
                        firmDetails.FirmAddress = reader.GetString(1);
                    }

                    if (reader.IsDBNull(2))
                    {
                        firmDetails.PhoneNumbers = string.Empty;
                    }
                    else
                    {
                        firmDetails.PhoneNumbers = reader.GetString(2);
                    }

                    errorText = null;
                    return firmDetails;
                }
            }
        }

        public static List<FinancialYear> GetFinancialYears(string directoryPath = null)
        {
            if (directoryPath == null)
            {
                directoryPath = Properties.Settings.Default.DatabasePath + "\\" +
                    Global.ROOT_DATA_FOLDER;
            }

            if (!Directory.Exists(directoryPath))
            {
                return null;
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            FileInfo[] filesInfo = null;

            try
            {
                filesInfo = directoryInfo.GetFiles("*." + Global.DATABASE_FILE_EXTENSION);
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex);
                return null;
            }

            List<FinancialYear> financialYears = new List<FinancialYear>();
            FinancialYear fy;

            foreach (FileInfo fileInfo in filesInfo)
            {
                fy = getFinancialYear(fileInfo.FullName);
                if (fy != null)
                {
                    financialYears.Add(fy);
                }
            }

            financialYears.Sort(CompareFinancialYears);
            financialYears.Reverse(); // so that the list is in the descending order

            return financialYears;
        }

        internal static FinancialYear getFinancialYear(string filePath)
        {
            string errorText;
            SqlCeConnection connection = Global.CreateDatabaseConnection(filePath, out errorText);

            if (connection == null)
            {
                return null;
            }

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM FinancialYear";

                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }
                        int startYear = reader.GetInt32(0); // start year
                        DateTime booksStartDate = reader.GetDateTime(1);
                        return new FinancialYear(startYear, booksStartDate, filePath);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        private static int CompareFinancialYears(FinancialYear a, FinancialYear b)
        {
            return a.CompareTo(b);
        }

        public static bool closeCurrentlyOpenYear()
        {
            string[] names = new string[6];
            names[0] = typeof(Configuration).Name;
            names[1] = typeof(OpenFinancialYear).Name;
            names[2] = typeof(RestoreDatabase).Name;
            names[3] = typeof(DeleteFinancialYear).Name;
            names[4] = typeof(CreateFinancialYear).Name;
            names[5] = typeof(BackupDatabase).Name;

            Form[] forms = Global.MDIForm.MdiChildren;
            foreach (Form form in forms)
            {
                if (!names.Contains(form.GetType().Name))
                {
                    try
                    {
                        form.Close();
                    }
                    catch (Exception ex)
                    {
                        ErrorLogger.LogError(ex);
                        return false;
                    }
                    form.Close();
                }
            }

            Global.CloseDatabaseConnection();
            Global.CurrentFinancialYear = null;
            Global.MDIForm.Text = Global.AssemblyTitle;

            return true;
        }

        public static bool ShrinkDatabase(string filePath)
        {
            string connectionString = "Data Source = " + filePath + "; Password = " +
                Properties.Settings.Default.PASSWORD;
            try
            {
                using (SqlCeEngine ceEngine = new SqlCeEngine(connectionString))
                {
                    ceEngine.Shrink();
                }
            }
            catch (Exception ex)
            {
                string message = "An error occurred in compacting the database." +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }
    }
}