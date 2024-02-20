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
