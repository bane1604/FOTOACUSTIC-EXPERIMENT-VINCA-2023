using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vinca_Projekat.lib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vinca_Projekat
{
    public partial class LaserTestForm : Form
    {
        public static bool inuse = false;
        private Thread t = null;

        public LaserTestForm()
        {
            InitializeComponent();
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void LaserTestForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void EnableButtons(string val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(EnableButtons), new object[] { val });
                return;
            }
            pwmbtn.Enabled = true;
            testericabtn.Enabled = true;
        }

        private void DisableButtons(string val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(DisableButtons), new object[] { val });
                return;
            }
            pwmbtn.Enabled = false;
            testericabtn.Enabled = false;
        }

        private void ForceStop()
        {
            if (t != null && t.IsAlive)
            {
                t.Interrupt();
                t.Join();
                t = null;
                EnableButtons("");
            }
        }

        private void dutytb_Leave(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dutytb.Text);

                if (x > 100)
                {
                    dutytb.Text = "100";
                    return;
                }

                x = x - x % 5;
                dutytb.Text = x.ToString();

            }
            catch
            {
                dutytb.Text = "50";
            }
        }

        private void PWM()
        {
            int S = (int)Math.Ceiling((Convert.ToDouble(snagatb.Text) * 255.0) / 100.0);
            DisableButtons("");

            bool val = Serial_Driver_Laser.laser_start(S, Convert.ToInt32(frekvtb.Text), Convert.ToInt32(vremetb.Text), Convert.ToInt32(dutytb.Text) / 5);
            if (val)
                EnableButtons("");

        }

        private void Testerica()
        {
            int S = (int)Math.Ceiling((Convert.ToDouble(snagatb.Text) * 255.0) / 100.0);
            DisableButtons("");

            bool val = Serial_Driver_Laser.laser_testerica(S, Convert.ToInt32(frekvtb.Text), Convert.ToInt32(vremetb.Text));
            if (val)
            {
                EnableButtons("");
            }
        }

        private void pwmbtn_Click(object sender, EventArgs e)
        {
            t = new Thread(PWM);
            t.Start();
        }

        private void testericabtn_Click(object sender, EventArgs e)
        {
            t = new Thread(Testerica);
            t.Start();
        }

        private void stpbutton_Click(object sender, EventArgs e)
        {
            ForceStop();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            ForceStop();
            inuse = false;
            this.Dispose();
        }

        private void LaserTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ForceStop();
            inuse = false;
        }
    }
}
