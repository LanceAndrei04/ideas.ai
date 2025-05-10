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
            lbl_message.Text = message;
            lbl_msgType.Dock = DockStyle.Fill;
            lbl_msgType.TextAlign = ContentAlignment.MiddleCenter;

            switch (type)
            {
                case MessageType.Success:
                    lbl_msgType.Text = "Success";
                    header.BackColor = Color.FromArgb(152, 229, 135);
                    lbl_msgType.BackColor = Color.FromArgb(152, 229, 135);
                    btn_ok.Visible = true;
                    btn_cancel.Visible = false;
                    break;
                case MessageType.Warning:
                    lbl_msgType.Text = "Warning";
                    header.BackColor = Color.FromArgb(255, 189, 89);
                    lbl_msgType.BackColor = Color.FromArgb(255, 189, 89);
                    btn_ok.Visible = true;
                    btn_cancel.Visible = false;
                    break;
                case MessageType.Question:
                    lbl_msgType.Text = "Confirm";
                    header.BackColor = Color.FromArgb(92, 225, 230);
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
    }
}
