using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Compare
{
    public partial class ViewDiff : Form
    {
        public ViewDiff()
        {
            InitializeComponent();
        }

        private void ViewDiff_Load(object sender, EventArgs e)
        {
            StreamReader rdr = File.OpenText("H:\\DEV\\ROGUE\\COMPARE\\Main.cs");
            string s=rdr.ReadToEnd();
            tbLeft.Text=s;
            tbRight.Text=s;
            rdr.Close();
            rdr.Dispose();
        }

        private void ViewDiff_Resize(object sender, EventArgs e)
        {
            splitContainer.SplitterDistance = (splitContainer.Width - splitContainer.SplitterWidth) / 2;
        }

        private void tbLeft_LocationChanged(object sender, EventArgs e)
        {
            MessageBox.Show("location changed: " + e.ToString());
        }

        private void tbLeft_Move(object sender, EventArgs e)
        {
            MessageBox.Show("move: " + e.ToString());
        }
    }
}
