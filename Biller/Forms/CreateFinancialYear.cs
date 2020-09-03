using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Bajaj.Dinesh.Biller
{
    internal sealed partial class CreateFinancialYear : Form
    {
        private List<FinancialYear> financialYears;

        public CreateFinancialYear()
        {
            InitializeComponent();
        }

        private void transferDataFromAnotherYearButton_CheckedChanged(object sender, EventArgs e)
        {
            if (transferDataFromAnotherYearButton.Checked)
            {
                booksStartDatePicker.Enabled = false;
                financialYearCombo.Enabled = true;
                financialYearCombo.Focus();
            }
            else
            {
                booksStartDatePicker.Enabled = true;
                financialYearCombo.Enabled = false;
            }
        }

        private void financialYearCombo_Validating(object sender, CancelEventArgs e)
        {
            if (financialYearCombo.SelectedItem == null)
            {
                errorProvider.SetError(financialYearCombo, "Year not selected");
                e.Cancel = true;
            }
        }

        private void financialYearCombo_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(financialYearCombo, string.Empty);
        }

        private void CreateFinancialYear_Load(object sender, EventArgs e)
        {
            this.Icon = Global.MDIForm.Icon;

            financialYears = GlobalMethods.GetFinancialYears();

            if (financialYears == null || financialYears.Count == 0)
            {
                transferDataFromAnotherYearButton.Enabled = false;
                financialYearCombo.Enabled = false;
            }

            DateTime today = DateTime.Today.Date;
            if (today.Month >= 4)
            {
                startYearField.Maximum = today.Year;
            }
            else
            {
                startYearField.Maximum = today.Year - 1;
            }

            try
            {
                startYearField.Value = startYearField.Maximum;
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex);
            }
        }

        private void startYearField_ValueChanged(object sender, EventArgs e)
        {
            int startYear = (int)startYearField.Value;
            endYearField.Text = Convert.ToString(startYear + 1);
            booksStartDatePicker.MaxDate = getMaxBooksStartDateForFinancialYear(startYear);
            booksStartDatePicker.Value = new DateTime(startYear, 4, 1);

            if (financialYears != null && financialYears.Count > 0)
            {
                List<FinancialYear> years = getPreviousFinancialYears(startYear);
                if (years.Count == 0)
                {
                    transferDataFromAnotherYearButton.Enabled = false;
                    financialYearCombo.Enabled = false;
                }
                else
                {
                    transferDataFromAnotherYearButton.Enabled = true;
                    financialYearCombo.Items.Clear();
                    financialYearCombo.Items.AddRange(years.ToArray<FinancialYear>());
                    financialYearCombo.SelectedIndex = -1;
                }

                okButton.Enabled = !isExists(startYear);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<FinancialYear> getPreviousFinancialYears(int startYear)
        {
            FinancialYear fy = new FinancialYear(startYear, DateTime.Today, string.Empty);
            List<FinancialYear> years = new List<FinancialYear>(financialYears.Count);

            foreach (FinancialYear year in financialYears)
            {
                if (year.CompareTo(fy) < 0)
                {
                    years.Add(year);
                }
            }

            return years;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!this.ValidateChildren(ValidationConstraints.Enabled))
            {
                Cursor.Current = Cursors.Default;
                return;
            }

            int startYear = (int)startYearField.Value;
            DateTime booksStartDate;

            if (transferDataFromAnotherYearButton.Enabled && transferDataFromAnotherYearButton.Checked)
            {
                booksStartDate = new DateTime(startYear, 4, 1);
            }
            else
            {
                booksStartDate = booksStartDatePicker.Value.Date;
            }

            if (!createRootFolderIfNotExists())
            {
                return;
            }

            if (!CreateDatabase(startYear, booksStartDate))
            {
                return;
            }

            if (transferDataFromAnotherYearButton.Enabled && transferDataFromAnotherYearButton.Checked)
            {
                string targetDatabasePath = getDatabaseNameWithPath(startYear);
                FinancialYear sourceYear = (FinancialYear)financialYearCombo.SelectedItem;
                bool result = InterDatabaseDataTransfer.TransferData(sourceYear.FilePath, targetDatabasePath);
                if (!result)
                {
                    deleteDatabaseFile(targetDatabasePath);
                    Cursor.Current = Cursors.Default;
                    return;
                }
            }

            string message = "The financial year " + startYear + "-" + (startYear + 1) +
                " was successfully created.";
            SystemSounds.Asterisk.Play();
            Cursor.Current = Cursors.Default;
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (Global.CurrentFinancialYear == null)
            {
                Global.CurrentFinancialYear = new FinancialYear(startYear, booksStartDate,
                    getDatabaseNameWithPath(startYear));
                this.MdiParent.Text = Global.AssemblyTitle + " (Financial Year: " + startYear + "-"
                    + (startYear + 1) + ")";
            }

            this.Close();
        }

        private bool isExists(int startYear)
        {
            FinancialYear fy = new FinancialYear(startYear, DateTime.Today, string.Empty);
            return financialYears.Contains(fy);
        }

        private bool CreateDatabase(int startYear, DateTime booksStartDate)
        {
            string connectionString = getConnectionString(startYear);

            try
            {
                using (SqlCeEngine engine = new SqlCeEngine(connectionString))
                {
                    engine.CreateDatabase();
                }
            }
            catch (Exception ex)
            {
                string message = "An error occurred in creating the database file for the new financial year." +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Creating Financial Year", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return createDatabaseStructure(connectionString, startYear, booksStartDate);
        }

        private string getConnectionString(int startYear)
        {
            //For including the locale id, see this post:
            //http://stackoverflow.com/questions/14956140/windows-xp-the-specified-locale-is-not-supported-on-this-operating-system-lci
           
            string connectionString = "Data Source = " + getDatabaseNameWithPath(startYear) + ";Password = " +
                Properties.Settings.Default.PASSWORD + "; LCID=1030";

            return connectionString;
        }

        private bool createDatabaseStructure(string connectionString, int startYear, DateTime booksStartDate)
        {
            try
            {
                using (SqlCeConnection connection = new SqlCeConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCeCommand command = connection.CreateCommand())
                    {
                        string[] commands = Properties.Resources.DatabaseScript.Split(new string[] { "GO" },
                            StringSplitOptions.RemoveEmptyEntries);
                        foreach (string commandText in commands)
                        {
                            command.CommandText = commandText;
                            command.ExecuteNonQuery();
                        }
                        //insert date into a table
                        command.CommandText = "Insert into FinancialYear Values(" + startYear + ", '" +
                            booksStartDate.ToString("yyyyMMdd") + "')";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "An error occurred in creating the database structure for the new financial year."
                    + "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Hand.Play();
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }

        private void okButton_EnabledChanged(object sender, EventArgs e)
        {
            if (okButton.Enabled)
            {
                okButton.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            }
            else
            {
                okButton.ForeColor = Color.Gray;
            }
        }

        private string getDatabaseNameWithPath(int startYear)
        {
            return Properties.Settings.Default.DatabasePath +
               "\\" + Global.ROOT_DATA_FOLDER +
               "\\" + Global.DATABASE_NAME_PREFIX + startYear + "-" + (startYear + 1) +
               "." + Global.DATABASE_FILE_EXTENSION;
        }

        private DateTime getMaxBooksStartDateForFinancialYear(int startYear)
        {
            DateTime yearEndDate = new DateTime(startYear + 1, 3, 31);
            DateTime today = DateTime.Today;

            if (yearEndDate.CompareTo(today) < 0)
            {
                return yearEndDate;
            }
            else
            {
                return today;
            }
        }

        private bool deleteDatabaseFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return true;
        }

        private bool createRootFolderIfNotExists()
        {
            string path = Properties.Settings.Default.DatabasePath;
            if (!Directory.Exists(path))
            {
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                string message = "The data location '" + path +
                    "' no longer exists. \nPlease select an existing location in the 'Configuration' window" +
                    ", and then create a financial year.";
                MessageBox.Show(message, "Database Location Not Valid", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return false;
            }

            path = path + Path.DirectorySeparatorChar + Global.ROOT_DATA_FOLDER;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    SystemSounds.Hand.Play();
                    Cursor.Current = Cursors.Default;
                    string message = "A folder couldn't be created under the folder '" +
                        Properties.Settings.Default.DatabasePath + "'. \nPlease ensure that you have sufficient "
                        + "privileges to run this application." + "\nIf you have administrative privileges, then"
                        + "relaunch the application by right-clicking on the application icon and choosing the option"
                        + " 'Run as administrator' from the context menu.";
                    MessageBox.Show(message, "Failed To Create Folder", MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                    return false;
                }
            }

            return true;
        }
    }
}