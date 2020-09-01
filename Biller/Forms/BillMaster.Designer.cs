namespace Bajaj.Dinesh.Biller
{
    partial class BillMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillMaster));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.billTypeGroup = new System.Windows.Forms.GroupBox();
            this.refreshCustomersList = new System.Windows.Forms.Button();
            this.customerNameField = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.creditBillButton = new System.Windows.Forms.RadioButton();
            this.cashBillButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.billItemsGrid = new System.Windows.Forms.DataGridView();
            this.billSubTotalField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.discountField = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.expenseAmountField = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.expenseTextField = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.billTotalField = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.successButton = new System.Windows.Forms.Button();
            this.printOnSaveButton = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.deleteRowsButton = new System.Windows.Forms.Button();
            this.refreshMeasurementUnitsButton = new System.Windows.Forms.Button();
            this.refreshItemsButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.billDateField = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.billTypeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.billItemsGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // billTypeGroup
            // 
            this.billTypeGroup.Controls.Add(this.refreshCustomersList);
            this.billTypeGroup.Controls.Add(this.customerNameField);
            this.billTypeGroup.Controls.Add(this.label2);
            this.billTypeGroup.Controls.Add(this.creditBillButton);
            this.billTypeGroup.Controls.Add(this.cashBillButton);
            this.billTypeGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billTypeGroup.Location = new System.Drawing.Point(12, 12);
            this.billTypeGroup.Name = "billTypeGroup";
            this.billTypeGroup.Size = new System.Drawing.Size(584, 63);
            this.billTypeGroup.TabIndex = 0;
            this.billTypeGroup.TabStop = false;
            this.billTypeGroup.Text = "Bill Type";
            // 
            // refreshCustomersList
            // 
            this.refreshCustomersList.Image = ((System.Drawing.Image)(resources.GetObject("refreshCustomersList.Image")));
            this.refreshCustomersList.Location = new System.Drawing.Point(545, 31);
            this.refreshCustomersList.Name = "refreshCustomersList";
            this.refreshCustomersList.Size = new System.Drawing.Size(33, 27);
            this.refreshCustomersList.TabIndex = 4;
            this.toolTip1.SetToolTip(this.refreshCustomersList, "Refreshes customers\' list.\r\nYou would refresh this list when you have added new c" +
        "ustomers\r\n while this form(window) remained open, and you would now\r\nlike the ne" +
        "wly added customers to appear here.");
            this.refreshCustomersList.UseVisualStyleBackColor = true;
            this.refreshCustomersList.Click += new System.EventHandler(this.refreshCustomersList_Click);
            // 
            // customerNameField
            // 
            this.customerNameField.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.customerNameField.Enabled = false;
            this.customerNameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerNameField.FormattingEnabled = true;
            this.customerNameField.Location = new System.Drawing.Point(209, 35);
            this.customerNameField.Name = "customerNameField";
            this.customerNameField.Size = new System.Drawing.Size(304, 21);
            this.customerNameField.TabIndex = 3;
            this.customerNameField.Validating += new System.ComponentModel.CancelEventHandler(this.customerNameField_Validating);
            this.customerNameField.Validated += new System.EventHandler(this.customerNameField_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(147, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "C&ustomer:";
            // 
            // creditBillButton
            // 
            this.creditBillButton.AutoSize = true;
            this.creditBillButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditBillButton.Location = new System.Drawing.Point(116, 18);
            this.creditBillButton.Name = "creditBillButton";
            this.creditBillButton.Size = new System.Drawing.Size(68, 17);
            this.creditBillButton.TabIndex = 1;
            this.creditBillButton.TabStop = true;
            this.creditBillButton.Text = "C&redit Bill";
            this.creditBillButton.UseVisualStyleBackColor = true;
            this.creditBillButton.CheckedChanged += new System.EventHandler(this.creditBillButton_CheckedChanged);
            // 
            // cashBillButton
            // 
            this.cashBillButton.AutoSize = true;
            this.cashBillButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashBillButton.Location = new System.Drawing.Point(19, 18);
            this.cashBillButton.Name = "cashBillButton";
            this.cashBillButton.Size = new System.Drawing.Size(65, 17);
            this.cashBillButton.TabIndex = 0;
            this.cashBillButton.TabStop = true;
            this.cashBillButton.Text = "&Cash Bill";
            this.cashBillButton.UseVisualStyleBackColor = true;
            this.cashBillButton.CheckedChanged += new System.EventHandler(this.cashBillButton_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bill Ite&ms:";
            // 
            // billItemsGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.billItemsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.billItemsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.billItemsGrid.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.billItemsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.billItemsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.billItemsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.billItemsGrid.Location = new System.Drawing.Point(15, 105);
            this.billItemsGrid.Name = "billItemsGrid";
            this.billItemsGrid.Size = new System.Drawing.Size(664, 178);
            this.billItemsGrid.TabIndex = 4;
            this.billItemsGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.billItemsGrid_CellEnter);
            this.billItemsGrid.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.billItemsGrid_CellValidated);
            this.billItemsGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.billItemsGrid_CellValidating);
            this.billItemsGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.billItemsGrid_DataError);
            this.billItemsGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.billItemsGrid_EditingControlShowing);
            this.billItemsGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.billItemsGrid_RowsAdded);
            this.billItemsGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.billItemsGrid_RowsRemoved);
            this.billItemsGrid.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.billItemsGrid_RowValidated);
            this.billItemsGrid.SelectionChanged += new System.EventHandler(this.billItemsGrid_SelectionChanged);
            // 
            // billSubTotalField
            // 
            this.billSubTotalField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.billSubTotalField.Location = new System.Drawing.Point(533, 289);
            this.billSubTotalField.Name = "billSubTotalField";
            this.billSubTotalField.ReadOnly = true;
            this.billSubTotalField.Size = new System.Drawing.Size(146, 21);
            this.billSubTotalField.TabIndex = 7;
            this.billSubTotalField.Text = "0.00";
            this.billSubTotalField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(402, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Bill Sub-Total (Rs.):";
            // 
            // discountField
            // 
            this.discountField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.discountField.Location = new System.Drawing.Point(533, 313);
            this.discountField.Name = "discountField";
            this.discountField.Size = new System.Drawing.Size(146, 21);
            this.discountField.TabIndex = 9;
            this.discountField.Text = "0.00";
            this.discountField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discountField.Leave += new System.EventHandler(this.discountField_Leave);
            this.discountField.Validating += new System.ComponentModel.CancelEventHandler(this.discountField_Validating);
            this.discountField.Validated += new System.EventHandler(this.discountField_Validated);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(421, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "(-) &Discount (Rs.):";
            // 
            // expenseAmountField
            // 
            this.expenseAmountField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.expenseAmountField.Location = new System.Drawing.Point(533, 337);
            this.expenseAmountField.Name = "expenseAmountField";
            this.expenseAmountField.Size = new System.Drawing.Size(146, 21);
            this.expenseAmountField.TabIndex = 13;
            this.expenseAmountField.Text = "0.00";
            this.expenseAmountField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.expenseAmountField.Leave += new System.EventHandler(this.exponseAmountField_Leave);
            this.expenseAmountField.Validating += new System.ComponentModel.CancelEventHandler(this.exponseAmountField_Validating);
            this.expenseAmountField.Validated += new System.EventHandler(this.exponseAmountField_Validated);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(419, 341);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "(+) E&xpense (Rs.):";
            // 
            // expenseTextField
            // 
            this.expenseTextField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.expenseTextField.Location = new System.Drawing.Point(116, 338);
            this.expenseTextField.MaxLength = 50;
            this.expenseTextField.Name = "expenseTextField";
            this.expenseTextField.Size = new System.Drawing.Size(297, 21);
            this.expenseTextField.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 342);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "&Expense Text:";
            // 
            // billTotalField
            // 
            this.billTotalField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.billTotalField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billTotalField.Location = new System.Drawing.Point(533, 361);
            this.billTotalField.Name = "billTotalField";
            this.billTotalField.ReadOnly = true;
            this.billTotalField.Size = new System.Drawing.Size(146, 20);
            this.billTotalField.TabIndex = 15;
            this.billTotalField.Text = "0.00";
            this.billTotalField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(417, 362);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 15);
            this.label11.TabIndex = 14;
            this.label11.Text = "Bill Total (Rs.):";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.successButton);
            this.panel1.Controls.Add(this.printOnSaveButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Location = new System.Drawing.Point(12, 393);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 34);
            this.panel1.TabIndex = 16;
            // 
            // successButton
            // 
            this.successButton.FlatAppearance.BorderSize = 0;
            this.successButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.successButton.Image = global::Bajaj.Dinesh.Biller.Properties.Resources.check_24;
            this.successButton.Location = new System.Drawing.Point(3, 3);
            this.successButton.Name = "successButton";
            this.successButton.Size = new System.Drawing.Size(68, 29);
            this.successButton.TabIndex = 1;
            this.successButton.UseVisualStyleBackColor = true;
            this.successButton.Visible = false;
            // 
            // printOnSaveButton
            // 
            this.printOnSaveButton.AutoSize = true;
            this.printOnSaveButton.Checked = true;
            this.printOnSaveButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.printOnSaveButton.Location = new System.Drawing.Point(345, 8);
            this.printOnSaveButton.Name = "printOnSaveButton";
            this.printOnSaveButton.Size = new System.Drawing.Size(98, 19);
            this.printOnSaveButton.TabIndex = 2;
            this.printOnSaveButton.Text = "&Print on Save";
            this.printOnSaveButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(474, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(87, 27);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.Location = new System.Drawing.Point(577, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 27);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "C&ancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // deleteRowsButton
            // 
            this.deleteRowsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteRowsButton.Enabled = false;
            this.deleteRowsButton.Image = global::Bajaj.Dinesh.Biller.Properties.Resources.delete_22;
            this.deleteRowsButton.Location = new System.Drawing.Point(685, 105);
            this.deleteRowsButton.Name = "deleteRowsButton";
            this.deleteRowsButton.Size = new System.Drawing.Size(29, 27);
            this.deleteRowsButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.deleteRowsButton, "Delete selected item(s)");
            this.deleteRowsButton.UseVisualStyleBackColor = true;
            this.deleteRowsButton.Click += new System.EventHandler(this.deleteRowsButton_Click);
            // 
            // refreshMeasurementUnitsButton
            // 
            this.refreshMeasurementUnitsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshMeasurementUnitsButton.Image = global::Bajaj.Dinesh.Biller.Properties.Resources.refresh_16_1;
            this.refreshMeasurementUnitsButton.Location = new System.Drawing.Point(685, 192);
            this.refreshMeasurementUnitsButton.Name = "refreshMeasurementUnitsButton";
            this.refreshMeasurementUnitsButton.Size = new System.Drawing.Size(29, 27);
            this.refreshMeasurementUnitsButton.TabIndex = 18;
            this.toolTip1.SetToolTip(this.refreshMeasurementUnitsButton, resources.GetString("refreshMeasurementUnitsButton.ToolTip"));
            this.refreshMeasurementUnitsButton.UseVisualStyleBackColor = true;
            this.refreshMeasurementUnitsButton.Click += new System.EventHandler(this.refreshMeasurementUnitsButton_Click);
            // 
            // refreshItemsButton
            // 
            this.refreshItemsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshItemsButton.Image = global::Bajaj.Dinesh.Biller.Properties.Resources.refresh_16_2;
            this.refreshItemsButton.Location = new System.Drawing.Point(685, 147);
            this.refreshItemsButton.Name = "refreshItemsButton";
            this.refreshItemsButton.Size = new System.Drawing.Size(29, 27);
            this.refreshItemsButton.TabIndex = 17;
            this.toolTip1.SetToolTip(this.refreshItemsButton, resources.GetString("refreshItemsButton.ToolTip"));
            this.refreshItemsButton.UseVisualStyleBackColor = true;
            this.refreshItemsButton.Click += new System.EventHandler(this.refreshItemsButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // billDateField
            // 
            this.billDateField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.billDateField.Checked = false;
            this.billDateField.Location = new System.Drawing.Point(526, 80);
            this.billDateField.Name = "billDateField";
            this.billDateField.Size = new System.Drawing.Size(153, 21);
            this.billDateField.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(461, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "&Bill Date:";
            // 
            // timer
            // 
            this.timer.Interval = 4000;
            this.timer.Tick += new System.EventHandler(this.time_Tick);
            // 
            // BillMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(720, 431);
            this.Controls.Add(this.billDateField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deleteRowsButton);
            this.Controls.Add(this.refreshMeasurementUnitsButton);
            this.Controls.Add(this.refreshItemsButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.billTotalField);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.expenseTextField);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.expenseAmountField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.discountField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.billSubTotalField);
            this.Controls.Add(this.billItemsGrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.billTypeGroup);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BillMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Bill";
            this.Activated += new System.EventHandler(this.BillMaster_Activated);
            this.Load += new System.EventHandler(this.BillMaster_Load);
            this.billTypeGroup.ResumeLayout(false);
            this.billTypeGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.billItemsGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox billTypeGroup;
        private System.Windows.Forms.ComboBox customerNameField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton creditBillButton;
        private System.Windows.Forms.RadioButton cashBillButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView billItemsGrid;
        private System.Windows.Forms.TextBox billSubTotalField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox discountField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox expenseAmountField;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox expenseTextField;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox billTotalField;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox printOnSaveButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button refreshItemsButton;
        private System.Windows.Forms.Button refreshMeasurementUnitsButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button refreshCustomersList;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button deleteRowsButton;
        private System.Windows.Forms.DateTimePicker billDateField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button successButton;
    }
}