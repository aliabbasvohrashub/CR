namespace Bajaj.Dinesh.Biller
{
    partial class CustomerDetails
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.nameField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addressField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.phoneNumbersField = new System.Windows.Forms.TextBox();
            this.mobileNumbersField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cityField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.balanceTypeField = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.notesField = new System.Windows.Forms.RichTextBox();
            this.openingBalanceField = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nameField, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.addressField, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.phoneNumbersField, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.mobileNumbersField, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cityField, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.balanceTypeField, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.notesField, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.openingBalanceField, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(19, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(693, 253);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // nameField
            // 
            this.nameField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.nameField, 2);
            this.nameField.Location = new System.Drawing.Point(149, 3);
            this.nameField.Margin = new System.Windows.Forms.Padding(12, 3, 3, 9);
            this.nameField.MaxLength = 70;
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(329, 21);
            this.nameField.TabIndex = 1;
            this.nameField.TextChanged += new System.EventHandler(this.nameField_TextChanged);
            this.nameField.Validating += new System.ComponentModel.CancelEventHandler(this.nameField_Validating);
            this.nameField.Validated += new System.EventHandler(this.nameField_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Address:";
            // 
            // addressField
            // 
            this.addressField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.addressField, 3);
            this.addressField.Location = new System.Drawing.Point(149, 36);
            this.addressField.Margin = new System.Windows.Forms.Padding(12, 3, 19, 9);
            this.addressField.MaxLength = 80;
            this.addressField.Name = "addressField";
            this.addressField.Size = new System.Drawing.Size(525, 21);
            this.addressField.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "&Phone Number(s):";
            // 
            // phoneNumbersField
            // 
            this.phoneNumbersField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.phoneNumbersField.Location = new System.Drawing.Point(149, 102);
            this.phoneNumbersField.Margin = new System.Windows.Forms.Padding(12, 3, 3, 9);
            this.phoneNumbersField.MaxLength = 100;
            this.phoneNumbersField.Name = "phoneNumbersField";
            this.phoneNumbersField.Size = new System.Drawing.Size(197, 21);
            this.phoneNumbersField.TabIndex = 7;
            // 
            // mobileNumbersField
            // 
            this.mobileNumbersField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mobileNumbersField.Location = new System.Drawing.Point(484, 102);
            this.mobileNumbersField.Margin = new System.Windows.Forms.Padding(3, 3, 19, 9);
            this.mobileNumbersField.MaxLength = 100;
            this.mobileNumbersField.Name = "mobileNumbersField";
            this.mobileNumbersField.Size = new System.Drawing.Size(190, 21);
            this.mobileNumbersField.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "C&ity:";
            // 
            // cityField
            // 
            this.cityField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cityField.Location = new System.Drawing.Point(149, 69);
            this.cityField.Margin = new System.Windows.Forms.Padding(12, 3, 3, 9);
            this.cityField.MaxLength = 25;
            this.cityField.Name = "cityField";
            this.cityField.Size = new System.Drawing.Size(197, 21);
            this.cityField.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(19, 6, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "&Mobile Number(s):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(3, 138);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Op&ening Balance (Rs):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(368, 138);
            this.label7.Margin = new System.Windows.Forms.Padding(19, 6, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Balance &Type:";
            // 
            // balanceTypeField
            // 
            this.balanceTypeField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.balanceTypeField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.balanceTypeField.FormattingEnabled = true;
            this.balanceTypeField.Location = new System.Drawing.Point(484, 135);
            this.balanceTypeField.Margin = new System.Windows.Forms.Padding(3, 3, 19, 12);
            this.balanceTypeField.Name = "balanceTypeField";
            this.balanceTypeField.Size = new System.Drawing.Size(190, 23);
            this.balanceTypeField.TabIndex = 13;
            this.balanceTypeField.Validating += new System.ComponentModel.CancelEventHandler(this.balanceTypeField_Validating);
            this.balanceTypeField.Validated += new System.EventHandler(this.balanceTypeField_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 176);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "&Notes:";
            // 
            // notesField
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.notesField, 3);
            this.notesField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notesField.Location = new System.Drawing.Point(149, 173);
            this.notesField.Margin = new System.Windows.Forms.Padding(12, 3, 19, 3);
            this.notesField.MaxLength = 200;
            this.notesField.Name = "notesField";
            this.notesField.Size = new System.Drawing.Size(525, 77);
            this.notesField.TabIndex = 15;
            this.notesField.Text = "";
            // 
            // openingBalanceField
            // 
            this.openingBalanceField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openingBalanceField.Location = new System.Drawing.Point(149, 135);
            this.openingBalanceField.Margin = new System.Windows.Forms.Padding(12, 3, 3, 9);
            this.openingBalanceField.MaxLength = 12;
            this.openingBalanceField.Name = "openingBalanceField";
            this.openingBalanceField.Size = new System.Drawing.Size(197, 21);
            this.openingBalanceField.TabIndex = 11;
            this.openingBalanceField.Validating += new System.ComponentModel.CancelEventHandler(this.openingBalanceField_Validating);
            this.openingBalanceField.Validated += new System.EventHandler(this.openingBalanceField_Validated);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.CausesValidation = false;
            this.cancelButton.Location = new System.Drawing.Point(606, 315);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 27);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(499, 315);
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
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(21, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(302, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "The fields labelled with the Blue colour are mandatory.";
            // 
            // CustomerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(731, 354);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CustomerDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Details";
            this.Activated += new System.EventHandler(this.CustomerDetails_Activated);
            this.Load += new System.EventHandler(this.CustomerDetails_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addressField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox phoneNumbersField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mobileNumbersField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cityField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox balanceTypeField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox notesField;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox openingBalanceField;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label9;
    }
}