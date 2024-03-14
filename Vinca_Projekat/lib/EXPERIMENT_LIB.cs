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
using Windows.UI.Composition;

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
        public static int br_merenja = 5;

        private static List<double>[] Rval =  new List<double>[102];
        private static List<double>[] Tval = new List<double>[102];



        private static int curi = 0;

        public static double[] get_R_data( int i )
        {
            
            List<double> l = Rval[i];

            if (l != null)
            {
                return l.ToArray();
            }
            return new double[0];
            
        }
        public static double[] get_T_data(int i)
        {
            List<double> l = Tval[i];

            if (l != null)
            {
                return l.ToArray();
            }
            return new double[0];
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

        public static void begin_experiment(int n, int sample_rate, int vreme_merenja, int vreme_stabilizacije )
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

            broj_tacaka = brt = broj_tacaka * 9 / 10;
            EXPERIMENT_LIB.br_merenja = n;
            try
            {

                for (int i = 0; i < n; i++)
                {
                    if (repeat) i--;
                    try { 
                    repeat = false;
                    curi = i;
                    //start the thread for laser
                    SR850_LOCK_IN_DRIVER.send_command("REST");
                    Console.WriteLine("Pokretanje lasera");
                    t = new Thread(() => Serial_Driver_Laser.laser_start(snaga[i], frekv[i], 100000, duty[i]));
                    Console.WriteLine("Snaga lasera = " + snaga[i].ToString());
                    Console.WriteLine("Frekv lasera = " + frekv[i].ToString());
                    Console.WriteLine("Duty lasera = " + duty[i].ToString());

                    t.Start();
                    Console.WriteLine("Cekanje za stabilizaciju" + vreme_stabilizacije + "s");
                    Thread.Sleep(vreme_stabilizacije * 1000);


                    Console.WriteLine("Zapocinjanje merenja!");
                    SR850_LOCK_IN_DRIVER.send_command("STRT");
                    Thread.Sleep(vreme_merenja * 1000);
                    Console.WriteLine("Merenje zavrseno!");


                    int iz = 0;
                    bool flagl = true;
                    while (flagl)
                    {
                        flagl = false;
                        SR850_LOCK_IN_DRIVER.flushin();
                        Console.WriteLine("Broj izmerenih tacaka (R) je: ");
                        SR850_LOCK_IN_DRIVER.send_command("SPTS ? 3");
                        string izmereno = SR850_LOCK_IN_DRIVER.read_line();
                        Console.WriteLine(izmereno);
                        try
                        {
                            iz = Convert.ToInt32(izmereno);
                        }
                        catch (Exception ex) { flagl = true; }
                    }
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

                            int z1 = m1;
                            z1 = z1 << 8;
                            uint z2 = m2;

                            int mantisa = (int)((uint)z1 + z2);


                            double broj = Math.Pow(2, (int)exp - 124) * mantisa;
                            if (Rval[i].Count != 0 && (Math.Abs(broj) < Math.Abs(Rval[i].Last()) / 1000 || Math.Abs(broj) > 1000 * Math.Abs(Rval[i].Last()))) {
                                j--;
                            }
                            else {
                                Rval[i].Add(broj);
                            }

                        }



                    }
                    else
                    {
                        repeat = true;
                    }

                    bool flaglosa = true;
                    int izT = 0;
                    while (flaglosa)
                    {

                        flaglosa = false;
                        SR850_LOCK_IN_DRIVER.flushin();
                        Console.WriteLine("Broj izmerenih tacaka (T) je: ");
                        SR850_LOCK_IN_DRIVER.send_command("SPTS ? 4");
                        string izmerenoT = SR850_LOCK_IN_DRIVER.read_line();
                        Console.WriteLine(izmerenoT);
                        try
                        {
                            izT = Convert.ToInt32(izmerenoT);
                        }
                        catch (Exception e) {
                            flaglosa = true;
                        }
                    }
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

                            int z1 = Convert.ToInt32(m1);
                            z1 = z1 << 8;

                            uint z2 = Convert.ToUInt32(m2);

                            if ((m1 & (Byte)0x80) != (Byte)0x00)
                            {
                                m1 = (Byte)(~m1 + (Byte)1);
                                z1 = m1 << 8;
                                z1 = -z1;
                            }

                            int mantisa = (int)(Math.Abs(z1) + Math.Abs(z2));
                            if (z1 < 0)
                                mantisa = -mantisa;
                            double broj = Math.Pow(2, (int)exp - 124) * mantisa;
                            if (Tval[i].Count != 0 && (Math.Abs(broj) < Math.Abs(Tval[i].Last()) / 1000 || Math.Abs(broj) > 1000 * Math.Abs(Tval[i].Last()))) {
                                j--;
                            }
                            else
                            {
                                Tval[i].Add(broj);
                            }
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
                    catch(TimeoutException ex)
                    {
                        Console.WriteLine("LockIn se nije odazvao u predvidjenom periodu.");
                        Console.Out.WriteLine("gasenje lasera");
                        if (t != null && t.IsAlive)
                        {
                            t.Interrupt();
                        }
                        t.Join();
                        repeat = true;
                        SR850_LOCK_IN_DRIVER.send_command("REST");
                        Thread.Sleep(50);
                    }
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
