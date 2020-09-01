using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Bajaj.Dinesh.Biller
{
    internal sealed partial class UnitOfMeasurement : Form
    {
        private bool toCloseForm = false;

        public UnitOfMeasurement()
        {
            InitializeComponent();
        }

        private void UnitOfMeasurement_Load(object sender, EventArgs e)
        {
            this.Icon = this.MdiParent.Icon;

            if (!LoadData())
            {
                toCloseForm = true;
                return;
            }

            ConfigureGridColumns();
        }

        private bool LoadData()
        {
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            if (errorText != null)
            {
                Global.DisplayConnectionErrorMessage();

                return false;
            }

            return LoadData(connection);
        }

        private bool LoadData(SqlCeConnection connection)
        {
            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UnitOfMeasurement";
                    command.CommandType = CommandType.TableDirect;

                    using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(command))
                    {
                        DataTable unitsTable = new DataTable("UnitOfMeasurement");
                        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        adapter.FillSchema(unitsTable, SchemaType.Source);

                        adapter.Fill(unitsTable);

                        unitsGrid.DataSource = unitsTable;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "An error occurred in fetching the data from the database." +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Exclamation.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Fetching Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }

        private void ConfigureGridColumns()
        {
            DataGridViewColumnCollection columns = unitsGrid.Columns;
            columns[0].Visible = false;

            DataGridViewColumn column = columns[1];
            columns[1].HeaderText = "Unit Name";
            columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            columns[1].FillWeight = 200;

            System.Diagnostics.Debug.Assert(unitsGrid.ColumnHeadersDefaultCellStyle.Font != null);
            unitsGrid.ColumnHeadersDefaultCellStyle.Font =
                new Font(unitsGrid.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            if (errorText != null)
            {
                Global.DisplayConnectionErrorMessage();
                return;
            }

            if (!saveData(connection))
            {
                return;
            }

            Cursor.Current = Cursors.Default;
            this.Close();
        }

        private void unitsGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                return;
            }

            if (unitsGrid.Rows[e.RowIndex].IsNewRow)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace((string)e.FormattedValue))
            {
                unitsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Unit name not specified.";
                e.Cancel = true;
            }
        }

        private void unitsGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            unitsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = null;
        }

        private void unitsGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string errorText = Global.getExceptionText(e.Exception);
            errorText = errorText.Replace("\n", " ");

            unitsGrid.Rows[e.RowIndex].ErrorText = errorText;
            e.Cancel = true;
        }

        private void unitsGrid_SelectionChanged(object sender, EventArgs e)
        {
            deleteUnitsButton.Enabled = unitsGrid.SelectedRows.Count > 0 ? true : false;
        }

        private void deleteUnitsButton_Click(object sender, EventArgs e)
        {
            int count = unitsGrid.SelectedRows.Count;
            string message = "Are you sure that you want to delete the selected ";

            if (count > 1)
            {
                message += count + " rows?";
            }
            else
            {
                message += " row?";
            }

            DialogResult result = MessageBox.Show(message, "Confirm Deletion", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            DataGridViewSelectedRowCollection rows = unitsGrid.SelectedRows;
            foreach (var item in rows)
            {
                unitsGrid.Rows.Remove((DataGridViewRow)item);
            }
        }

        private void unitsGrid_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            unitsGrid.Rows[e.RowIndex].ErrorText = null;
        }

        private bool saveData(SqlCeConnection connection)
        {
            SqlCeTransaction transaction = null;

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UnitOfMeasurement";
                    command.CommandType = CommandType.TableDirect;

                    using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(command))
                    {
                        adapter.AcceptChangesDuringUpdate = false;

                        adapter.InsertCommand = GetInsertCommand(connection);
                        adapter.UpdateCommand = GetUpdateCommand(connection);
                        adapter.DeleteCommand = GetDeleteCommand(connection);

                        transaction = connection.BeginTransaction();
                        adapter.InsertCommand.Transaction = transaction;
                        adapter.UpdateCommand.Transaction = transaction;
                        adapter.DeleteCommand.Transaction = transaction;

                        DataTable unitsTable = (DataTable)unitsGrid.DataSource;
                        adapter.Update(unitsTable);

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }

                string message = "An error occurred in saving the data. \n" +
                    "The error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Exclamation.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Saving Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }
            finally
            {
                if (transaction != null)
                {
                    transaction.Dispose();
                }
            }

            return true;
        }

        private SqlCeCommand GetInsertCommand(SqlCeConnection connection)
        {
            SqlCeCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO UnitOfMeasurement (UnitName) VALUES (@p1)";

            SqlCeParameter parameter = new SqlCeParameter("@p1", SqlDbType.NVarChar);
            parameter.SourceColumn = "UnitName";
            command.Parameters.Add(parameter);

            return command;
        }

        private SqlCeCommand GetUpdateCommand(SqlCeConnection connection)
        {
            SqlCeCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE UnitOfMeasurement SET UnitName = @p1 WHERE ID = @p2";

            SqlCeParameter paramter = new SqlCeParameter("@p1", SqlDbType.NVarChar);
            paramter.SourceColumn = "UnitName";
            command.Parameters.Add(paramter);

            paramter = new SqlCeParameter("@p2", SqlDbType.Int);
            paramter.SourceColumn = "ID";
            command.Parameters.Add(paramter);

            return command;
        }

        private SqlCeCommand GetDeleteCommand(SqlCeConnection connection)
        {
            SqlCeCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM UnitOfMeasurement WHERE ID = @p1";

            SqlCeParameter parameter = new SqlCeParameter("@p1", SqlDbType.Int);
            parameter.SourceColumn = "ID";
            parameter.SourceVersion = DataRowVersion.Default;

            command.Parameters.Add(parameter);

            return command;
        }

        private void UnitOfMeasurement_Shown(object sender, EventArgs e)
        {
            if (toCloseForm)
            {
                this.Close();
            }
        }
    }
}