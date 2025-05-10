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

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            mainForm.removeForm(this, mainForm.pnl_menuSect);


        }

        private void link_register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainForm.removeForm(this, mainForm.pnl_menuSect);
            mainForm.loadForm(mainForm.frm_register, mainForm.pnl_menuSect);
        }
    }
}
