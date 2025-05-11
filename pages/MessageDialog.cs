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
    public partial class MessageDialog : Form
    {
        public enum MessageType
        {
            Success,
            Warning,
            Question
        }

        public DialogResult Result { get; private set; }
        public MessageDialog(string message, string title, MessageType type)
        {
            InitializeComponent();
            this.Text = title;
            lbl_message.MaximumSize = new Size(300, 0); // Width = 300px, unlimited height
            lbl_message.Size = new Size(300, lbl_message.PreferredHeight); // Let height adjust
            lbl_message.Text = message;
            pnl_message.Resize += panel_message_Resize;


            switch (type)
            {
                case MessageType.Success:
                    lbl_msgType.Text = "Success";
                    dialog_color.BackColor = Color.FromArgb(152, 229, 135);
                    lbl_msgType.BackColor = Color.FromArgb(152, 229, 135);
                    btn_ok.Visible = true;
                    btn_cancel.Visible = false;
                    break;
                case MessageType.Warning:
                    lbl_msgType.Text = "Warning";
                    dialog_color.BackColor = Color.FromArgb(255, 189, 89);
                    lbl_msgType.BackColor = Color.FromArgb(255, 189, 89);
                    btn_ok.Visible = true;
                    btn_cancel.Visible = false;
                    break;
                case MessageType.Question:
                    lbl_msgType.Text = "Confirm";
                    dialog_color.BackColor = Color.FromArgb(92, 225, 230);
                    lbl_msgType.BackColor = Color.FromArgb(92, 225, 230);
                    btn_ok.Text = "Confirm";
                    btn_ok.Visible = true;
                    btn_cancel.Visible = true;
                    break;
            }

            btn_ok.Click += (s, e) => { Result = DialogResult.OK; this.Close(); };
            btn_cancel.Click += (s, e) => { Result = DialogResult.Cancel; this.Close(); };
        }

        public static DialogResult Show(string message, string title, MessageType type)
        {
            using (var dialog = new MessageDialog(message, title, type))
            {
                dialog.ShowDialog();
                return dialog.Result;
            }
        }

        private void panel_message_Resize(object sender, EventArgs e)
        {
            lbl_message.Left = (pnl_message.Width - lbl_message.Width) / 2;
            lbl_message.Top = (pnl_message.Height - lbl_message.Height) / 2;
            lbl_msgType.Left = (dialog_color.Width - lbl_msgType.Width) / 2;
            lbl_msgType.Top = (dialog_color.Height - lbl_msgType.Height) / 2;
        }

        
    }
}
