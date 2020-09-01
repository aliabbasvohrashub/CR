using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using Bajaj.Dinesh.Biller.Datasets;

namespace Bajaj.Dinesh.Biller
{
    internal sealed partial class BillMaster : Form
    {
        private bool toCloseForm = false;
        private DataTable customersTable;
        private DataTable itemsTable;
        private DataTable uomTable; //units of measurement table
        private DataTable billItems;
        private int? billToEdit = null;

        public BillMaster()
        {
            InitializeComponent();
        }

        public BillMaster(int billID)
            : this()
        {
            billToEdit = billID;
            this.Text = "Editing Bill# " + billID;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cashBillButton_CheckedChanged(object sender, EventArgs e)
        {
            customerNameField.Enabled = creditBillButton.Checked;
        }

        private void creditBillButton_CheckedChanged(object sender, EventArgs e)
        {
            if (creditBillButton.Checked)
            {
                customerNameField.Enabled = true;
                customerNameField.Focus();
            }
            else
            {
                customerNameField.Enabled = false;
            }
        }

        private void BillMaster_Load(object sender, EventArgs e)
        {
            this.Icon = Global.MDIForm.Icon;

            billDateField.MinDate = Global.CurrentFinancialYear.MinDate;
            billDateField.MaxDate = Global.CurrentFinancialYear.MaxDate;

            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            if (errorText != null)
            {
                Global.DisplayConnectionErrorMessage();
                toCloseForm = true;
                return;
            }

            if (!loadData(connection))
            {
                toCloseForm = true;
                return;
            }

            ConfigureCustomerField();
            CreateTable();

            if (billToEdit.HasValue) // editing an existing bill
            {
                if (!loadBillData(connection))
                {
                    toCloseForm = true;
                    return;
                }
                foreach (DataRow row in billItems.Rows)
                {
                    row["Amount"] = (decimal)row["Rate"] * (decimal)row["Quantity"];
                }
            }

            createDataGridColumns();
            billItemsGrid.DataSource = billItems;

            if (billToEdit.HasValue)
            {
                updateBillTotal();
            }
        }

        private bool loadData(SqlCeConnection connection)
        {
            try
            {
                loadCustomers(connection);
                loadItems(connection);
                loadUnitOfMeasurements(connection);
            }
            catch (Exception ex)
            {
                string message = "An error occurred in fetching data from the database."
                    + "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Fetching Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }

        private void loadCustomers(SqlCeConnection connection)
        {
            using (SqlCeCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT ID, NAME FROM Customers";

                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable("Customers");
                    table.Load(reader);
                    customersTable = table;
                }
            }
        }

        private void loadItems(SqlCeConnection connection)
        {
            using (SqlCeCommand command = connection.CreateCommand())
            {
                command.CommandText = "Items";
                command.CommandType = CommandType.TableDirect;

                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    itemsTable = new DataTable("Items");
                    itemsTable.Load(reader);
                }
            }
        }

        private void loadUnitOfMeasurements(SqlCeConnection connection)
        {
            using (SqlCeCommand command = connection.CreateCommand())
            {
                command.CommandText = "UnitOfMeasurement";
                command.CommandType = CommandType.TableDirect;

                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    uomTable = new DataTable(command.CommandText);
                    uomTable.Load(reader);
                }
            }
        }

        private void BillMaster_Activated(object sender, EventArgs e)
        {
            if (toCloseForm)
            {
                this.Close();
            }
        }

        private void ConfigureCustomerField()
        {
            customerNameField.DataSource = customersTable;
            customerNameField.DisplayMember = "Name";
            customerNameField.ValueMember = "ID";
            customerNameField.SelectedIndex = -1;

            customerNameField.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            customerNameField.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void refreshCustomersList_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            try
            {
                loadCustomers(connection);
            }
            catch (Exception ex)
            {
                string message = "An error occurred in fetching the customer list from the database."
                    + "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Fetching Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
            }

            customerNameField.DataSource = customersTable;
            Cursor.Current = Cursors.Default;
        }

        private void setUpGridColumns()
        {
        }

