using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Vinca_Projekat.lib
{
    internal static class SR850_LOCK_IN_DRIVER
    {
        private static bool _connected = false;
        private static SerialPort lckin = null;
        public static LockInTest my_form = null;
        public static int outputdata = -1;
        private static SerialDataReceivedEventHandler my_handler= null;
        
        public static void setForm(LockInTest form)
        {
            
            my_form = form;
            my_handler = new SerialDataReceivedEventHandler(DataReceivedHandler);
            lckin.DataReceived += my_handler;

        }

        private static void DataReceivedHandler(
                    object sender,
                    SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)lckin;

            String s = sp.ReadExisting();
            if (my_form != null)
            {
                my_form.Output(s);
            }
        }

        public static void releaseForm()
        {
            my_form = null;
            lckin.DataReceived -= my_handler;   
        }
        public static bool is_Connected() { return _connected; }
        public static bool Connect(String port, int BaudRate)
        {
            try
            {
                if (!is_Connected())
                {

                    lckin = new SerialPort(port, BaudRate);
                    lckin.Encoding = Encoding.ASCII;
                    
                   
                    lckin.Open();
                    lckin.DiscardInBuffer();
                    lckin.DiscardOutBuffer();
                    _connected = true;

                    return true;
                }
            }
            catch
            {
                PrintInfo.ShowMessage("Konekcija sa SR850 nije uspela.");
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
        
        

        public static string read_existing()
        {
            return ((SerialPort)lckin).ReadExisting();
        }

        public static string read_line()
        {
            return ((SerialPort)lckin).ReadLine();
        }
        public static Byte read_byte()
        {
            return (Byte)lckin.ReadByte();
        }

        public static void send_command(String command)
        {
            lckin.WriteLine(command);
        }

        public static void flushin()
        {
            lckin.DiscardInBuffer();
        }
        public static void flushout()
        {
            lckin.DiscardOutBuffer();
        }
    }
}
