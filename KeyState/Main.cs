using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyState
{
    public partial class Main : Form
    {
        private bool cap = false;
        private bool num = false;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Enabled = true;
            cap = !Console.CapsLock;
            num = !Console.NumberLock;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Console.NumberLock != num || Console.CapsLock != cap)
            {
                bool newCap = Console.CapsLock;
                bool newNum = Console.NumberLock;
                if (newCap != cap || newNum != num)
                {
                    cap = newCap;
                    num = newNum;
                    string state = (num ? "NUM" : "") + " " + (cap ? "CAPS" : "");
                    lblKeyState.Text = state;
                    this.Text = state;
                }
            }
        }
    }
}
