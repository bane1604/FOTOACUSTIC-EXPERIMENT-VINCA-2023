using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vinca_Projekat.lib;

namespace Vinca_Projekat
{
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();
            if( SR850_LOCK_IN_DRIVER.is_Connected() ) { button3.Enabled = true; }
            if( Serial_Driver_Laser.is_Connected()) { button2.Enabled = true; }
        }


        //LOCK IN
        private void button7_Click(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            comboBox3.DataSource = ports;


            String[] baud_rates = { "9600" };
            comboBox4.DataSource = baud_rates;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (SR850_LOCK_IN_DRIVER.is_Connected())
            {
                SR850_LOCK_IN_DRIVER.Disconnect();


                button8.Text = "Connect";
                button3.Enabled = false;

            }
            else
            {
                bool retval = SR850_LOCK_IN_DRIVER.Connect(comboBox3.GetItemText(comboBox3.SelectedItem), 9600);

                if (retval)
                {
                    button8.Text = "Disconnect";
                    button3.Enabled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            using (LockInTest mylockintestfrm = new LockInTest())
            {
                mylockintestfrm.ShowDialog();
            }
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void ConnectionForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            comboBox1.DataSource = ports;


            String[] baud_rates = { "115200" };
            comboBox2.DataSource = baud_rates;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Serial_Driver_Laser.is_Connected())
            {
                Serial_Driver_Laser.Disconnect();
                button1.Text = "Connect";
                button2.Enabled = false;
            }
            else
            {
                if (Serial_Driver_Laser.Connect(comboBox1.GetItemText(comboBox1.SelectedItem), 115200, null))
                {
                    button1.Text = "Disconnect";
                    button2.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            using( LaserTestForm mylaserfrm = new LaserTestForm())
            {
                mylaserfrm.ShowDialog();
            }
            this.Visible = true;
        }
    }
}
