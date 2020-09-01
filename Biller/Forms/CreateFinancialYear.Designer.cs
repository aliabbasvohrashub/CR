namespace Bajaj.Dinesh.Biller
{
    partial class CreateFinancialYear
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.booksStartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.startYearField = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.financialYearCombo = new System.Windows.Forms.ComboBox();
            this.transferDataFromAnotherYearButton = new System.Windows.Forms.CheckBox();
            this.endYearField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startYearField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.booksStartDatePicker);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.startYearField);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.financialYearCombo);
            this.groupBox1.Controls.Add(this.transferDataFromAnotherYearButton);
            this.groupBox1.Controls.Add(this.endYearField);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Financial Year";
            // 
            // booksStartDatePicker
            // 
            this.booksStartDatePicker.Location = new System.Drawing.Point(135, 109);
            this.booksStartDatePicker.Name = "booksStartDatePicker";
            this.booksStartDatePicker.Size = new System.Drawing.Size(148, 21);
            this.booksStartDatePicker.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "&Books Start Date:";
            // 
            // startYearField
            // 
            this.startYearField.Location = new System.Drawing.Point(135, 31);
            this.startYearField.Name = "startYearField";
            this.startYearField.Size = new System.Drawing.Size(82, 21);
            this.startYearField.TabIndex = 2;
            this.startYearField.ValueChanged += new System.EventHandler(this.startYearField_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "&Financial Year:";
            // 
            // financialYearCombo
            // 
            this.financialYearCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.financialYearCombo.Enabled = false;
            this.financialYearCombo.FormattingEnabled = true;
            this.financialYearCombo.Location = new System.Drawing.Point(153, 172);
            this.financialYearCombo.Name = "financialYearCombo";
            this.financialYearCombo.Size = new System.Drawing.Size(152, 23);
            this.financialYearCombo.TabIndex = 0;
            this.financialYearCombo.Validating += new System.ComponentModel.CancelEventHandler(this.financialYearCombo_Validating);
            this.financialYearCombo.Validated += new System.EventHandler(this.financialYearCombo_Validated);
            // 
            // transferDataFromAnotherYearButton
            // 
            this.transferDataFromAnotherYearButton.Enabled = false;
            this.transferDataFromAnotherYearButton.Location = new System.Drawing.Point(20, 148);
            this.transferDataFromAnotherYearButton.Name = "transferDataFromAnotherYearButton";
            this.transferDataFromAnotherYearButton.Size = new System.Drawing.Size(214, 19);
            this.transferDataFromAnotherYearButton.TabIndex = 7;
            this.transferDataFromAnotherYearButton.Text = "&Transfer data from an existing year";
            this.transferDataFromAnotherYearButton.UseVisualStyleBackColor = true;
            this.transferDataFromAnotherYearButton.CheckedChanged += new System.EventHandler(this.transferDataFromAnotherYearButton_CheckedChanged);
            // 
            // endYearField
            // 
            this.endYearField.Location = new System.Drawing.Point(135, 70);
            this.endYearField.Name = "endYearField";
            this.endYearField.ReadOnly = true;
            this.endYearField.Size = new System.Drawing.Size(82, 21);
            this.endYearField.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "&End Year:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Start Year:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(281, 239);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(178, 239);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.EnabledChanged += new System.EventHandler(this.okButton_EnabledChanged);
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // CreateFinancialYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(373, 268);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CreateFinancialYear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Financial Year";
            this.Load += new System.EventHandler(this.CreateFinancialYear_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startYearField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox financialYearCombo;
        private System.Windows.Forms.CheckBox transferDataFromAnotherYearButton;
        private System.Windows.Forms.TextBox endYearField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.NumericUpDown startYearField;
        private System.Windows.Forms.DateTimePicker booksStartDatePicker;
        private System.Windows.Forms.Label label4;
    }
}