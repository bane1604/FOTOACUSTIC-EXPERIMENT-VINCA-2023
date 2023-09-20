using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vinca_Projekat.lib
{
    internal class SR850_LOCK_IN_DRIVER
    {
        private static bool _connected = false;
        private static SerialPort lckin = null;
        private static MainForm my_form = null;

        public static bool is_Connected() { return _connected; }
        public static bool Connect(String port, int BaudRate, MainForm mfrm)
        {
            try
            {
                if (!is_Connected())
                {

                    lckin = new SerialPort(port, BaudRate);
                    lckin.Encoding = Encoding.ASCII;
                    my_form = mfrm;
                    if (my_form != null)
                        lckin.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    lckin.Open();
                    _connected = true;

                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Konkecija sa SR850 nije uspela.");
                return false;
            }
            return false;
        }
        public static void Disconnect()
        {
            if (is_Connected())
            {

                _connected = false;
                lckin.Close();

            }
        }
        
        
        private static void DataReceivedHandler(
                    object sender,
                    SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            my_form.AppendTextBox2(indata);

        }

        public static void send_command(String command)
        {
            lckin.WriteLine(command);
        }
    }
}
