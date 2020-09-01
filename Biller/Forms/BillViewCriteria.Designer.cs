namespace Bajaj.Dinesh.Biller
{
    partial class BillViewCriteria
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
            this.criteriaGroup = new System.Windows.Forms.GroupBox();
            this.additionalCriterialGroupBox = new System.Windows.Forms.GroupBox();
            this.paymentModePanel = new System.Windows.Forms.Panel();
            this.creditButton = new System.Windows.Forms.CheckBox();
            this.cashButton = new System.Windows.Forms.CheckBox();
            this.customerCombo = new System.Windows.Forms.ComboBox();
            this.customerButton = new System.Windows.Forms.RadioButton();
            this.paymentTypeButton = new System.Windows.Forms.RadioButton();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.findbyDateButton = new System.Windows.Forms.RadioButton();
            this.invoiceNumberField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.findByInvoiceNumberButton = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.criteriaGroup.SuspendLayout();
            this.additionalCriterialGroupBox.SuspendLayout();
            this.paymentModePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // criteriaGroup
            // 
            this.criteriaGroup.Controls.Add(this.additionalCriterialGroupBox);
            this.criteriaGroup.Controls.Add(this.endDatePicker);
            this.criteriaGroup.Controls.Add(this.label3);
            this.criteriaGroup.Controls.Add(this.startDatePicker);
            this.criteriaGroup.Controls.Add(this.label2);
            this.criteriaGroup.Controls.Add(this.findbyDateButton);
            this.criteriaGroup.Controls.Add(this.invoiceNumberField);
            this.criteriaGroup.Controls.Add(this.label1);
            this.criteriaGroup.Controls.Add(this.findByInvoiceNumberButton);
            this.criteriaGroup.Location = new System.Drawing.Point(14, 14);
            this.criteriaGroup.Name = "criteriaGroup";
            this.criteriaGroup.Size = new System.Drawing.Size(555, 265);
            this.criteriaGroup.TabIndex = 0;
            this.criteriaGroup.TabStop = false;
            this.criteriaGroup.Text = "Invoice Search Criteria";
            // 
            // additionalCriterialGroupBox
            // 
            this.additionalCriterialGroupBox.Controls.Add(this.paymentModePanel);
            this.additionalCriterialGroupBox.Controls.Add(this.customerCombo);
            this.additionalCriterialGroupBox.Controls.Add(this.customerButton);
            this.additionalCriterialGroupBox.Controls.Add(this.paymentTypeButton);
            this.additionalCriterialGroupBox.ForeColor = System.Drawing.Color.Indigo;
            this.additionalCriterialGroupBox.Location = new System.Drawing.Point(68, 73);
            this.additionalCriterialGroupBox.Name = "additionalCriterialGroupBox";
            this.additionalCriterialGroupBox.Size = new System.Drawing.Size(444, 134);
            this.additionalCriterialGroupBox.TabIndex = 5;
            this.additionalCriterialGroupBox.TabStop = false;
            this.additionalCriterialGroupBox.Text = "Additional Criteria";
            // 
            // paymentModePanel
            // 
            this.paymentModePanel.Controls.Add(this.creditButton);
            this.paymentModePanel.Controls.Add(this.cashButton);
            this.paymentModePanel.Location = new System.Drawing.Point(62, 42);
            this.paymentModePanel.Name = "paymentModePanel";
            this.paymentModePanel.Size = new System.Drawing.Size(143, 31);
            this.paymentModePanel.TabIndex = 0;
            this.paymentModePanel.Validating += new System.ComponentModel.CancelEventHandler(this.paymentModePanel_Validating);
            this.paymentModePanel.Validated += new System.EventHandler(this.paymentModePanel_Validated);
            // 
            // creditButton
            // 
            this.creditButton.Checked = true;
            this.creditButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.creditButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.creditButton.Location = new System.Drawing.Point(71, 9);
            this.creditButton.Name = "creditButton";
            this.creditButton.Size = new System.Drawing.Size(58, 19);
            this.creditButton.TabIndex = 1;
            this.creditButton.Text = "Credit";
            this.creditButton.UseVisualStyleBackColor = true;
            // 
            // cashButton
            // 
            this.cashButton.AutoSize = true;
            this.cashButton.Checked = true;
            this.cashButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cashButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cashButton.Location = new System.Drawing.Point(11, 9);
            this.cashButton.Name = "cashButton";
            this.cashButton.Size = new System.Drawing.Size(54, 19);
            this.cashButton.TabIndex = 0;
            this.cashButton.Text = "Cash";
            this.cashButton.UseVisualStyleBackColor = true;
            // 
            // customerCombo
            // 
            this.customerCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.customerCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.customerCombo.Enabled = false;
            this.customerCombo.FormattingEnabled = true;
            this.customerCombo.Location = new System.Drawing.Point(49, 105);
            this.customerCombo.Name = "customerCombo";
            this.customerCombo.Size = new System.Drawing.Size(365, 23);
            this.customerCombo.TabIndex = 2;
            this.customerCombo.Validating += new System.ComponentModel.CancelEventHandler(this.customerCombo_Validating);
            this.customerCombo.Validated += new System.EventHandler(this.customerCombo_Validated);
            // 
            // customerButton
            // 
            this.customerButton.AutoSize = true;
            this.customerButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.customerButton.Location = new System.Drawing.Point(25, 80);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(69, 17);
            this.customerButton.TabIndex = 1;
            this.customerButton.TabStop = true;
            this.customerButton.Text = "&Customer";
            this.customerButton.UseVisualStyleBackColor = true;
            this.customerButton.CheckedChanged += new System.EventHandler(this.customerButton_CheckedChanged);
            // 
            // paymentTypeButton
            // 
            this.paymentTypeButton.AutoSize = true;
            this.paymentTypeButton.Checked = true;
            this.paymentTypeButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.paymentTypeButton.Location = new System.Drawing.Point(27, 20);
            this.paymentTypeButton.Name = "paymentTypeButton";
            this.paymentTypeButton.Size = new System.Drawing.Size(87, 17);
            this.paymentTypeButton.TabIndex = 0;
            this.paymentTypeButton.TabStop = true;
            this.paymentTypeButton.Text = "&Invoice Type";
            this.paymentTypeButton.UseVisualStyleBackColor = true;
            this.paymentTypeButton.CheckedChanged += new System.EventHandler(this.paymentTypeButton_CheckedChanged);
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(387, 44);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(159, 21);
            this.endDatePicker.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "&End Date:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(131, 44);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(159, 21);
            this.startDatePicker.TabIndex = 2;
            this.startDatePicker.Validating += new System.ComponentModel.CancelEventHandler(this.startDatePicker_Validating);
            this.startDatePicker.Validated += new System.EventHandler(this.startDatePicker_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "&Start Date:";
            // 
            // findbyDateButton
            // 
            this.findbyDateButton.AutoSize = true;
            this.findbyDateButton.Checked = true;
            this.findbyDateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findbyDateButton.ForeColor = System.Drawing.Color.Blue;
            this.findbyDateButton.Location = new System.Drawing.Point(20, 22);
            this.findbyDateButton.Name = "findbyDateButton";
            this.findbyDateButton.Size = new System.Drawing.Size(141, 17);
            this.findbyDateButton.TabIndex = 0;
            this.findbyDateButton.TabStop = true;
            this.findbyDateButton.Text = "&Find by Invoice date";
            this.findbyDateButton.UseVisualStyleBackColor = true;
            this.findbyDateButton.CheckedChanged += new System.EventHandler(this.findbyDateButton_CheckedChanged);
            // 
            // invoiceNumberField
            // 
            this.invoiceNumberField.Enabled = false;
            this.invoiceNumberField.Location = new System.Drawing.Point(153, 236);
            this.invoiceNumberField.Name = "invoiceNumberField";
            this.invoiceNumberField.Size = new System.Drawing.Size(120, 21);
            this.invoiceNumberField.TabIndex = 8;
            this.invoiceNumberField.Validating += new System.ComponentModel.CancelEventHandler(this.invoiceNumberField_Validating);
            this.invoiceNumberField.Validated += new System.EventHandler(this.invoiceNumberField_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Invoice Number:";
            // 
            // findByInvoiceNumberButton
            // 
            this.findByInvoiceNumberButton.AutoSize = true;
            this.findByInvoiceNumberButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findByInvoiceNumberButton.ForeColor = System.Drawing.Color.Blue;
            this.findByInvoiceNumberButton.Location = new System.Drawing.Point(17, 213);
            this.findByInvoiceNumberButton.Name = "findByInvoiceNumberButton";
            this.findByInvoiceNumberButton.Size = new System.Drawing.Size(156, 17);
            this.findByInvoiceNumberButton.TabIndex = 6;
            this.findByInvoiceNumberButton.TabStop = true;
            this.findByInvoiceNumberButton.Text = "Fi&nd by invoice number";
            this.findByInvoiceNumberButton.UseVisualStyleBackColor = true;
            this.findByInvoiceNumberButton.CheckedChanged += new System.EventHandler(this.findByInvoiceNumberButton_CheckedChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(485, 285);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 27);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "C&ancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(371, 285);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(87, 27);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // BillViewCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(584, 318);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.criteriaGroup);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BillViewCriteria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bill Selection Criteria (Advanced)";
            this.Load += new System.EventHandler(this.BillViewCriteria_Load);
            this.criteriaGroup.ResumeLayout(false);
            this.criteriaGroup.PerformLayout();
            this.additionalCriterialGroupBox.ResumeLayout(false);
            this.additionalCriterialGroupBox.PerformLayout();
            this.paymentModePanel.ResumeLayout(false);
            this.paymentModePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox criteriaGroup;
        private System.Windows.Forms.GroupBox additionalCriterialGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker endDatePicker;
        internal System.Windows.Forms.DateTimePicker startDatePicker;
        internal System.Windows.Forms.RadioButton findbyDateButton;
        internal System.Windows.Forms.RadioButton findByInvoiceNumberButton;
        internal System.Windows.Forms.ComboBox customerCombo;
        internal System.Windows.Forms.RadioButton customerButton;
        internal System.Windows.Forms.RadioButton paymentTypeButton;
        internal System.Windows.Forms.TextBox invoiceNumberField;
        internal System.Windows.Forms.Button cancelButton;
        internal System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel paymentModePanel;
        internal System.Windows.Forms.CheckBox creditButton;
        internal System.Windows.Forms.CheckBox cashButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}