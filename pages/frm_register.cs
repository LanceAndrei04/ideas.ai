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
using static IdeasAi.pages.MessageDialog;

namespace IdeasAi.pages
{
    public partial class frm_register : Form
    {
       
        private MainForm mainForm;
    

        public frm_register(MainForm mainForm)
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
                MessageDialog.Show("Username cannot be empty.", "Warning", MessageType.Warning);
                return;
            }

            string passwordError = ValidatePassword(password, confirmPassword);
            if (passwordError != null)
            {
                MessageDialog.Show(passwordError, "Password Error", MessageType.Warning);
                return;
            }

            MessageDialog.Show("Registration successful.", "Success",MessageType.Success);
            txb_reg_user.Clear();
            txb_reg_pw.Clear();
            txb_reg_confpw.Clear();
            mainForm.btn_addTab.Visible = true;
            this.Hide();
            


        }

        private string ValidatePassword(string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                return "Password fields cannot be empty.";

            if (password.Length < 8) {
                txb_reg_confpw.Clear();
                txb_reg_pw.Clear();
                return "Password must be at least 8 characters long.";
            }
               

            if (!password.Any(char.IsDigit))
            {
                txb_reg_confpw.Clear();
                txb_reg_pw.Clear();
                return "Password must contain at least one number.";
            }

            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                txb_reg_confpw.Clear();
                txb_reg_pw.Clear();
                return "Password must contain at least one special character.";
            }
              

            if (password != confirmPassword)
            {
                txb_reg_confpw.Clear();
                txb_reg_pw.Clear();
                return "Passwords do not match.";
            }

            return null; // No errors
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          mainForm.loadForm(mainForm.frm_login, mainForm.pnl_menuSect);
        }
    }
}
