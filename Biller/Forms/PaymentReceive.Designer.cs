namespace Bajaj.Dinesh.Biller
{
    partial class PaymentReceive
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
            this.label1 = new System.Windows.Forms.Label();
            this.customerNameCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.balanceField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.paymentDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.amountField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.instrumentNumberLabel = new System.Windows.Forms.Label();
            this.instrumentNumberField = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.demandDraftButton = new System.Windows.Forms.RadioButton();
            this.chequeButton = new System.Windows.Forms.RadioButton();
            this.cashButton = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.successButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.notesField = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Customer:";
            // 
            // customerNameCombo
            // 
            this.customerNameCombo.FormattingEnabled = true;
            this.customerNameCombo.Location = new System.Drawing.Point(151, 17);
            this.customerNameCombo.Name = "customerNameCombo";
            this.customerNameCombo.Size = new System.Drawing.Size(299, 23);
            this.customerNameCombo.TabIndex = 1;
            this.customerNameCombo.SelectedValueChanged += new System.EventHandler(this.customerNameCombo_SelectedValueChanged);
            this.customerNameCombo.Validating += new System.ComponentModel.CancelEventHandler(this.customerNameCombo_Validating);
            this.customerNameCombo.Validated += new System.EventHandler(this.customerNameCombo_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Balance (Rs.):";
            // 
            // balanceField
            // 
            this.balanceField.Location = new System.Drawing.Point(151, 52);
            this.balanceField.Name = "balanceField";
            this.balanceField.ReadOnly = true;
            this.balanceField.Size = new System.Drawing.Size(188, 21);
            this.balanceField.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(15, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Date:";
            // 
            // paymentDatePicker
            // 
            this.paymentDatePicker.Location = new System.Drawing.Point(151, 85);
            this.paymentDatePicker.Name = "paymentDatePicker";
            this.paymentDatePicker.Size = new System.Drawing.Size(188, 21);
            this.paymentDatePicker.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(15, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Amount (Rs.):";
            // 
            // amountField
            // 
            this.amountField.Location = new System.Drawing.Point(151, 119);
            this.amountField.Name = "amountField";
            this.amountField.Size = new System.Drawing.Size(188, 21);
            this.amountField.TabIndex = 7;
            this.amountField.Leave += new System.EventHandler(this.amountField_Leave);
            this.amountField.Validating += new System.ComponentModel.CancelEventHandler(this.amountField_Validating);
            this.amountField.Validated += new System.EventHandler(this.amountField_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(15, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Payment Mode:";
            // 
            // instrumentNumberLabel
            // 
            this.instrumentNumberLabel.AutoSize = true;
            this.instrumentNumberLabel.Location = new System.Drawing.Point(15, 199);
            this.instrumentNumberLabel.Name = "instrumentNumberLabel";
            this.instrumentNumberLabel.Size = new System.Drawing.Size(116, 15);
            this.instrumentNumberLabel.TabIndex = 10;
            this.instrumentNumberLabel.Text = "&Instrument Number:";
            // 
            // instrumentNumberField
            // 
            this.instrumentNumberField.Enabled = false;
            this.instrumentNumberField.Location = new System.Drawing.Point(151, 195);
            this.instrumentNumberField.MaxLength = 20;
            this.instrumentNumberField.Name = "instrumentNumberField";
            this.instrumentNumberField.Size = new System.Drawing.Size(188, 21);
            this.instrumentNumberField.TabIndex = 11;
            this.toolTip.SetToolTip(this.instrumentNumberField, "Cheque / Demand Draft number.");
            this.instrumentNumberField.Validating += new System.ComponentModel.CancelEventHandler(this.instrumentNumberField_Validating);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.demandDraftButton);
            this.panel1.Controls.Add(this.chequeButton);
            this.panel1.Controls.Add(this.cashButton);
            this.panel1.Location = new System.Drawing.Point(151, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 32);
            this.panel1.TabIndex = 9;
            // 
            // demandDraftButton
            // 
            this.demandDraftButton.AutoSize = true;
            this.demandDraftButton.Location = new System.Drawing.Point(187, 5);
            this.demandDraftButton.Name = "demandDraftButton";
            this.demandDraftButton.Size = new System.Drawing.Size(102, 19);
            this.demandDraftButton.TabIndex = 2;
            this.demandDraftButton.Text = "De&mand Draft";
            this.demandDraftButton.UseVisualStyleBackColor = true;
            // 
            // chequeButton
            // 
            this.chequeButton.AutoSize = true;
            this.chequeButton.Location = new System.Drawing.Point(87, 3);
            this.chequeButton.Name = "chequeButton";
            this.chequeButton.Size = new System.Drawing.Size(68, 19);
            this.chequeButton.TabIndex = 1;
            this.chequeButton.Text = "C&heque";
            this.chequeButton.UseVisualStyleBackColor = true;
            // 
            // cashButton
            // 
            this.cashButton.AutoSize = true;
            this.cashButton.Checked = true;
            this.cashButton.Location = new System.Drawing.Point(7, 5);
            this.cashButton.Name = "cashButton";
            this.cashButton.Size = new System.Drawing.Size(53, 19);
            this.cashButton.TabIndex = 0;
            this.cashButton.TabStop = true;
            this.cashButton.Text = "Ca&sh";
            this.cashButton.UseVisualStyleBackColor = true;
            this.cashButton.CheckedChanged += new System.EventHandler(this.cashButton_CheckedChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.Location = new System.Drawing.Point(442, 306);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 27);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Canc&el";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(337, 304);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(87, 27);
            this.okButton.TabIndex = 14;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(15, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(295, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "The fields labelled with the Blue color are mandatory.";
            // 
            // successButton
            // 
            this.successButton.FlatAppearance.BorderSize = 0;
            this.successButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.successButton.Image = global::Bajaj.Dinesh.Biller.Properties.Resources.check_24;
            this.successButton.Location = new System.Drawing.Point(15, 297);
            this.successButton.Name = "successButton";
            this.successButton.Size = new System.Drawing.Size(62, 39);
            this.successButton.TabIndex = 17;
            this.successButton.UseVisualStyleBackColor = true;
            this.successButton.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "&Note:";
            // 
            // notesField
            // 
            this.notesField.Location = new System.Drawing.Point(151, 230);
            this.notesField.MaxLength = 60;
            this.notesField.Name = "notesField";
            this.notesField.Size = new System.Drawing.Size(378, 21);
            this.notesField.TabIndex = 13;
            // 
            // timer
            // 
            this.timer.Interval = 4000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // PaymentReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(544, 340);
            this.Controls.Add(this.notesField);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.successButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.instrumentNumberField);
            this.Controls.Add(this.instrumentNumberLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.amountField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.paymentDatePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.balanceField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.customerNameCombo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PaymentReceive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receive Payment";
            this.Load += new System.EventHandler(this.PaymentReceive_Load);
            this.Shown += new System.EventHandler(this.PaymentReceive_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox customerNameCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox balanceField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker paymentDatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox amountField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label instrumentNumberLabel;
        private System.Windows.Forms.TextBox instrumentNumberField;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton demandDraftButton;
        private System.Windows.Forms.RadioButton chequeButton;
        private System.Windows.Forms.RadioButton cashButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button successButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox notesField;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer timer;
    }
}