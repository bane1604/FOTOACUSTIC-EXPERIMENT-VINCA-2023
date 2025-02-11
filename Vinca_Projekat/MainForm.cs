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
using System.IO;
using ClosedXML.Excel;
using System.Runtime.InteropServices;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Numerics;

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
        Thread mexpt = null;



        public MainForm()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                datagrid.Rows.Add();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Serial_Driver_Laser.Disconnect();
            this.Close();
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

        private static int par0;
        private static int par1;

        private static int par2;
        private static int par3;
        private static int par4;



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

                par1 = Convert.ToInt32(textBox1.Text);
                par2 = Convert.ToInt32(cbsamplerate.Text);
                par3 = Convert.ToInt32(tbvrememerenja.Text);
                par4 = Convert.ToInt32(tbvremestabilizacije.Text);



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
            expt = new Thread(() => EXPERIMENT_LIB.begin_experiment(par1, par2, par3, par4));
            expt.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            expt.Interrupt();
        }


        public void setupTest()
        {
            pathtofile.Text = "TestniXLSX.xlsx";
            textBox1.Text = "5";
            datagrid.Rows.Clear();
            for( int i = 0; i < 5; i++ )
                datagrid.Rows.Add();

            cbsheets.Items.Clear();
            cbsheets.Items.Add("Test");
            cbsheets.SelectedIndex = 0;
            EXPERIMENT_LIB.setupTest();
        }

        public List<int> readData()
        {
            List<int> retval = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    retval.Add(int.Parse((string)datagrid.Rows[i].Cells[j].Value));
                }
            }
            return retval; 
        }

        public void ImportExperimentData( )
        {
            var wb = new XLWorkbook(pathtofile.Text);
            if (wb == null)
            {
                PrintInfo.ShowMessage("File nije pronadjen.");
                return;
            }

            IXLWorksheet ws;
            try
            {
                ws = wb.Worksheet(cbsheets.Text);
            }
            catch (Exception ex)
            {
                wb.Dispose();
                PrintInfo.ShowMessage("Worksheet nije pronadnjen.");
                return;
            }

            int n = Int32.Parse(textBox1.Text) + 1;

            var range = ws.Range($"A2:C{n}");

            int i = 0;
            int j = 0;
            foreach (var cell in range.Cells())
            {
                datagrid.Rows[i].Cells[j].Value = cell.Value.ToString();
                j++;
                if (j == 3)
                {
                    j = 0;
                    i++;
                }

            }
            wb.Dispose();
        }

        private void importbtn_Click(object sender, EventArgs e)
        {
            //IronXL.License.LicenseKey = "IRONSUITE.NESICVOJIN2011.GMAIL.COM.23983-EDBED480A9-BLYYZNV-JIUHV7RGXJDN-EFCZSKERCHDY-DRDC5ZGPPU2Y-FTAVFCFMAIQD-CVZGK432PISK-6EUNP4ROFOJC-XN3LCX-TSVYCGZ7COGMEA-DEPLOYMENT.TRIAL-6OKBS7.TRIAL.EXPIRES.13.APR.2024";
            ImportExperimentData();
        }

        private void selectfile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
                {
                    openFileDialog1.ShowDialog(this);
                    pathtofile.Text = openFileDialog1.FileName;
                    //IronXL.License.LicenseKey = "IRONSUITE.NESICVOJIN2011.GMAIL.COM.23983-EDBED480A9-BLYYZNV-JIUHV7RGXJDN-EFCZSKERCHDY-DRDC5ZGPPU2Y-FTAVFCFMAIQD-CVZGK432PISK-6EUNP4ROFOJC-XN3LCX-TSVYCGZ7COGMEA-DEPLOYMENT.TRIAL-6OKBS7.TRIAL.EXPIRES.13.APR.2024";

                    var wb = new XLWorkbook(pathtofile.Text);
                    cbsheets.Items.Clear();
                    foreach (var ws in wb.Worksheets)
                    {

                        cbsheets.Items.Add(ws.Name);

                    }
                    wb.Dispose();
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


        public void FillData()
        {
            var wb = new XLWorkbook(pathtofile.Text);
            try
            {


                var ws = wb.Worksheet(cbsheets.SelectedItem.ToString());
                if (ws == null)
                {
                    PrintInfo.ShowMessage("Worksheet nije pronadjen!");
                    return;
                }

                int n = Convert.ToInt32(textBox1.Text);
                int cl = 3;
                for (int z = 0; z < EXPERIMENT_LIB.brt; z++)
                {
                    ws.Cell(1, cl).Value = "R" + z.ToString();
                    cl++;
                }
                for (int z = 0; z < EXPERIMENT_LIB.brt; z++)
                {
                    ws.Cell(1, cl).Value = "T" + z.ToString();
                    cl++;
                }
                ws.Cell(1, cl).Value = "AverageR[mV]";
                ws.Cell(1, cl + 1).Value = "AverageT[stepeni]";


                for (int i = 0; i < EXPERIMENT_LIB.br_merenja; i++)
                {
                    int col = 3;
                    double[] dataR = EXPERIMENT_LIB.get_R_data(i);
                    double[] dataT = EXPERIMENT_LIB.get_T_data(i);

                    double averageR = 0;
                    double averageT = 0;

                    for (int z = 0; z < dataR.Length; z++)
                    {
                        ws.Cell(i + 2, col).Value = dataR[z];
                        averageR += dataR[z];
                        col++;
                    }



                    for (int z = 0; z < dataT.Length; z++)
                    {
                        ws.Cell(i + 2, col).Value = dataT[z];
                        averageT += dataT[z];
                        col++;
                    }

                    if (dataR.Length > 0)
                    {
                        averageR /= dataR.Length;
                        averageR = averageR * 1000;
                    }
                    else { averageR = 0; }
                    if (dataT.Length > 0)
                    {
                        averageT /= dataT.Length;
                    }
                    else { averageT = 0; }

                    ws.Cell(i + 2, col).Value = averageR;
                    ws.Cell(i + 2, col + 1).Value = averageT;
                }

                // Metadata
                ws.Cell(EXPERIMENT_LIB.br_merenja + 3, 1).Value = "Datum i vreme:";
                ws.Cell(EXPERIMENT_LIB.br_merenja + 3, 2).Value = DateTime.Now.ToString();
                ws.Cell(EXPERIMENT_LIB.br_merenja + 4, 1).Value = "Reserve Mode:";
                ws.Cell(EXPERIMENT_LIB.br_merenja + 5, 1).Value = "Time constant:";
                ws.Cell(EXPERIMENT_LIB.br_merenja + 6, 1).Value = "Low Pass:";

                if (SR850_LOCK_IN_DRIVER.is_Connected())
                {
                    try
                    {
                        LockInForm.read();
                        ws.Cell(EXPERIMENT_LIB.br_merenja + 4, 2).Value = LockInForm.get_reserve_mode();
                        ws.Cell(EXPERIMENT_LIB.br_merenja + 5, 2).Value = LockInForm.get_time_constant();
                        ws.Cell(EXPERIMENT_LIB.br_merenja + 6, 2).Value = LockInForm.get_low_pass();
                    }
                    catch (IOException ex)
                    {
                        ws.Cell(EXPERIMENT_LIB.br_merenja + 4, 2).Value = "ERR";
                        ws.Cell(EXPERIMENT_LIB.br_merenja + 5, 2).Value = "ERR";
                        ws.Cell(EXPERIMENT_LIB.br_merenja + 6, 2).Value = "ERR";
                    }
                    catch (Exception ex)
                    {
                        ws.Cell(EXPERIMENT_LIB.br_merenja + 4, 2).Value = "ERR";
                        ws.Cell(EXPERIMENT_LIB.br_merenja + 5, 2).Value = "ERR";
                        ws.Cell(EXPERIMENT_LIB.br_merenja + 6, 2).Value = "ERR";
                    }
                }
                else
                {
                    ws.Cell(EXPERIMENT_LIB.br_merenja + 4, 2).Value = "ERR";
                    ws.Cell(EXPERIMENT_LIB.br_merenja + 5, 2).Value = "ERR";
                    ws.Cell(EXPERIMENT_LIB.br_merenja + 6, 2).Value = "ERR";
                }


            }
            catch (Exception es)
            { PrintInfo.ShowMessage(es.ToString()); }
            finally
            {
                wb.Save();
                PrintInfo.ShowMessage("Podaci su upisani!");
            }
        }

        private void fillfile_Click(object sender, EventArgs e)
        {
            FillData();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            datagrid.Rows.Clear();
            if (textBox1.Text == "") { return; }
            int a = 5;
            try
            {
                a = Int32.Parse(textBox1.Text);


            }
            catch (Exception ex)
            {
                textBox1.Text = "5";
            }
            finally
            {
                for (int i = 0; i < a; i++)
                {
                    datagrid.Rows.Add();
                }
            }
        }

        private void tbvremestabilizacije_TextChanged(object sender, EventArgs e)
        {
            if (tbvremestabilizacije.Text == "") { return; }
            try
            {
                Int32.Parse(tbvremestabilizacije.Text);
            }
            catch (Exception ex)
            {
                tbvremestabilizacije.Text = "20";
            }
        }

        private void tbvrememerenja_TextChanged(object sender, EventArgs e)
        {
            if (tbvremestabilizacije.Text == "") { return; }
            try
            {
                Int32.Parse(tbvrememerenja.Text);
            }
            catch (Exception ex)
            {
                tbvrememerenja.Text = "5";
            }
        }

        private void multiple_run(int iter, int brmerenja, int sample, int vreme, int stab)
        {
            for (int i = 0; i < iter; i++)
            {
                EXPERIMENT_LIB.begin_experiment(brmerenja, sample, vreme, stab);
                fill_data(i * (brmerenja + 1));
            }
        }


        private void fill_data(int red)
        {
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                XLWorkbook wb = new XLWorkbook(pathtofile.Text);
                var ws = wb.Worksheet(cbsheets.SelectedItem.ToString());

                int cl = 3;
                for (int i = 0; i < EXPERIMENT_LIB.br_merenja; i++)
                {
                    ws.Cell(red + i + 2, 0).Value = (XLCellValue)datagrid.Rows[i].Cells[0].Value;
                    ws.Cell(red + i + 2, 1).Value = (XLCellValue)datagrid.Rows[i].Cells[1].Value;
                    ws.Cell(red + i + 2, 2).Value = (XLCellValue)datagrid.Rows[i].Cells[2].Value;
                }
                for (int z = 0; z < EXPERIMENT_LIB.brt; z++)
                {
                    ws.Cell(red + 1, cl).Value = $"R{z}";
                    cl++;
                }
                for (int z = 0; z < EXPERIMENT_LIB.brt; z++)
                {
                    ws.Cell(red + 1, cl).Value = $"T{z}";
                    cl++;
                }


                for (int i = red; i < EXPERIMENT_LIB.br_merenja; i++)
                {
                    int col = 3;
                    double[] dataR = EXPERIMENT_LIB.get_R_data(i);

                    for (int z = 0; z < EXPERIMENT_LIB.brt; z++)
                    {
                        ws.Cell(i + 2, col).Value = dataR[z];
                        col++;
                    }

                    double[] dataT = EXPERIMENT_LIB.get_T_data(i);

                    for (int z = 0; z < EXPERIMENT_LIB.brt; z++)
                    {
                        ws.Cell(i + 2, col).Value = dataT[z];
                        col++;
                    }

                }
                wb.Save();
                PrintInfo.ShowMessage("Podaci su upisani!");
            }
            catch (Exception es)
            { PrintInfo.ShowMessage(es.ToString()); }
        }

        private void itertb_TextChanged(object sender, EventArgs e)
        {

        }

        private void startmb_Click(object sender, EventArgs e)
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
                //par0 = Convert.ToInt32(itertb.Text);
                par1 = Convert.ToInt32(textBox1.Text);
                par2 = Convert.ToInt32(cbsamplerate.Text);
                par3 = Convert.ToInt32(tbvrememerenja.Text);
                par4 = Convert.ToInt32(tbvremestabilizacije.Text);



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
            expt = new Thread(() => multiple_run(par0, par1, par2, par3, par4));
            expt.Start();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            cbsamplerate.SelectedIndex = 3;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            String path = "./export.csv";
            try
            {
                using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
                {
                    openFileDialog1.ShowDialog(this);
                    path = openFileDialog1.FileName;
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

            var csv = new StringBuilder();

            int cl = 3;
            StringBuilder sb = new StringBuilder();
            for (int z = 0; z < EXPERIMENT_LIB.brt; z++)
            {
                if (z != 0)
                    sb.Append(",R" + z.ToString());
                else
                    sb.Append("R" + z.ToString());
                cl++;
            }
            for (int z = 0; z < EXPERIMENT_LIB.brt; z++)
            {
                sb.Append(",T" + z.ToString());
                cl++;
            }

            sb.Append(",AverageR[mV],AverageT[stepeni]");
            csv.AppendLine(sb.ToString());


            for (int i = 0; i < EXPERIMENT_LIB.br_merenja; i++)
            {
                sb.Clear();
                int col = 3;
                double[] dataR = EXPERIMENT_LIB.get_R_data(i);
                double[] dataT = EXPERIMENT_LIB.get_T_data(i);

                double averageR = 0;
                double averageT = 0;

                for (int z = 0; z < dataR.Length; z++)
                {
                    if (z == 0)
                        sb.Append(dataR[z].ToString());
                    else
                        sb.Append("," + dataR[z].ToString());
                    Console.WriteLine(dataR[z].ToString());
                    col++;
                }



                for (int z = 0; z < dataT.Length; z++)
                {
                    sb.Append("," + dataT[z].ToString());
                    averageT += dataT[z];
                    Console.WriteLine(dataT[z].ToString());
                    col++;
                }

                if (dataR.Length > 0)
                {
                    averageR /= dataR.Length;
                    averageR = averageR * 1000;
                }
                else { averageR = 0; }
                if (dataT.Length > 0)
                {
                    averageT /= dataT.Length;
                }
                else { averageT = 0; }

                sb.Append("," + averageR.ToString());
                sb.Append(',' + averageT.ToString());
                csv.AppendLine(sb.ToString());
            }
            File.WriteAllText(path, csv.ToString());
            PrintInfo.ShowMessage("Podaci uspesno upisani u csv.");
        }
    }
}