        private void CreateTable()
        {
            billItems = new DataTable("BillItems");

            DataColumnCollection columns = billItems.Columns;

            DataColumn column = new DataColumn("BillID", SqlDbType.Int.GetType());
            columns.Add(column);

            column = new DataColumn("ItemID", SqlDbType.Int.GetType());
            column.AllowDBNull = false;
            column.Unique = true;
            columns.Add(column);

            column = new DataColumn("UoMID", SqlDbType.Int.GetType());
            column.AllowDBNull = false;
            columns.Add(column);

            column = new DataColumn("Rate", typeof(decimal));
            column.AllowDBNull = false;
            columns.Add(column);

            column = new DataColumn("Quantity", typeof(decimal));
            column.AllowDBNull = false;
            column.DefaultValue = 1.0M;
            columns.Add(column);

            column = new DataColumn("Amount", typeof(decimal));
            columns.Add(column);

            setUpDataTableEvents();
        }

        private void createDataGridColumns()
        {
            billItemsGrid.AutoGenerateColumns = false;

            DataGridViewColumnCollection columns = billItemsGrid.Columns;

            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "BillID";
            textColumn.Name = "BillID";
            textColumn.ValueType = typeof(int);
            textColumn.Visible = false;
            columns.Add(textColumn);

            DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
            comboColumn.DataSource = itemsTable;
            comboColumn.DisplayMember = "Name";
            comboColumn.ValueMember = "ID";
            comboColumn.DataPropertyName = "ItemID";
            comboColumn.Name = "ItemID";
            comboColumn.HeaderText = "Item";
            comboColumn.ValueType = typeof(int);
            comboColumn.AutoComplete = true;
            comboColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            comboColumn.Width = 180;
            columns.Add(comboColumn);

            comboColumn = new DataGridViewComboBoxColumn();
            comboColumn.DataSource = uomTable;
            comboColumn.ValueMember = "ID";
            comboColumn.DisplayMember = "UnitName";
            comboColumn.DataPropertyName = "UoMID";
            comboColumn.Name = "UoMID";
            comboColumn.HeaderText = "Measurement Unit";
            comboColumn.ValueType = typeof(int);
            comboColumn.AutoComplete = true;
            comboColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            comboColumn.Width = 120;
            columns.Add(comboColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "Rate";
            textColumn.Name = "Rate";
            textColumn.HeaderText = "Rate (Rs.)";
            textColumn.ValueType = typeof(decimal);
            textColumn.DefaultCellStyle.Format = "N2";
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "Quantity";
            textColumn.Name = "Quantity";
            textColumn.HeaderText = "Quantity";
            textColumn.ValueType = typeof(decimal);
            textColumn.DefaultCellStyle.Format = "N4";
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "Amount";
            textColumn.Name = "Amount";
            textColumn.HeaderText = "Amount (Rs.)";
            textColumn.ValueType = typeof(decimal);
            textColumn.ReadOnly = true;
            textColumn.DefaultCellStyle.Format = "N2";
            textColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columns.Add(textColumn);
        }

        private void billItemsGrid_EditingControlShowing(object sender,
            DataGridViewEditingControlShowingEventArgs e)
        {
            int columnIndex = billItemsGrid.CurrentCell.ColumnIndex;
            if (billItemsGrid.Columns["ItemID"].DisplayIndex != columnIndex &&
                billItemsGrid.Columns["UoMID"].DisplayIndex != columnIndex)
            {
                return;
            }

            DataGridViewComboBoxEditingControl editControl =
                (DataGridViewComboBoxEditingControl)e.Control;
            editControl.DropDownStyle = ComboBoxStyle.DropDown;
            editControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            editControl.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void setUpDataTableEvents()
        {
            billItems.ColumnChanged += new DataColumnChangeEventHandler(itemsTable_ColumnChanged);
        }

        private void itemsTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            string columnName = e.Column.ColumnName;
            if (!(columnName.Equals("Rate") || columnName.Equals("Quantity")))
            {
                return;
            }

            decimal? quantity = (decimal?)e.Row["Quantity"];
            decimal? rate = (decimal?)e.Row["Rate"];

            if (quantity.HasValue && rate.HasValue)
            {
                e.Row["Amount"] = quantity.Value * rate.Value;
                //upgrade the display of the amount cell.
                billItemsGrid.UpdateCellValue(5, billItemsGrid.CurrentCell.RowIndex);
                updateBillTotal();
            }
            else
            {
                e.Row["Amount"] = null;
            }
        }

        private void updateBillTotal()
        {
            decimal billTotal = 0.0M;

            try
            {
                foreach (DataGridViewRow row in billItemsGrid.Rows)
                {
                    billTotal += (decimal)(row.Cells[5].Value == null ? 0.0M : row.Cells[5].Value);
                }
            }
            catch (Exception ex)
            {
                //do nothing here. Note this exception handler is necessary here.
            }

            billSubTotalField.Text = billTotal.ToString("N2");

            decimal value;
            if (decimal.TryParse(discountField.Text.Trim(), out value))
            {
                billTotal -= value;
            }

            if (decimal.TryParse(expenseAmountField.Text.Trim(), out value))
            {
                billTotal += value;
            }

            billTotalField.Text = billTotal.ToString("N2");
        }

        private void billItemsGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            updateBillTotal();
        }

