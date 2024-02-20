using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vinca_Projekat.lib;

namespace Vinca_Projekat
{
    public partial class LockInTest : Form
    {

        public static bool inuse = false;
        public LockInTest()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void LockInTest_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void clrbtn_Click(object sender, EventArgs e)
        {
            outputtb.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inuse = false;
            SR850_LOCK_IN_DRIVER.releaseForm();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SR850_LOCK_IN_DRIVER.send_command(cmndtb.Text);
        }

        public void Output(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Output), new object[] { value });
                return;
            }
            outputtb.Text += value;
        }

        private void LockInTest_Load(object sender, EventArgs e)
        {
            SR850_LOCK_IN_DRIVER.setForm
                (this);
        }
    }
}
