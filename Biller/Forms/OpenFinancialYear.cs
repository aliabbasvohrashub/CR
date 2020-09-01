using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Bajaj.Dinesh.Biller
{
    internal sealed partial class OpenFinancialYear : Form
    {
        public OpenFinancialYear()
        {
            InitializeComponent();
        }

        private void OpenFinancialYear_Load(object sender, EventArgs e)
        {
            this.Icon = this.MdiParent.Icon;
            loadFinancialYears();
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadFinancialYears()
        {
            List<FinancialYear> years = GlobalMethods.GetFinancialYears();
            financialYearsListBox.Items.Clear();

            if (years != null && years.Count > 0 && Global.CurrentFinancialYear != null)
            {
                int index = years.IndexOf(Global.CurrentFinancialYear);
                years.RemoveAt(index);
            }

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

        private void refreshListButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            loadFinancialYears();
            Cursor.Current = Cursors.Default;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (Global.CurrentFinancialYear != null)
            {
                string message = "The currently opened financial year and its associated "
                    + "windows will be closed?";
                SystemSounds.Question.Play();
                DialogResult result = MessageBox.Show(message, "Confirm Action",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
            }

            if (!GlobalMethods.closeCurrentlyOpenYear())
            {
                return;
            }

            openSelectedYear();

            this.Close();
        }

        private void openSelectedYear()
        {
            Global.CurrentFinancialYear = (FinancialYear)financialYearsListBox.SelectedItem;
            this.MdiParent.Text = Global.AssemblyTitle + " (Financial Year: " +
                Global.CurrentFinancialYear.ToString() + ")";
        }
    }
}