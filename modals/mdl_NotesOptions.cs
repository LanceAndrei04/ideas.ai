﻿using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace IdeasAi.modals
{
    public partial class mdl_NotesOptions : Form
    {
        int confirm_count = 0;
        public MainForm mainForm;
        public Guid obj_id;
        public string current_title;
        private string oldTitle;
        public mdl_NotesOptions(MainForm _mainForm)
        {
            this.mainForm = _mainForm;
            InitializeComponent();
        }
        private void mdl_NotesOptions_Load(object sender, EventArgs e)
        {
            txb_setNoteTitle.Text = mainForm.frm_notebook.saver_obj.Title;
            oldTitle = txb_setNoteTitle.Text;

            var ownerForm = mainForm;
            this.Location = ModalManager.CenterLocation(ownerForm.Width, ownerForm.Height, this.Width, this.Height, ownerForm.Location.X, ownerForm.Location.Y);

            txb_setNoteTitle.SelectionStart = txb_setNoteTitle.Text.Length; ;
            txb_setNoteTitle.SelectionLength = 0;
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            

            mainForm.dbManager_Note.modifyField(mainForm.frm_notebook.saver_obj.UUID, "Title", txb_setNoteTitle.Text);

            if (!txb_setNoteTitle.Text.Equals(oldTitle))
            {
                mainForm.dbManager_Note.modifyField(mainForm.frm_notebook.saver_obj.UUID, "Date_modified", DateTime.Now);
                mainForm.addNotification("Success", "Successfully saved!", txb_setNoteTitle.Text);
            }
            
            mainForm.frm_notebook.displaySavedIdeas(mainForm.dbManager_Note);
            mainForm.Focus();

        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            
            confirm_count++;

            if(confirm_count == 2)
            {
                mainForm.dbManager_Note.deleteRecord(mainForm.frm_notebook.saver_obj.UUID);
                confirm_count = 0;
                btn_delete.Text = "Delete";
                mainForm.frm_notebook.displaySavedIdeas(mainForm.dbManager_Note);

                this.Visible = false ;
                mainForm.Focus();
            }

            btn_delete.Text = "Click again to confirm";
        }
        private void txb_setNoteTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Call your save method here
                btn_save_Click(sender, e);

                // Prevent the default behavior (e.g., beep sound)
                e.SuppressKeyPress = true;
                Hide();
            }
        }

        //GETTERS
        public ref KryptonTextBox getTxbTitle()
        {
            return ref txb_setNoteTitle;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            mainForm.modalBG.Hide();
            this.Hide();
        }


    }
}
