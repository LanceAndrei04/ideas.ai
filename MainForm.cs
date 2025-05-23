﻿using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using IdeasAi.PageForms;


using IdeasAi.modals;
using IdeasAi.db;
using System.Web.UI.Design;
using System.IO;
using Newtonsoft.Json.Linq;
using IdeasAi.Properties;
using System.Text.RegularExpressions;
using IdeasAi.pages;
using System.Collections.Generic;

namespace IdeasAi
{
    public partial class MainForm : Form
    {
        //show or hide side pnl
        private bool showMode = true;
        public bool sliding = false;
        PictureBox pb_active;

        //tabs
        public List<PageTab> tabs;

        // json configs
        public JObject decors;
        public JObject settings;

        // database
        public DBManager_Note dbManager_Note;
        public DBManager_Docs dbManager_Docs;

        //pnl_header configs
        private bool isDragging = false;
        private Point lastCursorPosition;
        private bool isFullScreen = false;
        private FormWindowState normalWindowState;

        //loading states
        public const int state_loadMindmap = 1;
        public const int state_loadConsultation = 2;

        // PAGE FORMS
        public frm_home frm_home;
        //public frm_consultation frm_consultation;
        public frm_workspace frm_workspace;
        public frm_notebook frm_notebook;
        public frm_mindmap frm_mindmap;
        public frm_SPLASH frm_Splash;
        public frm_login frm_login;
        public frm_register frm_register;
        //
        // MODALS
        //
        public Form modalBG;
        //public mdl_notebookSettings mdl_notebookSettings;
        //public mdl_saveNotes mdl_save;
        //public mdl_saveDocs mdl_saveDocs;
        //public mdl_NotesOptions mdl_editNotes;
        //public mdl_DocsOptions mdl_editDocs;
        public mdl_organize mdl_organize;
        public mdl_loading mdl_loading;
        public ModalManager mdl_setter;

        public Button btn_active;
        

        public MainForm(frm_SPLASH FRM_SPLASH)
        {


            InitializeComponent();
            InitializeConfigs();


            this.frm_Splash = FRM_SPLASH; 
            
            dbManager_Note = new DBManager_Note(this);
            dbManager_Docs = new DBManager_Docs(this);

            frm_home = new frm_home(this);
            //frm_consultation = new frm_consultation(this);
            frm_notebook =  new frm_notebook(this);
            frm_mindmap = new frm_mindmap(this);
            frm_workspace = new frm_workspace(this);
            frm_login = new frm_login(this);
            frm_register = new frm_register(this);


            mdl_loading = new mdl_loading(this);
            modalBG = new Form();
            mdl_organize = new mdl_organize(this);
            mdl_setter = new ModalManager(this);

            pb_active = new PictureBox();
            pb_active.BackColor = Color.Transparent;
            pb_active.Image = Resources.activeState;
            pb_active.Dock = DockStyle.Left;
            pb_active.SizeMode = PictureBoxSizeMode.CenterImage;
            pb_active.Size = new Size(37, 48);

            btn_active = btn_mindmap;
            lbl_currentPage.Text = btn_active.Text;
            btn_howToUse.Enabled = false;

            tabs = new List<PageTab>();

            loadForm(frm_login, pnl_menuSect);
            loadForm(frm_home, pnl_content);
            setActiveBtn((object)btn_home, pnl_pageTabs);
            setThemeMode("light");

        }

        private void InitializeConfigs()
        {
            using (StreamReader reader = File.OpenText("configs/decors.json"))
            {
                string decorsJson = reader.ReadToEnd();
                decors = JObject.Parse(decorsJson);
            }
            setSettingsConfig();
            
        }
        public void setSettingsConfig()
        {
            using (StreamReader reader = File.OpenText("configs/settings.json"))
            {
                string settingsJson = reader.ReadToEnd();
                settings = JObject.Parse(settingsJson);
            }
        }

