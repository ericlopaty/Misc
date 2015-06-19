using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Messenger
{
    public partial class formHost : Form
    {
        public formHost()
        {
            InitializeComponent();
        }

        formMessenger messenger1, messenger2;

        private void formHost_Load(object sender, EventArgs e)
        {
            messenger1 = new formMessenger();
            messenger1.SendFrom = Program.LeftSide;
            messenger1.ReceiveFrom = Program.RightSide;
            messenger1.Show();

            messenger2 = new formMessenger();
            messenger2.SendFrom = Program.RightSide;
            messenger2.ReceiveFrom = Program.LeftSide;
            messenger2.Show();
        }

        private void formHost_FormClosing(object sender, FormClosingEventArgs e)
        {
            messenger1.Close();
            messenger2.Close();
        }
    }
}
