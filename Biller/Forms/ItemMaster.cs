using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Bajaj.Dinesh.Biller
{
    internal sealed partial class ItemMaster : Form
    {
        private DataTable unitsTable;
        private bool toCloseForm = false;
        private int lastUoMAssigned = 0;

        public ItemMaster()
        {
            InitializeComponent();
        }

        private void ItemMaster_Load(object sender, EventArgs e)
        {
            this.Icon = this.MdiParent.Icon;

            if (!loadData())
            {
                return;
            }

            ConfigureGridColumns();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!saveData())
            {
                return;
            }

            Cursor.Current = Cursors.Default;
            this.Close();
        }

        private void deleteItemButton_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = itemsGrid.SelectedRows.Count;
            string message = "Are you sure that you want to delete the selected ";

            if (selectedRowsCount > 1)
            {
                message += selectedRowsCount + " rows?";
            }
            else
            {
                message += "row?";
            }

            DialogResult result = MessageBox.Show(message, "Confirm Deletion", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            DataGridViewSelectedRowCollection rows = itemsGrid.SelectedRows;
            foreach (var row in rows)
            {
                itemsGrid.Rows.Remove((DataGridViewRow)row);
            }
        }

        private void itemsGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ////string errorText = Global.getExceptionText(e.Exception);
            ////errorText = errorText.Replace("\n", " ").Replace("nulls", "blank value");
            ////errorText = replaceColumnNamesWithHelpfulNames(errorText);

            ////itemsGrid.Rows[e.RowIndex].ErrorText = errorText;
            ////e.Cancel = true;
        }

        private void itemsGrid_SelectionChanged(object sender, EventArgs e)
        {
            deleteItemButton.Enabled = (itemsGrid.SelectedRows.Count > 0) ? true : false;
        }

        private void filterTextField_TextChanged(object sender, EventArgs e)
        {
            string text = filterTextField.Text.Trim();
            DataTable table = (DataTable)itemsGrid.DataSource;

            if (text.Length == 0)
            {
                table.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                table.DefaultView.RowFilter = "Name Like '*" + text + "*'";
            }
        }

        private void itemsGrid_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            itemsGrid.Rows[e.RowIndex].ErrorText = null;
        }

        private bool loadData()
        {
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            if (errorText != null)
            {
                Global.DisplayConnectionErrorMessage();
                return false;
            }

            return loadData(connection);
        }

        private bool loadData(SqlCeConnection connection)
        {
            try
            {
                unitsTable = loadUnits(connection);
                if (unitsTable.Rows.Count == 0)
                {
                    string message = "No unit of measurement (UoM) has been defined so far. " +
                        "\nThe items can only be defined after 1 or more UoM has been defined.";
                    System.Media.SystemSounds.Exclamation.Play();
                    MessageBox.Show(message, "UoM Not Defined", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    toCloseForm = true;
                    return false;
                }
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Items";
                    command.CommandType = CommandType.TableDirect;

                    using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(command))
                    {
                        DataTable table = new DataTable("Items");
                        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        adapter.FillSchema(table, SchemaType.Source);

                        adapter.Fill(table);
                        itemsGrid.DataSource = table;
                        table.ColumnChanged += new DataColumnChangeEventHandler(table_ColumnChanged);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "An error occurred in fetching the data from the database." +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Exclamation.Play();
                MessageBox.Show(message, "Error in Fetching Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                toCloseForm = true;
                return false;
            }

            return true;
        }

        private void table_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName != "UoMID")
            {
                return;
            }

            lastUoMAssigned = (int)e.ProposedValue;
            System.Diagnostics.Debug.WriteLine("value = " + lastUoMAssigned);
        }

        private DataTable loadUnits(SqlCeConnection connection)
        {
            DataTable table = new DataTable("UnitOfMeasurement");

            using (SqlCeCommand command = connection.CreateCommand())
            {
                command.CommandText = "UnitOfMeasurement";
                command.CommandType = CommandType.TableDirect;

                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            return table;
        }

        private void ConfigureGridColumns()
        {
            DataGridViewColumnCollection columns = itemsGrid.Columns;

            columns[0].Visible = false;

            columns[1].HeaderText = "Item Name";
            columns[1].Width = 230;

            columns.RemoveAt(2);

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.DataPropertyName = "UoMID";
            column.DataSource = unitsTable;
            column.DisplayMember = "UnitName";
            column.ValueMember = "ID";
            column.ValueType = SqlDbType.Int.GetType();
            column.Width = 120;
            column.Name = "UoMID";
            column.HeaderText = "Measurement Unit";
            column.DisplayStyleForCurrentCellOnly = true;

            columns.Insert(2, column);

            DataGridViewTextBoxColumn textColumn = (DataGridViewTextBoxColumn)columns[3];
            textColumn.HeaderText = "Price Per Unit (Rs.)";
            textColumn.Width = 120;
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            textColumn.DefaultCellStyle.Format = "N2";
        }

        private void itemsGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (itemsGrid.Rows[e.RowIndex].IsNewRow)
            {
                return;
            }

            if (e.ColumnIndex == 3)
            {
                validateItemPrice(e);
            }
            else if (e.ColumnIndex == 1)
            {
                validateItemName(e);
            }
        }

        private void validateItemPrice(DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                decimal value = decimal.Parse((string)e.FormattedValue);
                if (value <= 0.0M)
                {
                    itemsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Price has to be greater than zero.";
                    e.Cancel = true;
                }
            }
            catch (Exception)
            {
                itemsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Not a valid numeric value provided for the price.";
                e.Cancel = true;
            }
        }

        private void validateItemName(DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue == null)
            {
                e.Cancel = true;
                itemsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Item name can't be left blank";
                return;
            }

            string str = (string)e.FormattedValue;
            if (string.IsNullOrWhiteSpace(str))
            {
                e.Cancel = true;
                itemsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Item name can't be left blank";
            }
        }

        private void itemsGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            itemsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = null;
        }

        private string replaceColumnNamesWithHelpfulNames(string message)
        {
            return message.Replace("NAME", "Item Name")
                  .Replace("UoMID", "Measurement Unit")
                  .Replace("UnitPrice", "Unit Price");
        }

        private bool saveData()
        {
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            if (errorText != null)
            {
                Global.DisplayConnectionErrorMessage();
                return false;
            }

            return saveData(connection);
        }

        private bool saveData(SqlCeConnection connection)
        {
            SqlCeTransaction transaction = null;

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Items";
                    command.CommandType = CommandType.TableDirect;

                    using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(command))
                    {
                        adapter.InsertCommand = getInsertCommand(connection);
                        adapter.UpdateCommand = getUpdateCommand(connection);
                        adapter.DeleteCommand = getDeleteCommand(connection);

                        adapter.AcceptChangesDuringUpdate = false;

                        DataTable table = (DataTable)itemsGrid.DataSource;

                        transaction = connection.BeginTransaction();
                        adapter.InsertCommand.Transaction = transaction;
                        adapter.UpdateCommand.Transaction = transaction;
                        adapter.DeleteCommand.Transaction = transaction;

                        adapter.Update(table);

                        transaction.Commit();
                        table.AcceptChanges();
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

        private SqlCeCommand getInsertCommand(SqlCeConnection connection)
        {
            SqlCeCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Items (Name, UoMID, UnitPrice) "
                + "VALUES (@p1, @p2, @p3)";

            SqlCeParameterCollection parameters = command.Parameters;

            SqlCeParameter parameter = new SqlCeParameter();
            parameter.ParameterName = "@p1";
            parameter.SourceColumn = "Name";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameters.Add(parameter);

            parameter = new SqlCeParameter();
            parameter.ParameterName = "@p2";
            parameter.SourceColumn = "UoMID";
            parameter.SqlDbType = SqlDbType.Int;
            parameters.Add(parameter);

            parameter = new SqlCeParameter();
            parameter.ParameterName = "@p3";
            parameter.SourceColumn = "UnitPrice";
            parameter.SqlDbType = SqlDbType.Money;
            parameters.Add(parameter);

            return command;
        }

        private SqlCeCommand getUpdateCommand(SqlCeConnection connection)
        {
            SqlCeCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Items SET Name = @p1, UoMID = @p2, " +
                "UnitPrice = @p3 WHERE ID = @p4";

            SqlCeParameterCollection parameters = command.Parameters;

            SqlCeParameter parameter = new SqlCeParameter();
            parameter.ParameterName = "@p1";
            parameter.SourceColumn = "Name";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameters.Add(parameter);

            parameter = new SqlCeParameter();
            parameter.ParameterName = "@p2";
            parameter.SourceColumn = "UoMID";
            parameter.SqlDbType = SqlDbType.Int;
            parameters.Add(parameter);

            parameter = new SqlCeParameter();
            parameter.ParameterName = "@p3";
            parameter.SourceColumn = "UnitPrice";
            parameter.SqlDbType = SqlDbType.Money;
            parameters.Add(parameter);

            parameter = new SqlCeParameter();
            parameter.ParameterName = "@p4";
            parameter.SourceColumn = "ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.SourceVersion = DataRowVersion.Original;
            parameters.Add(parameter);

            return command;
        }

        private SqlCeCommand getDeleteCommand(SqlCeConnection connection)
        {
            SqlCeCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM ITEMS WHERE ID = @p1";

            SqlCeParameterCollection parameters = command.Parameters;

            SqlCeParameter parameter = new SqlCeParameter();
            parameter.ParameterName = "@p1";
            parameter.SourceColumn = "ID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.SourceVersion = DataRowVersion.Default;
            parameters.Add(parameter);

            return command;
        }

        private void ItemMaster_Shown(object sender, EventArgs e)
        {
            if (toCloseForm)
            {
                this.Close();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            try
            {
                unitsTable = loadUnits(connection);
            }
            catch (Exception ex)
            {
                string message = "An error occurred in fetching the refreshed units of measurement."
                    + "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Exclamation.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Fetching Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return;
            }

            ((DataGridViewComboBoxColumn)itemsGrid.Columns[2]).DataSource = unitsTable;
            Cursor.Current = Cursors.Default;
        }

        private void itemsGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2)
            {
                return;
            }

            if (itemsGrid[e.ColumnIndex, e.RowIndex].Value == DBNull.Value)
            {
                SendKeys.Send("{F4}");
            }
        }

        private void itemsGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2)
            {
                return;
            }

            DataGridViewCell cell = itemsGrid[e.ColumnIndex, e.RowIndex];
            if (cell.Value != DBNull.Value)
            {
                return;
            }

            itemsGrid.EndEdit();

            if (lastUoMAssigned != 0)
            {
                cell.Value = lastUoMAssigned;
            }
            else
            {
                cell.Value = unitsTable.Rows[0][0];
            }
        }
    }
}