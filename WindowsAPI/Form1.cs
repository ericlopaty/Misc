using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsAPI
{
    public partial class Form1 : Form
    {
        private bool f = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            textBox1.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //f = !f;
            //bool rc= WinAPI.SetTopMost(this.Handle, f);
            bool rc = WinAPI.SetFocus(this.Handle);
            textBox1.Text = rc.ToString();
        }

    }
}
