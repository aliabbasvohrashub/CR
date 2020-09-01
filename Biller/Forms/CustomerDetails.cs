using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bajaj.Dinesh.Biller
{
    internal sealed partial class CustomerDetails : Form
    {
        private DataRow rowBeingEdited;
        private DataTable customersTable;

        private CustomerDetails()
        {
            InitializeComponent();
            populateBalanceTypes();
        }

        public CustomerDetails(DataRow rowBeingEdited, DataTable customersTable)
            : this()
        {
            this.rowBeingEdited = rowBeingEdited;
            this.customersTable = customersTable;

            if (rowBeingEdited != null)
            {
                populateControlsWithData();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Hide();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren(ValidationConstraints.Enabled))
            {
                System.Media.SystemSounds.Exclamation.Play();
                return;
            }

            if (rowBeingEdited != null)
            {
                populateRowWithData(rowBeingEdited);
            }
            else
            {
                DataRow newlyAddedRow = customersTable.NewRow();
                populateRowWithData(newlyAddedRow);
                customersTable.Rows.Add(newlyAddedRow);
            }

            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void CustomerDetails_Load(object sender, EventArgs e)
        {
            this.Icon = Global.MDIForm.Icon;
        }

        private class BalanceType
        {
            public string DisplayMember { get; set; }

            public string ValueMember { get; set; }

            public BalanceType(string displayMember, string valueMember)
            {
                DisplayMember = displayMember;
                ValueMember = valueMember;
            }
        }

        private void populateBalanceTypes()
        {
            List<BalanceType> balanceTypes = new List<BalanceType>
            {
                new BalanceType("None", "N"),
                new BalanceType ("Credit", "C"),
                new BalanceType("Debit", "D")
            };

            balanceTypeField.DataSource = balanceTypes;
            balanceTypeField.DisplayMember = "DisplayMember";
            balanceTypeField.ValueMember = "ValueMember";
        }

        private void openingBalanceField_Validating(object sender, CancelEventArgs e)
        {
            string text = openingBalanceField.Text.Trim();
            if (text.Length == 0)
            {
                errorProvider.SetError(openingBalanceField, "Opening Balance not specified.");
                e.Cancel = true;
                return;
            }

            try
            {
                decimal value = decimal.Parse(text);
                if (value < 0.0M)
                {
                    errorProvider.SetError(openingBalanceField,
                        "Negative number not valid for opening balance.");
                    e.Cancel = true;
                }
            }
            catch (Exception)
            {
                errorProvider.SetError(openingBalanceField,
                    "Not a valid numeric value provided for opening balance.");
                e.Cancel = true;
            }
        }

        private void openingBalanceField_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(openingBalanceField, null);

            decimal value = decimal.Parse(openingBalanceField.Text.Trim());

            if (value == 0.0M) //balance type not required for zero value
            {
                balanceTypeField.SelectedValue = "N";
                balanceTypeField.Enabled = false;
            }
            else
            {
                balanceTypeField.Enabled = true;
            }
        }

        private void nameField_TextChanged(object sender, EventArgs e)
        {
            string text = nameField.Text.Trim();
            if (text.Length > 0)
            {
                errorProvider.SetError(nameField, null);
            }
        }

        private void nameField_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(nameField, null);
        }

        private void nameField_Validating(object sender, CancelEventArgs e)
        {
            string text = nameField.Text.Trim();
            if (text.Length == 0)
            {
                errorProvider.SetError(nameField, "Customer name not specified.");
                e.Cancel = true;
                return;
            }

            //check wheter the customer name is duplicate
            string searchExpression = "Name = '" + text + "'";
            if (rowBeingEdited != null)
            {
                searchExpression += " AND ID <> " + rowBeingEdited["ID"];
            }

            DataRow[] matchedrows = customersTable.Select(searchExpression);
            if (matchedrows.Length > 0)
            {
                errorProvider.SetError(nameField, "Duplicate name being provided");
                e.Cancel = true;
            }
        }

        private void balanceTypeField_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(balanceTypeField, null);
        }

        private void balanceTypeField_Validating(object sender, CancelEventArgs e)
        {
            decimal? openingBalance = null;
            try
            {
                openingBalance = decimal.Parse(openingBalanceField.Text.Trim());
            }
            catch (Exception)
            {
                // no action required here
            }

            string selectedValue = (string)balanceTypeField.SelectedValue;
            if (selectedValue.ToLower() == "n")
            {
                if (openingBalance.HasValue && openingBalance.Value > 0.0M)
                {
                    errorProvider.SetError(balanceTypeField,
                        "'Credit' or 'Debit' must be selected for non-zero opening balance.");
                    e.Cancel = true;
                }
            }
            else if (openingBalance.HasValue == false || openingBalance.Value == 0.0M)
            {
                errorProvider.SetError(balanceTypeField,
                    "'Credit' or 'Debit' can only be selected for a non-zero opening balance.");
                e.Cancel = true;
            }
        }

        private void populateRowWithData(DataRow row)
        {
            row["Name"] = nameField.Text.Trim();

            string value = addressField.Text.Trim();
            if (string.IsNullOrEmpty(value))
            {
                row["Address"] = DBNull.Value;
            }
            else
            {
                row["Address"] = value;
            }

            value = cityField.Text.Trim();
            if (string.IsNullOrEmpty(value))
            {
                row["City"] = DBNull.Value;
            }
            else
            {
                row["City"] = value;
            }

            value = phoneNumbersField.Text.Trim();
            if (string.IsNullOrEmpty(value))
            {
                row["PhoneNumbers"] = DBNull.Value;
            }
            else
            {
                row["PhoneNumbers"] = value;
            }

            value = mobileNumbersField.Text.Trim();
            if (string.IsNullOrEmpty(value))
            {
                row["MobileNumbers"] = DBNull.Value;
            }
            else
            {
                row["MobileNumbers"] = value;
            }

            value = notesField.Text.Trim();
            if (string.IsNullOrEmpty(value))
            {
                row["Notes"] = DBNull.Value;
            }
            else
            {
                row["Notes"] = value;
            }

            decimal balance = decimal.Parse(openingBalanceField.Text.Trim());
            row["OpeningBalance"] = Math.Round(balance, 2);

            value = (string)balanceTypeField.SelectedValue;
            if (value.ToLower() == "n")
            {
                row["BalanceType"] = DBNull.Value;
            }
            else
            {
                row["BalanceType"] = value;
            }

            string formattedBalance = string.Format("{0:N2}", row["OpeningBalance"]);
            if (value.ToLower() == "c")
            {
                formattedBalance += " Cr.";
            }
            else if (value.ToLower() == "d")
            {
                formattedBalance += " Dr.";
            }
            row["FormattedBalance"] = formattedBalance;
        }

        private void populateControlsWithData()
        {
            nameField.Text = (string)rowBeingEdited["Name"];
            object value = rowBeingEdited["Address"];
            if (value != DBNull.Value)
            {
                addressField.Text = (string)value;
            }

            value = rowBeingEdited["City"];
            if (value != DBNull.Value)
            {
                cityField.Text = (string)value;
            }

            value = rowBeingEdited["PhoneNumbers"];
            if (value != DBNull.Value)
            {
                phoneNumbersField.Text = (string)value;
            }

            value = rowBeingEdited["MobileNumbers"];
            if (value != DBNull.Value)
            {
                mobileNumbersField.Text = (string)value;
            }

            value = rowBeingEdited["Notes"];
            if (value != DBNull.Value)
            {
                notesField.Text = (string)value;
            }

            openingBalanceField.Text = ((decimal)rowBeingEdited["OpeningBalance"]).ToString("N2");

            value = rowBeingEdited["BalanceType"];
            if (value == DBNull.Value)
            {
                balanceTypeField.SelectedValue = "N";
            }
            else
            {
                balanceTypeField.SelectedValue = (string)value;
            }
        }

        private void CustomerDetails_Activated(object sender, EventArgs e)
        {
            nameField.Focus();
        }
    }
}