        public static string ConvertMarkdownToPlainText(string markdown)
        {
            // Remove Markdown bold formatting
            string plainText = Regex.Replace(markdown, @"\*\*(.*?)\*\*", "$1");

            // Remove Markdown italic formatting
            plainText = Regex.Replace(plainText, @"\*(.*?)\*", "$1");

            // Replace line breaks
            plainText = Regex.Replace(plainText, "<br>", "\n");

            // You can add more rules to handle other Markdown formatting

            return plainText;
        }
        public void setModalBackground(Form callerForm)
        {
            modalBG.Owner = this;
            modalBG.StartPosition = FormStartPosition.Manual;
            modalBG.FormBorderStyle = FormBorderStyle.None;
            modalBG.Opacity = .50d;
            modalBG.BackColor = Color.Black;
            modalBG.Size = this.Size;
            modalBG.Location = callerForm.Owner.Location;
            modalBG.ShowInTaskbar = false;
            modalBG.Show();
        }
        public void setNotifPosition()
        {
            int offset = mdl_notif.instancesCount;
            foreach (var c in this.Controls)
            {
                if (c is mdl_notif)
                {
                    mdl_notif notifControl = c as mdl_notif;
                    if (notifControl != null)
                    {
                        int notifX = (this.Width - notifControl.Width) - 34;
                        int notifY = (this.Height) - ((notifControl.Height + 5) * offset--);

                        if (notifY > (this.Height) - (notifControl.Height + 5)) notifY = (this.Height - (notifControl.Height)) - (notifControl.Height + 5); 

                        notifControl.Location = new Point(notifX, notifY);
                    }
                }
            }
        }

