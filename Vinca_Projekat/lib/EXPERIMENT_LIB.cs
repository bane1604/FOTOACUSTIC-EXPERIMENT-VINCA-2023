using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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

        public static int brt;
        public static int br_merenja;

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
                    

                    Thread.Sleep(10000);
                    //mfrm.update_status("Status: Recording", i);
                    SR850_LOCK_IN_DRIVER.send_command("STRT");
                    Thread.Sleep(vreme_merenja * 1000);

                    //mfrm.update_status("Status: Saving", i);
                    SR850_LOCK_IN_DRIVER.outputdata = i;
                    flag = false;
                    SR850_LOCK_IN_DRIVER.send_command("TRCA ? 3,0," + broj_tacaka.ToString());
                    Thread.Sleep(10000);
                    
                    flag = true;
                    SR850_LOCK_IN_DRIVER.send_command("TRCA ? 4,0," + broj_tacaka.ToString());
                    Thread.Sleep(10000);
                    SR850_LOCK_IN_DRIVER.outputdata = -1;
                    

                    SR850_LOCK_IN_DRIVER.send_command("REST");
                    
                    Thread.Sleep(1000);
                    if (t != null && t.IsAlive)
                        t.Interrupt();
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

        private static void writebyte( Byte b )
        {
            for( int i = 0; i < 8; i++ )
            {
                if( (b & 1) == 1 )
                {
                    Console.Write("1");
                }
                else
                {
                    Console.Write("0");
                }
                b = (Byte) (b >> 1);
            }
        }

        public static void begin_experiment_v2(int n, int sample_rate, int vreme_merenja )
        {
            Thread t = null;
            bool repeat = false;
            int val = 4 + Convert.ToInt32(Math.Log2(Convert.ToDouble(sample_rate)));
            broj_tacaka = sample_rate * vreme_merenja;
            SR850_LOCK_IN_DRIVER.send_command("SRAT " + val.ToString());
            SR850_LOCK_IN_DRIVER.send_command("SEND 0");
            SR850_LOCK_IN_DRIVER.send_command("SLEN " + vreme_merenja.ToString());
            SR850_LOCK_IN_DRIVER.send_command("REST");
            SR850_LOCK_IN_DRIVER.send_command("TRCD 3,3,0,0,1");
            SR850_LOCK_IN_DRIVER.send_command("TRCD 4,4,0,0,1");
            SR850_LOCK_IN_DRIVER.send_command("REST");

            brt = broj_tacaka;
            EXPERIMENT_LIB.br_merenja = n;
            try
            {

                for (int i = 0; i < n; i++)
                {
                    if (repeat) i--;
                    repeat = false;
                    curi = i;
                    //start the thread for laser
                    SR850_LOCK_IN_DRIVER.send_command("REST");
                    Console.WriteLine("Pokretanje lasera");
                    t = new Thread(() => Serial_Driver_Laser.laser_start(snaga[i], frekv[i], 100000, duty[i]));
                    t.Start();
                    Console.WriteLine("Cekanje za stabilizaciju 20s");
                    Thread.Sleep(20000);


                    Console.WriteLine("Zapocinjanje merenja!");
                    SR850_LOCK_IN_DRIVER.send_command("STRT");
                    Thread.Sleep(vreme_merenja * 1000);
                    Console.WriteLine("Merenje zavrseno!");


                    SR850_LOCK_IN_DRIVER.flushin();
                    Console.WriteLine("Broj izmerenih tacaka (R) je: ");
                    SR850_LOCK_IN_DRIVER.send_command("SPTS ? 3");
                    string izmereno = SR850_LOCK_IN_DRIVER.read_line();
                    Console.WriteLine(izmereno);

                    int iz = Convert.ToInt32(izmereno);
                    if (iz >= broj_tacaka)
                    {
                        Rval[i] = new List<double>();
                        for (int j = 0; j < broj_tacaka; j++)
                        {
                            SR850_LOCK_IN_DRIVER.flushin();
                            SR850_LOCK_IN_DRIVER.send_command("TRCL ? 3," + j.ToString() + ",1");

                            Byte m2 = SR850_LOCK_IN_DRIVER.read_byte();
                            Byte m1 = SR850_LOCK_IN_DRIVER.read_byte();
                            Byte exp = SR850_LOCK_IN_DRIVER.read_byte();
                            Byte zero = SR850_LOCK_IN_DRIVER.read_byte();

                            int z1= m1;
                            z1 = z1 << 8;
                            uint z2 = m2;
                            
                            int mantisa = (int) ((uint) z1 + z2 );
                            
                            
                            double broj = Math.Pow(2, (int)exp-124) * mantisa;
                            Rval[i].Add(broj);

                        }



                    }
                    else
                    {
                        repeat = true;
                    }

                    SR850_LOCK_IN_DRIVER.flushin();
                    Console.WriteLine("Broj izmerenih tacaka (T) je: ");
                    SR850_LOCK_IN_DRIVER.send_command("SPTS ? 4");
                    string izmerenoT = SR850_LOCK_IN_DRIVER.read_line();
                    Console.WriteLine(izmerenoT);

                    int izT = Convert.ToInt32(izmereno);
                    if (izT >= broj_tacaka)
                    {
                        Tval[i] = new List<double>();
                        for (int j = 0; j < broj_tacaka; j++)
                        {
                            SR850_LOCK_IN_DRIVER.flushin();
                            SR850_LOCK_IN_DRIVER.send_command("TRCL ? 4," + j.ToString() + ",1");

                            Byte m2 = SR850_LOCK_IN_DRIVER.read_byte();
                            Byte m1 = SR850_LOCK_IN_DRIVER.read_byte();
                            Byte exp = SR850_LOCK_IN_DRIVER.read_byte();
                            Byte zero = SR850_LOCK_IN_DRIVER.read_byte();

                            int z1 = m1;
                            z1 = z1 << 8;
                            uint z2 = m2;

                            int mantisa = (int)((uint)z1 + z2);

                            double broj = Math.Pow(2, (int)exp - 124) * mantisa;
                            Tval[i].Add(broj);
                        }
                        Console.WriteLine();



                    }
                    else
                    {
                        repeat = true;
                    }


                    Console.Out.WriteLine("gasenje lasera");
                    if (t != null && t.IsAlive)
                    {
                        t.Interrupt();
                    }
                    t.Join();

                }
                PrintInfo.ShowMessage("Merenje je zavrseno!");
            }
            catch( Exception e)
            {
                Console.WriteLine(e.Message); Console.WriteLine();
                if (t != null && t.IsAlive)
                {
                    t.Interrupt();
                }
                t.Join();
                
            }
        }
    }
}
