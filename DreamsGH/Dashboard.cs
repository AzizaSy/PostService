using FontAwesome.Sharp;
using DreamsGH.Classes;
using DreamsGH.Forms;
using DreamsGH.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DreamsGH
{
    public partial class Dashboard : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn = new Panel();
        private Login log;

        public Dashboard()
        {
            InitializeComponent();
            //Form
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            UC_Dashboard uc = new UC_Dashboard();
            uc.Dock = DockStyle.Fill;
            panelFill.Controls.Add(uc);

        }

        public Dashboard(Login login)
        {
            InitializeComponent();
            //Form
            log = login;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            UC_Dashboard uc = new UC_Dashboard();
            uc.Dock = DockStyle.Fill;
            panelFill.Controls.Add(uc);
        }

        //FormHandeling

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //structs

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 218);
            public static Color color4 = Color.FromArgb(95, 77, 121);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //Methods

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButtons();
                //button Customization
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(27, 38, 59);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //leftBorder customization
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Update Current Button Icon and text
                pbCurrentControlIcon.IconChar = currentBtn.IconChar;
                pbCurrentControlIcon.IconColor = currentBtn.IconColor;
                labelCurrentControl.Text = currentBtn.Text;
                labelCurrentControl.ForeColor = currentBtn.IconColor;
            }
        }

        private void DisableButtons()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(26, 32, 40);
                currentBtn.ForeColor = Color.FromArgb(224, 224, 224);
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.FromArgb(224, 224, 224);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(UserControl childForm)
        {
            //if (currentChildForm != null)
            //{
            //    //open only one form at a time
            //    currentChildForm.Close();
            //}
            panelFill.Controls.Clear();
            childForm.Dock = DockStyle.Fill;
            panelFill.Tag = childForm;
            panelFill.Controls.Add(childForm);
            labelCurrentControl.Text = currentBtn.Text;
            childForm.BringToFront();
        }

        //Menu Clicks

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.WhiteSmoke);
            OpenChildForm(new UC_Dashboard());
        }

        private void btnNewMedicine_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.WhiteSmoke);
            OpenChildForm(new UC_Customers());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.WhiteSmoke);
            OpenChildForm(new UC_Settings(log));
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.WhiteSmoke);
            OpenChildForm(new UC_Orders());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();
            frm.Show();
            this.Hide();
        }
    }
}
