namespace DreamsGH.UserControls
{
    partial class UC_Orders
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

        #region Component Designer generated code

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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnExportToExcel = new FontAwesome.Sharp.IconPictureBox();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.dg = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecepientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.dp = new Bunifu.Framework.UI.BunifuDatepicker();
            this.cbxFilter = new Bunifu.Framework.UI.BunifuDropdown();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportToExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExportToExcel.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btnExportToExcel.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExportToExcel.IconSize = 26;
            this.btnExportToExcel.Location = new System.Drawing.Point(1056, 3);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(26, 27);
            this.btnExportToExcel.TabIndex = 70;
            this.btnExportToExcel.TabStop = false;
            this.toolTip1.SetToolTip(this.btnExportToExcel, "Export to Excel");
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 15;
            this.bunifuElipse2.TargetControl = this.dg;
            // 
            // dg
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.dg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.CustomerId,
            this.RecepientName,
            this.Items,
            this.Address,
            this.Phone,
            this.OrderDate,
            this.AmountPaid});
            this.dg.DoubleBuffered = true;
            this.dg.EnableHeadersVisualStyles = false;
            this.dg.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.dg.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dg.Location = new System.Drawing.Point(37, 55);
            this.dg.Name = "dg";
            this.dg.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dg.RowHeadersVisible = false;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dg.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dg.Size = new System.Drawing.Size(1010, 497);
            this.dg.TabIndex = 2;
            this.dg.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dg_CellFormatting);
            this.dg.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellMouseEnter);
            this.dg.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellMouseLeave);
            this.dg.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCustomer_CellValueChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CustomerId
            // 
            this.CustomerId.DataPropertyName = "CustomerId";
            this.CustomerId.HeaderText = "Customer Id";
            this.CustomerId.Name = "CustomerId";
            // 
            // RecepientName
            // 
            this.RecepientName.DataPropertyName = "RecepientName";
            this.RecepientName.HeaderText = "Recipient Name";
            this.RecepientName.Name = "RecepientName";
            // 
            // Items
            // 
            this.Items.DataPropertyName = "Items";
            this.Items.HeaderText = "Items";
            this.Items.Name = "Items";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            // 
            // OrderDate
            // 
            this.OrderDate.DataPropertyName = "OrderDate";
            this.OrderDate.HeaderText = "Order Date";
            this.OrderDate.Name = "OrderDate";
            // 
            // AmountPaid
            // 
            this.AmountPaid.DataPropertyName = "AmountPaid";
            this.AmountPaid.HeaderText = "Amount Paid";
            this.AmountPaid.Name = "AmountPaid";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.tbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbSearch.Location = new System.Drawing.Point(416, 15);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(200, 27);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.Text = "Search";
            this.toolTip1.SetToolTip(this.tbSearch, "Search Customer");
            this.tbSearch.Click += new System.EventHandler(this.tbSearch_Click);
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // dp
            // 
            this.dp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dp.BackColor = System.Drawing.Color.Gray;
            this.dp.BorderRadius = 0;
            this.dp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dp.ForeColor = System.Drawing.Color.White;
            this.dp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp.FormatCustom = null;
            this.dp.Location = new System.Drawing.Point(622, 15);
            this.dp.Name = "dp";
            this.dp.Size = new System.Drawing.Size(160, 27);
            this.dp.TabIndex = 77;
            this.dp.Value = new System.DateTime(2020, 9, 28, 15, 22, 0, 35);
            this.dp.onValueChanged += new System.EventHandler(this.dp_onValueChanged);
            // 
            // cbxFilter
            // 
            this.cbxFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.cbxFilter.BorderRadius = 3;
            this.cbxFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cbxFilter.ForeColor = System.Drawing.Color.White;
            this.cbxFilter.Items = new string[] {
        "Order Id",
        "Customer Id",
        "Recipient",
        "Address",
        "Phone"};
            this.cbxFilter.Location = new System.Drawing.Point(295, 15);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.cbxFilter.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cbxFilter.selectedIndex = 2;
            this.cbxFilter.Size = new System.Drawing.Size(115, 27);
            this.cbxFilter.TabIndex = 78;
            this.cbxFilter.onItemSelected += new System.EventHandler(this.cbxFilter_onItemSelected);
            // 
            // UC_Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.dp);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.tbSearch);
            this.Name = "UC_Orders";
            this.Size = new System.Drawing.Size(1085, 563);
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.ToolTip toolTip1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dg;
        private System.Windows.Forms.TextBox tbSearch;
        private FontAwesome.Sharp.IconPictureBox btnExportToExcel;
        private Bunifu.Framework.UI.BunifuDatepicker dp;
        private Bunifu.Framework.UI.BunifuDropdown cbxFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecepientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Items;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountPaid;
    }
}