        private void billItemsGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            billItemsGrid[e.ColumnIndex, e.RowIndex].ErrorText = null;
        }

        private void billItemsGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != 3 && e.ColumnIndex != 4)
            {
                return;
            }

            if (billItemsGrid.Rows[e.RowIndex].IsNewRow)
            {
                return;
            }

            decimal value;
            if (!decimal.TryParse(e.FormattedValue.ToString(), out value))
            {
                billItemsGrid[e.ColumnIndex, e.RowIndex].ErrorText = "Valid numeric value not provided.";
                e.Cancel = true;
            }

            if (value <= 0.0M)
            {
                billItemsGrid[e.ColumnIndex, e.RowIndex].ErrorText = "Value has to be greater than zero.";
                e.Cancel = true;
            }
        }

        private void billItemsGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string errorText = Global.getExceptionText(e.Exception).Replace("\n", " ");
            billItemsGrid.Rows[e.RowIndex].ErrorText = getRefinedText(errorText);
            e.Cancel = true;
        }

        private void billItemsGrid_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            billItemsGrid.Rows[e.RowIndex].ErrorText = null;
        }

        private string getRefinedText(string errorMessage)
        {
            return errorMessage.Replace("ItemID", "Item Name").Replace("UoMID", "Measurement Unit")
                 .Replace("nulls", "blank value");
        }

        private void deleteRowsButton_Click(object sender, EventArgs e)
        {
            int count = billItemsGrid.SelectedRows.Count;
            if (count == 0)
            {
                SystemSounds.Beep.Play();
                return;
            }

            string prompt = "Are you sure that you want to delete the selected " +
                ((count > 1) ? count + " rows?" : "row?");
            DialogResult result = MessageBox.Show(prompt, "Confirm Deletion", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            DataGridViewSelectedRowCollection selectedRows = billItemsGrid.SelectedRows;
            foreach (DataGridViewRow row in selectedRows)
            {
                billItemsGrid.Rows.Remove(row);
            }
        }

        private void billItemsGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updateBillTotal();
        }

        private void billItemsGrid_SelectionChanged(object sender, EventArgs e)
        {
            deleteRowsButton.Enabled = billItemsGrid.SelectedRows.Count > 0;
        }

        private void discountField_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(discountField, null);
        }

        private void discountField_Validating(object sender, CancelEventArgs e)
        {
            decimal value;
            if (!decimal.TryParse(discountField.Text.Trim(), out value))
            {
                errorProvider.SetError(discountField, "Valid numeric value not provided for discount.");
                e.Cancel = true;
            }

            if (value < 0.0M)
            {
                errorProvider.SetError(discountField, "Discount amount can't be less than zero.");
                e.Cancel = true;
            }
        }

        private void exponseAmountField_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(expenseAmountField, null);
        }

        private void exponseAmountField_Validating(object sender, CancelEventArgs e)
        {
            decimal value;
            if (!decimal.TryParse(expenseAmountField.Text.Trim(), out value))
            {
                errorProvider.SetError(expenseAmountField, "Valid numeric value not provided for expense amount.");
                e.Cancel = true;
            }

            if (value < 0.0M)
            {
                errorProvider.SetError(expenseAmountField, "Expense amount can't be less than zero.");
                e.Cancel = true;
            }
        }

        private void discountField_Leave(object sender, EventArgs e)
        {
            decimal value;
            if (decimal.TryParse(discountField.Text.Trim(), out value))
            {
                discountField.Text = value.ToString("N2");
            }
            updateBillTotal();
        }

        private void exponseAmountField_Leave(object sender, EventArgs e)
        {
            decimal value;
            if (decimal.TryParse(expenseAmountField.Text.Trim(), out value))
            {
                expenseAmountField.Text = value.ToString("N2");
            }
            updateBillTotal();
        }

        private void billTypeGroup_Validating(object sender, CancelEventArgs e)
        {
            if (customerNameField.SelectedValue == null)
            {
                errorProvider.SetError(customerNameField, "No customer selected.");
                e.Cancel = true;
            }
        }

        private void billTypeGroup_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(customerNameField, null);
        }

        private void refreshItemsButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            try
            {
                loadItems(connection);
            }
            catch (Exception ex)
            {
                string message = "An error occurred in fetching the items' list from the database." +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Exclamation.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Fetching Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ErrorLogger.LogError(ex);
                return;
            }

            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)billItemsGrid.Columns["ItemID"];
            column.DataSource = itemsTable;
            Cursor.Current = Cursors.Default;
        }

        private void refreshMeasurementUnitsButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            try
            {
                loadUnitOfMeasurements(connection);
            }
            catch (Exception ex)
            {
                string message = "An error occurred in fetching the measurement units' list from the database." +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Exclamation.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Fetching Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ErrorLogger.LogError(ex);
                return;
            }

            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)billItemsGrid.Columns["UomID"];
            column.DataSource = uomTable;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!this.ValidateChildren(ValidationConstraints.Enabled))
            {
                SystemSounds.Exclamation.Play();
                Cursor.Current = Cursors.Default;
                return;
            }

            DataRow[] rows = billItems.Select("", "", DataViewRowState.CurrentRows);
            if (rows.Length == 0)
            {
                string message = "No item selected in the bill. Please select atleast one item.";
                SystemSounds.Exclamation.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "No Item Selected", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            Decimal value = decimal.Parse(billTotalField.Text);
            if (value < 0.0M)
            {
                string message = "The bill total can't be less than zero.";
                SystemSounds.Exclamation.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int billID;
            if (!saveData(out billID))
            {
                return;
            }

            if (this.billToEdit.HasValue)
            {
                Cursor.Current = Cursors.Default;
                SystemSounds.Asterisk.Play();
                MessageBox.Show("The bill was successfully updated.", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            Cursor.Current = Cursors.WaitCursor;
            if (printOnSaveButton.Checked)
            {
                printBill(billID);
            }

            if (this.billToEdit.HasValue)
            {
                Cursor.Current = Cursors.Default;
                this.Close();
                return;
            }

            successButton.Visible = true;
            timer.Enabled = true;
            clearControls();
        }

        private bool saveData(out int billID)
        {
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            SqlCeTransaction transaction = null;

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    if (billToEdit.HasValue)
                    {
                        configureBillMasterUpdateCommand(command);
                    }
                    else
                    {
                        configureBillMasterInsertCommand(command);
                    }

                    transaction = connection.BeginTransaction();

                    command.Transaction = transaction;
                    command.ExecuteNonQuery(); //save bill master data

                    if (!billToEdit.HasValue)
                    {
                        command.CommandText = "SELECT @@IDENTITY AS BillID";
                        command.Parameters.Clear();

                        decimal ID = (decimal)(command.ExecuteScalar());
                        billID = decimal.ToInt32(ID);
                    }
                    else
                    {
                        //delete bill details for the existing bill
                        command.CommandText = "DELETE FROM BILLDETAILS WHERE BILLID = " + billToEdit.Value;
                        command.ExecuteNonQuery();
                        billID = billToEdit.Value;
                    }

                    saveBillDetails(command, decimal.ToInt32(billID));

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }

                string message = "An error occurred in saving the bill data in the database." +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Saving Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                billID = 0;
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

        private void configureBillMasterInsertCommand(SqlCeCommand command)
        {
            command.CommandText = "INSERT INTO BillMaster (BillDate, CustomerID, DiscountAmount, ExpenseAmount, ExpenseText) "
                    + "VALUES (@billDate, @customerID, @discountAmount, @expenseAmount, @expenseText)";

            createBillMasterSaveCommandParameters(command);
        }

        private void configureBillMasterUpdateCommand(SqlCeCommand command)
        {
            command.CommandText = "UPDATE BILLMASTER SET BillDate = @billDate, CustomerID = @customerID, " +
                "DiscountAmount = @discountAmount, ExpenseAmount = @expenseAmount, ExpenseText = @expenseText " +
                "WHERE ID = " + billToEdit.Value;

            createBillMasterSaveCommandParameters(command);
        }

        private void createBillMasterSaveCommandParameters(SqlCeCommand command)
        {
            SqlCeParameterCollection parameters = command.Parameters;

            SqlCeParameter parameter = parameters.Add("@billDate", SqlDbType.DateTime);
            parameter.Value = billDateField.Value.Date;

            parameter = parameters.Add("@CustomerID", SqlDbType.Int);
            parameter.IsNullable = true;
            if (cashBillButton.Checked)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = (int)customerNameField.SelectedValue;
            }

            parameter = parameters.Add("@DiscountAmount", SqlDbType.Money);
            parameter.Value = decimal.Parse(discountField.Text.Trim());

            parameter = parameters.Add("@ExpenseAmount", SqlDbType.Money);
            parameter.Value = decimal.Parse(expenseAmountField.Text.Trim());

            parameter = parameters.Add("@ExpenseText", SqlDbType.NVarChar, 50);
            parameter.IsNullable = true;
            string str = expenseTextField.Text.Trim();
            if (string.IsNullOrEmpty(str))
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = str;
            }
        }

        private void saveBillDetails(SqlCeCommand command, int billID)
        {
            command.CommandText = "INSERT INTO BILLDETAILS VALUES(@billID, @itemID, @uomID, @rate, @quantity)";

            SqlCeParameterCollection parameters = command.Parameters;

            SqlCeParameter bill = parameters.Add("@billID", SqlDbType.Int);
            bill.Value = billID;

            SqlCeParameter itemID = parameters.Add("@itemID", SqlDbType.Int);
            SqlCeParameter measurementUnit = parameters.Add("@uomID", SqlDbType.Int);
            SqlCeParameter rate = parameters.Add("@rate", SqlDbType.Money);
            SqlCeParameter quantity = parameters.Add("@quantity", SqlDbType.Money);

            DataRow[] rows = billItems.Select(string.Empty, string.Empty, DataViewRowState.CurrentRows);

            foreach (DataRow row in rows)
            {
                itemID.Value = row["ItemID"];
                measurementUnit.Value = row["UoMID"];
                rate.Value = row["Rate"];
                quantity.Value = row["Quantity"];
                command.ExecuteNonQuery();
            }
        }

        private void loadBillDetails(SqlCeConnection connection)
        {
            using (SqlCeCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM BILLDETAILS WHERE BillID = " + billToEdit.Value;

                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    billItems.Load(reader);
                }
            }
        }

        private bool loadBillData(SqlCeConnection connection)
        {
            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM BILLMASTER WHERE ID = " + billToEdit.Value;

                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        billDateField.Value = reader.GetDateTime(reader.GetOrdinal("BillDate"));

                        object val = reader.GetValue(reader.GetOrdinal("CustomerID"));
                        if (val == DBNull.Value)
                        {
                            cashBillButton.Checked = true;
                        }
                        else
                        {
                            creditBillButton.Checked = true;
                            customerNameField.SelectedValue = (int)val;
                        }

                        decimal amount = reader.GetDecimal(reader.GetOrdinal("DiscountAmount"));
                        discountField.Text = amount.ToString("N2");
                        amount = reader.GetDecimal(reader.GetOrdinal("ExpenseAmount"));
                        expenseAmountField.Text = amount.ToString("N2");

                        val = reader.GetValue(reader.GetOrdinal("ExpenseText"));
                        if (val != DBNull.Value)
                        {
                            expenseTextField.Text = (string)val;
                        }
                    }
                }

                loadBillDetails(connection);
            }
            catch (Exception ex)
            {
                string message = "An error occurred in loading the bill data. \nThe error text is as follows:\n"
                    + Global.getExceptionText(ex);
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Loading Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }

        private void billItemsGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            updateBillTotal();
        }

        private void customerNameField_Validating(object sender, CancelEventArgs e)
        {
            if (customerNameField.Enabled && customerNameField.SelectedValue == null)
            {
                errorProvider.SetError(customerNameField, "Customer not selected");
                e.Cancel = true;
            }
        }

        private void customerNameField_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(customerNameField, null);
        }

        private void billItemsGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                SendKeys.Send("{F4}");
                return;
            }

            if (e.ColumnIndex != 2)
            {
                return;
            }

            if (billItemsGrid.CurrentCell.Value != DBNull.Value)
            {
                return;
            }

            DataGridViewRow row = billItemsGrid.CurrentRow;
            if (row.Cells[1].Value == DBNull.Value)
            {
                return;
            }

            int? itemID = row.Cells[1].Value as int?;
            if (!itemID.HasValue)
            {
                return;
            }

            DataRow[] rows = itemsTable.Select("ID = " + itemID.Value);
            if (rows.Length == 0)
            {
                return;
            }

            row.Cells[2].Value = rows[0][2];
            row.Cells[3].Value = rows[0][3];
        }

        private void printBill(int billID)
        {
            BillItemsDataSet dataset = getPrintDataSet();
            Dictionary<string, object> parameters = getReportParameters(billID);

            BillReportView form = new BillReportView(dataset, parameters);
            form.MdiParent = this.MdiParent;

            try
            {
                form.ShowReport();
            }
            catch (Exception ex)
            {
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                string message = "An error occurred in showing the Print Preview of the bill."
                    + "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                ErrorLogger.LogError(ex);
            }
        }

        private BillItemsDataSet getPrintDataSet()
        {
            BillItemsDataSet dataset = new BillItemsDataSet();
            BillItemsDataSet.BillItemsTableRow reportRow;

            DataRow[] itemRows;
            DataRow[] uomRows;

            foreach (DataRow row in billItems.Rows)
            {
                itemRows = itemsTable.Select("ID = " + (int)row[1]);
                uomRows = uomTable.Select("ID = " + (int)row[2]);

                reportRow = dataset.BillItemsTable.NewBillItemsTableRow();
                reportRow.ItemName = (string)itemRows[0][1];
                reportRow.UoM = (string)uomRows[0][1];

                reportRow.Rate = (decimal)row[3];
                reportRow.Quantity = (decimal)row[4];
                reportRow.Amount = (decimal)row[5];

                dataset.BillItemsTable.AddBillItemsTableRow(reportRow);
            }

            return dataset;
        }

        private Dictionary<string, object> getReportParameters(int billID)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>(10);

            parameters.Add("InvoiceDate", billDateField.Value.Date);
            parameters.Add("InvoiceID", billID);
            parameters.Add("CustomerName", creditBillButton.Checked ? customerNameField.Text : "Cash Invoice");
            parameters.Add("DiscountAmount", Math.Round(decimal.Parse(discountField.Text.Trim()), 2));
            parameters.Add("ExpenseAmount", Math.Round(decimal.Parse(expenseAmountField.Text.Trim()), 2));
            parameters.Add("ExpenseText", expenseTextField.Text.Trim());

            return parameters;
        }

        private void clearControls()
        {
            cashBillButton.Checked = true;
            customerNameField.SelectedIndex = -1;

            billSubTotalField.Text = "0.00";
            expenseAmountField.Text = "0.00";
            discountField.Text = "0.00";
            expenseTextField.Text = string.Empty;
            billTotalField.Text = "0.00";
            billItems.Rows.Clear();
        }

        private void time_Tick(object sender, EventArgs e)
        {
            successButton.Visible = false;
            timer.Enabled = false;
        }
    }
}