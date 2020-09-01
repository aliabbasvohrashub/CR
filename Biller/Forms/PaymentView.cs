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

namespace Bajaj.Dinesh.Biller
{
    internal sealed partial class PaymentView : Form
    {
        public PaymentView()
        {
            InitializeComponent();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void betweenDatesButton_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = betweenDatesButton.Checked;
            startDatePicker.Enabled = isChecked;
            endDatePicker.Enabled = isChecked;

            onCriteriaChanged();
        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {
            onCriteriaChanged();
        }

        private void endDatePicker_ValueChanged(object sender, EventArgs e)
        {
            onCriteriaChanged();
        }

        private void paymentModeButton_CheckedChanged(object sender, EventArgs e)
        {
            paymentModePanel.Enabled = paymentModeButton.Checked;
            onCriteriaChanged();
        }

        private void cashButton_CheckedChanged(object sender, EventArgs e)
        {
            onCriteriaChanged();
        }

        private void chequeButton_CheckedChanged(object sender, EventArgs e)
        {
            onCriteriaChanged();
        }

        private void demandDraftButton_CheckedChanged(object sender, EventArgs e)
        {
            onCriteriaChanged();
        }

        private void customerButton_CheckedChanged(object sender, EventArgs e)
        {
            customerComboBox.Enabled = customerButton.Checked;
            onCriteriaChanged();
        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            onCriteriaChanged();
        }

        private void findPaymentsButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!this.ValidateChildren(ValidationConstraints.Enabled))
            {
                SystemSounds.Exclamation.Play();
                Cursor.Current = Cursors.Default;
                return;
            }

            string sql = getQuerySQL();

            DataTable table = getQueryResult(sql);
            if (table == null)
            {
                Cursor.Current = Cursors.Default;
                return;
            }

            if (table.Rows.Count == 0)
            {
                SystemSounds.Asterisk.Play();
                Cursor.Current = Cursors.Default;
                string message = "No payment matched the selected criteria.";
                MessageBox.Show(message, "No Matching Payment", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            paymentsGrid.DataSource = table;
            configureDataGridColumns();
            showPaymentSummary(table);
            resultsGroupBox.Visible = true;
            resultsGroupBox.Focus();

            Cursor.Current = Cursors.Default;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DataGridViewRow row = paymentsGrid.CurrentRow;
            int paymentID = (int)row.Cells["ID"].Value;

            PaymentReceive paymentReceive = new PaymentReceive(paymentID);
            paymentReceive.MdiParent = this.MdiParent;
            paymentReceive.Show();

            Cursor.Current = Cursors.Default;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = paymentsGrid.CurrentRow;
            decimal amount = (decimal)row.Cells["Amount"].Value;

            string message = "Are you sure that you want to delete the selected payment of " +
                "Rs. " + amount.ToString("N2") + " ?";
            SystemSounds.Question.Play();
            DialogResult result = MessageBox.Show(message, "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            int paymentID = (int)row.Cells["ID"].Value;
            bool deleted = deletePayment(paymentID);

            if (!deleted)
            {
                Cursor.Current = Cursors.WaitCursor;
                return;
            }

            paymentsGrid.Rows.Remove(row);
            showPaymentSummary((DataTable)paymentsGrid.DataSource);
            Cursor.Current = Cursors.WaitCursor;
        }

        private void PaymentView_Load(object sender, EventArgs e)
        {
            this.Icon = Global.MDIForm.Icon;

            startDatePicker.MinDate = Global.CurrentFinancialYear.MinDate;
            startDatePicker.MaxDate = Global.CurrentFinancialYear.MaxDate;

            endDatePicker.MinDate = startDatePicker.MinDate;
            endDatePicker.MaxDate = startDatePicker.MaxDate;

            paymentsGrid.AutoGenerateColumns = false;

            if (!loadCustomers())
            {
                customerButton.Enabled = false;
            }
        }

        private void startDatePicker_Validating(object sender, CancelEventArgs e)
        {
            if (startDatePicker.Value.Date.CompareTo(endDatePicker.Value.Date) > 0)
            {
                errorProvider.SetError(startDatePicker, "Start date can't be later than the end date.");
                e.Cancel = true;
            }
        }

        private void startDatePicker_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(startDatePicker, null);
        }

        private void endDatePicker_Validating(object sender, CancelEventArgs e)
        {
            if (startDatePicker.Value.Date.CompareTo(endDatePicker.Value.Date) > 0)
            {
                errorProvider.SetError(startDatePicker, "End date can't be before than the end date.");
                e.Cancel = true;
            }
        }

        private void endDatePicker_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(endDatePicker, null);
        }

        private void paymentModePanel_Validating(object sender, CancelEventArgs e)
        {
            if (paymentModeButton.Checked)
            {
                if (!cashButton.Checked && !chequeButton.Checked && !demandDraftButton.Checked)
                {
                    errorProvider.SetError(paymentModePanel, "No Payment mode selected");
                    e.Cancel = true;
                }
            }
        }

        private void paymentModePanel_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(paymentModePanel, null);
        }

