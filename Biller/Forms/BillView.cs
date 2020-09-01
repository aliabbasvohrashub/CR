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
    internal sealed partial class BillView : Form
    {
        private BillViewCriteria criteriaDialog;
        private bool advancedQuerySelected = false;

        public BillView()
        {
            InitializeComponent();
        }

        private void BillView_Load(object sender, EventArgs e)
        {
            this.Icon = Global.MDIForm.Icon;

            startDatePicker.MinDate = Global.CurrentFinancialYear.MinDate;
            startDatePicker.MaxDate = Global.CurrentFinancialYear.MaxDate;

            endDatePicker.MinDate = startDatePicker.MinDate;
            endDatePicker.MaxDate = startDatePicker.MaxDate;
        }

        private void findInvoicesButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!this.ValidateChildren(ValidationConstraints.Enabled))
            {
                SystemSounds.Exclamation.Play();
                Cursor.Current = Cursors.Default;
                return;
            }

            string sql = getSearchSQL();
            DataTable table = getQueryResult(sql);

            if (table == null)
            {
                Cursor.Current = Cursors.Default;
                return;
            }

            invoicesGrid.DataSource = table;

            if (!invoicesGrid.Columns["ID"].HeaderText.Contains("Bill"))
            {
                configureDataGridViewColumns();
            }

            if (table.Rows.Count == 0)
            {
                SystemSounds.Asterisk.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show("The query returned no matching invoice.", "No Matching Invoice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            displayInvoiceSummary(table);
            resultGroupBox.Visible = true;
            invoicesGrid.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void editInvoiceButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DataGridViewRow row = invoicesGrid.CurrentRow;
            int billID = (int)row.Cells["ID"].Value;

            BillMaster billMaster = new BillMaster(billID);
            billMaster.MdiParent = this.MdiParent;
            billMaster.Show();

            Cursor.Current = Cursors.Default;
        }

        private void printInvoiceButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Dictionary<string, object> parameters = new Dictionary<string, object>(10);

            if (!setReportParameters(parameters))
            {
                return;
            }

            BillItemsDataSet dataset;
            if (!getReportDataSet(out dataset))
            {
                return;
            }

            BillReportView form = new BillReportView(dataset, parameters);
            form.MdiParent = this.MdiParent;

            try
            {
                form.ShowReport();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                SystemSounds.Exclamation.Play();
                string message = "An error occurred in printing the bill." +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);

                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
            }

            Cursor.Current = Cursors.Default;
        }

        private void deleteInvoiceButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow gridRow = invoicesGrid.CurrentRow;
            int billNumber = (int)gridRow.Cells["ID"].Value;

            string message = "Are you sure that you want to delete the invoice numbered " +
                billNumber + " ?";
            SystemSounds.Question.Play();
            DialogResult result = MessageBox.Show(message, "Confirm Deletion", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if (!deleteInvoiceFromDatabase(billNumber))
            {
                return;
            }

            //delete the row from the grid
            invoicesGrid.Rows.Remove(gridRow);
            displayInvoiceSummary((DataTable)invoicesGrid.DataSource);
        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {
            advancedQuerySelected = false;
            onCriteriaChanged();
        }

        private void endDatePicker_ValueChanged(object sender, EventArgs e)
        {
            advancedQuerySelected = false;
            onCriteriaChanged();
        }

        private void invoicesGrid_SelectionChanged(object sender, EventArgs e)
        {
            bool rowSelected = invoicesGrid.SelectedRows.Count > 0;

            editInvoiceButton.Enabled = rowSelected;
            printInvoiceButton.Enabled = rowSelected;
            deleteInvoiceButton.Enabled = rowSelected;
        }

        private void startDatePicker_Validating(object sender, CancelEventArgs e)
        {
            if (startDatePicker.Value.Date.CompareTo(endDatePicker.Value.Date) > 0)
            {
                errorProvider.SetError(startDatePicker,
                    "Start date has to be less than or equal to the end date.");
                e.Cancel = true;
            }
        }

        private void startDatePicker_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(startDatePicker, null);
        }

        private string getSearchSQL()
        {
            StringBuilder sql = new StringBuilder("SELECT BM.ID, BillDate, ")
            .Append("COALESCE(CM.Name, 'Cash Invoice') AS CustomerName, BD.ItemsTotal, ")
            .Append("ExpenseAmount, DiscountAmount, ")
            .Append("(BD.ItemsTotal + ExpenseAmount - DiscountAmount) as InvoiceTotal ")
            .Append("FROM BillMaster BM ")
            .Append("OUTER APPLY (")
            .Append("SELECT SUM(Rate * Quantity) AS ItemsTotal ")
            .Append("FROM BillDetails WHERE BillID = BM.ID ) BD ")
            .Append("LEFT JOIN Customers CM ON BM.CustomerID = CM.ID ");

            addConditionClauseToSql(sql);

            return sql.ToString();
        }

        private void addConditionClauseToSql(StringBuilder sql)
        {
            if (advancedQuerySelected && criteriaDialog.findByInvoiceNumberButton.Checked)
            {
                sql.Append(" WHERE BM.ID = " + criteriaDialog.invoiceNumberField.Text.Trim());
                return;
            }

            sql.Append(" WHERE BILLDATE BETWEEN '")
                .Append(startDatePicker.Value.Date.ToString("yyyyMMdd"))
                .Append("' AND '").Append(endDatePicker.Value.Date.ToString("yyyyMMdd"))
                .Append("'");

            if (advancedQuerySelected)
            {
                if (criteriaDialog.paymentTypeButton.Checked)
                {
                    if (criteriaDialog.cashButton.Checked && criteriaDialog.creditButton.Checked)
                    {
                        return;
                    }
                    else if (criteriaDialog.cashButton.Checked)
                    {
                        sql.Append(" AND CUSTOMERID IS NULL ");
                    }
                    else
                    {
                        sql.Append(" AND CUSTOMERID IS NOT NULL");
                    }
                }
                else
                {
                    sql.Append(" AND CUSTOMERID = ").Append(criteriaDialog.customerCombo.SelectedValue.ToString());
                }
            }
        }

        private DataTable getCustomersTable(SqlCeConnection connection)
        {
            using (SqlCeCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT ID, Name FROM Customers";

                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable("Customers");
                    table.Load(reader);
                    return table;
                }
            }
        }

        private DataTable getQueryResult(string sql)
        {
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable("Result");
                        table.Load(reader);
                        return table;
                    }
                }
            }
            catch (Exception ex)
            {
                SystemSounds.Exclamation.Play();
                string message = "An error occurred in getting the query result from the database."
                    + "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                MessageBox.Show(message, "Error in fetching Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                ErrorLogger.LogError(ex);
                return null;
            }
        }

        private void configureDataGridViewColumns()
        {
            DataGridViewColumnCollection columns = invoicesGrid.Columns;

            DataGridViewColumn column = columns[0];
            column.HeaderText = "Bill #";
            column.Width = 60;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            column = columns[1];
            column.HeaderText = "Date";
            column.DefaultCellStyle.Format = "dd-MM-yyyy";
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.Width = 75;

            column = columns[2];
            column.HeaderText = "Customer";
            column.Width = 110;

            column = columns[3];
            column.HeaderText = "Items Total (Rs.)";
            column.Width = 95;
            column.DefaultCellStyle.Format = "N2";
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            column = columns[4];
            column.HeaderText = "Expense (Rs.)";
            column.Width = 70;
            column.DefaultCellStyle.Format = "N2";
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            column = columns[5];
            column.HeaderText = "Discount (Rs.)";
            column.Width = 70;
            column.DefaultCellStyle.Format = "N2";
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            column = columns[6];
            column.HeaderText = "Invoice Amount (Rs.)";
            column.Width = 120;
            column.DefaultCellStyle.Format = "N2";
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Padding padding = column.DefaultCellStyle.Padding;
            padding.Right = 10;
            column.DefaultCellStyle.Padding = padding;
        }

        private void displayInvoiceSummary(DataTable table)
        {
            int invoiceCount = 0;
            decimal invoiceTotal = 0.0M;

            DataRow[] rows = table.Select("", "", DataViewRowState.CurrentRows);
            foreach (DataRow row in rows)
            {
                invoiceCount++;
                invoiceTotal += (decimal)row["InvoiceTotal"];
            }

            invoiceCountField.Text = invoiceCount.ToString();
            invoiceTotalField.Text = invoiceTotal.ToString("N2");
        }

        private void onCriteriaChanged()
        {
            resultGroupBox.Visible = false;
            DataTable table = invoicesGrid.DataSource as DataTable;
            if (table == null)
            {
                return;
            }

            table.Clear();
            invoiceCountField.Text = string.Empty;
            invoiceTotalField.Text = string.Empty;
        }

        private bool deleteInvoiceFromDatabase(int billNumber)
        {
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM BillMaster WHERE ID = " + billNumber;
                    int rowsAffected = command.ExecuteNonQuery();

                    return (rowsAffected == 1);
                }
            }
            catch (Exception ex)
            {
                SystemSounds.Exclamation.Play();
                string message = "An error occurred in deleting the selected invoice from the database."
                    + "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                MessageBox.Show(message, "Error in Deleting Invoice", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                ErrorLogger.LogError(ex);
                return false;
            }
        }

        private void advancedCriteriaButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (criteriaDialog == null)
            {
                criteriaDialog = new BillViewCriteria();
                if (!loadCustomers())
                {
                    return;
                }
            }

            if (startDatePicker.Enabled)
            {
                criteriaDialog.startDatePicker.Value = startDatePicker.Value;
                criteriaDialog.endDatePicker.Value = endDatePicker.Value;
            }

            Cursor.Current = Cursors.Default;

            DialogResult result = criteriaDialog.ShowDialog(this);
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            if (criteriaDialog.findByInvoiceNumberButton.Checked)
            {
                startDatePicker.Enabled = endDatePicker.Enabled = false;
            }
            else
            {
                startDatePicker.Enabled = endDatePicker.Enabled = true;
                startDatePicker.Value = criteriaDialog.startDatePicker.Value;
                endDatePicker.Value = criteriaDialog.endDatePicker.Value;
            }

            onCriteriaChanged();
            advancedQuerySelected = true;
        }

        private bool loadCustomers()
        {
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            if (errorText != null)
            {
                Global.DisplayConnectionErrorMessage();
                return false;
            }

            DataTable table = null;
            try
            {
                table = getCustomersTable(connection);
            }
            catch (Exception ex)
            {
                SystemSounds.Exclamation.Play();
                string message = "An error occurred in fetching the customers' list from the database." +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Fetching Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                ErrorLogger.LogError(ex);
                return false;
            }

            criteriaDialog.customerCombo.DataSource = table;
            criteriaDialog.customerCombo.DisplayMember = "Name";
            criteriaDialog.customerCombo.ValueMember = "ID";
            criteriaDialog.customerCombo.SelectedIndex = -1;

            return true;
        }

        private void BillView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (criteriaDialog != null)
            {
                criteriaDialog.Dispose();
            }
        }

        private bool setReportParameters(Dictionary<string, object> parameters)
        {
            DataGridViewRow row = invoicesGrid.CurrentRow;
            DataGridViewCellCollection cells = row.Cells;

            parameters.Add("InvoiceDate", cells[1].Value);
            parameters.Add("InvoiceID", cells[0].Value);
            parameters.Add("CustomerName", cells[2].Value);
            parameters.Add("DiscountAmount", cells[5].Value);
            parameters.Add("ExpenseAmount", cells[4].Value);

            string expenseText;
            if (!getExpenseText((int)cells[0].Value, out expenseText))
            {
                return false;
            }

            parameters.Add("ExpenseText", expenseText);
            return true;
        }

        private bool getExpenseText(int billID, out string expenseText)
        {
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            string sql = "SELECT ExpenseText FROM BillMaster WHERE ID = " + billID;

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    object value = command.ExecuteScalar();
                    if (value == DBNull.Value || value == null || value.ToString().Length == 0)
                    {
                        expenseText = string.Empty;
                    }
                    else
                    {
                        expenseText = (string)value;
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                SystemSounds.Hand.Play();
                string message = "An error occurred in retrieving the account details from the database."
                    + "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                expenseText = null;
                return false;
            }

            return true;
        }

        private bool getReportDataSet(out BillItemsDataSet dataset)
        {
            DataGridViewRow row = invoicesGrid.CurrentRow;
            int billID = (int)row.Cells[0].Value;

            StringBuilder sql = new StringBuilder("SELECT Items.NAME, UM.UnitName, BD.Rate, BD.quantity")
                .Append(" FROM (SELECT * FROM BillDetails WHERE  BILLID = ").Append(billID)
                .Append(") BD INNER JOIN Items ON ItemID = Items.ID ")
                .Append("INNER JOIN UnitOfMeasurement UM ON BD.UoMID = UM.ID");

            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql.ToString();
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        dataset = new BillItemsDataSet();
                        BillItemsDataSet.BillItemsTableRow tableRow;
                        while (reader.Read())
                        {
                            tableRow = dataset.BillItemsTable.NewBillItemsTableRow();
                            tableRow.ItemName = reader.GetString(0);
                            tableRow.UoM = reader.GetString(1);
                            tableRow.Rate = reader.GetDecimal(2);
                            tableRow.Quantity = reader.GetDecimal(3);
                            tableRow.Amount = tableRow.Rate * tableRow.Quantity;
                            dataset.BillItemsTable.AddBillItemsTableRow(tableRow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                SystemSounds.Exclamation.Play();
                string message = "An error occurred in retrieving the bill details." +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                dataset = null;
                return false;
            }

            return true;
        }
    }
}