        public void loadForm(Form frm, Control container)
        {
            removeForm(frm, container);
            frm.Owner = this;
            frm.TopLevel = false;
            container.Controls.Add(frm);
            frm.BringToFront();
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
        public void removeForm(Form frm, Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is Form form)
                {
                    container.Controls.Remove(control);

                    break;
                }
            }
        }
        public void setActiveBtn(object btn, Panel pnl)
        {
            if ((Button)btn != btn_active && btn_active != null)
            {
                
                

                removeActiveBtn();
                btn_active = (Button)btn;
                btn_active.Parent.Controls.Add(pb_active);
                btn_active.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["LightTheme"]["accent"]);
                lbl_currentPage.Text = btn_active.Text.Trim();
            }
        }
        private void removeActiveBtn()
        {
            if(btn_active != null)
            {
                btn_active.Parent.Controls.Remove(pb_active);
                btn_active.BackColor = Color.Transparent;
            }

        }


        public void addNotification(string type, string typeTxt, string typeInfo)
        {
            var notif = new mdl_notif(this, type);
            notif.lbl_type.Text = typeTxt;

            if (mdl_notif.instancesCount > 1) notif.lbl_type.Text = typeTxt;

            notif.lbl_info.Text = typeInfo;
            notif.TopLevel = false;
            this.Controls.Add(notif);
            notif.Show();
            notif.BringToFront();
        }
        public mdl_notif addAsyncNotification(string type, string typeTxt, string typeInfo)
        {
            var notif = new mdl_notif(this, type);
            notif.lbl_type.Text = typeTxt;

            if (mdl_notif.instancesCount > 1) notif.lbl_type.Text = typeTxt;

            notif.lbl_info.Text = typeInfo;
            notif.TopLevel = false;
            this.Controls.Add(notif);
      
            return notif;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            setNotifPosition();

        }
        private void btn_home_Click(object sender, EventArgs e)
        {
            btn_howToUse.Enabled = false;
            setActiveBtn(sender, pnl_pageTabs);

            if (tabs.Count > 0)
            {
                tabs[tabs.Count - 1].removeActive();

            }

            loadForm(frm_home, pnl_content);
        }
        private void btn_consultation_Click(object sender, EventArgs e)
        {
            Console.WriteLine(tabs.Count);
            btn_howToUse.Enabled = true;
            if(tabs.Count <= 0)
            {
                btn_addTab.PerformClick();
            }
            else
            {
                tabs[tabs.Count - 1].container_Click();
            }
        }
        private void btn_workspace_Click(object sender, EventArgs e)
        {
            btn_howToUse.Enabled = true;
            setActiveBtn(sender, pnl_pageTabs);
            if (tabs.Count > 0)
            {
                tabs[tabs.Count - 1].removeActive();
            }
            loadForm(frm_workspace, pnl_content);
        }        
        private void btn_notebook_Click(object sender, EventArgs e)
        {
            btn_howToUse.Enabled = true;
            InitializeConfigs();
            frm_notebook.showAllIdeas();
            setActiveBtn(sender, pnl_pageTabs);
            if (tabs.Count > 0)
            {
                tabs[tabs.Count - 1].removeActive();
            }
            loadForm(frm_notebook, pnl_content);

        }
        private void btn_mindmap_Click(object sender, EventArgs e)
        {
            btn_howToUse.Enabled = true;
            setActiveBtn(sender, pnl_pageTabs);
            if (tabs.Count > 0)
            {
                tabs[tabs.Count - 1].removeActive();
            }
            loadForm(frm_mindmap, pnl_content);
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageDialog.Show(
             "Are you sure you want to logout?",
             "Confirm Logout",
             MessageDialog.MessageType.Question 
     );

            if (result == DialogResult.OK)
            {
                resetToHome();

                if (frm_login == null)
                {
                    frm_login = new frm_login(this);
                }

                loadForm(frm_login, pnl_menuSect);
            }
        }

        public void resetToHome()
        {
            loadForm(frm_home, pnl_content);
            lbl_currentPage.Text = "Home";
            btn_addTab.Visible = false;
            setActiveBtn(btn_home, pnl_pageTabs);
            frm_home.SetGetStartedClickable(true);
        }

        private void btn_howToUse_Click(object sender, EventArgs e)
        {
            var currentActivBtn = btn_active.Text.Trim();
            var contentToDisplay = "";

            if (currentActivBtn == btn_home.Text.Trim())
            {
                contentToDisplay = frm_home.howToUse;
            }
            else if (currentActivBtn == btn_notebook.Text.Trim())
            {
                contentToDisplay = frm_notebook.howToUse;

            }
            else if (currentActivBtn == btn_workspace.Text.Trim())
            {
                contentToDisplay = frm_workspace.howToUse;

            }
            else if (currentActivBtn == btn_mindmap.Text.Trim())
            {
                contentToDisplay = frm_mindmap.howToUse;

            }
            else if (currentActivBtn == btn_consultation.Text.Trim())
            {
                contentToDisplay = frm_consultation.howToUse;

            }

            ModalManager.ShowModal(this, frm_home, new mdl_howToUse(this, currentActivBtn, contentToDisplay));

        }
        private void btn_toggleDarkMode_Click(object sender, EventArgs e)
        {
            if (btn_toggleDarkMode.Dock == DockStyle.Right)
            {
                setThemeMode("dark");
            }
            else
            {
                setThemeMode("light");
            }
        }

        private void pnl_formHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPosition = e.Location;
            }
        }
        private void pnl_formHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.X - lastCursorPosition.X;
                int deltaY = e.Y - lastCursorPosition.Y;
                this.Location = new Point(this.Left + deltaX, this.Top + deltaY);
            }
        }
        private void pnl_formHeader_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
        private void pnl_formHeader_DoubleClick(object sender, EventArgs e)
        {
            ToggleFullScreen();
        }
        private void ToggleFullScreen()
        {
            if (isFullScreen)
            {
                this.WindowState = normalWindowState;
                isFullScreen = false;
            }
            else
            {
                normalWindowState = this.WindowState;
                this.WindowState = FormWindowState.Maximized;
                isFullScreen = true;
            }
        }

        public void setThemeMode(string theme)
        {
            switch (theme.ToLower())
            {
                case "light":
                    toggleLightMode();
                    break;
                case "dark":
                    toggleDarkMode();
                    break;
            }
        }
        private void toggleDarkMode()
        {
            btn_toggleDarkMode.Dock = DockStyle.Left;


            this.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["DarkTheme"]["primary"]);
            this.pnl_menuSect.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["DarkTheme"]["primary100"]);
            frm_home.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["DarkTheme"]["primary100"]);
            frm_notebook.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["DarkTheme"]["primary100"]);
            frm_workspace.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["DarkTheme"]["primary100"]);
            frm_workspace.spl_workspace.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["DarkTheme"]["primary100"]);
            frm_mindmap.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["DarkTheme"]["primary100"]);
            frm_mindmap.spl_mindmap.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["DarkTheme"]["primary100"]);

            pnl_pageTitle.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["DarkTheme"]["primary100"]);

            pnl_btnCont.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["DarkTheme"]["primary100"]);
            btn_toggleDarkMode.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["LightTheme"]["primary100"]);
            btn_toggleDarkMode.Image = Resources.darkModeBtn;

            foreach(var tab in tabs)
            {
                tab.page.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["DarkTheme"]["primary100"]);
            }

        }
        private void toggleLightMode()
        {
            btn_toggleDarkMode.Dock = DockStyle.Right;


            this.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["LightTheme"]["primary"]);
            this.pnl_menuSect.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["LightTheme"]["primary100"]);
            frm_home.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["LightTheme"]["primary100"]);
            frm_notebook.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["LightTheme"]["primary100"]);
            frm_workspace.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["LightTheme"]["primary100"]);
            frm_workspace.spl_workspace.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["LightTheme"]["primary100"]);
            frm_mindmap.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["LightTheme"]["primary100"]);
            frm_mindmap.spl_mindmap.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["LightTheme"]["primary100"]);

            pnl_pageTitle.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["LightTheme"]["primary100"]);

            pnl_btnCont.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["DarkTheme"]["primary"]);
            btn_toggleDarkMode.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["DarkTheme"]["primary100"]);
            btn_toggleDarkMode.Image = Resources.lightModeBtn;

            foreach (var tab in tabs)
            {
                tab.page.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["LightTheme"]["primary100"]);
            }

        }
        private void sideBarExpand()
        {
            btn_home.ImageAlign = ContentAlignment.MiddleLeft;
            btn_workspace.ImageAlign = ContentAlignment.MiddleLeft;
            btn_notebook.ImageAlign = ContentAlignment.MiddleLeft;
            btn_mindmap.ImageAlign = ContentAlignment.MiddleLeft;
            btn_consultation.ImageAlign = ContentAlignment.MiddleLeft;
            btn_exit.ImageAlign = ContentAlignment.MiddleLeft;

            pnl_header.Size = new Size(214, 180);

            pb_active.Visible = true;
            pbx_logo.Image = Resources.app_logo;
            pbx_logo.Size = new Size(210, 145);

        }
        private void sideBarShrink()
        {

            btn_home.ImageAlign = ContentAlignment.MiddleCenter;
            btn_workspace.ImageAlign = ContentAlignment.MiddleCenter;
            btn_notebook.ImageAlign = ContentAlignment.MiddleCenter;
            btn_mindmap.ImageAlign = ContentAlignment.MiddleCenter;
            btn_consultation.ImageAlign = ContentAlignment.MiddleCenter;
            btn_exit.ImageAlign = ContentAlignment.MiddleCenter;


            pnl_header.Size = new Size(214, 110);

            pb_active.Visible = false;
            pbx_logo.Image = Resources.mini_logo;
            pbx_logo.Size = new Size(70, 70);


        }
        
        private void btn_showOrHide_Click(object sender, EventArgs e)
        {
            if (showMode)
            {
                showMode = false;
                sideBarShrink();
            }
            else
            {
                showMode = true;
                sideBarExpand();
            }
            tmr_animation.Start();
            sliding = true;
            pnl_sideContentHolder.Visible = false;

        }
        private void tmr_animation_Tick(object sender, EventArgs e)
        {
            int maxW = 320;
            int minW = 170;
            if(showMode)
            {
                if (pnl_sideContent.Width >= maxW)
                {
                    tmr_animation.Stop();
                    pnl_sideContent.Width = maxW;
                    pnl_sideContent.Width += 1;
                    sliding = false;
                    pnl_sideContent.Width -= 1;


                    pnl_sideContentHolder.Visible = true;



                }
                else
                {
                    pnl_sideContent.Width += 30;
                }
            }
            else
            {
                if (pnl_sideContent.Width <= minW)
                {
                    tmr_animation.Stop();
                    pnl_sideContent.Width = minW;
                    pnl_sideContent.Width += 1;
                    sliding = false;
                    pnl_sideContent.Width -= 1;
                    


                    pnl_sideContentHolder.Visible = true;



                }
                else
                {
                    pnl_sideContent.Width -= 30;
                }
            }
            
        }

        //GETTERS
        public ref Button getBtnNotebook()
        {
            return ref btn_notebook;
        }
        public ref Button getBtnWorkspace()
        {
            return ref btn_workspace;
        }
        public ref Button getBtnHome()
        {
            return ref btn_home;
        }
        public ref Button getBtnConsult()
        {
            return ref btn_consultation;
        }
        public ref Panel getPnlContent()
        {
            return ref pnl_content;
        }
        public ref Panel getPnlPageTabs()
        {
            return ref pnl_pageTabs; 
        }
        public ref Button getBtnMindmap()
        {
            return ref btn_mindmap; 
        }

        private void pnl_helpbtn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbx_logo_MouseHover(object sender, EventArgs e)
        {
            pbx_logo.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pbx_logo_MouseLeave(object sender, EventArgs e)
        {
            pbx_logo.BorderStyle = BorderStyle.None;
        }

        private void btn_appExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_appMax_Click(object sender, EventArgs e)
        {
            ToggleFullScreen();
        }

        public void btn_addTab_Click(object sender, EventArgs e)
        {
            Panel tabPnl = new Panel();
            tabPnl.Dock = DockStyle.Left;
            tabPnl.Size = new Size(180, 34);
            tabPnl.BackColor = ColorTranslator.FromHtml((string)decors["Themes"]["LightTheme"]["accent100"]);
            tabPnl.BorderStyle = BorderStyle.FixedSingle;

            Button btnClose = new Button();
            btnClose.Dock = DockStyle.Right;
            btnClose.Text = "X";
            btnClose.Size = new Size(40, 34); // Adjusted button size to match panel height
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            

            Label title = new Label();
            title.Font = new System.Drawing.Font("Cascadia Code", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title.AutoEllipsis = true;
            title.Padding = new Padding(5,6,5,0);
            title.Dock = DockStyle.Fill;

            tabPnl.Controls.Add(title);
            tabPnl.Controls.Add(btnClose);

            var pageTab = new PageTab(this, tabPnl, new frm_consultation(this), title, btnClose);

            tabs.Add(pageTab);
            

            pnl_addTab.Controls.Add(tabPnl);
        }



        

        private void pnl_addTab_ControlAdded(object sender, ControlEventArgs e)
        {
            pnl_addTab.Padding = new Padding(15,30,15,0);

            if (pnl_addTab.HorizontalScroll.Visible)
            {
                pnl_addTab.Padding = new Padding(15, 3, 15, 12);
            }
            else
            {
            }
        }

        private void pnl_addTab_SizeChanged(object sender, EventArgs e)
        {
            pnl_addTab.Padding = new Padding(15, 30, 15, 0);


            if (pnl_addTab.HorizontalScroll.Visible)
            {
                pnl_addTab.Padding = new Padding(15, 0, 15, 5);
            }
        }

        private void btn_appMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    
    }
}
