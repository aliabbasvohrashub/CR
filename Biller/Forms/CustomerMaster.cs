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
    internal sealed partial class CustomerMaster : Form
    {
        private readonly List<FilterColumn> filterColumns;
        private bool toCloseForm = false;

        public CustomerMaster()
        {
            InitializeComponent();

            filterColumns = getFilterColumns();
            filterColumnsBox.DataSource = filterColumns;
            filterColumnsBox.DisplayMember = "DisplayMember";
            filterColumnsBox.ValueMember = "ValueMember";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private class FilterColumn
        {
            public string DisplayMember { get; set; }

            public string ValueMember { get; set; }

            public FilterColumn(string displayMember, string valueMember)
            {
                DisplayMember = displayMember;
                ValueMember = valueMember;
            }
        }

        private void CustomerMaster_Load(object sender, EventArgs e)
        {
            this.Icon = Global.MDIForm.Icon;

            if (!loadData())
            {
                toCloseForm = true;
                return;
            }

            configureDataGridColumns();
        }

        private List<FilterColumn> getFilterColumns()
        {
            List<FilterColumn> list = new List<FilterColumn>
            {
                new FilterColumn("Name", "Name"),
                new FilterColumn("Address", "Address"),
                new FilterColumn("City", "City"),
                new FilterColumn("Phone Numbers", "PhoneNumbers"),
                new FilterColumn("Mobile Numbers", "MobileNumbers"),
                new FilterColumn("Notes", "Notes")
            };

            return list;
        }

        private void filterColumnsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            applyFilter();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)customersGrid.DataSource;

            CustomerDetails customerDetails = new CustomerDetails(null, table);
            DialogResult result = customerDetails.ShowDialog(this);
            customerDetails.Dispose();

            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            //get the selected row
            DataGridViewRow gridRow = customersGrid.SelectedRows[0];
            int customerID = (int)gridRow.Cells[0].Value;

            DataTable table = (DataTable)customersGrid.DataSource;
            DataRow[] rows = table.Select("ID = " + customerID);

            CustomerDetails dialog = new CustomerDetails(rows[0], table);
            DialogResult result = dialog.ShowDialog(this);
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow gridRow = customersGrid.CurrentRow;
            string customerName = (string)gridRow.Cells["Name"].Value;

            DialogResult result = MessageBox.Show("Are you sure that you wish to remove the customer '" +
                customerName + "' ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            //remove the underlying data row from the table

            int id = (int)gridRow.Cells["ID"].Value;
            string filterExpression = "ID = " + id;

            DataTable table = (DataTable)customersGrid.DataSource;
            DataRow[] rows = table.Select(filterExpression);

            System.Diagnostics.Debug.Assert(rows.Length == 1);
            rows[0].Delete();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            if (errorText != null)
            {
                Cursor.Current = Cursors.Default;
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

        private void filterTextField_TextChanged(object sender, EventArgs e)
        {
            applyFilter();
        }

        private void customersGrid_SelectionChanged(object sender, EventArgs e)
        {
            bool rowSelected = customersGrid.SelectedRows.Count > 0;
            editButton.Enabled = rowSelected;
            deleteButton.Enabled = rowSelected;
        }

        private void CustomerMaster_Shown(object sender, EventArgs e)
        {
            if (toCloseForm)
            {
                this.Close();
            }
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
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Customers";
                    command.CommandType = CommandType.TableDirect;

                    using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(command))
                    {
                        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        DataTable table = new DataTable(command.CommandText);
                        adapter.FillSchema(table, SchemaType.Source);
                        adapter.Fill(table);

                        //create the expression column and populate it
                        createFormattedBalanceColumn(table);
                        customersGrid.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred in fetching the data from the database." +
                    "\nThe error text is as follows:\n" +
                    Global.getExceptionText(ex);
                SystemSounds.Exclamation.Play();
                MessageBox.Show(errorMessage, "Error in Fetching Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }

        private void configureDataGridColumns()
        {
            DataGridViewColumnCollection columns = customersGrid.Columns;
            columns[0].Visible = false; // hide the ID column

            DataGridViewColumn column = columns[1]; //customer name
            column.HeaderText = "Name";
            column.Width = 150;

            columns[2].HeaderText = "Phone Numbers";
            columns[2].Width = 90;

            column = columns[3];
            column.HeaderText = "Mobile Numbers";
            column.Width = 90;

            column = columns[4];
            column.HeaderText = "Address";
            column.Width = 100;

            column = columns[5];
            column.HeaderText = "City";
            column.Width = 50;

            columns.Remove("OpeningBalance");
            columns.Remove("BalanceType");

            columns[6].HeaderText = "Notes";
            columns[6].Width = 120;

            column = columns[7];
            column.HeaderText = "Opening Balance (Rs.)";
            column.Width = 140;
            column.DisplayIndex = 2;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void createFormattedBalanceColumn(DataTable table)
        {
            //create an expression column
            DataColumn column = new DataColumn("FormattedBalance", typeof(string));
            table.Columns.Add(column);

            foreach (DataRow row in table.Rows)
            {
                row[9] = getFormattedBalance(row); //populate the expression column
            }
        }

        private string getFormattedBalance(DataRow row)
        {
            decimal balance = (decimal)row[6];
            if (balance == 0.0M)
            {
                return balance.ToString("N2");
            }

            string result = balance.ToString("N2");
            string balanceType = (string)row[7];
            balanceType = balanceType.ToLower();

            result += " " + ((balanceType == "c") ? "Cr." : "Dr.");
            return result;
        }

        private bool saveData(SqlCeConnection connection)
        {
            SqlCeTransaction transaction = null;

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Customers";
                    command.CommandType = CommandType.TableDirect;

                    using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(command))
                    {
                        adapter.AcceptChangesDuringUpdate = false;

                        adapter.InsertCommand = getInsertCommand(connection);
                        adapter.UpdateCommand = getUpdateCommand(connection);
                        adapter.DeleteCommand = getDeleteCommand(connection);

                        transaction = connection.BeginTransaction();

                        adapter.InsertCommand.Transaction = transaction;
                        adapter.UpdateCommand.Transaction = transaction;
                        adapter.DeleteCommand.Transaction = transaction;

                        DataTable table = (DataTable)customersGrid.DataSource;
                        adapter.Update(table);

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
                string message = "An error occurred in saving the data. The error text is as follows:\n" +
                    Global.getExceptionText(ex);
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Saving Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            command.CommandText = "INSERT INTO Customers (Name, PhoneNumbers, MobileNumbers, Address, City, " +
                "OpeningBalance, BalanceType, Notes) Values(@name, @phone, @mobile, @address, @city, @balance, "
                + "@balanceType, @notes)";

            SqlCeParameterCollection parameters = command.Parameters;

            SqlCeParameter parameter = parameters.Add("@name", SqlDbType.NVarChar);
            parameter.SourceColumn = "Name";

            parameter = parameters.Add("@phone", SqlDbType.NVarChar);
            parameter.SourceColumn = "PhoneNumbers";

            parameter = parameters.Add("@mobile", SqlDbType.NVarChar);
            parameter.SourceColumn = "MobileNumbers";

            parameter = parameters.Add("@address", SqlDbType.NVarChar);
            parameter.SourceColumn = "Address";

            parameter = parameters.Add("@city", SqlDbType.NVarChar);
            parameter.SourceColumn = "City";

            parameter = parameters.Add("@balance", SqlDbType.Money);
            parameter.SourceColumn = "OpeningBalance";

            parameter = parameters.Add("@balanceType", SqlDbType.NChar);
            parameter.SourceColumn = "BalanceType";

            parameter = parameters.Add("@notes", SqlDbType.NVarChar);
            parameter.SourceColumn = "Notes";

            return command;
        }

        private SqlCeCommand getUpdateCommand(SqlCeConnection connection)
        {
            SqlCeCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Customers SET Name = @name, PhoneNumbers = @phone, " +
                "MobileNumbers = @mobile, Address = @address, City = @city, OpeningBalance = " +
                "@balance, BalanceType = @balanceType, Notes = @notes Where ID = @id";

            SqlCeParameterCollection parameters = command.Parameters;

            SqlCeParameter parameter = parameters.Add("@name", SqlDbType.NVarChar);
            parameter.SourceColumn = "Name";

            parameter = parameters.Add("@phone", SqlDbType.NVarChar);
            parameter.SourceColumn = "PhoneNumbers";

            parameter = parameters.Add("@mobile", SqlDbType.NVarChar);
            parameter.SourceColumn = "MobileNumbers";

            parameter = parameters.Add("@address", SqlDbType.NVarChar);
            parameter.SourceColumn = "Address";

            parameter = parameters.Add("@city", SqlDbType.NVarChar);
            parameter.SourceColumn = "City";

            parameter = parameters.Add("@balance", SqlDbType.Money);
            parameter.SourceColumn = "OpeningBalance";

            parameter = parameters.Add("@balanceType", SqlDbType.NChar);
            parameter.SourceColumn = "BalanceType";

            parameter = parameters.Add("@notes", SqlDbType.NVarChar);
            parameter.SourceColumn = "Notes";

            parameter = parameters.Add("@id", SqlDbType.Int);
            parameter.SourceColumn = "ID";

            return command;
        }

        private SqlCeCommand getDeleteCommand(SqlCeConnection connection)
        {
            SqlCeCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Customers WHERE ID = @id";

            SqlCeParameterCollection parameters = command.Parameters;

            SqlCeParameter parameter = parameters.Add("@id", SqlDbType.Int);
            parameter.SourceColumn = "ID";

            return command;
        }

        private void applyFilter()
        {
            string filterText = filterTextField.Text.Trim();

            DataTable table = (DataTable)customersGrid.DataSource;

            if (table == null)
            {
                return;
            }

            if (filterText.Length == 0)
            {
                table.DefaultView.RowFilter = string.Empty;
                return;
            }

            string selectedColumn = (string)filterColumnsBox.SelectedValue;
            table.DefaultView.RowFilter = selectedColumn + " Like '*" + filterText + "*'";
        }
    }
}