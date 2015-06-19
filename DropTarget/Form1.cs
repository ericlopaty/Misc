using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DropTarget
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_DragDrop(object sender, DragEventArgs e)
        {
            //IDataObject what = e.Data;
            textBox1.Text = "dragdrop";
            //label1.Text = what.ToString();
        }

        private void label1_DragEnter(object sender, DragEventArgs e)
        {
            textBox1.Text = "dragenter";
        }

        private void label1_DragOver(object sender, DragEventArgs e)
        {
            textBox1.Text = "dragover";
        }

        private void label1_DragLeave(object sender, EventArgs e)
        {
            //textBox1.Text = "";
        }
    }
}
