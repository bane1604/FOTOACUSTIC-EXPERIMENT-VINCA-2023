﻿using MicroLibrary;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vinca_Projekat.lib
{
    internal class Serial_Driver_Laser
    {
        private static bool _connected = false;
        private static SerialPort printer = null;
        private static int lineno = 1;
        private static int okcnt = 0;


        private static int duty;
        private static int power;



        public static bool is_Connected() { return _connected; }
        public static bool Connect(String port, int BaudRate )
        {
            try
            {
                if (!is_Connected())
                {
                    if (printer == null)
                    {
                        printer = new SerialPort(port, BaudRate);
                        printer.Encoding = Encoding.ASCII;
                        printer.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    }
                    printer.Open();
                    _connected = true;
                    
                    lineno = 1;
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Konkecija sa stampacom nije uspela.");
                return false;
            }
            return false;
        }

        private static void DataReceivedHandler(
                    object sender,
                    SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.Write(indata);
           
        }
        public static void Disconnect()
        {
            if (is_Connected())
            {
                
                _connected = false;
                printer.Close();
                
            }
        }

        private static string Checksum(string command)
        {
            int result = command.Aggregate(0, (x, y) => x ^ Convert.ToInt32(y));
            return result.ToString();
        }

        public static void send_instruction(String command)
        {   
            String fcmd = "N" + lineno + " " + command;
            printer.WriteLine( fcmd + "*" + Checksum(fcmd));
            lineno++;
        }

        private static void laser_thread(object sender,
                                  MicroLibrary.MicroTimerEventArgs timerEventArgs)
        {
            

            if( timerEventArgs.TimerCount % 20 == duty)
            {
                send_instruction("M107");
            }
            if( timerEventArgs.TimerCount % 20 == 0)
            {
                send_instruction("M106 S" + power.ToString());
            }
            

        }

        public static async void laser_start(int S, int frekv, int time, int dutyc = 10 )
        {
            MicroLibrary.MicroTimer microTimer = new MicroLibrary.MicroTimer();
            microTimer.MicroTimerElapsed +=
                new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(laser_thread);

            power = S;
         
            duty = dutyc;

            
            microTimer.Interval = (1000000)/(frekv*20);
            Console.WriteLine(microTimer.Interval.ToString());

            send_instruction("M106 S" + power.ToString());
            microTimer.Start();

            Thread.Sleep(time * 1000);

            microTimer.StopAndWait();
            send_instruction("M107");



        }



        private static void laser_testerica_thread(object sender,
                                  MicroLibrary.MicroTimerEventArgs timerEventArgs)
        {

            switch (timerEventArgs.TimerCount%10)
            {
                case 0: send_instruction("M107"); break;
                case 1: send_instruction("M106 S" + (1 * power).ToString()); break;
                case 2: send_instruction("M106 S" + (2 * power).ToString()); break;
                case 3: send_instruction("M106 S" + (3 * power).ToString()); break;
                case 4: send_instruction("M106 S" + (4 * power).ToString()); break;
                case 5: send_instruction("M106 S" + (5 * power).ToString()); break;
                case 6: send_instruction("M106 S" + (4 * power).ToString()); break;
                case 7: send_instruction("M106 S" + (3 * power).ToString()); break;
                case 8: send_instruction("M106 S" + (2 * power).ToString()); break;
                case 9: send_instruction("M106 S" + (1 * power).ToString()); break;


            }
        }

        public static async void laser_testerica( int max_power, int frekv, int time)
        {

            MicroLibrary.MicroTimer microTimer = new MicroLibrary.MicroTimer();
            microTimer.MicroTimerElapsed +=
                new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(laser_testerica_thread);

            power = max_power/5;


            microTimer.Interval = (1000000) / (frekv * 10);
            Console.WriteLine(microTimer.Interval.ToString());

           
            microTimer.Start();

            Thread.Sleep(time * 1000);

            microTimer.StopAndWait();
            send_instruction("M107");
        }
    }
}
