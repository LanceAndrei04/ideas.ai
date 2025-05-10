namespace IdeasAi.pages
{
    partial class MessageDialog
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
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_message = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.PictureBox();
            this.lbl_msgType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.header)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(229)))), ((int)(((byte)(135)))));
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(187, 152);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(123, 36);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(177)))));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(44, 152);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(123, 36);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_message.Location = new System.Drawing.Point(12, 94);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(162, 20);
            this.lbl_message.TabIndex = 3;
            this.lbl_message.Text = "This is a message";
            this.lbl_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(229)))), ((int)(((byte)(135)))));
            this.header.Location = new System.Drawing.Point(-1, -2);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(375, 50);
            this.header.TabIndex = 4;
            this.header.TabStop = false;
            // 
            // lbl_msgType
            // 
            this.lbl_msgType.AutoSize = true;
            this.lbl_msgType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(229)))), ((int)(((byte)(135)))));
            this.lbl_msgType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_msgType.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_msgType.Location = new System.Drawing.Point(0, 0);
            this.lbl_msgType.Name = "lbl_msgType";
            this.lbl_msgType.Size = new System.Drawing.Size(117, 20);
            this.lbl_msgType.TabIndex = 5;
            this.lbl_msgType.Text = "Message Type";
            // 
            // MessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(374, 218);
            this.Controls.Add(this.lbl_msgType);
            this.Controls.Add(this.header);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageDialog";
            ((System.ComponentModel.ISupportInitialize)(this.header)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.PictureBox header;
        private System.Windows.Forms.Label lbl_msgType;
    }
}