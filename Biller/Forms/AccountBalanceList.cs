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
    internal sealed partial class AccountBalanceList : Form
    {
        public AccountBalanceList()
        {
            InitializeComponent();
        }

        private void allCustomersButton_CheckedChanged(object sender, EventArgs e)
        {
            onCriteriaChanged();
        }

        private void selectedCustomersButton_CheckedChanged(object sender, EventArgs e)
        {
            CustomersListBox.Enabled = selectedCustomersButton.Checked;
            onCriteriaChanged();
            if (CustomersListBox.Enabled)
            {
                CustomersListBox.Focus();
            }
        }

        private void refreshCustomerList_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            loadCustomers();
            onCriteriaChanged();
            Cursor.Current = Cursors.Default;
        }

        private void CustomersListBox_Validating(object sender, CancelEventArgs e)
        {
            if (CustomersListBox.CheckedItems.Count == 0)
            {
                errorProvider.SetError(CustomersListBox, "No customer selected.");
                e.Cancel = true;
            }
        }

        private void CustomersListBox_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(CustomersListBox, null);
        }

        private void showBalanceButton_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren(ValidationConstraints.Enabled))
            {
                SystemSounds.Exclamation.Play();
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            string sql = getQuerySql();
            DataTable table;

            if (!getQueryResultTable(sql, out table))
            {
                return;
            }

            decimal totalBalance;
            if (!populateCustomerBalanceInTable(table, out totalBalance))
            {
                return;
            }

            customerCountField.Text = table.Rows.Count.ToString();
            balanceTotalField.Text = GlobalMethods.GetBalanceAsString(totalBalance);

            balanceGrid.DataSource = table;
            resultGroupBox.Visible = true;
            Cursor.Current = Cursors.Default;
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

            CustomersListBox.DataSource = table;
            CustomersListBox.DisplayMember = "Name";
            CustomersListBox.ValueMember = "ID";

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

        private void AccountBalanceList_Load(object sender, EventArgs e)
        {
            balanceGrid.AutoGenerateColumns = false;
            this.Icon = this.MdiParent.Icon;

            if (!loadCustomers())
            {
                return;
            }
        }

        private void onCriteriaChanged()
        {
            resultGroupBox.Visible = false;
            balanceGrid.DataSource = null;
            customerCountField.Text = string.Empty;
            balanceTotalField.Text = string.Empty;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private string getQuerySql()
        {
            StringBuilder sql = new StringBuilder("SELECT ID, Name as CustomerName, City FROM Customers ");

            if (selectedCustomersButton.Checked)
            {
                sql.Append("Where ID in (");

                CheckedListBox.CheckedItemCollection checkedItems =
                    CustomersListBox.CheckedItems;

                foreach (DataRowView row in checkedItems)
                {
                    sql.Append(row[0] + ", ");
                }

                sql.Remove(sql.Length - 2, 2).Append(")");
            }

            return sql.ToString();
        }

        private bool getQueryResultTable(string sql, out DataTable table)
        {
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            if (errorText != null)
            {
                Global.DisplayConnectionErrorMessage();
                table = null;
                return false;
            }

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        table = new DataTable("BalanceList");
                        table.Load(reader);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "An error occurred in fetching the query result from the database."
                    + "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Exclamation.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Fetching Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                table = null;
                ErrorLogger.LogError(ex);
                return false;
            }
        }

        private bool populateCustomerBalanceInTable(DataTable table, out decimal totalBalance)
        {
            table.Columns.Add("BalanceAmount", typeof(decimal));

            decimal? balanceAmount;
            string errorText;

            totalBalance = 0.0M;

            foreach (DataRow row in table.Rows)
            {
                balanceAmount = GlobalMethods.GetCustomerBalance((int)row["ID"], out errorText);
                if (!balanceAmount.HasValue)
                {
                    return false;
                }
                row["BalanceAmount"] = balanceAmount.Value;
                totalBalance += balanceAmount.Value;
            }

            return true;
        }

        private void balanceGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (balanceGrid.Columns[e.ColumnIndex].Name != "BalanceAmount")
            {
                return;
            }

            e.Value = GlobalMethods.GetBalanceAsString((decimal)e.Value);
            e.FormattingApplied = true;
        }

        private void balanceGrid_DataSourceChanged(object sender, EventArgs e)
        {
            printListbutton.Enabled = (balanceGrid.DataSource != null);
        }

        private void CustomersListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            onCriteriaChanged();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printListbutton_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)balanceGrid.DataSource;

            BalanceListReportView form = new BalanceListReportView(table);
            form.MdiParent = this.MdiParent;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                form.Show();
            }
            catch (Exception ex)
            {
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                string message = "An error occurred in showing the Print Preview of the balances."
                    + "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ErrorLogger.LogError(ex);
            }

            Cursor.Current = Cursors.Default;
        }
    }
}