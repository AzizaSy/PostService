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
    public partial class FormImport : Form
    {
        public FormImport()
        {
            InitializeComponent();
        }

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

        DataTableCollection tableCollection;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tbFilename.Text = ofd.FileName;
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            cbxSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                            {
                                cbxSheet.Items.Add(table.TableName);
                            }
                        }
                    }
                }
            }
        }

        private void cbxSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cbxSheet.SelectedItem.ToString()];
            //dg.DataSource = dt;

            if (dt != null)
            {
                List<Customer> customers = new List<Customer>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Customer c = new Customer();
                    //c.Name = dt.Rows[i]["Name"].ToString();
                    //c.Email = dt.Rows[i]["Email"].ToString();
                    //c.Address = dt.Rows[i]["Address"].ToString();
                    //c.City = dt.Rows[i]["City"].ToString();
                    //c.PostalCode = dt.Rows[i]["Postal Code"].ToString();
                    //c.State = dt.Rows[i]["State"].ToString();
                    //c.Phone = dt.Rows[i]["Phone"].ToString();
                    //if (dt.Rows[i]["Order Date"].ToString() != null && dt.Rows[i]["Order Date"].ToString() != "")
                    //{
                    //    c.OrderDate = Convert.ToDateTime(dt.Rows[i]["Order Date"].ToString());
                    //}

                    //c.OrderTime = dt.Rows[i]["Time"].ToString();
                    //c.EbayID = dt.Rows[i]["Ebay"].ToString();
                    //customers.Add(c);
                }
                customerBindingSource.DataSource = customers;
            }
        }

        private void cbxTables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                DapperPlusManager.Entity<Customer>().Table("Customers");
                List<Customer> customers = customerBindingSource.DataSource as List<Customer>;
                if (customers != null)
                {
                    using (IDbConnection cnn = DB.Connect)
                    {
                        cnn.BulkInsert(customers);
                        MessageBox.Show("Customers imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
