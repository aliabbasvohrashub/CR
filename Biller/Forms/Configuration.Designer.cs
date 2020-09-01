namespace Bajaj.Dinesh.Biller
{
    partial class Configuration
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
            this.printDirectlyButton = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.printFirmNameButton = new System.Windows.Forms.CheckBox();
            this.printFirmAddressButton = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.changeDatabaseLocationButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.databasePathField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // printDirectlyButton
            // 
            this.printDirectlyButton.AutoSize = true;
            this.printDirectlyButton.Location = new System.Drawing.Point(22, 112);
            this.printDirectlyButton.Name = "printDirectlyButton";
            this.printDirectlyButton.Size = new System.Drawing.Size(375, 19);
            this.printDirectlyButton.TabIndex = 4;
            this.printDirectlyButton.Text = "&Print a bill directly to printer (Don\'t show the Print Preview dialog)";
            this.printDirectlyButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(588, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "(This option shall only be applicable if the \'Print on Save\' option is selected i" +
    "n the  \'Create New Bill\' window)";
            // 
            // printFirmNameButton
            // 
            this.printFirmNameButton.AutoSize = true;
            this.printFirmNameButton.Location = new System.Drawing.Point(22, 164);
            this.printFirmNameButton.Name = "printFirmNameButton";
            this.printFirmNameButton.Size = new System.Drawing.Size(161, 19);
            this.printFirmNameButton.TabIndex = 6;
            this.printFirmNameButton.Text = "Print &firm\'s name on bills";
            this.printFirmNameButton.UseVisualStyleBackColor = true;
            this.printFirmNameButton.CheckedChanged += new System.EventHandler(this.printFirmNameButton_CheckedChanged);
            // 
            // printFirmAddressButton
            // 
            this.printFirmAddressButton.AutoSize = true;
            this.printFirmAddressButton.Enabled = false;
            this.printFirmAddressButton.Location = new System.Drawing.Point(59, 189);
            this.printFirmAddressButton.Name = "printFirmAddressButton";
            this.printFirmAddressButton.Size = new System.Drawing.Size(173, 19);
            this.printFirmAddressButton.TabIndex = 7;
            this.printFirmAddressButton.Text = "Print firm\'s &address on bills";
            this.printFirmAddressButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(22, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(625, 2);
            this.label4.TabIndex = 10;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(572, 236);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(467, 236);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // changeDatabaseLocationButton
            // 
            this.changeDatabaseLocationButton.Image = global::Bajaj.Dinesh.Biller.Properties.Resources.explore_24;
            this.changeDatabaseLocationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.changeDatabaseLocationButton.Location = new System.Drawing.Point(144, 73);
            this.changeDatabaseLocationButton.Name = "changeDatabaseLocationButton";
            this.changeDatabaseLocationButton.Size = new System.Drawing.Size(195, 28);
            this.changeDatabaseLocationButton.TabIndex = 3;
            this.changeDatabaseLocationButton.Text = "&Change database location...";
            this.changeDatabaseLocationButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.changeDatabaseLocationButton.UseVisualStyleBackColor = true;
            this.changeDatabaseLocationButton.Click += new System.EventHandler(this.changeDatabaseLocationButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(490, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "(The application shall store the data files in a folder named \'Biller-Data\' under" +
    " this folder.)";
            // 
            // databasePathField
            // 
            this.databasePathField.Location = new System.Drawing.Point(141, 24);
            this.databasePathField.Name = "databasePathField";
            this.databasePathField.ReadOnly = true;
            this.databasePathField.Size = new System.Drawing.Size(509, 21);
            this.databasePathField.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Database Location:";
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(660, 272);
            this.Controls.Add(this.changeDatabaseLocationButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.databasePathField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.printFirmAddressButton);
            this.Controls.Add(this.printFirmNameButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.printDirectlyButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Configuration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.Configuration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox printDirectlyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox printFirmNameButton;
        private System.Windows.Forms.CheckBox printFirmAddressButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button changeDatabaseLocationButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox databasePathField;
        private System.Windows.Forms.Label label2;
    }
}