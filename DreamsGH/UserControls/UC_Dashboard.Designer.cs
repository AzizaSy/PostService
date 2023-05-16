namespace DreamsGH.UserControls
{
    partial class UC_Dashboard
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblUsers = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAmountReceived = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblOrders = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.cbxFilter = new Bunifu.Framework.UI.BunifuDropdown();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(96, 435);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 1);
            this.panel2.TabIndex = 45;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Location = new System.Drawing.Point(83, 212);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(900, 1);
            this.panel3.TabIndex = 1;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuCards1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.bunifuCards1.Controls.Add(this.pbLogo);
            this.bunifuCards1.ForeColor = System.Drawing.Color.Transparent;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(266, 33);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(528, 79);
            this.bunifuCards1.TabIndex = 46;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::DreamsGH.Properties.Resources.Logo_Upper;
            this.pbLogo.Location = new System.Drawing.Point(157, 6);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(233, 70);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 14;
            this.pbLogo.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel5.Controls.Add(this.lblUsers);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.lblAmountReceived);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.lblOrders);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.lblCustomers);
            this.panel5.Controls.Add(this.label24);
            this.panel5.Location = new System.Drawing.Point(214, 274);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(676, 76);
            this.panel5.TabIndex = 45;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.lblUsers.ForeColor = System.Drawing.Color.White;
            this.lblUsers.Location = new System.Drawing.Point(550, 44);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(43, 22);
            this.lblUsers.TabIndex = 35;
            this.lblUsers.Text = "529";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(547, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 19);
            this.label6.TabIndex = 34;
            this.label6.Text = "Users";
            // 
            // lblAmountReceived
            // 
            this.lblAmountReceived.AutoSize = true;
            this.lblAmountReceived.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.lblAmountReceived.ForeColor = System.Drawing.Color.White;
            this.lblAmountReceived.Location = new System.Drawing.Point(378, 44);
            this.lblAmountReceived.Name = "lblAmountReceived";
            this.lblAmountReceived.Size = new System.Drawing.Size(43, 22);
            this.lblAmountReceived.TabIndex = 33;
            this.lblAmountReceived.Text = "529";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(325, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 19);
            this.label4.TabIndex = 32;
            this.label4.Text = "Amount Received";
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.lblOrders.ForeColor = System.Drawing.Color.White;
            this.lblOrders.Location = new System.Drawing.Point(212, 44);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(43, 22);
            this.lblOrders.TabIndex = 31;
            this.lblOrders.Text = "529";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(198, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 30;
            this.label2.Text = "Orders";
            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.lblCustomers.ForeColor = System.Drawing.Color.White;
            this.lblCustomers.Location = new System.Drawing.Point(52, 44);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(43, 22);
            this.lblCustomers.TabIndex = 29;
            this.lblCustomers.Text = "529";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(30, 11);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(88, 19);
            this.label24.TabIndex = 28;
            this.label24.Text = "Customers";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tbSearch.Location = new System.Drawing.Point(398, 142);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(288, 29);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.Text = "Search Customers";
            this.tbSearch.Click += new System.EventHandler(this.tbSearch_Click);
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // cbxFilter
            // 
            this.cbxFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.cbxFilter.BorderRadius = 3;
            this.cbxFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cbxFilter.ForeColor = System.Drawing.Color.White;
            this.cbxFilter.Items = new string[] {
        "Id",
        "First Name",
        "Last Name",
        "Phone Number",
        "Address",
        "City"};
            this.cbxFilter.Location = new System.Drawing.Point(481, 176);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.cbxFilter.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cbxFilter.selectedIndex = 1;
            this.cbxFilter.Size = new System.Drawing.Size(115, 27);
            this.cbxFilter.TabIndex = 73;
            this.cbxFilter.onItemSelected += new System.EventHandler(this.cbxFilter_onItemSelected);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this.panel5;
            // 
            // UC_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(62)))));
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.bunifuCards1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(1085, 563);
            this.bunifuCards1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAmountReceived;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuDropdown cbxFilter;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}
