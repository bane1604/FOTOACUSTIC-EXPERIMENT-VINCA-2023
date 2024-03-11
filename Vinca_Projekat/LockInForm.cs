using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Vinca_Projekat.lib;

namespace Vinca_Projekat
{
    public partial class LockInForm : Form
    {
        static int rmcb_selected = 0;
        static int tcb_selected = 0;
        static int lpcb_selected = 0;

        public LockInForm()
        {
            
            InitializeComponent();
            
            read();
            rmcb.SelectedIndex = rmcb_selected;
            tccb.SelectedIndex = tcb_selected;
            lpcb.SelectedIndex = lpcb_selected;
        }

        public static void print()
        {
            SR850_LOCK_IN_DRIVER.flushout();
            SR850_LOCK_IN_DRIVER.send_command("RMOD " + rmcb_selected.ToString());
            SR850_LOCK_IN_DRIVER.send_command("OFLT " + tcb_selected.ToString());
            SR850_LOCK_IN_DRIVER.send_command("OFSL " + lpcb_selected.ToString());
        }
        public static void read()
        {

            SR850_LOCK_IN_DRIVER.flushin();
            SR850_LOCK_IN_DRIVER.send_command("RMOD ?");
            rmcb_selected = Int32.Parse(SR850_LOCK_IN_DRIVER.read_line());

            SR850_LOCK_IN_DRIVER.send_command("OFLT ?");
            tcb_selected = Int32.Parse(SR850_LOCK_IN_DRIVER.read_line());

            SR850_LOCK_IN_DRIVER.send_command("OFSL ?");
            lpcb_selected = Int32.Parse(SR850_LOCK_IN_DRIVER.read_line());

        }

        public static string get_time_constant()
        {
            switch ( tcb_selected )
            {
                case 0: return "10 μs";
                case 1: return "30 μs";
                case 2: return "100 μs";
                case 3: return "300 μs";
                case 4: return "1 ms";
                case 5: return "3 ms";
                case 6: return "10 ms";
                case 7: return "30 ms";
                case 8: return "100 ms";
                case 9: return "300 ms";
                case 10: return "1 s";
                case 11: return "3 s";
                case 12: return "10 s";
                case 13: return "30 s";
                case 14: return "100 s";
                case 15: return "300 s";
                case 16: return "1 ks";
                case 17: return "3 ks";
                case 18: return "10 ks";
                case 19: return "30 ks";
                default: return "UNKNOWN";
            }
        }

        public static string get_low_pass()
        {
            switch (lpcb_selected)
            {
                case 0: return "6 db/Oct";
                case 1: return "12 db/Oct";
                case 2: return "18 db/Oct";
                case 3: return "24 db/Oct";
                default: return "UNKNOWN";
            }
        }

        public static string get_reserve_mode()
        {
            switch(rmcb_selected)
            {
                case 0: return "Max";
                case 1: return "Manual";
                case 2: return "Min";
                default: return "UNKNOWN";
            }
        }

        private void rmcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SR850_LOCK_IN_DRIVER.is_Connected() == false)
            {
                PrintInfo.ShowMessage("Lock in uredjaj nije povezan!");
                return;
            }
            SR850_LOCK_IN_DRIVER.flushout();
            rmcb_selected = rmcb.SelectedIndex;
            SR850_LOCK_IN_DRIVER.send_command("RMOD " + rmcb_selected.ToString());
        }

        private void tccb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SR850_LOCK_IN_DRIVER.is_Connected() == false)
            {
                PrintInfo.ShowMessage("Lock in uredjaj nije povezan!");
                return;
            }
            SR850_LOCK_IN_DRIVER.flushout();
            tcb_selected = tccb.SelectedIndex;
            SR850_LOCK_IN_DRIVER.send_command("OFLT " + tcb_selected.ToString());
        }

        private void lpcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SR850_LOCK_IN_DRIVER.is_Connected() == false)
            {
                PrintInfo.ShowMessage("Lock in uredjaj nije povezan!");
                return;
            }
            SR850_LOCK_IN_DRIVER.flushout();
            lpcb_selected = lpcb.SelectedIndex;
            SR850_LOCK_IN_DRIVER.send_command("OFSL " + lpcb_selected.ToString());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
