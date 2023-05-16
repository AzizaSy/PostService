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
using System.Data.SqlClient;

namespace DreamsGH.Forms
{
    public partial class FormImportOrder : Form
    {
        public FormImportOrder()
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
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                DapperPlusManager.Entity<Order>().Table("Orders");
                List<Order> customers = orderBindingSource.DataSource as List<Order>;
                if (customers != null)
                {
                    using (IDbConnection cnn = new SqlConnection(DB.ConnectionString))
                    {
                        cnn.BulkInsert(customers);
                        MessageBox.Show("Orders imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cbxSheet.SelectedItem.ToString()];
            //dg.DataSource = dt;

            if (dt != null)
            {
                List<Order> customers = new List<Order>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Order c = new Order();
                    c.Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                    c.CustomerId = Convert.ToInt32(dt.Rows[i]["Customer Id"].ToString());
                    c.Address = dt.Rows[i]["Address"].ToString();
                    c.RecepientName = dt.Rows[i]["Recipient Name"].ToString();
                    c.Items = dt.Rows[i]["Items"].ToString();
                    c.Phone = dt.Rows[i]["Phone"].ToString();
                    if (dt.Rows[i]["Order Date"].ToString() != null && dt.Rows[i]["Order Date"].ToString() != "")
                    {
                        c.OrderDate = Convert.ToDateTime(dt.Rows[i]["Order Date"].ToString());
                    }
                    c.AmountPaid = Convert.ToDouble(dt.Rows[i]["Amount Paid"].ToString());
                    //c.Picture = (byte[])dt.Rows[i]["Picture"];
                    customers.Add(c);
                }
                orderBindingSource.DataSource = customers;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelCurrentControl_Click(object sender, EventArgs e)
        {

        }

        private void tbFilename_TextChanged(object sender, EventArgs e)
        {

        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ordersBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