        private void customerComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (customerComboBox.SelectedValue == null)
            {
                errorProvider.SetError(customerComboBox, "Customer not selected");
                e.Cancel = true;
            }
        }

        private void customerComboBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(customerComboBox, null);
        }

        private void onCriteriaChanged()
        {
            resultsGroupBox.Visible = false;
            paymentsGrid.DataSource = null;
            paymentsGrid.Refresh();
            paymentCountField.Text = string.Empty;
            paymentTotalField.Text = string.Empty;
        }

        private string getQuerySQL()
        {
            StringBuilder sql = new StringBuilder("SELECT PM.*, CM.Name FROM Payments PM ")
                .Append("INNER JOIN Customers CM ON PM.CustomerID = CM.ID ");

            bool whereAdded = false;

            if (betweenDatesButton.Checked)
            {
                whereAdded = true;
                sql.Append("WHERE PaymentDate BETWEEN '")
                    .Append(startDatePicker.Value.Date.ToString("yyyyMMdd"))
                    .Append("' AND '")
                    .Append(endDatePicker.Value.Date.ToString("yyyyMMdd")).Append("' ");
            }

            if (paymentModeButton.Checked)
            {
                if (whereAdded)
                {
                    sql.Append(" AND ");
                }
                else
                {
                    sql.Append(" WHERE ");
                    whereAdded = true;
                }

                sql.Append("PaymentMode IN (");
                string paymentMode = string.Empty;
                paymentMode = cashButton.Checked ? "'C', " : string.Empty;
                paymentMode += chequeButton.Checked ? "'Q', " : string.Empty;
                paymentMode += demandDraftButton.Checked ? "'D', " : string.Empty;

                paymentMode = paymentMode.Remove(paymentMode.Length - 2);
                sql.Append(paymentMode + ") ");
            }

            if (customerButton.Checked)
            {
                if (whereAdded)
                {
                    sql.Append(" AND ");
                }
                else
                {
                    sql.Append(" WHERE ");
                    whereAdded = true;
                }

                sql.Append(" CustomerID = ").Append((int)customerComboBox.SelectedValue);
            }

            sql.Append(" ORDER BY PaymentDate ");

            return sql.ToString();
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
                table = getCustomers(connection);
            }
            catch (Exception ex)
            {
                SystemSounds.Exclamation.Play();
                string message = "An error occurred in fetching the customers' list"
                    + " from the database." + "\nThe error text is as follows:\n" +
                    Global.getExceptionText(ex);
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in fetching Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ErrorLogger.LogError(ex);
                return false;
            }

            customerComboBox.DataSource = table;
            customerComboBox.DisplayMember = "Name";
            customerComboBox.ValueMember = "ID";
            customerComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            customerComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            customerComboBox.SelectedIndex = -1;

            return true;
        }

        private DataTable getCustomers(SqlCeConnection connection)
        {
            using (SqlCeCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT ID, Name FROM Customers ORDER BY Name";

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
                string message = "An error occurred in getting the query result from the database."
                    + "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                Cursor.Current = Cursors.Default;
                SystemSounds.Exclamation.Play();
                MessageBox.Show(message, "Error in Getting Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                ErrorLogger.LogError(ex);
                return null;
            }
        }

        private void showPaymentSummary(DataTable table)
        {
            decimal paymentTotal = 0.0M;

            DataRow[] rows = table.Select("", "", System.Data.DataViewRowState.CurrentRows);
            foreach (DataRow row in rows)
            {
                paymentTotal += (decimal)row[3];
            }

            paymentTotalField.Text = paymentTotal.ToString("N2");

            paymentCountField.Text = rows.Length.ToString();
        }

        private void paymentsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (paymentsGrid.Columns[e.ColumnIndex].Name != "PaymentMode")
            {
                return;
            }

            switch ((string)e.Value)
            {
                case "C":
                    e.Value = "Cash";
                    e.FormattingApplied = true;
                    break;
                case "Q":
                    e.Value = "Cheque";
                    e.FormattingApplied = true;
                    break;
                case "D":
                    e.Value = "DD";
                    e.FormattingApplied = true;
                    break;
            }
        }

        private void configureDataGridColumns()
        {
            if (paymentsGrid.Tag != null)
            {
                return;
            }

            DataGridViewColumnCollection columns = paymentsGrid.Columns;

            columns["PaymentDate"].DisplayIndex = 0;
            columns["CustomerName"].DisplayIndex = 1;
            columns["Amount"].DisplayIndex = 2;
            columns["PaymentMode"].DisplayIndex = 3;
            columns["InstrumentNumber"].DisplayIndex = 4;
            columns["Notes"].DisplayIndex = 5;

            paymentsGrid.Tag = true;
        }

        private void paymentsGrid_SelectionChanged(object sender, EventArgs e)
        {
            bool rowSelected = paymentsGrid.SelectedRows.Count > 0;
            editButton.Enabled = rowSelected;
            deleteButton.Enabled = rowSelected;
        }

        private bool deletePayment(int paymentID)
        {
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            if (errorText != null)
            {
                Global.DisplayConnectionErrorMessage();
                return false;
            }

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Payments WHERE ID = " + paymentID;
                    int recordsDeleted = command.ExecuteNonQuery();

                    return (recordsDeleted == 1 ? true : false);
                }
            }
            catch (Exception ex)
            {
                string message = "An error occurred in deleting the selected payment from " +
                    "the database. \nThe error text is as follows:\n " +
                    Global.getExceptionText(ex);
                Cursor.Current = Cursors.Default;
                SystemSounds.Exclamation.Play();
                MessageBox.Show(message, "Error in Deleting Payment Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                ErrorLogger.LogError(ex);
                return false;
            }
        }

        private void customerComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            onCriteriaChanged();
        }
    }
}