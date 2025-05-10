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

            switch (type)
            {
                case MessageType.Success:
                    pic_icon.Image = Properties.Resources.notifSuccess; 
                    btn_ok.Visible = true;
                    btn_cancel.Visible = false;
                    break;
                case MessageType.Warning:
                    pic_icon.Image = Properties.Resources.notifError;
                    btn_ok.Visible = true;
                    btn_cancel.Visible = false;
                    break;
                case MessageType.Question:
                    pic_icon.Image = Properties.Resources.notifInfo;
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
