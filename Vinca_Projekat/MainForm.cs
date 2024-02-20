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
using IronXL;
using System.IO;
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
        Button[] rbuttons = new Button[10];
        Button[] tbuttons = new Button[10];
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





<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes






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
            return 10000;
        }


        private void data_callbackT(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int i = Convert.ToInt32(button.Name.Substring(1));

            double[] a = EXPERIMENT_LIB.get_R_data(i);

            double[] test = new double[a.Length - 9];

            for (int ix = 5; ix < a.Length - 4; ix++)
            {
                test[ix - 5] = a[ix];
            }

            new ViewData(test, par2).Show();
        }

        private void data_callbackR(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int i = Convert.ToInt32(button.Name.Substring(1));

            double[] a = EXPERIMENT_LIB.get_T_data(i);

            double[] test = new double[a.Length - 9];

            for (int ix = 5; ix < a.Length - 4; ix++)
            {
                test[ix - 5] = a[ix];
            }


            new ViewData(test, par2).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (LockInTest.inuse == false)
            {
                mylockintestfrm = new LockInTest();
                mylockintestfrm.Show();
                mylockintestfrm.Focus();
                SR850_LOCK_IN_DRIVER.setForm(mylockintestfrm);
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

                if (rbuttons[i] != null)
                {
                    Controls.Remove(rbuttons[i]);
                    rbuttons[i].Dispose();
                    rbuttons[i] = null;
                }

                if (tbuttons[i] != null)
                {
                    Controls.Remove(tbuttons[i]);
                    tbuttons[i].Dispose();
                    tbuttons[i] = null;
                }
            }

            datagrid.Rows.Clear();

            int x = datagrid.Location.X;
            int y = datagrid.Location.Y;



            for (int i = 0; i < val; i++)
            {
                datagrid.Rows.Add();
                /*
                statuslabels[i] = new Label();
                statuslabels[i].Location = new Point(x + 400, y + (i + 1) * 25);
                statuslabels[i].Text = "Status: Waiting";
                statuslabels[i].Visible = true;
                Controls.Add(statuslabels[i]);

                rbuttons[i] = new Button();
                rbuttons[i].Location = new Point(x + 500, y + (i + 1) * 25);
                rbuttons[i].Text = "View R";
                rbuttons[i].Name = "R" + i.ToString();
                rbuttons[i].Click += data_callbackR;
                rbuttons[i].Visible = true;
                rbuttons[i].UseVisualStyleBackColor = true;
                rbuttons[i].Enabled = false;
                Controls.Add(rbuttons[i]);

                tbuttons[i] = new Button();
                tbuttons[i].Location = new Point(x + 600, y + (i + 1) * 25);
                tbuttons[i].Text = "View T";
                tbuttons[i].Name = "T" + i.ToString();
                tbuttons[i].Click += data_callbackT;
                tbuttons[i].Visible = true;
                tbuttons[i].UseVisualStyleBackColor = true;
                tbuttons[i].Enabled = false;
                Controls.Add(tbuttons[i]);
                */
            }



        }

        public void EnableRbutton(int i)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(EnableRbutton), new object[] { i });
                return;
            }
            rbuttons[i].Enabled = true;
        }

        public void EnableTbutton(int i)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(EnableTbutton), new object[] { i });
                return;
            }
            tbuttons[i].Enabled = true;
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
            EXPERIMENT_LIB.begin_experiment_v2(
                par1, par2, par3);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (!SR850_LOCK_IN_DRIVER.is_Connected())
            {
                PrintInfo.ShowMessage("Lock in uredjaj nije povezan.");
                return;
            }
            if (!Serial_Driver_Laser.is_Connected())
            {
                PrintInfo.ShowMessage("Laser nije povezan.");
                return;
            }
            try
            {

                par1 = Convert.ToInt32(cbbrojmerenja.SelectedItem.ToString());
                par2 = Convert.ToInt32(cbsamplerate.Text);
                par3 = Convert.ToInt32(tbvremeakvizicije.Text);
                par4 = 10000;



                for (int i = 0; i < par1; i++)
                {

                    EXPERIMENT_LIB.snaga[i] = (int)Math.Ceiling((Convert.ToDouble(datagrid.Rows[i].Cells[0].Value.ToString()) * 255.0) / 100.0);

                    EXPERIMENT_LIB.frekv[i] = Convert.ToInt32(datagrid.Rows[i].Cells[1].Value.ToString());

                    EXPERIMENT_LIB.duty[i] = Convert.ToInt32(datagrid.Rows[i].Cells[2].Value.ToString()) / 5;
                }
            }
            catch
            {
                PrintInfo.ShowMessage("Nisu valjani parametri eksperimenta.");
                return;
            }
            expt = new Thread(start_exp);
            expt.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            expt.Interrupt();
        }

        private void importbtn_Click(object sender, EventArgs e)
        {
            IronXL.License.LicenseKey = "IRONSUITE.MIOLJUB.GMAIL.COM.21532-A741AA501B-M3KMN-4BJ37NHO4ASV-JDZKWGB2YJMM-YXHOI7W7B5DD-3MFD33EUBIEX-4DQIL3P64OY5-RB5L4O3XOLFX-XUC7XE-TI7LUU3P77WLUA-DEPLOYMENT.TRIAL-MURWUZ.TRIAL.EXPIRES.15.MAR.2024";

            WorkBook wb = WorkBook.Load(pathtofile.Text);
            WorkSheet ws = wb.GetWorkSheet(cbsheets.SelectedItem.ToString());

            int n = Convert.ToInt32(cbbrojmerenja.SelectedItem.ToString()) + 1;


            if (ws == null) { wb.Close(); return; }
            var range = ws["A2:C" + n.ToString()];

            int i = 0;
            int j = 0;
            foreach (var cell in range)
            {
                datagrid.Rows[i].Cells[j].Value = cell.ToString();
                j++;
                if (j == 3)
                {
                    j = 0;
                    i++;
                }

            }
            wb.Close();

        }

        private void selectfile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
                {
                    openFileDialog1.ShowDialog(this);
                    pathtofile.Text = openFileDialog1.FileName;
                    IronXL.License.LicenseKey = "IRONSUITE.MIOLJUB.GMAIL.COM.21532-A741AA501B-M3KMN-4BJ37NHO4ASV-JDZKWGB2YJMM-YXHOI7W7B5DD-3MFD33EUBIEX-4DQIL3P64OY5-RB5L4O3XOLFX-XUC7XE-TI7LUU3P77WLUA-DEPLOYMENT.TRIAL-MURWUZ.TRIAL.EXPIRES.15.MAR.2024";

                    WorkBook wb = WorkBook.Load(pathtofile.Text);
                    cbsheets.Items.Clear();
                    foreach (var ws in wb.WorkSheets)
                    {

                        cbsheets.Items.Add(ws.Name);

                    }
                    wb.Close();
                }
            }
            catch (FileNotFoundException ffe)
            {
                PrintInfo.ShowMessage("Fajl nije odabran.");
            }
            catch
            {
                PrintInfo.ShowMessage("Nije moguce otvoriti fajl.");
            }
        }

        private void fillfile_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(cbbrojmerenja.SelectedItem.ToString());
                WorkBook wb = WorkBook.Load(pathtofile.Text);
                WorkSheet ws = wb.GetWorkSheet(cbsheets.SelectedItem.ToString());

                int cl = 3;
                for (int z = 0; z < EXPERIMENT_LIB.brt; z++)
                {
                    ws.SetCellValue(0, cl, "R" + z.ToString());
                    cl++;
                }
                for (int z = 0; z < EXPERIMENT_LIB.brt; z++)
                {
                    ws.SetCellValue(0, cl, "T" + z.ToString());
                    cl++;
                }


                for (int i = 0; i < EXPERIMENT_LIB.br_merenja; i++)
                {
                    int col = 3;
                    double[] dataR = EXPERIMENT_LIB.get_R_data(i);
                    
                    for( int z = 0; z < EXPERIMENT_LIB.brt; z++ )
                    {
                        ws.SetCellValue(i + 1, col, dataR[z]);
                        col++;
                    }

                    double[] dataT = EXPERIMENT_LIB.get_T_data(i);

                    for (int z = 0; z < EXPERIMENT_LIB.brt; z++)
                    {
                        ws.SetCellValue(i + 1, col, dataT[z]);
                        col++;
                    }

                }
                wb.Save();

                wb.Close();
                PrintInfo.ShowMessage("Podaci su upisani!");
            }
            catch (Exception es)
            { MessageBox.Show(es.ToString()); }
        }

        private void connectform_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (ConnectionForm z = new ConnectionForm())
            {

                z.ShowDialog();


            }
            this.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (LockInForm z = new LockInForm())
            {

                z.ShowDialog();


            }
            this.Show();
        }
    }
}
