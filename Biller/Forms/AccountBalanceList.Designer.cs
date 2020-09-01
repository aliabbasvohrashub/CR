namespace Bajaj.Dinesh.Biller
{
    partial class AccountBalanceList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showBalanceButton = new System.Windows.Forms.Button();
            this.refreshCustomerList = new System.Windows.Forms.Button();
            this.CustomersListBox = new System.Windows.Forms.CheckedListBox();
            this.selectedCustomersButton = new System.Windows.Forms.RadioButton();
            this.allCustomersButton = new System.Windows.Forms.RadioButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.doneButton = new System.Windows.Forms.Button();
            this.printListbutton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.resultGroupBox = new System.Windows.Forms.GroupBox();
            this.summaryPanel = new System.Windows.Forms.Panel();
            this.balanceTotalField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.customerCountField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.balanceGrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.resultGroupBox.SuspendLayout();
            this.summaryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balanceGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.showBalanceButton);
            this.groupBox1.Controls.Add(this.refreshCustomerList);
            this.groupBox1.Controls.Add(this.CustomersListBox);
            this.groupBox1.Controls.Add(this.selectedCustomersButton);
            this.groupBox1.Controls.Add(this.allCustomersButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection Criteria";
            // 
            // showBalanceButton
            // 
            this.showBalanceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showBalanceButton.Image = global::Bajaj.Dinesh.Biller.Properties.Resources.search_16;
            this.showBalanceButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showBalanceButton.Location = new System.Drawing.Point(377, 165);
            this.showBalanceButton.Name = "showBalanceButton";
            this.showBalanceButton.Size = new System.Drawing.Size(130, 27);
            this.showBalanceButton.TabIndex = 4;
            this.showBalanceButton.Text = "Show &Balance";
            this.showBalanceButton.UseVisualStyleBackColor = true;
            this.showBalanceButton.Click += new System.EventHandler(this.showBalanceButton_Click);
            // 
            // refreshCustomerList
            // 
            this.refreshCustomerList.Image = global::Bajaj.Dinesh.Biller.Properties.Resources.refresh_16;
            this.refreshCustomerList.Location = new System.Drawing.Point(465, 43);
            this.refreshCustomerList.Name = "refreshCustomerList";
            this.refreshCustomerList.Size = new System.Drawing.Size(42, 27);
            this.refreshCustomerList.TabIndex = 3;
            this.toolTip.SetToolTip(this.refreshCustomerList, "Click to refresh the customers\' list.");
            this.refreshCustomerList.UseVisualStyleBackColor = true;
            this.refreshCustomerList.Click += new System.EventHandler(this.refreshCustomerList_Click);
            // 
            // CustomersListBox
            // 
            this.CustomersListBox.CheckOnClick = true;
            this.CustomersListBox.FormattingEnabled = true;
            this.CustomersListBox.Location = new System.Drawing.Point(164, 43);
            this.CustomersListBox.Name = "CustomersListBox";
            this.CustomersListBox.Size = new System.Drawing.Size(295, 116);
            this.CustomersListBox.TabIndex = 2;
            this.CustomersListBox.ThreeDCheckBoxes = true;
            this.CustomersListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CustomersListBox_ItemCheck);
            this.CustomersListBox.Validating += new System.ComponentModel.CancelEventHandler(this.CustomersListBox_Validating);
            this.CustomersListBox.Validated += new System.EventHandler(this.CustomersListBox_Validated);
            // 
            // selectedCustomersButton
            // 
            this.selectedCustomersButton.AutoSize = true;
            this.selectedCustomersButton.Checked = true;
            this.selectedCustomersButton.Location = new System.Drawing.Point(142, 20);
            this.selectedCustomersButton.Name = "selectedCustomersButton";
            this.selectedCustomersButton.Size = new System.Drawing.Size(85, 19);
            this.selectedCustomersButton.TabIndex = 1;
            this.selectedCustomersButton.TabStop = true;
            this.selectedCustomersButton.Text = "&Select Few";
            this.selectedCustomersButton.UseVisualStyleBackColor = true;
            this.selectedCustomersButton.CheckedChanged += new System.EventHandler(this.selectedCustomersButton_CheckedChanged);
            // 
            // allCustomersButton
            // 
            this.allCustomersButton.AutoSize = true;
            this.allCustomersButton.Location = new System.Drawing.Point(21, 20);
            this.allCustomersButton.Name = "allCustomersButton";
            this.allCustomersButton.Size = new System.Drawing.Size(100, 19);
            this.allCustomersButton.TabIndex = 0;
            this.allCustomersButton.Text = "&All Customers";
            this.allCustomersButton.UseVisualStyleBackColor = true;
            this.allCustomersButton.CheckedChanged += new System.EventHandler(this.allCustomersButton_CheckedChanged);
            // 
            // doneButton
            // 
            this.doneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.doneButton.Location = new System.Drawing.Point(450, 408);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(86, 23);
            this.doneButton.TabIndex = 3;
            this.doneButton.Text = "&Done";
            this.toolTip.SetToolTip(this.doneButton, "Close the window.");
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // printListbutton
            // 
            this.printListbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.printListbutton.Enabled = false;
            this.printListbutton.Location = new System.Drawing.Point(331, 408);
            this.printListbutton.Name = "printListbutton";
            this.printListbutton.Size = new System.Drawing.Size(86, 23);
            this.printListbutton.TabIndex = 2;
            this.printListbutton.Text = "&Print List...";
            this.toolTip.SetToolTip(this.printListbutton, "Prints the data shown on the grid.");
            this.printListbutton.UseVisualStyleBackColor = true;
            this.printListbutton.Click += new System.EventHandler(this.printListbutton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // resultGroupBox
            // 
            this.resultGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultGroupBox.Controls.Add(this.summaryPanel);
            this.resultGroupBox.Controls.Add(this.balanceGrid);
            this.resultGroupBox.Location = new System.Drawing.Point(13, 202);
            this.resultGroupBox.Name = "resultGroupBox";
            this.resultGroupBox.Size = new System.Drawing.Size(529, 200);
            this.resultGroupBox.TabIndex = 1;
            this.resultGroupBox.TabStop = false;
            this.resultGroupBox.Text = "&Result";
            this.resultGroupBox.Visible = false;
            this.resultGroupBox.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // summaryPanel
            // 
            this.summaryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryPanel.Controls.Add(this.balanceTotalField);
            this.summaryPanel.Controls.Add(this.label2);
            this.summaryPanel.Controls.Add(this.customerCountField);
            this.summaryPanel.Controls.Add(this.label1);
            this.summaryPanel.Location = new System.Drawing.Point(7, 162);
            this.summaryPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.summaryPanel.Name = "summaryPanel";
            this.summaryPanel.Size = new System.Drawing.Size(516, 33);
            this.summaryPanel.TabIndex = 1;
            // 
            // balanceTotalField
            // 
            this.balanceTotalField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.balanceTotalField.Location = new System.Drawing.Point(319, 6);
            this.balanceTotalField.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.balanceTotalField.Name = "balanceTotalField";
            this.balanceTotalField.ReadOnly = true;
            this.balanceTotalField.Size = new System.Drawing.Size(133, 21);
            this.balanceTotalField.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(192, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Balance Total (Rs.):";
            // 
            // customerCountField
            // 
            this.customerCountField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.customerCountField.Location = new System.Drawing.Point(113, 6);
            this.customerCountField.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.customerCountField.Name = "customerCountField";
            this.customerCountField.ReadOnly = true;
            this.customerCountField.Size = new System.Drawing.Size(58, 21);
            this.customerCountField.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Count:";
            // 
            // balanceGrid
            // 
            this.balanceGrid.AllowUserToAddRows = false;
            this.balanceGrid.AllowUserToDeleteRows = false;
            this.balanceGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Azure;
            this.balanceGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.balanceGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.balanceGrid.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.balanceGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.balanceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.balanceGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CustomerName,
            this.BalanceAmount,
            this.City});
            this.balanceGrid.Location = new System.Drawing.Point(5, 16);
            this.balanceGrid.Name = "balanceGrid";
            this.balanceGrid.ReadOnly = true;
            this.balanceGrid.RowHeadersVisible = false;
            this.balanceGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.balanceGrid.ShowCellErrors = false;
            this.balanceGrid.ShowCellToolTips = false;
            this.balanceGrid.ShowEditingIcon = false;
            this.balanceGrid.ShowRowErrors = false;
            this.balanceGrid.Size = new System.Drawing.Size(518, 143);
            this.balanceGrid.TabIndex = 0;
            this.balanceGrid.DataSourceChanged += new System.EventHandler(this.balanceGrid_DataSourceChanged);
            this.balanceGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.balanceGrid_CellFormatting);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 200;
            // 
            // BalanceAmount
            // 
            this.BalanceAmount.DataPropertyName = "BalanceAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.BalanceAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.BalanceAmount.HeaderText = "Balance Amount (Rs.)";
            this.BalanceAmount.Name = "BalanceAmount";
            this.BalanceAmount.ReadOnly = true;
            this.BalanceAmount.Width = 130;
            // 
            // City
            // 
            this.City.DataPropertyName = "City";
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.Width = 160;
            // 
            // AccountBalanceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(556, 433);
            this.Controls.Add(this.printListbutton);
            this.Controls.Add(this.resultGroupBox);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AccountBalanceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Balance";
            this.Load += new System.EventHandler(this.AccountBalanceList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.resultGroupBox.ResumeLayout(false);
            this.summaryPanel.ResumeLayout(false);
            this.summaryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balanceGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button refreshCustomerList;
        private System.Windows.Forms.CheckedListBox CustomersListBox;
        private System.Windows.Forms.RadioButton selectedCustomersButton;
        private System.Windows.Forms.RadioButton allCustomersButton;
        private System.Windows.Forms.Button showBalanceButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.GroupBox resultGroupBox;
        private System.Windows.Forms.Panel summaryPanel;
        private System.Windows.Forms.DataGridView balanceGrid;
        private System.Windows.Forms.TextBox balanceTotalField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox customerCountField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button printListbutton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
    }
}