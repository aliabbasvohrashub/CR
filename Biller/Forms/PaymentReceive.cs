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
    internal sealed partial class PaymentReceive : Form
    {
        private bool toCloseForm = false;
        private int? paymentToEdit = null;

        public PaymentReceive()
        {
            InitializeComponent();
        }

        public PaymentReceive(int paymentID)
            : this()
        {
            this.paymentToEdit = paymentID;
            this.Text = "Editing Payment";
        }

        private void PaymentReceive_Load(object sender, EventArgs e)
        {
            this.Icon = Global.MDIForm.Icon;

            paymentDatePicker.MinDate = Global.CurrentFinancialYear.MinDate;
            paymentDatePicker.MaxDate = Global.CurrentFinancialYear.MaxDate;
            paymentDatePicker.Value = paymentDatePicker.MaxDate;

            if (!loadCustomers())
            {
                toCloseForm = true;
                return;
            }

            if (paymentToEdit.HasValue)
            {
                if (!loadPaymentDetails(paymentToEdit.Value))
                {
                    toCloseForm = true;
                    return;
                }
            }
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
                SystemSounds.Hand.Play();
                string message = "An error occurred in fetching the customers' list"
                    + " from the database." + "\nThe error text is as follows:\n" +
                    Global.getExceptionText(ex);
                MessageBox.Show(message, "Error in fetching Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            customerNameCombo.DataSource = table;
            customerNameCombo.DisplayMember = "Name";
            customerNameCombo.ValueMember = "ID";
            customerNameCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            customerNameCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
            customerNameCombo.SelectedIndex = -1;

            return true;
        }

        private void PaymentReceive_Activated(object sender, EventArgs e)
        {
        }

        private DataTable getCustomers(SqlCeConnection connection)
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

        private void customerNameCombo_Validating(object sender, CancelEventArgs e)
        {
            if (customerNameCombo.SelectedValue == null)
            {
                errorProvider.SetError(customerNameCombo, "Customer not selected.");
                e.Cancel = true;
            }
        }

        private void customerNameCombo_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(customerNameCombo, null);
        }

        private void amountField_Validating(object sender, CancelEventArgs e)
        {
            string str = amountField.Text.Trim();
            if (string.IsNullOrEmpty(str))
            {
                errorProvider.SetError(amountField, "Payment amount not specified.");
                e.Cancel = true;
                return;
            }

            decimal amount;
            if (!decimal.TryParse(str, out amount))
            {
                errorProvider.SetError(amountField, "Not a valid numeric value.");
                e.Cancel = true;
                return;
            }

            if (amount <= 0.0M)
            {
                errorProvider.SetError(amountField, "Payment amount has to be greater than zero.");
                e.Cancel = true;
                return;
            }
        }

        private void amountField_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(amountField, null);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cashButton_CheckedChanged(object sender, EventArgs e)
        {
            instrumentNumberField.Enabled = !cashButton.Checked;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!this.ValidateChildren())
            {
                SystemSounds.Exclamation.Play();
                Cursor.Current = Cursors.Default;
                return;
            }

            if (!saveData())
            {
                return;
            }

            if (paymentToEdit.HasValue) // if editing a payment
            {
                Cursor.Current = Cursors.Default;
                SystemSounds.Asterisk.Play();
                MessageBox.Show("The payment was successfully updated!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
                return;
            }

            timer.Enabled = true;
            successButton.Visible = true;

            clearControls();

            showCustomerBalance();
            Cursor.Current = Cursors.Default;
        }

        private void clearControls()
        {
            amountField.Text = string.Empty;
            instrumentNumberField.Text = string.Empty;
            notesField.Text = string.Empty;
            balanceField.Text = string.Empty;
        }

        private void customerNameCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            showCustomerBalance();
        }

        private void amountField_Leave(object sender, EventArgs e)
        {
            string text = amountField.Text.Trim();
            if (text.Length == 0)
            {
                return;
            }

            decimal amount;
            if (!decimal.TryParse(text, out amount))
            {
                return;
            }

            amountField.Text = amount.ToString("N2");
        }

        private bool saveData()
        {
            string errorText;
            SqlCeConnection connection = Global.getDatabaseConnection(out errorText);

            try
            {
                using (SqlCeCommand command = getSaveCommand(connection))
                {
                    int recordsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string message = "An error occurred in saving the payment data. " +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Saving Data", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }

        private SqlCeCommand getSaveCommand(SqlCeConnection connection)
        {
            SqlCeCommand command = connection.CreateCommand();

            if (paymentToEdit.HasValue)
            {
                command.CommandText = "Update Payments Set CustomerID = @customerID, PaymentDate = @paymentDate, "
                    + "Amount = @amount, PaymentMode = @paymentMode, InstrumentNumber = @instrumentNumber, "
                    + "Notes = @notes Where ID = " + paymentToEdit.Value;
            }
            else
            {
                command.CommandText = "INSERT INTO PAYMENTS (CustomerID, PaymentDate, Amount, PaymentMode, " +
                "InstrumentNumber, Notes) VALUES (@customerID, @paymentDate, @amount, @paymentMode, " +
                "@instrumentNumber, @notes)";
            }

            SqlCeParameterCollection parameters = command.Parameters;
            SqlCeParameter parameter = parameters.Add("@customerID", SqlDbType.Int);
            parameter.Value = customerNameCombo.SelectedValue;

            parameter = parameters.Add("@paymentDate", SqlDbType.DateTime);
            parameter.Value = paymentDatePicker.Value.Date;

            parameter = parameters.Add("@amount", SqlDbType.Decimal);
            decimal amount = decimal.Parse(amountField.Text.Trim());
            parameter.Value = Math.Round(amount, 2);

            parameter = parameters.Add("@paymentMode", SqlDbType.NChar);
            parameter.Value = cashButton.Checked ? 'C' : (chequeButton.Checked ? 'Q' : 'D');

            parameter = parameters.Add("@instrumentNumber", SqlDbType.NVarChar, 20);
            string text = instrumentNumberField.Text.Trim();
            if (text.Length > 0)
            {
                parameter.Value = text;
            }
            else
            {
                parameter.Value = DBNull.Value;
            }

            parameter = parameters.Add("@notes", SqlDbType.NVarChar, 60);
            text = notesField.Text.Trim();
            if (text.Length > 0)
            {
                parameter.Value = text;
            }
            else
            {
                parameter.Value = DBNull.Value;
            }

            return command;
        }

        private void instrumentNumberField_Validating(object sender, CancelEventArgs e)
        {
            string str = instrumentNumberField.Text.Trim();
            if (str.Length == 0)
            {
                e.Cancel = false;
                return;
            }

            char[] chars = str.ToCharArray();
            foreach (char c in chars)
            {
                if (!char.IsDigit(c))
                {
                    errorProvider.SetError(instrumentNumberField, "Instrument number can contain digits only.");
                    e.Cancel = true;
                    return;
                }
            }

            e.Cancel = false;
        }

        private void showCustomerBalance()
        {
            balanceField.Text = string.Empty;
            if (customerNameCombo.SelectedValue == null)
            {
                return;
            }

            if (!(customerNameCombo.SelectedValue is int))
            {
                return;
            }

            int customerID = (int)customerNameCombo.SelectedValue;

            string errorText;
            decimal? balance = GlobalMethods.GetCustomerBalance(customerID, out errorText);

            if (!balance.HasValue)
            {
                string message = "An error occurred in retrieving the balance amount of the customer '"
                    + customerNameCombo.SelectedText + "'." + "\nThe error text is as follows:\n" +
                    errorText;
                SystemSounds.Exclamation.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Getting Balance Amount",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            balanceField.Text = GlobalMethods.GetBalanceAsString(balance.Value);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            successButton.Visible = false;
            timer.Enabled = false;
        }

        private bool loadPaymentDetails(int paymentID)
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
                    command.CommandText = "SELECT * FROM Payments Where ID = " +
                        paymentID;

                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        populateControlsWithData(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "An error occurred in loading the payment details. " +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Loading Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }

        private void populateControlsWithData(SqlCeDataReader reader)
        {
            int customerID = reader.GetInt32(reader.GetOrdinal("CustomerID"));
            customerNameCombo.SelectedValue = customerID;

            paymentDatePicker.Value = reader.GetDateTime(reader.GetOrdinal("PaymentDate"));

            decimal amount = reader.GetDecimal(reader.GetOrdinal("Amount"));
            amountField.Text = amount.ToString("N2");

            string paymentMode = reader.GetString(reader.GetOrdinal("PaymentMode"));
            switch (paymentMode)
            {
                case "C":
                    cashButton.Checked = true;
                    break;
                case "Q":
                    chequeButton.Checked = true;
                    break;
                case "D":
                    demandDraftButton.Checked = true;
                    break;
            }

            object value = reader.GetValue(reader.GetOrdinal("InstrumentNumber"));
            if (value != DBNull.Value)
            {
                instrumentNumberField.Text = (string)value;
            }

            value = reader.GetValue(reader.GetOrdinal("Notes"));
            if (value != DBNull.Value)
            {
                notesField.Text = (string)value;
            }

            string errorText;
            decimal? balanceAmount = GlobalMethods.GetCustomerBalance(customerID,
                out errorText);

            if (!balanceAmount.HasValue)
            {
                string message = "An error occurred in fetching the customer's balance from the database."
                    + "\nThe error text is as follows:\n" + errorText;
                Cursor.Current = Cursors.Default;
                SystemSounds.Exclamation.Play();
                MessageBox.Show(message, "Error in Fetching Account Balance", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            balanceAmount = balanceAmount.Value - amount;
            balanceField.Text = GlobalMethods.GetBalanceAsString(balanceAmount.Value);
        }

        private void PaymentReceive_Shown(object sender, EventArgs e)
        {
            if (this.toCloseForm)
            {
                this.Close();
            }
        }
    }
}