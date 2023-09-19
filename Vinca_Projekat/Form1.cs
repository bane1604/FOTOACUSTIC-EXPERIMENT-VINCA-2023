using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using Vinca_Projekat.lib;
using System.Runtime.InteropServices;


namespace Vinca_Projekat
{
    public partial class Form1 : Form
    {
        String[] ports = SerialPort.GetPortNames();
        String[] baud_rates = { "115200" };
        Thread t = null;




        public void AppendTextBox2(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox2), new object[] { value });
                return;
            }
            richTextBox2.Text += value;
        }

        public void EnableButtons(string val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(EnableButtons), new object[] { val });
                return;
            }
            button2.Enabled = true;
            button4.Enabled = true;
        }

        public void DisableButtons(string val)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(DisableButtons), new object[] { val });
                return;
            }
            button2.Enabled = false;
            button4.Enabled = false;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Serial_Driver_Laser.Disconnect();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Serial_Driver_Laser.is_Connected())
            {
                Serial_Driver_Laser.Disconnect();
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                button6.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;

                button1.Text = "Connect";
            }
            else
            {
                Serial_Driver_Laser.Connect(comboBox1.GetItemText(comboBox1.SelectedItem), 115200, this);
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;

                button1.Text = "Disconnect";
            }

        }


        private void PWM()
        {
            int S = (int)Math.Ceiling((Convert.ToDouble(textBox1.Text) * 255.0) / 100.0);
            DisableButtons("");
            Console.WriteLine(textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text);
            bool val = Serial_Driver_Laser.laser_start(S, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text) / 5);
            if (val)
                EnableButtons("");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            t = new Thread(PWM);
            t.Start();
        }

        private void Testerica()
        {
            int S = (int)Math.Ceiling((Convert.ToDouble(textBox1.Text) * 255.0) / 100.0);
            DisableButtons("");
            Console.WriteLine(textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text);
            bool val = Serial_Driver_Laser.laser_testerica(S, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            if (val)
            {
                EnableButtons("");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            t = new Thread(Testerica);
            t.Start();
        }



        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            comboBox1.DataSource = ports;


            String[] baud_rates = { "115200" };
            comboBox2.DataSource = baud_rates;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (t != null && t.IsAlive)
            {
                t.Interrupt();
                t.Join();
                t = null;
                EnableButtons("");
            }


        }

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
                cmndlckin.Enabled = false;
                sndcmndlckin.Enabled = false;
                richTextBox2.Enabled = false;
                button9.Enabled = false;
            }
            else
            {
                bool retval = SR850_LOCK_IN_DRIVER.Connect(comboBox3.GetItemText(comboBox3.SelectedItem), 9600, this);

                if (retval)
                {
                    button8.Text = "Disconnect";
                    cmndlckin.Enabled = true;
                    sndcmndlckin.Enabled = true;
                    richTextBox2.Enabled = true;
                    button9.Enabled = true;
                }
            }
        }

        private void sndcmndlckin_Click(object sender, EventArgs e)
        {
            SR850_LOCK_IN_DRIVER.send_command(cmndlckin.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(textBox4.Text);

                if (x > 100)
                {
                    textBox4.Text = "100";
                    return;
                }

                x = x - x % 5;
                textBox4.Text = x.ToString();

            }
            catch
            {
                textBox4.Text = "50";
            }
        }
    }
}
