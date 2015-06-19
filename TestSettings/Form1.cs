using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestSettings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.Setting1;
            textBox2.Text = Properties.Settings.Default.Setting2;
            textBox3.Text = Special.Default.Setting3;
            textBox4.Text = Special.Default.Setting4;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Setting2 = textBox2.Text;
            Properties.Settings.Default.Save();
            Special.Default.Setting4 = textBox4.Text;
            Special.Default.Save();
        }
    }
}
