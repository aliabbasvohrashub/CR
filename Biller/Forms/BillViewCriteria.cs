using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bajaj.Dinesh.Biller
{
    internal sealed partial class BillViewCriteria : Form
    {
        public BillViewCriteria()
        {
            InitializeComponent();
        }

        private void findInvoicesButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void findbyDateButton_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = findbyDateButton.Checked;
            startDatePicker.Enabled = isChecked;
            endDatePicker.Enabled = isChecked;
            additionalCriterialGroupBox.Enabled = isChecked;
        }

        private void findByInvoiceNumberButton_CheckedChanged(object sender, EventArgs e)
        {
            if (findByInvoiceNumberButton.Checked)
            {
                invoiceNumberField.Enabled = true;
                invoiceNumberField.Focus();
            }
            else
            {
                invoiceNumberField.Enabled = false;
            }
        }

        private void paymentTypeButton_CheckedChanged(object sender, EventArgs e)
        {
            paymentModePanel.Enabled = paymentTypeButton.Checked;
        }

        private void customerButton_CheckedChanged(object sender, EventArgs e)
        {
            if (customerButton.Checked)
            {
                customerCombo.Enabled = true;
                customerCombo.Focus();
            }
            else
            {
                customerCombo.Enabled = false;
            }
        }

        private void paymentModePanel_Validating(object sender, CancelEventArgs e)
        {
            if (paymentTypeButton.Checked && !cashButton.Checked && !creditButton.Checked)
            {
                errorProvider.SetError(paymentModePanel, "Invoice type not specified");
                e.Cancel = true;
            }
        }

        private void paymentModePanel_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(paymentModePanel, string.Empty);
        }

        private void customerCombo_Validating(object sender, CancelEventArgs e)
        {
            if (customerCombo.SelectedValue == null)
            {
                errorProvider.SetError(customerCombo, "Customer not selected");
                e.Cancel = true;
            }
        }

        private void customerCombo_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(customerCombo, string.Empty);
        }

        private void invoiceNumberField_Validating(object sender, CancelEventArgs e)
        {
            string str = invoiceNumberField.Text.Trim();
            if (string.IsNullOrEmpty(str))
            {
                errorProvider.SetError(invoiceNumberField, "Invoice number not specified.");
                e.Cancel = true;
                return;
            }

            int number;
            if (!int.TryParse(str, out number))
            {
                errorProvider.SetError(invoiceNumberField, "Valid numeric value not provided");
                e.Cancel = true;
                return;
            }

            if (number < 0)
            {
                errorProvider.SetError(invoiceNumberField, "Value provided must be greater than zero.");
                e.Cancel = true;
            }
        }

        private void invoiceNumberField_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(invoiceNumberField, string.Empty);
        }

        private void startDatePicker_Validating(object sender, CancelEventArgs e)
        {
            if (startDatePicker.Value.Date.CompareTo(endDatePicker.Value.Date) > 0)
            {
                errorProvider.SetError(startDatePicker, "Start date can't be later than the end date");
                e.Cancel = true;
            }
        }

        private void startDatePicker_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(startDatePicker, string.Empty);
        }

        private void BillViewCriteria_Load(object sender, EventArgs e)
        {
            startDatePicker.MinDate = Global.CurrentFinancialYear.MinDate;
            startDatePicker.MaxDate = Global.CurrentFinancialYear.MaxDate;

            endDatePicker.MinDate = startDatePicker.MinDate;
            endDatePicker.MaxDate = startDatePicker.MaxDate;

            this.Icon = Global.MDIForm.Icon;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren(ValidationConstraints.Enabled))
            {
                System.Media.SystemSounds.Exclamation.Play();
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}