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
using Excel = Microsoft.Office.Interop.Excel;
using DreamsGH.Forms;
using System.IO;

namespace DreamsGH.UserControls
{
    public partial class UC_Customers : UserControl
    {
        Customer cust = new Customer();

        public UC_Customers()
        {
            InitializeComponent();
            LoadCustomerID();
            LoadCustomerName();
            PopulateDataGrid();
            isValidTimeToUpdate = true;
        }

        //Methods

        private void LoadCustomerID()
        {
            labelCustomerId.Text = Access.GetNextCustomerID();
        }

        private void PopulateDataGrid()
        {
            dg.AutoGenerateColumns = false;
            dg.DataSource = Access.GetCustomerTable();
        }

        private void LoadCustomerName()
        {
            cbxFilter_onItemSelected(this, new EventArgs());
        }

        private void LoadCustomerIDByName(string name)
        {

        }

        private void PopulateCustomerDetails()
        {
            labelCustomerId.Text = cust.Id.ToString();
            tbFirstName.Text = cust.FirstName;
            tbLastName.Text = cust.LastName;
            tbPhoneNumber.Text = cust.Phone;
            dpDate.Value = Convert.ToDateTime(cust.DOB);
            tbAddress.Text = cust.Address;
            tbCity.Text = cust.City;
            tbState.Text = cust.State;
            pb.Image = Access.ConvertBytesToImage(cust.Picture);
            btnOrders.Text = $"Orders : {Access.GetOrderCountByCustomer(cust.Id)}";
        }

        private bool isValidTimeToUpdate = false;

        private byte[] ConvertImageToBytes(Image img)
        {
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }
            return arr;
        }

        private void ReloadCustomer()
        {
            cust.Id = Convert.ToInt32(labelCustomerId.Text);
            cust.FirstName = tbFirstName.Text;
            cust.LastName = tbLastName.Text;
            cust.Phone = tbPhoneNumber.Text;
            cust.DOB = dpDate.Value.ToShortDateString();
            cust.Address = tbAddress.Text;
            cust.City = tbCity.Text;
            cust.State = tbState.Text;
            cust.Picture = Access.ConvertImageToBytes(pb.Image);
        }

        //Events

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbFirstName.Text))
            {
                ReloadCustomer();
                Access.InsertCustomer(cust);
                MessageBox.Show("Customer was successfully registered.", Application.ProductName);

                LoadCustomerName();
                PopulateDataGrid();

            }
            else
            {
                MessageBox.Show("Please fill out the required details.", Application.ProductName);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (true)
            {
                ReloadCustomer();
                Access.DeleteCustomer(cust);
                MessageBox.Show("Customer was successfully deleted.", Application.ProductName);
                cbxFilter_onItemSelected(sender, e);
                PopulateDataGrid();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (true)
            {
                ReloadCustomer();
                Access.UpdateCustomer(cust);
                MessageBox.Show("Customer was successfully updated.", Application.ProductName);

                LoadCustomerName();
                PopulateDataGrid();
            }
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
                            PopulateCustomerDetails();
                            dg.DataSource = Access.GetCustomerTable(tbSearch.Text.Trim(), true);
                            break;
                        case "First Name":
                            dg.DataSource = Access.GetCustomerTable(tbSearch.Text.Trim());
                            cust = Access.GetCustomer(tbSearch.Text.Trim());
                            PopulateCustomerDetails();

                            break;
                        case "Last Name":

                            cust = Access.GetCustomer(tbSearch.Text.Trim());
                            PopulateCustomerDetails();
                            dg.DataSource = Access.GetCustomerTable(tbSearch.Text.Trim());
                            break;
                        case "Phone Number":
                            cust = Access.GetCustomer(tbSearch.Text.Trim());
                            PopulateCustomerDetails();

                            dg.DataSource = Access.GetCustomerTable(tbSearch.Text.Trim());
                            break;

                        case "Address":

                            cust = Access.GetCustomer(tbSearch.Text.Trim());
                            PopulateCustomerDetails();

                            dg.DataSource = Access.GetCustomerTable(tbSearch.Text.Trim());
                            break;
                        case "City":
                            cust = Access.GetCustomer(tbSearch.Text.Trim());
                            PopulateCustomerDetails();

                            dg.DataSource = Access.GetCustomerTable(tbSearch.Text.Trim());
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not retrieve Customer,\n" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgCustomer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isValidTimeToUpdate)
            {
                try
                {
                    //DataGridViewRow row = dgCustomer.Rows[e.RowIndex];
                    //string id = row.Cells["Id"].Value.ToString();

                    //SqlCommand cmd = new SqlCommand("UpdateCustomer")
                    //{
                    //    CommandType = CommandType.StoredProcedure
                    //};
                    ////LoadAccountIDByName(tbName.Text);
                    //cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    //cmd.Parameters.AddWithValue("@name", row.Cells["FullName"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@email", row.Cells["Email"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@address", row.Cells["Address"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@city", row.Cells["City"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@postal", row.Cells["PostalCode"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@state", row.Cells["State"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@phone", row.Cells["Phone"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@date", row.Cells["OrderDate"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@time", row.Cells["OrderTime"].Value.ToString());
                    //cmd.Parameters.AddWithValue("@ebay", row.Cells["EbayID"].Value.ToString());
                    //Access.ExecuteProcedure(cmd);

                    LoadCustomerName();
                    PopulateDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not update Customer.\n" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            dg.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = $"Customers";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Copy DataGridView results to clipboard
                copyAlltoClipboard();

                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlexcel = new Excel.Application();

                xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                // Format column D as text before pasting results, this was required for my data
                Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
                rng.NumberFormat = "@";

                // Paste clipboard results to worksheet range
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
                // Delete blank column A and select cell A1
                //Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                //delRng.Delete(Type.Missing);
                //xlWorkSheet.get_Range("A1").Select();

                // Save the excel file under the captured location from the SaveFileDialog
                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);

                // Clear Clipboard and DataGridView selection
                Clipboard.Clear();
                dg.ClearSelection();

                //Open the newly saved excel file
                //if (File.Exists(sfd.FileName))
                //System.Diagnostics.Process.Start(sfd.FileName);
            }


        }

        private void copyAlltoClipboard()
        {
            dg.SelectAll();
            DataObject dataObj = dg.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            tbFirstName.Clear();
            tbLastName.Clear();
            dpDate.Value = DateTime.Now;
            tbPhoneNumber.Clear();
            tbAddress.Clear();
            tbCity.Clear();
            tbState.Clear();
            pb.Image = Properties.Resources.image_not_found;
            labelCustomerId.Text = Access.GetNextCustomerID();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            FormImport imp = new FormImport();
            imp.ShowDialog();
            PopulateDataGrid();
            LoadCustomerName();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panelDataEntry_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pb_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.png;*jpeg;";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(ofd.FileName))
                        pb.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void labelCustomerId_TextChanged(object sender, EventArgs e)
        {
            btnOrders.Text = $"Orders : {Access.GetOrderCountByCustomer(cust.Id)}";
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            ReloadCustomer();
            FormViewOrders f = new FormViewOrders(cust);
            f.ShowDialog();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            ReloadCustomer();
            FormNewOrder f = new FormNewOrder(cust);
            f.ShowDialog();
            btnOrders.Text = $"Orders : {Access.GetOrderCountByCustomer(cust.Id)}";
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
