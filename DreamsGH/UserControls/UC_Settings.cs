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

namespace DreamsGH.UserControls
{
    public partial class UC_Settings : UserControl
    {
        Login log;

        public UC_Settings()
        {
            InitializeComponent();
        }

        public UC_Settings(Login login)
        {
            InitializeComponent();
            log = login;
            if (log.Id != 1)
            {
                groupBox2.Enabled = false;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text != tbConfirm.Text)
            {
                MessageBox.Show("Password do not match.", "Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Access.ChangePassword(log.Username, tbPassword.Text.Trim());
            MessageBox.Show("Password was successfully changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text.Length == 0 || tbPass.Text.Length == 0)
            {
                MessageBox.Show("Invalid Username or Password", "Fields can't be empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Access.InsertUser(tbUsername.Text.Trim(), tbPass.Text.Trim());
            MessageBox.Show("Account was successfully registered", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
