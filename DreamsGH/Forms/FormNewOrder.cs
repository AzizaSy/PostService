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
    public partial class FormNewOrder : Form
    {
        Order o = new Order();
        Customer cust;

        public FormNewOrder(Customer c)
        {
            InitializeComponent();
            cust = c;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            lblCustomerId.Text = c.Id.ToString();
            lblFullName.Text = c.FirstName + " " + c.LastName;
            lblPhoneNumber.Text = c.Phone;
            lblAddress.Text = c.Address;
            lblCity.Text = c.City;
            lblState.Text = c.State;
            lblDOB.Text = c.DOB;
            lblDate.Text = DateTime.Now.ToShortDateString();
            pb.Image = Access.ConvertBytesToImage(c.Picture);
            //btnClear_Click(this, new EventArgs());
            lblOrderId.Text = Access.GetNextOrderID();
        }

        // Methods

        private void ReloadOrder()
        {
            o.Id = Convert.ToInt32(Access.GetNextOrderID());
            o.CustomerId = cust.Id;
            o.RecepientName = tbName.Text;
            o.Address = tbAddress.Text;
            o.Phone = tbPhone.Text;
            o.Picture = Access.ConvertImageToBytes(pbRecepientImage.Image);
            o.OrderDate = DateTime.Now;
            o.Items = tbItems.Text;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            pbRecepientImage.Image = Properties.Resources.image_not_found;
            tbName.Text = "";
            tbPhone.Text = "";
            tbAddress.Text = "";
            tbItems.Text = "";
            lblOrderId.Text = Access.GetNextOrderID();
            ReloadOrder();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ReloadOrder();
            foreach (char s in tbAmountPaid.Text)
            {
                if (!Char.IsNumber(s) && !Char.IsPunctuation(s))
                {
                    MessageBox.Show("Amount Paid can only contain numbers. Please validate!", Application.ProductName);
                    return;
                }
            }
            if (String.IsNullOrEmpty(tbAmountPaid.Text))
                tbAmountPaid.Text = "0";
            else
                o.AmountPaid = Convert.ToDouble(tbAmountPaid.Text.Trim());
            Access.InsertOrder(o);
            MessageBox.Show("Order was successfully registered.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pbRecepientImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.png;*jpeg;";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(ofd.FileName))
                        pbRecepientImage.Image = Image.FromFile(ofd.FileName);
                }
            }
        }
    }
}
