using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vinca_Projekat.lib
{
    internal static class EXPERIMENT_LIB
    {
        private static bool flag = false;
        private static Mutex mut = new Mutex(false);
        private static StringBuilder[] dataR = new StringBuilder[102];
        private static StringBuilder[] dataT = new StringBuilder[102];
  
        private static int broj_tacaka;
        private static int vreme_isijavanja;
        public static int[] snaga = new Int32[102];
        public static int[] frekv =new Int32[102];
        public static int[] duty =new Int32[102];

        private static List<double>[] Rval =  new List<double>[102];
        private static List<double>[] Tval = new List<double>[102];



        private static int curi = 0;

        public static double[] get_R_data( int i )
        {
            List<double> l = Rval[i];

            return l.ToArray();
        }
        public static double[] get_T_data(int i)
        {
            List<double> l = Tval[i];

            return l.ToArray();
        }

        public static void append_data( int i, String x)
        {
            if (i != -1)
            {
                if (flag)
                    dataR[i].Append(x);
                else
                    dataT[i].Append(x);
            }
        }

        private static void help_start()
        {
            Serial_Driver_Laser.laser_start(snaga[curi], frekv[curi], vreme_isijavanja, duty[curi]);
        }

        public static void begin_experiment(int n, int sample_rate, int vreme_merenja, int vreme_pucanja, MainForm mfrm)
        {
            Thread t = null;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    dataR[i] = new StringBuilder(sample_rate * vreme_merenja * 20);
                    dataT[i] = new StringBuilder(sample_rate * vreme_merenja * 20);
                }

                

                int val = 4 + Convert.ToInt32(Math.Log2(Convert.ToDouble(sample_rate)));
                broj_tacaka = sample_rate * vreme_merenja;
                SR850_LOCK_IN_DRIVER.send_command("SRAT " + val.ToString());
                SR850_LOCK_IN_DRIVER.send_command("SEND 0");
                SR850_LOCK_IN_DRIVER.send_command("SLEN " + vreme_merenja.ToString());
                SR850_LOCK_IN_DRIVER.send_command("REST");
                vreme_isijavanja = vreme_pucanja;
                for(int i = 0; i < n; i++)
                {
                    curi = i;


                    //mfrm.update_status("Status: Running", i );
                    t = new Thread(help_start);
                    t.Start();
                    

                    Thread.Sleep(5000);
                    //mfrm.update_status("Status: Recording", i);
                    SR850_LOCK_IN_DRIVER.send_command("STRT");
                    Thread.Sleep(vreme_merenja * 1000);

                    //mfrm.update_status("Status: Saving", i);
                    SR850_LOCK_IN_DRIVER.outputdata = i;
                    flag = false;
                    SR850_LOCK_IN_DRIVER.send_command("TRCA ? 2,0," + broj_tacaka.ToString());
                    Thread.Sleep(10000);
                    
                    flag = true;
                    SR850_LOCK_IN_DRIVER.send_command("TRCA ? 3,0," + broj_tacaka.ToString());
                    Thread.Sleep(10000);
                    SR850_LOCK_IN_DRIVER.outputdata = -1;
                    

                    SR850_LOCK_IN_DRIVER.send_command("REST");
                    
                    Thread.Sleep(1000);
                    t.Join();
                    //mfrm.update_status("Status: Finished", i);
                }

                for( int i = 0; i < n; i++)
                {
                    List<double> r = new List<double>();
                    List<double> u = new List<double>();

                    String[] rs = dataR[i].ToString().Split(",");
                    String[] us = dataT[i].ToString().Split(",");

                    
                    
                    foreach( String  s in rs )
                    {
                        try
                        {
                            r.Add(Convert.ToDouble(s));
                        }
                        catch( Exception e ) {
                        }
                    }

                    foreach ( String s in us )
                    {
                        try
                        {
                            u.Add(Convert.ToDouble(s));
                        }
                        catch (Exception e) { }
                    }

                    Rval[i] = r;
                    Tval[i] = u;
                    //mfrm.EnableRbutton(i);
                    //mfrm.EnableTbutton(i);
                }
                MessageBox.Show("Merenje zavrseno!");
            }
            catch (Exception e)
            {
                if (t != null && t.IsAlive)
                    t.Interrupt();
                t.Join();

            }
            
            
        }
    }
}
