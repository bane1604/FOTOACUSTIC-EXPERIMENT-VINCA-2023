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
        Thread expt = null;



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


        public int get_vreme_merenja()
        {
            return Convert.ToInt32(vremepucanjatb.Text);
        }


        private void data_callbackR(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int i = Convert.ToInt32(button.Name.Substring(1));

            double[] a = EXPERIMENT_LIB.get_R_data(i);
            

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

            int x = datagrid.Location.X;
            int y = datagrid.Location.Y;



            for (int i = 0; i < val; i++)
            {
                datagrid.Rows.Add();
                statuslabels[i] = new Label();
                statuslabels[i].Location = new Point(x + 400, y + (i + 1) * 25);
                statuslabels[i].Text = "Status: Waiting";
                statuslabels[i].Visible = true;
                Controls.Add(statuslabels[i]);

                raw_data_buttons[i] = new Button();
                raw_data_buttons[i].Location = new Point(x + 500, y + (i + 1) * 25);
                raw_data_buttons[i].Text = "RawData";
                raw_data_buttons[i].Name = "R" + i.ToString();
                raw_data_buttons[i].Click += data_callbackR;
                raw_data_buttons[i].Visible = true;
                raw_data_buttons[i].UseVisualStyleBackColor = true;


                raw_data_buttons[i].Enabled = true;
                Controls.Add(raw_data_buttons[i]);
            }



        }

        public void update_status(String val, int i)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string, int>(update_status), new object[] { val, i });
                return;
            }

            statuslabels[i].Text = val;

        }


        private static int par1;

        private static int par2;
        private static int par3;
        private static int par4;

        private void start_exp()
        {
            EXPERIMENT_LIB.begin_experiment(
                par1, par2, par3, par4,
                this
                );
        }

        private void button4_Click(object sender, EventArgs e)
        {


            par1 = Convert.ToInt32(cbbrojmerenja.SelectedItem.ToString());
            par2 = Convert.ToInt32(cbsamplerate.Text);
            par3 = Convert.ToInt32(tbvremeakvizicije.Text);
            par4 = Convert.ToInt32(vremepucanjatb.Text);

            for (int i = 0; i < par1; i++)
            {
                EXPERIMENT_LIB.snaga[i] = (int)Math.Ceiling((Convert.ToDouble(datagrid.Rows[i].Cells[0].Value.ToString()) * 255.0) / 100.0);

                EXPERIMENT_LIB.frekv[i] = Convert.ToInt32(datagrid.Rows[i].Cells[1].Value.ToString());

                EXPERIMENT_LIB.duty[i] = Convert.ToInt32(datagrid.Rows[i].Cells[2].Value.ToString()) / 5;
            }
            expt = new Thread(start_exp);
            expt.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            expt.Interrupt();
        }

    }
}
