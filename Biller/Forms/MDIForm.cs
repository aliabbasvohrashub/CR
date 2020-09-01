using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bajaj.Dinesh.Biller.Properties;

namespace Bajaj.Dinesh.Biller
{
    internal sealed partial class MDIForm : Form
    {
        public MDIForm()
        {
            InitializeComponent();
            this.Text = Global.AssemblyTitle;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void firmDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(FirmDetails));
        }

        private void MDIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.CurrentFinancialYear != null)
            {
                Properties.Settings.Default.LastlyOpenedFYPath = Global.CurrentFinancialYear.FilePath;
            }

            if (this.WindowState != FormWindowState.Minimized)
            {
                Properties.Settings.Default.LastMDIWindowState = this.WindowState;
            }

            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.LastMDIFormSize = this.Size;
            }

            try
            {
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex);
            }

            Global.CloseDatabaseConnection();
        }

        private void unitsOfMeasurementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(UnitOfMeasurement));
        }

        private void itemsMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(ItemMaster));
        }

        private void masterFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(CustomerMaster));
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(AccountBalanceList));
        }

        private void makeBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(BillMaster));
        }

        private void viewBillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(BillView));
        }

        private void receivePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(PaymentReceive));
        }

        private void viewPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(PaymentView));
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void MDIForm_Load(object sender, EventArgs e)
        {
            this.WindowState = Properties.Settings.Default.LastMDIWindowState;
            if (Properties.Settings.Default.LastMDIWindowState == FormWindowState.Normal)
            {
                Size lastSize = Properties.Settings.Default.LastMDIFormSize;
                if (!lastSize.IsEmpty)
                {
                    this.Size = Properties.Settings.Default.LastMDIFormSize;
                }
            }

            string filePath = Properties.Settings.Default.LastlyOpenedFYPath;
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                if (File.Exists(filePath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (fileInfo.Directory.Parent.FullName.Equals(Properties.Settings.Default.DatabasePath))
                    {
                        FinancialYear financialYear = GlobalMethods.getFinancialYear(filePath);
                        if (financialYear != null)
                        {
                            Global.CurrentFinancialYear = financialYear;
                            this.Text = Global.AssemblyTitle + " (Financial Year: " +
                                        financialYear.ToString() + ")";
                        }
                    }
                }
            }
        }

        private void MDIForm_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Biller.Properties.Settings.Default.DatabasePath))
            {
                string message = "To get started with the application, please specify the database location " +
                    "i.e. the directory path where the data files will be saved and opened from.";

                MessageBox.Show(message, "Database Location", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showForm(typeof(Configuration));
            }
        }

        private void configurationButton_Click(object sender, EventArgs e)
        {
            showForm(typeof(Configuration));
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            showForm(typeof(ItemMaster));
        }

        private void customerMasterButton_Click(object sender, EventArgs e)
        {
            showForm(typeof(CustomerMaster));
        }

        private void addInvoiceButton_Click(object sender, EventArgs e)
        {
            showForm(typeof(BillMaster));
        }

        private void addPaymentButton_Click(object sender, EventArgs e)
        {
            showForm(typeof(PaymentReceive));
        }

        private void customerAccountButton_Click(object sender, EventArgs e)
        {
            showForm(typeof(CustomerAccount));
        }

        private void viewInvoiceButton_Click(object sender, EventArgs e)
        {
            showForm(typeof(BillView));
        }

        private void calculatorButton_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe");
            //p.WaitForInputIdle();
            //NativeMethods.SetParent(p.MainWindowHandle, this.Handle);

            System.Diagnostics.Process.Start("calc.exe");
        }

        private void backupButton_Click(object sender, EventArgs e)
        {
            showForm(typeof(BackupDatabase));
        }

        private void createFinancialYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(CreateFinancialYear));
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            bool enableState = Global.CurrentFinancialYear == null ? false : true;

            closeFinancialYearToolStripMenuItem.Enabled = enableState;
            firmDetailsToolStripMenuItem.Enabled = enableState;
            unitsOfMeasurementToolStripMenuItem.Enabled = enableState;
            itemsMasterToolStripMenuItem.Enabled = enableState;

            enableState = string.IsNullOrWhiteSpace(Properties.Settings.Default.DatabasePath) ? false : true;
            deleteFinancialYearToolStripMenuItem.Enabled = enableState;
            openFinancialYearToolStripMenuItem.Enabled = enableState;
        }

        private void customersToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            bool enableState = Global.CurrentFinancialYear == null ? false : true;
            masterFormToolStripMenuItem.Enabled = enableState;
            accountStatementToolStripMenuItem.Enabled = enableState;
            accountsToolStripMenuItem.Enabled = enableState;
        }

        private void billToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            bool enableState = Global.CurrentFinancialYear == null ? false : true;

            makeBillToolStripMenuItem.Enabled = enableState;
            viewBillsToolStripMenuItem.Enabled = enableState;
        }

        private void paymentsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            bool enableState = Global.CurrentFinancialYear == null ? false : true;

            receivePaymentToolStripMenuItem.Enabled = enableState;
            viewPaymentsToolStripMenuItem.Enabled = enableState;
        }

        private void maintenanceToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            bool enableState = Global.CurrentFinancialYear == null ? false : true;

            backupDatabaseToolStripMenuItem.Enabled = enableState;
            compactDatbaseToolStripMenuItem.Enabled = enableState;
        }

        private void closeFinancialYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalMethods.closeCurrentlyOpenYear();
        }

        private void openFinancialYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(OpenFinancialYear));
        }

        private void deleteFinancialYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(DeleteFinancialYear));
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(BackupDatabase));
        }

        internal void showForm(Type formType)
        {
            Cursor.Current = Cursors.WaitCursor;

            string[] duplicateFormNames = new string[] { typeof(BillMaster).Name, typeof(PaymentReceive).Name };
            string typeName = formType.Name;

            if (duplicateFormNames.Contains(typeName))
            {
                Form form = (Form)Activator.CreateInstance(formType);
                form.MdiParent = this;
                form.Show();
                Cursor.Current = Cursors.Default;
                return;
            }

            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType().Equals(formType))
                {
                    try
                    {
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                        form.BringToFront();
                        form.Activate();
                    }
                    catch (Exception)
                    {
                        // do nothing
                    }

                    Cursor.Current = Cursors.Default;
                    return;
                }
            }

            Form formInstance = (Form)Activator.CreateInstance(formType);
            formInstance.MdiParent = this;
            formInstance.Show();
            Cursor.Current = Cursors.Default;
        }

        private void configurationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showForm(typeof(Configuration));
        }

        private void compactDatbaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Compacting the database will discard the unused space occupied by it."
                + "\nAny open window associated with the currently opened financial year " +
                "will be closed prior to compacting it. OK?";
            System.Media.SystemSounds.Question.Play();
            DialogResult result = MessageBox.Show(message, "Confirm Action", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            FinancialYear financialYear = Global.CurrentFinancialYear;
            GlobalMethods.closeCurrentlyOpenYear();

            bool returnValue = GlobalMethods.ShrinkDatabase(financialYear.FilePath);
            if (returnValue)
            {
                System.Media.SystemSounds.Asterisk.Play();
                message = "The database was successfully compacted !!";
                Cursor.Current = Cursors.Default;
                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Global.CurrentFinancialYear = financialYear;
            this.Text = Global.AssemblyTitle + " (Financial Year: " +
               Global.CurrentFinancialYear.ToString() + ")";
        }

        private void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(RestoreDatabase));
        }

        private void accountStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(CustomerAccount));
        }

        private void aboutBillerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(typeof(About));
        }
    }
}