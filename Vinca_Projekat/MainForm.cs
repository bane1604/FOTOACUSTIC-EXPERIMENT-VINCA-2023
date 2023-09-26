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
    public partial class MainForm : Form
    {
        String[] ports = SerialPort.GetPortNames();
        String[] baud_rates = { "115200" };
        LaserTestForm mylaserfrm = null;
        LockInTest mylockintestfrm = null;
        Label[] statuslabels = new Label[10];
        Button[] raw_data_buttons = new Button[10];




        public MainForm()
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
                button1.Text = "Connect";
                button2.Enabled = false;
            }
            else
            {
                if (Serial_Driver_Laser.Connect(comboBox1.GetItemText(comboBox1.SelectedItem), 115200, this))
                {
                    button1.Text = "Disconnect";
                    button2.Enabled = true;
                }
            }

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
                bool retval = SR850_LOCK_IN_DRIVER.Connect(comboBox3.GetItemText(comboBox3.SelectedItem), 9600, null);

                if (retval)
                {
                    button8.Text = "Disconnect";
                    button3.Enabled = true;
                }
            }
        }





        private void button2_Click(object sender, EventArgs e)
        {
            if (LaserTestForm.inuse == false)
            {
                mylaserfrm = new LaserTestForm();
                mylaserfrm.Show();
                mylaserfrm.Focus();
                LaserTestForm.inuse = true;
            }
            else
            {
                mylaserfrm.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (LockInTest.inuse == false)
            {
                mylockintestfrm = new LockInTest();
                mylockintestfrm.Show();
                mylockintestfrm.Focus();
                SR850_LOCK_IN_DRIVER.my_form = mylockintestfrm;
                LockInTest.inuse = true;
            }
            else
            {
                mylockintestfrm.Focus();
                SR850_LOCK_IN_DRIVER.my_form = null;
            }
        }

        private void cbbrojmerenja_SelectedValueChanged(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(cbbrojmerenja.SelectedItem.ToString());

            for (int i = 0; i < 10; i++)
            {
                if (statuslabels[i] != null)
                {
                    Controls.Remove(statuslabels[i]);
                    statuslabels[i].Dispose();
                    statuslabels[i] = null;
                }

                if (raw_data_buttons[i] != null)
                {
                    Controls.Remove(raw_data_buttons[i]);
                    raw_data_buttons[i].Dispose();
                    raw_data_buttons[i] = null;
                }
            }

            datagrid.Rows.Clear();

            for (int i = 0; i < val; i++)
            {
                datagrid.Rows.Add();
                statuslabels[i] = new Label();
                statuslabels[i].Location = new Point(322, 265 + (i + 1) * 25);
                statuslabels[i].Text = "Status: Waiting";
                statuslabels[i].BackColor = Color.Yellow;
                statuslabels[i].Visible = true;
                Controls.Add(statuslabels[i]);

                raw_data_buttons[i] = new Button();
                raw_data_buttons[i].Location = new Point(425, 265 + (i + 1) * 25);
                raw_data_buttons[i].Text = "RawData";
                raw_data_buttons[i].Visible = true;
                raw_data_buttons[i].UseVisualStyleBackColor = true;
                raw_data_buttons[i].Enabled = false;
                Controls.Add(raw_data_buttons[i]);
            }

           
        }
    }
}
