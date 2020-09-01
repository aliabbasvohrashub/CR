namespace Bajaj.Dinesh.Biller
{
    partial class PaymentView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.criteriaGroupBox = new System.Windows.Forms.GroupBox();
            this.paymentModePanel = new System.Windows.Forms.Panel();
            this.demandDraftButton = new System.Windows.Forms.CheckBox();
            this.chequeButton = new System.Windows.Forms.CheckBox();
            this.cashButton = new System.Windows.Forms.CheckBox();
            this.findPaymentsButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.customerButton = new System.Windows.Forms.CheckBox();
            this.paymentModeButton = new System.Windows.Forms.CheckBox();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.betweenDatesButton = new System.Windows.Forms.CheckBox();
            this.resultsGroupBox = new System.Windows.Forms.GroupBox();
            this.summaryPanel = new System.Windows.Forms.Panel();
            this.paymentTotalField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.paymentCountField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.paymentsGrid = new System.Windows.Forms.DataGridView();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.PaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstrumentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.criteriaGroupBox.SuspendLayout();
            this.paymentModePanel.SuspendLayout();
            this.resultsGroupBox.SuspendLayout();
            this.summaryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentsGrid)).BeginInit();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // criteriaGroupBox
            // 
            this.criteriaGroupBox.Controls.Add(this.paymentModePanel);
            this.criteriaGroupBox.Controls.Add(this.findPaymentsButton);
            this.criteriaGroupBox.Controls.Add(this.label3);
            this.criteriaGroupBox.Controls.Add(this.customerComboBox);
            this.criteriaGroupBox.Controls.Add(this.customerButton);
            this.criteriaGroupBox.Controls.Add(this.paymentModeButton);
            this.criteriaGroupBox.Controls.Add(this.endDatePicker);
            this.criteriaGroupBox.Controls.Add(this.label2);
            this.criteriaGroupBox.Controls.Add(this.startDatePicker);
            this.criteriaGroupBox.Controls.Add(this.label1);
            this.criteriaGroupBox.Controls.Add(this.betweenDatesButton);
            this.criteriaGroupBox.Location = new System.Drawing.Point(15, 8);
            this.criteriaGroupBox.Name = "criteriaGroupBox";
            this.criteriaGroupBox.Size = new System.Drawing.Size(626, 192);
            this.criteriaGroupBox.TabIndex = 0;
            this.criteriaGroupBox.TabStop = false;
            this.criteriaGroupBox.Text = "Payment Search Criteria:";
            // 
            // paymentModePanel
            // 
            this.paymentModePanel.Controls.Add(this.demandDraftButton);
            this.paymentModePanel.Controls.Add(this.chequeButton);
            this.paymentModePanel.Controls.Add(this.cashButton);
            this.paymentModePanel.Enabled = false;
            this.paymentModePanel.Location = new System.Drawing.Point(51, 91);
            this.paymentModePanel.Name = "paymentModePanel";
            this.paymentModePanel.Size = new System.Drawing.Size(328, 29);
            this.paymentModePanel.TabIndex = 6;
            this.paymentModePanel.Validating += new System.ComponentModel.CancelEventHandler(this.paymentModePanel_Validating);
            this.paymentModePanel.Validated += new System.EventHandler(this.paymentModePanel_Validated);
            // 
            // demandDraftButton
            // 
            this.demandDraftButton.AutoSize = true;
            this.demandDraftButton.Location = new System.Drawing.Point(191, 4);
            this.demandDraftButton.Name = "demandDraftButton";
            this.demandDraftButton.Size = new System.Drawing.Size(103, 19);
            this.demandDraftButton.TabIndex = 2;
            this.demandDraftButton.Text = "De&mand Draft";
            this.demandDraftButton.UseVisualStyleBackColor = true;
            this.demandDraftButton.CheckedChanged += new System.EventHandler(this.demandDraftButton_CheckedChanged);
            // 
            // chequeButton
            // 
            this.chequeButton.AutoSize = true;
            this.chequeButton.Location = new System.Drawing.Point(99, 4);
            this.chequeButton.Name = "chequeButton";
            this.chequeButton.Size = new System.Drawing.Size(69, 19);
            this.chequeButton.TabIndex = 1;
            this.chequeButton.Text = "C&heque";
            this.chequeButton.UseVisualStyleBackColor = true;
            this.chequeButton.CheckedChanged += new System.EventHandler(this.chequeButton_CheckedChanged);
            // 
            // cashButton
            // 
            this.cashButton.AutoSize = true;
            this.cashButton.Location = new System.Drawing.Point(28, 4);
            this.cashButton.Name = "cashButton";
            this.cashButton.Size = new System.Drawing.Size(54, 19);
            this.cashButton.TabIndex = 0;
            this.cashButton.Text = "C&ash";
            this.cashButton.UseVisualStyleBackColor = true;
            this.cashButton.CheckedChanged += new System.EventHandler(this.cashButton_CheckedChanged);
            // 
            // findPaymentsButton
            // 
            this.findPaymentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findPaymentsButton.Image = global::Bajaj.Dinesh.Biller.Properties.Resources.search_16;
            this.findPaymentsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.findPaymentsButton.Location = new System.Drawing.Point(486, 156);
            this.findPaymentsButton.Name = "findPaymentsButton";
            this.findPaymentsButton.Size = new System.Drawing.Size(134, 27);
            this.findPaymentsButton.TabIndex = 10;
            this.findPaymentsButton.Text = "&Search Payments";
            this.findPaymentsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.findPaymentsButton.UseVisualStyleBackColor = true;
            this.findPaymentsButton.Click += new System.EventHandler(this.findPaymentsButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "C&ustomer:";
            // 
            // customerComboBox
            // 
            this.customerComboBox.Enabled = false;
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(121, 145);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(296, 23);
            this.customerComboBox.TabIndex = 9;
            this.customerComboBox.SelectedValueChanged += new System.EventHandler(this.customerComboBox_SelectedValueChanged);
            this.customerComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.customerComboBox_Validating);
            this.customerComboBox.Validated += new System.EventHandler(this.customerComboBox_Validated);
            // 
            // customerButton
            // 
            this.customerButton.AutoSize = true;
            this.customerButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.customerButton.Location = new System.Drawing.Point(4, 126);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(70, 17);
            this.customerButton.TabIndex = 7;
            this.customerButton.Text = "&Customer";
            this.customerButton.UseVisualStyleBackColor = true;
            this.customerButton.CheckedChanged += new System.EventHandler(this.customerButton_CheckedChanged);
            // 
            // paymentModeButton
            // 
            this.paymentModeButton.AutoSize = true;
            this.paymentModeButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.paymentModeButton.Location = new System.Drawing.Point(6, 70);
            this.paymentModeButton.Name = "paymentModeButton";
            this.paymentModeButton.Size = new System.Drawing.Size(97, 17);
            this.paymentModeButton.TabIndex = 5;
            this.paymentModeButton.Text = "&Payment Mode";
            this.paymentModeButton.UseVisualStyleBackColor = true;
            this.paymentModeButton.CheckedChanged += new System.EventHandler(this.paymentModeButton_CheckedChanged);
            // 
            // endDatePicker
            // 
            this.endDatePicker.Enabled = false;
            this.endDatePicker.Location = new System.Drawing.Point(385, 43);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(157, 21);
            this.endDatePicker.TabIndex = 4;
            this.endDatePicker.ValueChanged += new System.EventHandler(this.endDatePicker_ValueChanged);
            this.endDatePicker.Validating += new System.ComponentModel.CancelEventHandler(this.endDatePicker_Validating);
            this.endDatePicker.Validated += new System.EventHandler(this.endDatePicker_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "E&nd Date:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Enabled = false;
            this.startDatePicker.Location = new System.Drawing.Point(124, 42);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(157, 21);
            this.startDatePicker.TabIndex = 2;
            this.startDatePicker.ValueChanged += new System.EventHandler(this.startDatePicker_ValueChanged);
            this.startDatePicker.Validating += new System.ComponentModel.CancelEventHandler(this.startDatePicker_Validating);
            this.startDatePicker.Validated += new System.EventHandler(this.startDatePicker_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "S&tart Date:";
            // 
            // betweenDatesButton
            // 
            this.betweenDatesButton.AutoSize = true;
            this.betweenDatesButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.betweenDatesButton.Location = new System.Drawing.Point(7, 22);
            this.betweenDatesButton.Name = "betweenDatesButton";
            this.betweenDatesButton.Size = new System.Drawing.Size(99, 17);
            this.betweenDatesButton.TabIndex = 0;
            this.betweenDatesButton.Text = "&Between Dates";
            this.betweenDatesButton.UseVisualStyleBackColor = true;
            this.betweenDatesButton.CheckedChanged += new System.EventHandler(this.betweenDatesButton_CheckedChanged);
            // 
            // resultsGroupBox
            // 
            this.resultsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsGroupBox.Controls.Add(this.summaryPanel);
            this.resultsGroupBox.Controls.Add(this.paymentsGrid);
            this.resultsGroupBox.Controls.Add(this.buttonPanel);
            this.resultsGroupBox.Location = new System.Drawing.Point(12, 202);
            this.resultsGroupBox.Name = "resultsGroupBox";
            this.resultsGroupBox.Size = new System.Drawing.Size(663, 228);
            this.resultsGroupBox.TabIndex = 1;
            this.resultsGroupBox.TabStop = false;
            this.resultsGroupBox.Text = "Payments Found";
            this.resultsGroupBox.Visible = false;
            // 
            // summaryPanel
            // 
            this.summaryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.summaryPanel.Controls.Add(this.paymentTotalField);
            this.summaryPanel.Controls.Add(this.label5);
            this.summaryPanel.Controls.Add(this.paymentCountField);
            this.summaryPanel.Controls.Add(this.label4);
            this.summaryPanel.Location = new System.Drawing.Point(7, 193);
            this.summaryPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.summaryPanel.Name = "summaryPanel";
            this.summaryPanel.Size = new System.Drawing.Size(510, 32);
            this.summaryPanel.TabIndex = 2;
            // 
            // paymentTotalField
            // 
            this.paymentTotalField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.paymentTotalField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentTotalField.Location = new System.Drawing.Point(335, 6);
            this.paymentTotalField.Name = "paymentTotalField";
            this.paymentTotalField.ReadOnly = true;
            this.paymentTotalField.Size = new System.Drawing.Size(159, 20);
            this.paymentTotalField.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(206, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Payment Total (Rs.):";
            // 
            // paymentCountField
            // 
            this.paymentCountField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.paymentCountField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentCountField.Location = new System.Drawing.Point(105, 6);
            this.paymentCountField.Name = "paymentCountField";
            this.paymentCountField.ReadOnly = true;
            this.paymentCountField.Size = new System.Drawing.Size(72, 20);
            this.paymentCountField.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Payment Count:";
            // 
            // paymentsGrid
            // 
            this.paymentsGrid.AllowUserToDeleteRows = false;
            this.paymentsGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.paymentsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.paymentsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paymentsGrid.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.paymentsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.paymentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paymentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PaymentDate,
            this.CustomerName,
            this.Amount,
            this.PaymentMode,
            this.InstrumentNumber,
            this.Notes,
            this.ID,
            this.CustomerID});
            this.paymentsGrid.Location = new System.Drawing.Point(7, 22);
            this.paymentsGrid.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.paymentsGrid.MultiSelect = false;
            this.paymentsGrid.Name = "paymentsGrid";
            this.paymentsGrid.ReadOnly = true;
            this.paymentsGrid.RowHeadersVisible = false;
            this.paymentsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.paymentsGrid.ShowCellErrors = false;
            this.paymentsGrid.ShowCellToolTips = false;
            this.paymentsGrid.ShowEditingIcon = false;
            this.paymentsGrid.ShowRowErrors = false;
            this.paymentsGrid.Size = new System.Drawing.Size(562, 168);
            this.paymentsGrid.TabIndex = 0;
            this.paymentsGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.paymentsGrid_CellFormatting);
            this.paymentsGrid.SelectionChanged += new System.EventHandler(this.paymentsGrid_SelectionChanged);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPanel.Controls.Add(this.deleteButton);
            this.buttonPanel.Controls.Add(this.editButton);
            this.buttonPanel.Location = new System.Drawing.Point(573, 22);
            this.buttonPanel.Margin = new System.Windows.Forms.Padding(1, 3, 0, 3);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(84, 203);
            this.buttonPanel.TabIndex = 1;
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(3, 37);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(78, 27);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "&Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(3, 4);
            this.editButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(78, 27);
            this.editButton.TabIndex = 0;
            this.editButton.Text = "&Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // PaymentDate
            // 
            this.PaymentDate.DataPropertyName = "PaymentDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.PaymentDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.PaymentDate.HeaderText = "Date";
            this.PaymentDate.Name = "PaymentDate";
            this.PaymentDate.ReadOnly = true;
            this.PaymentDate.Width = 85;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "Name";
            this.CustomerName.HeaderText = "Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.Amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.Amount.HeaderText = "Amount (Rs.)";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 70;
            // 
            // PaymentMode
            // 
            this.PaymentMode.DataPropertyName = "PaymentMode";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PaymentMode.DefaultCellStyle = dataGridViewCellStyle5;
            this.PaymentMode.HeaderText = "Mode";
            this.PaymentMode.Name = "PaymentMode";
            this.PaymentMode.ReadOnly = true;
            this.PaymentMode.Width = 60;
            // 
            // InstrumentNumber
            // 
            this.InstrumentNumber.DataPropertyName = "InstrumentNumber";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.InstrumentNumber.DefaultCellStyle = dataGridViewCellStyle6;
            this.InstrumentNumber.HeaderText = "Instrument Number";
            this.InstrumentNumber.Name = "InstrumentNumber";
            this.InstrumentNumber.ReadOnly = true;
            // 
            // Notes
            // 
            this.Notes.DataPropertyName = "Notes";
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            this.Notes.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.Visible = false;
            // 
            // PaymentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(686, 434);
            this.Controls.Add(this.resultsGroupBox);
            this.Controls.Add(this.criteriaGroupBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PaymentView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment View";
            this.Load += new System.EventHandler(this.PaymentView_Load);
            this.criteriaGroupBox.ResumeLayout(false);
            this.criteriaGroupBox.PerformLayout();
            this.paymentModePanel.ResumeLayout(false);
            this.paymentModePanel.PerformLayout();
            this.resultsGroupBox.ResumeLayout(false);
            this.summaryPanel.ResumeLayout(false);
            this.summaryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentsGrid)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox criteriaGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.CheckBox customerButton;
        private System.Windows.Forms.CheckBox paymentModeButton;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox betweenDatesButton;
        private System.Windows.Forms.Button findPaymentsButton;
        private System.Windows.Forms.GroupBox resultsGroupBox;
        private System.Windows.Forms.DataGridView paymentsGrid;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Panel summaryPanel;
        private System.Windows.Forms.TextBox paymentCountField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox paymentTotalField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel paymentModePanel;
        private System.Windows.Forms.CheckBox demandDraftButton;
        private System.Windows.Forms.CheckBox chequeButton;
        private System.Windows.Forms.CheckBox cashButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstrumentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
    }
}