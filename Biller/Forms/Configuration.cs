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
using Bajaj.Dinesh.Biller.Properties;

namespace Bajaj.Dinesh.Biller
{
    internal sealed partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            this.Icon = this.MdiParent.Icon;

            label3.Text = "(The application shall store the data files in a folder named '" +
                Global.ROOT_DATA_FOLDER + "' under this folder)";

            string path = Properties.Settings.Default.DatabasePath;
            if (!string.IsNullOrWhiteSpace(path) && Directory.Exists(path))
            {
                databasePathField.Text = path;
                databasePathField.Tag = path;
                toolTip1.SetToolTip(databasePathField, path);
            }
            if (Properties.Settings.Default.PrintDirectlyToPrinter)
            {
                printDirectlyButton.Checked = true;
            }

            if (Properties.Settings.Default.PrintFirmName)
            {
                printFirmNameButton.Checked = true;
                if (Properties.Settings.Default.PrintFirmAddress)
                {
                    printFirmAddressButton.Checked = true;
                }
            }
        }

        private void changeDatabaseLocationButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            string path = databasePathField.Text;
            if (Directory.Exists(path))
            {
                folderBrowserDialog.SelectedPath = path;
            }
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.Description = "Select the folder where the data files will be stored.";

            while (true)
            {
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                if (path.Equals(folderBrowserDialog.SelectedPath))
                {
                    string message = "The existing path and the new path are same. Do you want to keep the same path?";
                    DialogResult response = MessageBox.Show(message, "Confirm Selection",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (response == System.Windows.Forms.DialogResult.Yes)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            databasePathField.Text = folderBrowserDialog.SelectedPath;
            toolTip1.SetToolTip(databasePathField, databasePathField.Text);
        }

        private void databasePathField_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(databasePathField.Text))
            {
                errorProvider.SetError(databasePathField, "Database location not specified");
                e.Cancel = true;
            }
        }

        private void databasePathField_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(databasePathField, string.Empty);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren(ValidationConstraints.Enabled))
            {
                System.Media.SystemSounds.Exclamation.Play();
                return;
            }

            Settings.Default.DatabasePath = databasePathField.Text;
            Settings.Default.PrintDirectlyToPrinter = printDirectlyButton.Checked;
            Settings.Default.PrintFirmName = printFirmNameButton.Checked;
            Settings.Default.PrintFirmAddress = printFirmAddressButton.Checked;

            if (!createDataRootFolderIfRequired(databasePathField.Text))
            {
                return;
            }

            try
            {
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                string message = "An error occurred in saving the settings." +
                    "\nThe error text is as follows: \n" + Global.getExceptionText(ex);
                SystemSounds.Hand.Play();
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return;
            }

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printFirmNameButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!printFirmNameButton.Checked)
            {
                printFirmAddressButton.Checked = false;
                printFirmAddressButton.Enabled = false;
            }
            else
            {
                printFirmAddressButton.Enabled = true;
            }
        }

        private bool createDataRootFolderIfRequired(string folderPath)
        {
            folderPath = folderPath + "\\" + Global.ROOT_DATA_FOLDER;

            if (Directory.Exists(folderPath))
            {
                return true;
            }

            try
            {
                DirectoryInfo dirInfo = Directory.CreateDirectory(folderPath);
                if (dirInfo == null)
                {
                    throw new ApplicationException("An unknown error occurred in creating the folder.");
                }
            }
            catch (Exception ex)
            {
                string message = "An error occurred in creating a folder under the selected folder." +
                    "\nThe error text is as follows:\n" + Global.getExceptionText(ex);
                SystemSounds.Hand.Play();
                MessageBox.Show(message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLogger.LogError(ex);
                return false;
            }

            return true;
        }
    }
}