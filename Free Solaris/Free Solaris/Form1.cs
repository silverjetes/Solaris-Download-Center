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
    public partial class Form1 : Form
    {
        public static Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread clr = new Thread(color);
            clr.Start();
            void color()
            {
                while (true)
                {
                    label1.ForeColor = Color.FromArgb(255, r.Next(0, 150), r.Next(0, 150), r.Next(0, 150));
                    Thread.Sleep(20);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            new Thread(form).Start();
            void form()
            {
                Application.Run(new Form2());
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Point point = new Point(r.Next(0, 400), r.Next(0, 300));
            button1.Location = point;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
