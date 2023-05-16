using ExcelDataReader;
using DreamsGH.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Z.Dapper.Plus;

namespace DreamsGH.Forms
{
    public partial class FormViewOrders : Form
    {
        Customer cust;

        public FormViewOrders()
        {
            InitializeComponent();
        }

        public FormViewOrders(Customer c)
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            cust = c;
            lblCustomerId.Text = c.Id.ToString();
            lblFullName.Text = c.FirstName + " " + c.LastName;
            lblPhoneNumber.Text = c.Phone;
            lblAddress.Text = c.Address;
            lblCity.Text = c.City;
            lblState.Text = c.State;
            lblDOB.Text = c.DOB;
            pb.Image = Access.ConvertBytesToImage(c.Picture);
            PopulateOrderHistory();
        }

        // Methods

        private void PopulateOrderHistory()
        {
            fp.SuspendLayout();

            List<Order> li = Access.GetOrderList(cust);

            foreach (Order o in li)
            {

                Panel p = new Panel()
                {
                    Size = new Size(845, 220),
                    BackColor = Color.FromArgb(0, 102, 204)
                };

                Label label101 = new Label()
                {
                    Text = "Recipient:",
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = new Font("Sitka Small", 9, FontStyle.Regular),
                    Location = new Point(26, 7),
                    AutoSize = true
                };

                Label RecepientName = new Label()
                {
                    Text = o.RecepientName,
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = new Font("Sitka Small", 12, FontStyle.Regular),
                    Location = new Point(24, 22),
                    AutoSize = true,
                };

                Label RecepientAddress = new Label()
                {
                    Text = o.Address,
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = new Font("Sitka Small", 9, FontStyle.Regular),
                    Location = new Point(26, 195),
                    AutoSize = true
                };

                Label RecepientPhone = new Label()
                {
                    Text = o.Phone,
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = new Font("Sitka Small", 9, FontStyle.Regular),
                    Location = new Point(26, 174),
                    AutoSize = true
                };

                Label OrderDate = new Label()
                {
                    Text = o.OrderDate.ToShortDateString(),
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = new Font("Sitka Small", 9, FontStyle.Regular),
                    Location = new Point(740, 5)
                };

                Label Label89 = new Label()
                {
                    Text = "Order ID #",
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = new Font("Sitka Small", 12, FontStyle.Regular),
                    Location = new Point(351, 6),
                    AutoSize = true

                };

                Label OrderId = new Label()
                {
                    Text = o.Id.ToString(),
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = new Font("Times New Roman", 14, FontStyle.Bold),
                    Location = new Point(447, 10)
                };

                Label Label32 = new Label()
                {
                    Text = "Item Information",
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = new Font("Sitka Small", 9, FontStyle.Regular),
                    Location = new Point(189, 55),
                    AutoSize = true

                };

                Label Label13 = new Label()
                {
                    Text = "Amount Paid :",
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = new Font("Sitka Small", 9, FontStyle.Regular),
                    Location = new Point(609, 54),
                    AutoSize = true

                };

                Label AmountPaid = new Label()
                {
                    Text = o.AmountPaid.ToString(),
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = new Font("Sitka Small", 9, FontStyle.Regular),
                    Location = new Point(716, 55),
                    AutoSize = true

                };

                PictureBox box = new PictureBox()
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Access.ConvertBytesToImage(o.Picture),
                    Size = new Size(119, 107),
                    Location = new Point(30, 64)
                };

                RichTextBox tb = new RichTextBox()
                {
                    Text = o.Items,
                    Location = new Point(191, 76),
                    Size = new Size(626, 117),
                    Font = new Font("Sitka Small", 9, FontStyle.Regular),
                };

                //Set tooltip texts

                toolTip1.SetToolTip(RecepientName, "Recipient Name");
                toolTip1.SetToolTip(RecepientAddress, "Recipient Address");
                toolTip1.SetToolTip(OrderDate, "Order Date");
                toolTip1.SetToolTip(AmountPaid, "Amount Paid by Customer");
                toolTip1.SetToolTip(box, "Recipient Image");
                toolTip1.SetToolTip(RecepientPhone, "Recipient Phone");


                //Adding controls to panel

                p.Controls.Add(label101); p.Controls.Add(RecepientName); p.Controls.Add(RecepientAddress); p.Controls.Add(RecepientPhone); p.Controls.Add(OrderId);
                p.Controls.Add(OrderDate); p.Controls.Add(Label89); p.Controls.Add(Label32); p.Controls.Add(box); p.Controls.Add(tb); p.Controls.Add(Label13);
                p.Controls.Add(AmountPaid);

                fp.Controls.Add(p);
            }

            fp.ResumeLayout(true);
        }

        // Events

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void panelTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }
    }
}
