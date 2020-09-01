using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Bajaj.Dinesh.Biller
{
    internal sealed partial class DeleteFinancialYear : Form
    {
        public DeleteFinancialYear()
        {
            InitializeComponent();
        }

        private void DeleteFinancialYear_Load(object sender, EventArgs e)
        {
            this.Icon = this.MdiParent.Icon;
            loadFinancialYears();
        }

        private void loadFinancialYears()
        {
            List<FinancialYear> years = GlobalMethods.GetFinancialYears();
            financialYearsListBox.Items.Clear();

            if (years == null || years.Count == 0)
            {
                financialYearsListBox.Items.Add("<No Year To Open>");
                financialYearsListBox.Enabled = false;
                okButton.Enabled = false;
                return;
            }

            foreach (FinancialYear year in years)
            {
                financialYearsListBox.Items.Add(year);
            }
            financialYearsListBox.SelectedIndex = 0;
        }

        private void financialYearsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (financialYearsListBox.SelectedIndex == -1)
            {
                okButton.Enabled = false;
            }
            else if (financialYearsListBox.SelectedItem.ToString().StartsWith("<No"))
            {
                okButton.Enabled = false;
            }
            else
            {
                okButton.Enabled = true;
            }
        }

        private void refreshListButton_Click(object sender, EventArgs e)
        {
            loadFinancialYears();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            FinancialYear selectedYear = (FinancialYear)financialYearsListBox.SelectedItem;

            string message = "Are you sure that you want to delete the financial year " +
                selectedYear.ToString() + "?";
            SystemSounds.Question.Play();

            DialogResult result = MessageBox.Show(message, "Confirm Deletion", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if (Global.CurrentFinancialYear != null && Global.CurrentFinancialYear.StartYear ==
                selectedYear.StartYear)
            {
                if (!GlobalMethods.closeCurrentlyOpenYear())
                {
                    return;
                }
            }

            if (!deleteFinancialYear(selectedYear))
            {
                return;
            }

            financialYearsListBox.Items.Remove(selectedYear);
            SystemSounds.Asterisk.Play();
            MessageBox.Show("The financial year " + selectedYear.ToString() + " was successfully deleted.",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool deleteFinancialYear(FinancialYear year)
        {
            try
            {
                File.Delete(year.FilePath);
            }
            catch (Exception ex)
            {
                string message = "An error occurred in deleting the database file for the financial year " +
                    year.ToString() + "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }
    }
}