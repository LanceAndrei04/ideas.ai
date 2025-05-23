﻿namespace IdeasAi.PageForms
{
    partial class frm_consultation
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_consultation));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_wbCont = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_searchMode = new System.Windows.Forms.Button();
            this.btn_toWorkspace = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_print = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnl_borderTxb = new System.Windows.Forms.Panel();
            this.pnl_txbCont = new System.Windows.Forms.Panel();
            this.txb_Consult = new System.Windows.Forms.RichTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_send = new System.Windows.Forms.Button();
            this.webViewContainer = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.panel1.SuspendLayout();
            this.pnl_wbCont.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnl_borderTxb.SuspendLayout();
            this.pnl_txbCont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webViewContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pnl_wbCont);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 616);
            this.panel1.TabIndex = 0;
            // 
            // pnl_wbCont
            // 
            this.pnl_wbCont.BackColor = System.Drawing.Color.Transparent;
            this.pnl_wbCont.Controls.Add(this.webViewContainer);
            this.pnl_wbCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_wbCont.Location = new System.Drawing.Point(0, 93);
            this.pnl_wbCont.Name = "pnl_wbCont";
            this.pnl_wbCont.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.pnl_wbCont.Size = new System.Drawing.Size(930, 459);
            this.pnl_wbCont.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.btn_searchMode);
            this.panel3.Controls.Add(this.btn_toWorkspace);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.btn_print);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.btn_save);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 552);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 12, 15, 10);
            this.panel3.Size = new System.Drawing.Size(930, 64);
            this.panel3.TabIndex = 11;
            // 
            // btn_searchMode
            // 
            this.btn_searchMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(229)))), ((int)(((byte)(135)))));
            this.btn_searchMode.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_searchMode.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_searchMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_searchMode.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_searchMode.Image = global::IdeasAi.Properties.Resources.chrome;
            this.btn_searchMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_searchMode.Location = new System.Drawing.Point(801, 12);
            this.btn_searchMode.Name = "btn_searchMode";
            this.btn_searchMode.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_searchMode.Size = new System.Drawing.Size(114, 42);
            this.btn_searchMode.TabIndex = 15;
            this.btn_searchMode.Text = "Google";
            this.btn_searchMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_searchMode.UseVisualStyleBackColor = false;
            this.btn_searchMode.Click += new System.EventHandler(this.btn_searchMode_Click);
            // 
            // btn_toWorkspace
            // 
            this.btn_toWorkspace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(229)))), ((int)(((byte)(135)))));
            this.btn_toWorkspace.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_toWorkspace.Enabled = false;
            this.btn_toWorkspace.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_toWorkspace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_toWorkspace.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_toWorkspace.Image = global::IdeasAi.Properties.Resources.workspace_small;
            this.btn_toWorkspace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_toWorkspace.Location = new System.Drawing.Point(249, 12);
            this.btn_toWorkspace.Name = "btn_toWorkspace";
            this.btn_toWorkspace.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_toWorkspace.Size = new System.Drawing.Size(154, 42);
            this.btn_toWorkspace.TabIndex = 12;
            this.btn_toWorkspace.Text = "Workspace";
            this.btn_toWorkspace.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_toWorkspace.UseVisualStyleBackColor = false;
            this.btn_toWorkspace.Click += new System.EventHandler(this.btn_toWorkspace_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(239, 12);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 42);
            this.panel7.TabIndex = 14;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(229)))), ((int)(((byte)(135)))));
            this.btn_print.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_print.Enabled = false;
            this.btn_print.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.Image = global::IdeasAi.Properties.Resources.print;
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.Location = new System.Drawing.Point(127, 12);
            this.btn_print.Name = "btn_print";
            this.btn_print.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_print.Size = new System.Drawing.Size(112, 42);
            this.btn_print.TabIndex = 11;
            this.btn_print.Text = "Print";
            this.btn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);

            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(117, 12);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 42);
            this.panel6.TabIndex = 14;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(229)))), ((int)(((byte)(135)))));
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_save.Enabled = false;
            this.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Image = global::IdeasAi.Properties.Resources.saveAsFile;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.Location = new System.Drawing.Point(16, 12);
            this.btn_save.Name = "btn_save";
            this.btn_save.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btn_save.Size = new System.Drawing.Size(101, 42);
            this.btn_save.TabIndex = 10;
            this.btn_save.Text = "Save";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(16, 42);
            this.panel4.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.pnl_borderTxb);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.btn_send);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(15);
            this.panel2.Size = new System.Drawing.Size(930, 93);
            this.panel2.TabIndex = 5;
            // 
            // pnl_borderTxb
            // 
            this.pnl_borderTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.pnl_borderTxb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_borderTxb.Controls.Add(this.pnl_txbCont);
            this.pnl_borderTxb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_borderTxb.Location = new System.Drawing.Point(15, 15);
            this.pnl_borderTxb.Name = "pnl_borderTxb";
            this.pnl_borderTxb.Padding = new System.Windows.Forms.Padding(10);
            this.pnl_borderTxb.Size = new System.Drawing.Size(834, 63);
            this.pnl_borderTxb.TabIndex = 3;
            // 
            // pnl_txbCont
            // 
            this.pnl_txbCont.BackColor = System.Drawing.Color.White;
            this.pnl_txbCont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_txbCont.Controls.Add(this.txb_Consult);
            this.pnl_txbCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_txbCont.Location = new System.Drawing.Point(10, 10);
            this.pnl_txbCont.Name = "pnl_txbCont";
            this.pnl_txbCont.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.pnl_txbCont.Size = new System.Drawing.Size(812, 41);
            this.pnl_txbCont.TabIndex = 2;
            // 
            // txb_Consult
            // 
            this.txb_Consult.AccessibleRole = System.Windows.Forms.AccessibleRole.Caret;
            this.txb_Consult.BackColor = System.Drawing.Color.White;
            this.txb_Consult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_Consult.BulletIndent = 1;
            this.txb_Consult.DetectUrls = false;
            this.txb_Consult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_Consult.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_Consult.ForeColor = System.Drawing.Color.Black;
            this.txb_Consult.Location = new System.Drawing.Point(10, 10);
            this.txb_Consult.Multiline = false;
            this.txb_Consult.Name = "txb_Consult";
            this.txb_Consult.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txb_Consult.Size = new System.Drawing.Size(788, 27);
            this.txb_Consult.TabIndex = 2;
            this.txb_Consult.Text = "What does \'Hello, world!\' mean?";
            this.txb_Consult.TextChanged += new System.EventHandler(this.txb_Consult_TextChanged);
            this.txb_Consult.Enter += new System.EventHandler(this.txb_Consult_Enter);
            this.txb_Consult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_Consult_KeyDown);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(849, 15);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 63);
            this.panel5.TabIndex = 3;
            // 
            // btn_send
            // 
            this.btn_send.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btn_send.AllowDrop = true;
            this.btn_send.BackColor = System.Drawing.Color.Transparent;
            this.btn_send.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_send.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_send.FlatAppearance.BorderSize = 0;
            this.btn_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_send.Image = ((System.Drawing.Image)(resources.GetObject("btn_send.Image")));
            this.btn_send.Location = new System.Drawing.Point(859, 15);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(56, 63);
            this.btn_send.TabIndex = 5;
            this.btn_send.TabStop = false;
            this.btn_send.UseMnemonic = false;
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // webViewContainer
            // 
            this.webViewContainer.AllowExternalDrop = true;
            this.webViewContainer.CreationProperties = null;
            this.webViewContainer.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webViewContainer.Location = new System.Drawing.Point(15, 0);
            this.webViewContainer.Name = "webViewContainer";
            this.webViewContainer.Size = new System.Drawing.Size(900, 459);
            this.webViewContainer.TabIndex = 8;
            this.webViewContainer.ZoomFactor = 1D;
            // 
            // frm_consultation
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(930, 616);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_consultation";
            this.Text = "frm_home";
            this.panel1.ResumeLayout(false);
            this.pnl_wbCont.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnl_borderTxb.ResumeLayout(false);
            this.pnl_txbCont.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webViewContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnl_txbCont;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_toWorkspace;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Panel pnl_borderTxb;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel pnl_wbCont;
        private System.Windows.Forms.Button btn_searchMode;
        public System.Windows.Forms.Button btn_send;
        public System.Windows.Forms.RichTextBox txb_Consult;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewContainer;
    }
}