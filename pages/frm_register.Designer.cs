namespace IdeasAi.pages
{
    partial class frm_register
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_reg_user = new System.Windows.Forms.TextBox();
            this.txb_reg_pw = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_reg_confpw = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btn_register = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::IdeasAi.Properties.Resources.app_logo;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(1, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 152);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "REGISTER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-2, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // txb_reg_user
            // 
            this.txb_reg_user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_reg_user.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_reg_user.Location = new System.Drawing.Point(2, 253);
            this.txb_reg_user.Name = "txb_reg_user";
            this.txb_reg_user.Size = new System.Drawing.Size(229, 25);
            this.txb_reg_user.TabIndex = 4;
            // 
            // txb_reg_pw
            // 
            this.txb_reg_pw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_reg_pw.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_reg_pw.Location = new System.Drawing.Point(2, 314);
            this.txb_reg_pw.Name = "txb_reg_pw";
            this.txb_reg_pw.Size = new System.Drawing.Size(229, 25);
            this.txb_reg_pw.TabIndex = 6;
            this.txb_reg_pw.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-2, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // txb_reg_confpw
            // 
            this.txb_reg_confpw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_reg_confpw.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_reg_confpw.Location = new System.Drawing.Point(2, 380);
            this.txb_reg_confpw.Name = "txb_reg_confpw";
            this.txb_reg_confpw.Size = new System.Drawing.Size(229, 25);
            this.txb_reg_confpw.TabIndex = 8;
            this.txb_reg_confpw.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-2, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Confirm Password";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(34, 451);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(117, 20);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Log in here.";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btn_register
            // 
            this.btn_register.BackColor = System.Drawing.SystemColors.Window;
            this.btn_register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_register.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_register.Image = global::IdeasAi.Properties.Resources.add;
            this.btn_register.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_register.Location = new System.Drawing.Point(28, 492);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(153, 45);
            this.btn_register.TabIndex = 12;
            this.btn_register.Text = "Register";
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Already have an account?";
            // 
            // frm_register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 624);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txb_reg_confpw);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_reg_pw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_reg_user);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_register";
            this.Text = "frm_register";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_reg_user;
        private System.Windows.Forms.TextBox txb_reg_pw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_reg_confpw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Label label5;
    }
}