using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bajaj.Dinesh.Biller
{
    internal sealed partial class RestoreDatabase : Form
    {
        public RestoreDatabase()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            string path = sourceLocationField.Text;
            if (!string.IsNullOrWhiteSpace(path) && Directory.Exists(path))
            {
                folderBrowserDialog.SelectedPath = path;
            }
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.Description =
                "Select the folder where the database will be restored from (source folder).";

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string destinationPath = Properties.Settings.Default.DatabasePath;
            string sourcePath = folderBrowserDialog.SelectedPath;

            if (!string.IsNullOrWhiteSpace(destinationPath) && destinationPath == sourcePath)
            {
                System.Media.SystemSounds.Exclamation.Play();
                string message = "Source folder and destination folder can't be same." +
                    "\nPlease select a different folder.";
                MessageBox.Show(message, "Invalid Folder Selection", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return;
            }

            sourceLocationField.Text = sourcePath;
        }

        private void sourceLocationField_TextChanged(object sender, EventArgs e)
        {
            availableDatabasesListBox.Items.Clear();
            string text = sourceLocationField.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                toolTip.SetToolTip(sourceLocationField, string.Empty);

                return;
            }

            toolTip.SetToolTip(sourceLocationField, text);

            List<FinancialYear> years = GlobalMethods.GetFinancialYears(text);

            if (years == null || years.Count == 0)
            {
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("No database in the selected location.", "No Source Database",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            availableDatabasesListBox.Items.AddRange(years.ToArray());
            availableDatabasesListBox.SelectedIndex = 0;
            availableDatabasesListBox.Focus();
        }

        private void availableDatabasesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = availableDatabasesListBox.SelectedIndex;
            okButton.Enabled = selectedIndex >= 0 ? true : false;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            FinancialYear sourceYear = (FinancialYear)availableDatabasesListBox.SelectedItem;

            FinancialYear currentYear = Global.CurrentFinancialYear;
            if (currentYear != null && currentYear.Equals(sourceYear))
            {
                if (!GlobalMethods.closeCurrentlyOpenYear())
                {
                    return;
                }
            }

            Cursor.Current = Cursors.WaitCursor;

            if (!restoreDatabase(sourceYear.FilePath))
            {
                return;
            }

            System.Media.SystemSounds.Asterisk.Play();
            Cursor.Current = Cursors.Default;
            MessageBox.Show("The database was successfully restored !!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (currentYear != null)
            {
                Global.CurrentFinancialYear = currentYear;
                this.MdiParent.Text = Global.AssemblyTitle + " (Financial Year: " +
                Global.CurrentFinancialYear.ToString() + ")";
            }

            this.Close();
        }

        private bool restoreDatabase(string sourcePath)
        {
            FileInfo fileInfo = new FileInfo(sourcePath);

            string destinationPath = Properties.Settings.Default.DatabasePath + "\\" +
                Global.ROOT_DATA_FOLDER + "\\" + fileInfo.Name;

            try
            {
                File.Copy(sourcePath, destinationPath, true);
            }
            catch (Exception ex)
            {
                string message = "An error occurred in restoring the database." +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                System.Media.SystemSounds.Hand.Play();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }

        private void RestoreDatabase_Load(object sender, EventArgs e)
        {
            this.Icon = this.MdiParent.Icon;
        }
    }
}