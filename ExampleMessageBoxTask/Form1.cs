using System;
using System.Windows.Forms;

namespace ExampleMessageBoxTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fieldButtons.SelectedIndex = 0;
            fieldIcons.SelectedIndex = 0;
            fieldDefaultButton.SelectedIndex = 0;
        }

        private string GetMessage()
        {
            var result = @"Some text";
            try
            {
                result = fieldMessage.Text;
            }
            catch (Exception)
            {
                //
            }
            return result;
        }

        private int GetTimeOut()
        {
            var result = 10;
            try
            {
                result = Convert.ToInt32(fieldTimeout.Value);
            }
            catch (Exception)
            {
                //
            }
            return result;
        }

        private MessageBoxButtons GetButtons()
        {
            var buttons = MessageBoxButtons.OK;
            try
            {
                switch (fieldButtons.SelectedIndex)
                {
                    case 0:
                        buttons = MessageBoxButtons.AbortRetryIgnore;
                        break;
                    case 1:
                        buttons = MessageBoxButtons.OK;
                        break;
                    case 2:
                        buttons = MessageBoxButtons.OKCancel;
                        break;
                    case 3:
                        buttons = MessageBoxButtons.RetryCancel;
                        break;
                    case 4:
                        buttons = MessageBoxButtons.YesNo;
                        break;
                    case 5:
                        buttons = MessageBoxButtons.YesNoCancel;
                        break;
                    default:
                        buttons = MessageBoxButtons.OK;
                        break;
                }
            }
            catch (Exception)
            {
                //
            }
            return buttons;
        }

        private MessageBoxIcon GetIcons()
        {
            var icons = MessageBoxIcon.None;
            try
            {
                switch (fieldIcons.SelectedIndex)
                {
                    case 0:
                        icons = MessageBoxIcon.Asterisk;
                        break;
                    case 1:
                        icons = MessageBoxIcon.Error;
                        break;
                    case 2:
                        icons = MessageBoxIcon.Exclamation;
                        break;
                    case 3:
                        icons = MessageBoxIcon.Hand;
                        break;
                    case 4:
                        icons = MessageBoxIcon.Information;
                        break;
                    case 5:
                        icons = MessageBoxIcon.None;
                        break;
                    case 6:
                        icons = MessageBoxIcon.Question;
                        break;
                    case 7:
                        icons = MessageBoxIcon.Stop;
                        break;
                    case 8:
                        icons = MessageBoxIcon.Warning;
                        break;
                    default:
                        icons = MessageBoxIcon.None;
                        break;
                }
            }
            catch (Exception)
            {
                //
            }
            return icons;
        }

        private MessageBoxDefaultButton GetDefaultButtons()
        {
            var defaultButtons = MessageBoxDefaultButton.Button1;
            try
            {
                switch (fieldDefaultButton.SelectedIndex)
                {
                    case 0:
                        defaultButtons = MessageBoxDefaultButton.Button1;
                        break;
                    case 1:
                        defaultButtons = MessageBoxDefaultButton.Button2;
                        break;
                    case 2:
                        defaultButtons = MessageBoxDefaultButton.Button3;
                        break;
                    default:
                        defaultButtons = MessageBoxDefaultButton.Button1;
                        break;
                }
            }
            catch (Exception)
            {
                //
            }
            return defaultButtons;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var messageBoxTask = new UtilsMessageBoxTask(GetMessage(), Application.ProductName,
                GetTimeOut(), GetButtons(), GetIcons(), GetDefaultButtons()))
            {
                messageBoxTask.Show(this);
            }
        }
    }
}
