namespace Bajaj.Dinesh.Biller
{
    partial class BillView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.resultGroupBox = new System.Windows.Forms.GroupBox();
            this.invoiceSummaryPanel = new System.Windows.Forms.Panel();
            this.invoiceTotalField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.invoiceCountField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.deleteInvoiceButton = new System.Windows.Forms.Button();
            this.printInvoiceButton = new System.Windows.Forms.Button();
            this.editInvoiceButton = new System.Windows.Forms.Button();
            this.invoicesGrid = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchInvoiceButton = new System.Windows.Forms.Button();
            this.advancedCriteriaButton = new System.Windows.Forms.Button();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.resultGroupBox.SuspendLayout();
            this.invoiceSummaryPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoicesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultGroupBox
            // 
            this.resultGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultGroupBox.Controls.Add(this.invoiceSummaryPanel);
            this.resultGroupBox.Controls.Add(this.panel1);
            this.resultGroupBox.Controls.Add(this.invoicesGrid);
            this.resultGroupBox.Location = new System.Drawing.Point(12, 153);
            this.resultGroupBox.Name = "resultGroupBox";
            this.resultGroupBox.Size = new System.Drawing.Size(692, 253);
            this.resultGroupBox.TabIndex = 1;
            this.resultGroupBox.TabStop = false;
            this.resultGroupBox.Text = "Found Invoices";
            this.resultGroupBox.Visible = false;
            // 
            // invoiceSummaryPanel
            // 
            this.invoiceSummaryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invoiceSummaryPanel.Controls.Add(this.invoiceTotalField);
            this.invoiceSummaryPanel.Controls.Add(this.label5);
            this.invoiceSummaryPanel.Controls.Add(this.invoiceCountField);
            this.invoiceSummaryPanel.Controls.Add(this.label4);
            this.invoiceSummaryPanel.Location = new System.Drawing.Point(12, 215);
            this.invoiceSummaryPanel.Name = "invoiceSummaryPanel";
            this.invoiceSummaryPanel.Size = new System.Drawing.Size(541, 32);
            this.invoiceSummaryPanel.TabIndex = 2;
            // 
            // invoiceTotalField
            // 
            this.invoiceTotalField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceTotalField.Location = new System.Drawing.Point(314, 5);
            this.invoiceTotalField.Name = "invoiceTotalField";
            this.invoiceTotalField.ReadOnly = true;
            this.invoiceTotalField.Size = new System.Drawing.Size(155, 20);
            this.invoiceTotalField.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(191, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Invoice Total (Rs.):";
            // 
            // invoiceCountField
            // 
            this.invoiceCountField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceCountField.Location = new System.Drawing.Point(99, 5);
            this.invoiceCountField.Name = "invoiceCountField";
            this.invoiceCountField.ReadOnly = true;
            this.invoiceCountField.Size = new System.Drawing.Size(56, 20);
            this.invoiceCountField.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Invoice Count:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.deleteInvoiceButton);
            this.panel1.Controls.Add(this.printInvoiceButton);
            this.panel1.Controls.Add(this.editInvoiceButton);
            this.panel1.Location = new System.Drawing.Point(577, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(112, 229);
            this.panel1.TabIndex = 1;
            // 
            // deleteInvoiceButton
            // 
            this.deleteInvoiceButton.Enabled = false;
            this.deleteInvoiceButton.Location = new System.Drawing.Point(3, 64);
            this.deleteInvoiceButton.Name = "deleteInvoiceButton";
            this.deleteInvoiceButton.Size = new System.Drawing.Size(106, 23);
            this.deleteInvoiceButton.TabIndex = 2;
            this.deleteInvoiceButton.Text = "Delete &Invoice";
            this.deleteInvoiceButton.UseVisualStyleBackColor = true;
            this.deleteInvoiceButton.Click += new System.EventHandler(this.deleteInvoiceButton_Click);
            // 
            // printInvoiceButton
            // 
            this.printInvoiceButton.Enabled = false;
            this.printInvoiceButton.Location = new System.Drawing.Point(3, 35);
            this.printInvoiceButton.Name = "printInvoiceButton";
            this.printInvoiceButton.Size = new System.Drawing.Size(106, 23);
            this.printInvoiceButton.TabIndex = 1;
            this.printInvoiceButton.Text = "&Print Invoice...";
            this.printInvoiceButton.UseVisualStyleBackColor = true;
            this.printInvoiceButton.Click += new System.EventHandler(this.printInvoiceButton_Click);
            // 
            // editInvoiceButton
            // 
            this.editInvoiceButton.Enabled = false;
            this.editInvoiceButton.Location = new System.Drawing.Point(3, 6);
            this.editInvoiceButton.Name = "editInvoiceButton";
            this.editInvoiceButton.Size = new System.Drawing.Size(106, 23);
            this.editInvoiceButton.TabIndex = 0;
            this.editInvoiceButton.Text = "E&dit Invoice...";
            this.editInvoiceButton.UseVisualStyleBackColor = true;
            this.editInvoiceButton.Click += new System.EventHandler(this.editInvoiceButton_Click);
            // 
            // invoicesGrid
            // 
            this.invoicesGrid.AllowUserToAddRows = false;
            this.invoicesGrid.AllowUserToDeleteRows = false;
            this.invoicesGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.invoicesGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.invoicesGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invoicesGrid.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.invoicesGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.invoicesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.invoicesGrid.Location = new System.Drawing.Point(12, 17);
            this.invoicesGrid.MultiSelect = false;
            this.invoicesGrid.Name = "invoicesGrid";
            this.invoicesGrid.ReadOnly = true;
            this.invoicesGrid.RowHeadersVisible = false;
            this.invoicesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.invoicesGrid.ShowCellErrors = false;
            this.invoicesGrid.ShowCellToolTips = false;
            this.invoicesGrid.ShowEditingIcon = false;
            this.invoicesGrid.ShowRowErrors = false;
            this.invoicesGrid.Size = new System.Drawing.Size(562, 197);
            this.invoicesGrid.TabIndex = 0;
            this.invoicesGrid.SelectionChanged += new System.EventHandler(this.invoicesGrid_SelectionChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchInvoiceButton);
            this.groupBox1.Controls.Add(this.advancedCriteriaButton);
            this.groupBox1.Controls.Add(this.endDatePicker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.startDatePicker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bill Selection Criteria";
            // 
            // searchInvoiceButton
            // 
            this.searchInvoiceButton.Image = global::Bajaj.Dinesh.Biller.Properties.Resources.search_16;
            this.searchInvoiceButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchInvoiceButton.Location = new System.Drawing.Point(383, 98);
            this.searchInvoiceButton.Name = "searchInvoiceButton";
            this.searchInvoiceButton.Size = new System.Drawing.Size(123, 23);
            this.searchInvoiceButton.TabIndex = 5;
            this.searchInvoiceButton.Text = "&Search Invoices";
            this.searchInvoiceButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchInvoiceButton.UseVisualStyleBackColor = true;
            this.searchInvoiceButton.Click += new System.EventHandler(this.findInvoicesButton_Click);
            // 
            // advancedCriteriaButton
            // 
            this.advancedCriteriaButton.Location = new System.Drawing.Point(17, 65);
            this.advancedCriteriaButton.Name = "advancedCriteriaButton";
            this.advancedCriteriaButton.Size = new System.Drawing.Size(138, 23);
            this.advancedCriteriaButton.TabIndex = 4;
            this.advancedCriteriaButton.Text = "&Advanced Criteria...";
            this.advancedCriteriaButton.UseVisualStyleBackColor = true;
            this.advancedCriteriaButton.Click += new System.EventHandler(this.advancedCriteriaButton_Click);
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(343, 33);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(163, 21);
            this.endDatePicker.TabIndex = 3;
            this.endDatePicker.ValueChanged += new System.EventHandler(this.endDatePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "&End Date:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(84, 31);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(163, 21);
            this.startDatePicker.TabIndex = 1;
            this.startDatePicker.ValueChanged += new System.EventHandler(this.startDatePicker_ValueChanged);
            this.startDatePicker.Validating += new System.ComponentModel.CancelEventHandler(this.startDatePicker_Validating);
            this.startDatePicker.Validated += new System.EventHandler(this.startDatePicker_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Start Date:";
            // 
            // BillView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(715, 409);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resultGroupBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BillView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BillView_FormClosing);
            this.Load += new System.EventHandler(this.BillView_Load);
            this.resultGroupBox.ResumeLayout(false);
            this.invoiceSummaryPanel.ResumeLayout(false);
            this.invoiceSummaryPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.invoicesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox resultGroupBox;
        private System.Windows.Forms.DataGridView invoicesGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button deleteInvoiceButton;
        private System.Windows.Forms.Button printInvoiceButton;
        private System.Windows.Forms.Button editInvoiceButton;
        private System.Windows.Forms.Panel invoiceSummaryPanel;
        private System.Windows.Forms.TextBox invoiceTotalField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox invoiceCountField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button advancedCriteriaButton;
        private System.Windows.Forms.Button searchInvoiceButton;

    }
}