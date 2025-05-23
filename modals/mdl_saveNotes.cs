﻿using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using IdeasAi.db;
using IdeasAi.Ideas;

namespace IdeasAi.modals
{
    public partial class mdl_saveNotes : Form
    {
        public MainForm mainForm;
        public DBObjectManager saver_obj;
        public mdl_saveNotes(MainForm _mainForm)
        {
            InitializeComponent();
            this.mainForm = _mainForm;


        }
        private void frm_modal_Load(object sender, EventArgs e)
        {
            txb_setNoteTitle.Text = saver_obj.Input;
            var ownerForm = mainForm;
            this.Location = ModalManager.CenterLocation(ownerForm.Width, ownerForm.Height, this.Width, this.Height, ownerForm.Location.X, ownerForm.Location.Y);

            txb_setNoteTitle.SelectionStart = txb_setNoteTitle.Text.Length; ;
            txb_setNoteTitle.SelectionLength = 0;
        }

        
        private void btn_save_Click(object sender, EventArgs e)
        {

            try 
            {
                var idea_save_obj = new DBObjectManager();
                idea_save_obj.UUID = saver_obj.UUID;
                idea_save_obj.Title = txb_setNoteTitle.Text;
                idea_save_obj.Input = saver_obj.Input;
                idea_save_obj.Content = saver_obj.Content;
                idea_save_obj.DateCreated = saver_obj.DateCreated;


                mainForm.dbManager_Note.saveObject(idea_save_obj);

                mainForm.loadForm(mainForm.frm_notebook, mainForm.getPnlContent());
                mainForm.setActiveBtn(mainForm.getBtnNotebook(), mainForm.getPnlPageTabs());
                mainForm.frm_notebook.setActiveBtn(mainForm.frm_notebook.getBtnNotesTab(), mainForm.frm_notebook.getTbpnlTabs());
                mainForm.frm_notebook.displaySavedIdeas(mainForm.dbManager_Note);

                mainForm.addNotification("success", "Successfully saved!", txb_setNoteTitle.Text);
            }
            catch(Exception ex)
            {
                mainForm.addNotification("error", "Saving Failed", ex.Message);
            }


            
            // Load the notebook form into the content panel
            mainForm.BringToFront();
            this.Hide();

        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Owner.BringToFront();
            this.Hide();
        }

        private void txb_setNoteTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txb_setNoteTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var idea_save_obj = new DBObjectManager();
                idea_save_obj.UUID = saver_obj.UUID;
                idea_save_obj.Title = txb_setNoteTitle.Text;
                idea_save_obj.Input = saver_obj.Input;
                idea_save_obj.Content = saver_obj.Content;
                idea_save_obj.DateCreated = saver_obj.DateCreated;

                mainForm.dbManager_Note.saveObject(idea_save_obj);

                mainForm.loadForm(mainForm.frm_notebook, mainForm.getPnlContent());
                mainForm.setActiveBtn(mainForm.getBtnNotebook(), mainForm.getPnlPageTabs());
                mainForm.frm_notebook.setActiveBtn(mainForm.frm_notebook.getBtnNotesTab(), mainForm.frm_notebook.getTbpnlTabs());
                mainForm.frm_notebook.displaySavedIdeas(mainForm.dbManager_Note);

                mainForm.addNotification("success", "Successfully saved!", txb_setNoteTitle.Text);
                // Load the notebook form into the content panel
                mainForm.BringToFront();
                this.Hide();
            }
            
        }
    }
}
