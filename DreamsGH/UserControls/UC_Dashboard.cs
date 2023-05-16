using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DreamsGH.Classes;
using DreamsGH.Forms;
using System.Security.AccessControl;

namespace DreamsGH.UserControls
{
    public partial class UC_Dashboard : UserControl
    {
        Customer cust = new Customer();

        public UC_Dashboard()
        {
            InitializeComponent();
            LoadDashboardContents();
            tbSearch.AutoCompleteCustomSource = Access.GetAutoCompleteStringCollection("SELECT FirstName FROM Customers");
        }

        private void LoadDashboardContents()
        {
            lblCustomers.Text = Access.GetInteger("SELECT COUNT(*) FROM Customers").ToString();
            lblOrders.Text = Access.GetInteger("SELECT COUNT(*) FROM Orders").ToString();
            lblUsers.Text = Access.GetInteger("SELECT COUNT(*) FROM Login").ToString();
            lblAmountReceived.Text = Access.GetDouble("SELECT SUM(AmountPaid) FROM Orders").ToString();
        }

        private void tbSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Clear();
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    switch (cbxFilter.selectedValue)
                    {
                        case "Id":
                            cust = Access.GetCustomer(tbSearch.Text.Trim(), true);
                            break;
                        case "First Name":
                            cust = Access.GetCustomer(tbSearch.Text.Trim());

                            break;
                        case "Last Name":
                            cust = Access.GetCustomer(tbSearch.Text.Trim());

                            break;
                        case "Phone Number":
                            cust = Access.GetCustomer(tbSearch.Text.Trim());

                            break;

                        case "Address":
                            cust = Access.GetCustomer(tbSearch.Text.Trim());

                            break;
                        case "City":
                            cust = Access.GetCustomer(tbSearch.Text.Trim());

                            break;
                        default:
                            break;
                    }
                    OpenForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not retrieve Customer,\n" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OpenForm()
        {
            FormViewOrders f = new FormViewOrders(cust);
            f.ShowDialog();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbxFilter_onItemSelected(object sender, EventArgs e)
        {
            switch (cbxFilter.selectedValue)
            {
                case "Id":
                    tbSearch.AutoCompleteCustomSource = Access.GetAutoCompleteStringCollection("SELECT Id FROM Customers", true);
                    break;
                case "First Name":
                    tbSearch.AutoCompleteCustomSource = Access.GetAutoCompleteStringCollection("SELECT FirstName FROM Customers");
                    break;
                case "Last Name":
                    tbSearch.AutoCompleteCustomSource = Access.GetAutoCompleteStringCollection("SELECT LastName FROM Customers");

                    break;
                case "Phone Number":
                    tbSearch.AutoCompleteCustomSource = Access.GetAutoCompleteStringCollection("SELECT PhoneNumber FROM Customers");

                    break;

                case "Address":
                    tbSearch.AutoCompleteCustomSource = Access.GetAutoCompleteStringCollection("SELECT Address FROM Customers");

                    break;
                case "City":
                    tbSearch.AutoCompleteCustomSource = Access.GetAutoCompleteStringCollection("SELECT City FROM Customers");

                    break;
                default:
                    break;
            }
        }
    }
}
