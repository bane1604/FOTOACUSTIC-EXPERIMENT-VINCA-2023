using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vinca_Projekat
{
    public partial class ViewData : Form
    {
        private double[] mydata;

        public ViewData(double[] data, int sample_rate)
        {
            InitializeComponent();

            mydata = data;
            fplot.Plot.AddSignal(data, sample_rate);
            label1.Text = "Sample rate = " + sample_rate.ToString();
            label2.Text = "Broj tacaka = " + data.Length.ToString();
            Refresh();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();



        private void ViewData_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ViewData_Load(object sender, EventArgs e)
        {
            fplot.Plot.AxisAuto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Title = "Sacuvaj tacke";
            saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter outputFile = new StreamWriter(saveFileDialog1.FileName, true))
                {
                    for (int i = 0; i < mydata.Length; i++)
                    {
                        outputFile.Write(mydata[i]);
                        if (i != mydata.Length - 1)
                        {
                            outputFile.Write(',');
                        }
                    }
                }

            }

        }
    }
}
