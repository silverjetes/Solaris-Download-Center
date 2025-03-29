using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Free_Solaris
{
    public partial class Form2 : Form
    {
        public static Random r = new Random();

        public Form2()
        {
            InitializeComponent();
            new Thread(gdi).Start();
        }

        static void gdi()
        {
            Thread snd = new Thread(Program.sound);
            Thread inv = new Thread(Program.invert);
            Thread icn = new Thread(Program.icons);
            Thread tun = new Thread(Program.tunnel);

            Thread.Sleep(20000);
            snd.Start();
            inv.Start();
            Thread.Sleep(10000);
            icn.Start();
            Thread.Sleep(7000);
            tun.Start();

            Thread.Sleep(r.Next(15000, 40000));

            snd.Abort();
            inv.Abort();
            icn.Abort();
            tun.Abort();

            MessageBox.Show("Could not install Solaris.exe!\nUnknown Error 5844", "", MessageBoxButtons.OK,
MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            Environment.Exit(0);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
}
