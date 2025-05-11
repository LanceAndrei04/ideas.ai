using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeasAi.pages
{
    public partial class frm_login : Form
    {
        private MainForm mainForm;
        public frm_login(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            mainForm.resetToHome();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txb_login_user.Text.Trim();
            string password = txb_login_pw.Text;

            // Validate Username
            if (string.IsNullOrEmpty(username))
            {
                MessageDialog.Show("Username cannot be empty.", "Login Error", MessageDialog.MessageType.Warning);
                return;
            }

            // Validate Password
            if (string.IsNullOrEmpty(password))
            {
                MessageDialog.Show("Password cannot be empty.", "Login Error", MessageDialog.MessageType.Warning);
                return;
            }

            if (password.Length < 8)
            {
                MessageDialog.Show("Password must be at least 8 characters long.", "Login Error", MessageDialog.MessageType.Warning);
                txb_login_pw.Clear();
                return;
            }

            if (password == "thiserror")
            {
                MessageDialog.Show("Wrong password.", "Login Failed", MessageDialog.MessageType.Warning);
                txb_login_pw.Clear();
                return;
            }

            // Success
            MessageDialog.Show("Login successful!", "Success", MessageDialog.MessageType.Success);
            txb_login_pw.Clear();
            txb_login_user.Clear();
            mainForm.removeForm(this, mainForm.pnl_menuSect);
            mainForm.btn_addTab.Visible = true;


        }

        private void link_register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainForm.removeForm(this, mainForm.pnl_menuSect);
            mainForm.loadForm(mainForm.frm_register, mainForm.pnl_menuSect);
        }
    }
}
