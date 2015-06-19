using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrainDump
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnTimers_Click(object sender, EventArgs e)
        {
            FormTimers f = new FormTimers();
            f.ShowDialog();
        }
    }
}
