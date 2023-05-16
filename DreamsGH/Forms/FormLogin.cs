using DreamsGH.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DreamsGH.Forms
{
    public partial class FormLogin : Form
    {
        Login log = new Login();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLogin())
            {
                if (Authenticate())
                {
                    Dashboard ds = new Dashboard(log);
                    ds.Show();
                    this.Hide();
                }
            }
        }

        private bool ValidateLogin()
        {
            if (tbUsername.Text.Length == 0)
            {
                MessageBox.Show("Username can not be empty", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (tbPassword.Text.Length == 0)
            {
                MessageBox.Show("Password can not be empty", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool Authenticate()
        {
            if (Access.GetInteger($"SELECT COUNT(*) from Login WHERE Username = '{tbUsername.Text.Trim()}'") <= 0)
            {
                MessageBox.Show("No account exists with this username.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //get password
            log = Access.GetLogin(tbUsername.Text.Trim());

            if (log.Password != tbPassword.Text)
            {
                MessageBox.Show("Your password is incorrect", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
