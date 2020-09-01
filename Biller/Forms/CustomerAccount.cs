using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    internal sealed partial class CustomerAccount : Form
    {
        private bool toCloseForm = false;

        public CustomerAccount()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomerAccount_Load(object sender, EventArgs e)
        {
            this.Icon = this.MdiParent.Icon;

            this.accountDatePicker.MinDate = Global.CurrentFinancialYear.MinDate;
            this.accountDatePicker.MaxDate = Global.CurrentFinancialYear.MaxDate;

            DataTable table = loadCustomers();
            if (table == null)
            {
                toCloseForm = true;
            }

            customerComboBox.DisplayMember = "Name";
            customerComboBox.ValueMember = "ID";
            customerComboBox.DataSource = table;
            customerComboBox.SelectedIndex = -1;
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
            errorProvider.SetError(customerComboBox, string.Empty);
        }

        private void showAccountButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!this.ValidateChildren(ValidationConstraints.Enabled))
            {
                SystemSounds.Exclamation.Play();
                Cursor.Current = Cursors.Default;
                return;
            }

            DateTime openingDate;

            if (accountDatePicker.Checked)
            {
                openingDate = accountDatePicker.Value.Date;
            }
            else
            {
                openingDate = Global.CurrentFinancialYear.BooksStartDate;
            }

            AccountStatementDataSet dataSet = new AccountStatementDataSet();
            if (!populateOpeningBalance(openingDate, dataSet))
            {
                return;
            }

            if (!populateInvoiceStatements(openingDate, dataSet))
            {
                return;
            }

            if (!populatePaymentStatements(openingDate, dataSet))
            {
                return;
            }

            AccountStatementView form = new AccountStatementView(dataSet,
                (string)customerComboBox.Text);
            form.MdiParent = this.MdiParent;

            try
            {
                form.Show();
            }
            catch (Exception ex)
            {
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                string message = "An error occurred in showing the Print Preview of the account statement."
                    + "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ErrorLogger.LogError(ex);
            }
            Cursor.Current = Cursors.Default;
        }

        private bool populateOpeningBalance(DateTime openingDate,
            AccountStatementDataSet dataset)
        {
            decimal? openingBalance;
            string errorText;
            int customerID = (int)customerComboBox.SelectedValue;

            if (openingDate.CompareTo(Global.CurrentFinancialYear.BooksStartDate) == 0)
            {
                openingBalance = GlobalMethods.GetCustomerOpeningBalance(customerID, out errorText);
            }
            else
            {
                openingBalance = GlobalMethods.GetCustomerBalance(customerID, out errorText, null,
                    openingDate.Subtract(new TimeSpan(1, 0, 0, 0)));
            }

            if (errorText != null)
            {
                SystemSounds.Hand.Play();
                string message = "An error occurred in fetching the customer's account details from "
                    + "the database. \nThe error text is as follows:\n" + errorText;
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            AccountStatementDataSet.AccountStatementRow row =
                dataset.AccountStatement.NewAccountStatementRow();
            row.TransactionDate = openingDate;
            row.Description = "Opening Balance";

            if (openingBalance.Value > 0.0M)
            {
                row.CreditAmount = openingBalance.Value;
            }
            else
            {
                row.DebitAmount = Math.Abs(openingBalance.Value);
            }

            dataset.AccountStatement.AddAccountStatementRow(row);
            return true;
        }

        private bool populateInvoiceStatements(DateTime openingDate, AccountStatementDataSet dataset)
        {
            string sql = getInvoiceRetrievalSQL(openingDate);
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        AccountStatementDataSet.AccountStatementRow row;
                        while (reader.Read())
                        {
                            row = dataset.AccountStatement.NewAccountStatementRow();
                            row.TransactionDate = reader.GetDateTime(1);
                            row.Description = "Invoice# " + reader.GetInt32(0) + " issued";
                            row.DebitAmount = reader.GetDecimal(2);
                            dataset.AccountStatement.AddAccountStatementRow(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "An error occurred in fetching the account details from " +
                    "the database. The error text is as follows:\n" +
                    Global.getExceptionText(ex);
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }

        private string getInvoiceRetrievalSQL(DateTime openingDate)
        {
            int customerID = (int)customerComboBox.SelectedValue;
            string dateCondition = string.Empty;
            if (openingDate.CompareTo(Global.CurrentFinancialYear.BooksStartDate) > 0)
            {
                dateCondition = " And BillDate >= '" + openingDate.ToString("yyyyMMdd") + "' ";
            }

            StringBuilder sql = new StringBuilder("SELECT BM.ID,  BillDate, ")
                .Append("(BD.ItemsTotal + ExpenseAmount - DiscountAmount) as InvoiceTotal ")
                .Append("FROM (Select ID, BillDate, ExpenseAmount, DiscountAmount ")
                .Append("From BillMaster Where CustomerID = ")
                .Append(customerID.ToString());

            if (dateCondition != string.Empty)
            {
                sql.Append(dateCondition);
            }

            sql.Append(") BM OUTER APPLY (")
            .Append("SELECT SUM(Rate * Quantity) AS ItemsTotal ")
            .Append("FROM BillDetails WHERE BillID = BM.ID ) BD ");

            return sql.ToString();
        }

        private string getPaymentRetrievalSQL(DateTime openingDate)
        {
            int customerID = (int)customerComboBox.SelectedValue;
            string dateCondition = string.Empty;
            if (openingDate.CompareTo(Global.CurrentFinancialYear.BooksStartDate) > 0)
            {
                dateCondition = " And PaymentDate >= '" + openingDate.ToString("yyyyMMdd") + "' ";
            }

            StringBuilder sql = new StringBuilder("Select PaymentDate, Amount, PaymentMode ")
            .Append("From Payments ")
            .Append("Where CustomerID = ").Append(customerID);

            if (dateCondition != string.Empty)
            {
                sql.Append(dateCondition);
            }

            return sql.ToString();
        }

        private bool populatePaymentStatements(DateTime openingDate, AccountStatementDataSet dataset)
        {
            string sql = getPaymentRetrievalSQL(openingDate);
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            try
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        AccountStatementDataSet.AccountStatementRow row;
                        string mode;
                        while (reader.Read())
                        {
                            row = dataset.AccountStatement.NewAccountStatementRow();
                            row.TransactionDate = reader.GetDateTime(0);
                            mode = reader.GetString(2);
                            row.Description = "Payment received through " +
                                (mode == "C" ? "cash" : (mode == "Q" ? "cheque" : "DD"));
                            row.CreditAmount = reader.GetDecimal(1);
                            dataset.AccountStatement.AddAccountStatementRow(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "An error occurred in fetching the account details from " +
                    "the database. The error text is as follows:\n" +
                    Global.getExceptionText(ex);
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }

        private DataTable loadCustomers()
        {
            DataTable table;

            try
            {
                string errorText;
                SqlCeConnection connection = Global.getDatabaseConnection(out errorText);
                if (errorText != null)
                {
                    throw new Exception(errorText);
                }

                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT ID, NAME FROM Customers";

                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        table = new DataTable("Customers");
                        table.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                SystemSounds.Hand.Play();
                string message = "An error occurred in fetching the customers' list from the database." +
                    "The error text is as follows:\n" + Global.getExceptionText(ex);
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return null;
            }

            return table;
        }

        private void CustomerAccount_Shown(object sender, EventArgs e)
        {
            if (toCloseForm)
            {
                this.Close();
            }
        }
    }
}