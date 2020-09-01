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
    internal sealed partial class BackupDatabase : Form
    {
        public BackupDatabase()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            FinancialYear financialYear = Global.CurrentFinancialYear;
            if (financialYear == null)
            {
                SystemSounds.Exclamation.Play();
                string message = "No Financial year to back up." +
                    "\nPlease open a financial year and then backup its database.";
                MessageBox.Show(message, "No Opened Financial Year", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            if (!GlobalMethods.closeCurrentlyOpenYear())
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            bool success = backupDatabase(financialYear);
            if (success)
            {
                SystemSounds.Asterisk.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show("The database was successfully backed up !!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //open the financial year irrespective of the result

            Global.CurrentFinancialYear = financialYear;
            this.MdiParent.Text = Global.AssemblyTitle + " (Financial Year: " +
                Global.CurrentFinancialYear.ToString() + ")";

            Properties.Settings.Default.LastBackupLocation = backupLocationField.Text;
            try
            {
                Properties.Settings.Default.Save();
            }
            catch (Exception ex) { ErrorLogger.LogError(ex); }

            Cursor.Current = Cursors.Default;
            this.Close();
        }

        private void BackupDatabase_Load(object sender, EventArgs e)
        {
            this.Icon = this.MdiParent.Icon;

            string location = Properties.Settings.Default.LastBackupLocation;
            if (!string.IsNullOrWhiteSpace(location) && Directory.Exists(location))
            {
                backupLocationField.Text = location;
            }
        }

        private void backupLocationField_TextChanged(object sender, EventArgs e)
        {
            string text = backupLocationField.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                okButton.Enabled = false;
                toolTip.SetToolTip(backupLocationField, string.Empty);
            }
            else
            {
                okButton.Enabled = true;
                toolTip.SetToolTip(backupLocationField, text);
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            string path = backupLocationField.Text;
            if (!string.IsNullOrWhiteSpace(path) && Directory.Exists(path))
            {
                folderBrowserDialog.SelectedPath = path;
            }
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.Description =
                "Select the folder where the backedup database file will be stored.";

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            backupLocationField.Text = folderBrowserDialog.SelectedPath;
        }

        private bool backupDatabase(FinancialYear financialYear)
        {
            string sourcePath = financialYear.FilePath;
            string destinationPath = backupLocationField.Text;
            destinationPath = destinationPath + "\\" + Global.AssemblyTitle + "-Backup-" +
                DateTime.Today.ToString("dd-MMM-yyyy");

            if (!createBackupFolder(destinationPath))
            {
                return false;
            }

            return copyDatabaseFile(financialYear.FilePath, destinationPath);
        }

        private bool createBackupFolder(string destinationPath)
        {
            if (Directory.Exists(destinationPath))
            {
                return true;
            }

            try
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(destinationPath);
            }
            catch (Exception ex)
            {
                string message = "An error occurred in creating a folder at the selected backup location."
                    + "\nPlease ensure that you have 'Write' permission to this folder, or select another"
                    + " folder and then try again.";
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Creating Folder", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }

        private bool copyDatabaseFile(string sourceFilePath, string destinationFolderPath)
        {
            FileInfo fileInfo = new FileInfo(sourceFilePath);
            string destinationFilePath = destinationFolderPath + "\\" + fileInfo.Name;

            try
            {
                File.Copy(sourceFilePath, destinationFilePath, true);
            }
            catch (Exception ex)
            {
                string message = "An error occurred in backing up the database to the selected folder."
                    + "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error in Copying File", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }
    }
}