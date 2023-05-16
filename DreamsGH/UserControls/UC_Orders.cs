using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DreamsGH.Classes;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using DreamsGH.Forms;
using System.IO;

namespace DreamsGH.UserControls
{
    public partial class UC_Orders : UserControl
    {
        public UC_Orders()
        {
            InitializeComponent();
            LoadCustomerName();
            dg.AutoGenerateColumns = false;
            PopulateDataGrid();
        }

        private void LoadCustomerName()
        {
            tbSearch.AutoCompleteCustomSource = Access.GetAutoCompleteStringCollection("SELECT RecepientName FROM Orders");
        }

        private void PopulateDataGrid()
        {
            dg.DataSource = Access.GetOrderTable();
        }

        private void dgCustomer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Clear();
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (cbxFilter.selectedValue)
                {
                    case "Order Id":
                        dg.DataSource = Access.GetOrderTable(tbSearch.Text.Trim(), true);
                        break;
                    case "Recipient":
                        dg.DataSource = Access.GetOrderTable(tbSearch.Text.Trim());

                        break;
                    case "Address":
                        dg.DataSource = Access.GetOrderTable(tbSearch.Text.Trim());

                        break;
                    case "Phone":
                        dg.DataSource = Access.GetOrderTable(tbSearch.Text.Trim());

                        break;
                    default:
                        break;
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            dg.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = $"Orders";
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

        private void btnImport_Click(object sender, EventArgs e)
        {
            FormImportOrder f = new FormImportOrder();
            f.ShowDialog();
            PopulateDataGrid();
        }

        private void dp_onValueChanged(object sender, EventArgs e)
        {
            dg.DataSource = Access.GetOrderTable(dp.Value);
        }

        private void dg_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == this.dg.Columns["Items"].Index) && e.Value != null)
            {
                DataGridViewCell cell =
                    this.dg.Rows[e.RowIndex].Cells[e.ColumnIndex];

                cell.ToolTipText = cell.Value.ToString();
            }
        }

        private void dg_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView dgv_sender = sender as DataGridView;
            //DataGridViewCell dgv_MouseOverCell = null;
            //if (e.RowIndex > 0 && e.ColumnIndex > 0 && e.RowIndex < dgv_sender.RowCount && e.ColumnIndex < dgv_sender.ColumnCount)
            //{
            //    dgv_MouseOverCell = dgv_sender.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //}
            //if (dgv_MouseOverCell != null)
            //    if (e.ColumnIndex == 6)
            //    {
            //        if (dgv_MouseOverCell.Value != null)
            //        {
            //            Image img = Access.ConvertBytesToImage((byte[])dgv_MouseOverCell.Value);
            //            //Image img = Image.FromFile(dgv_MouseOverCell.Value.ToString());
            //            pictureBox1.ImageLocation = dgv_MouseOverCell.Value.ToString();
            //            pictureBox1.Location = new System.Drawing.Point(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y);
            //            pictureBox1.Visible = true;
            //            pictureBox1.Image = img;
            //        }
            //    }
        }

        private void dg_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            //pictureBox1.Visible = false;
        }

        private void cbxFilter_onItemSelected(object sender, EventArgs e)
        {
            switch (cbxFilter.selectedValue)
            {
                case "Order Id":
                    tbSearch.AutoCompleteCustomSource = Access.GetAutoCompleteStringCollection("SELECT Id FROM Orders;", true);
                    break;
                case "Recipient":
                    tbSearch.AutoCompleteCustomSource = Access.GetAutoCompleteStringCollection("SELECT RecepientName FROM Orders");
                    break;
                case "Address":
                    tbSearch.AutoCompleteCustomSource = Access.GetAutoCompleteStringCollection("SELECT Address FROM Orders");

                    break;
                case "Phone":
                    tbSearch.AutoCompleteCustomSource = Access.GetAutoCompleteStringCollection("SELECT Phone FROM Orders");

                    break;
                default:
                    break;
            }
        }
    }
}
