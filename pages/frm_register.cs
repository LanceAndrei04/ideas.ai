using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeasAi.pages
{
    public partial class frm_register : Form
    {
       
        private MainForm mainForm;

        public frm_register(MainForm mainform)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            string username = txb_reg_user.Text.Trim();
            string password = txb_reg_pw.Text;
            string confirmPassword = txb_reg_confpw.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string passwordError = ValidatePassword(password, confirmPassword);
            if (passwordError != null)
            {
                MessageBox.Show(passwordError, "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Registration successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            mainForm.removeForm(this, mainForm.pnl_menuSect);

        }

        private string ValidatePassword(string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                return "Password fields cannot be empty.";

            if (password.Length < 8)
                return "Password must be at least 8 characters long.";

            if (!password.Any(char.IsDigit))
                return "Password must contain at least one number.";

            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                return "Password must contain at least one special character.";

            if (password != confirmPassword)
                return "Passwords do not match.";

            return null; // No errors
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainForm.removeForm(this, mainForm.pnl_menuSect);
            mainForm.loadForm(mainForm.frm_login, mainForm.pnl_menuSect);
        }
    }
}
