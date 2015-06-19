using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Explorer
{
    public partial class ExplorerMain : Form
    {
        public ExplorerMain()
        {
            InitializeComponent();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuFillTree_Click(object sender, EventArgs e)
        {
            treeView.Nodes.Clear();
            TreeNode node = treeView.Nodes.Add("Groups");
            node.Nodes.Add("Beatles");
            node.Nodes.Add("Who");
            node.Nodes.Add("Rolling Stones");
            node.Nodes.Add("Rush");
            node.Nodes.Add("Genesis");
            node.Nodes.Add("Yes");
            node.Nodes.Add("Jethro Tull");
            node.Nodes.Add("Pink Floyd");
            node.Nodes.Add("AC/DC");
            node.Nodes.Add("Def Leppard");
            node.Nodes.Add("Lynyrd Skynyrd");
            node.Nodes.Add("ELP");
            node.Nodes.Add("Aerosmith");
            node.Nodes.Add("Fleetwood Mac");
            node.Nodes.Add("Styx");
            node.Nodes.Add("Queen");
            node.Nodes.Add("America");
            node.Nodes.Add("Moody Blues");
            node.Nodes.Add("Doors");
            node.Nodes.Add("Doobie Brothers");
            node = treeView.Nodes.Add("Singers");
            node.Nodes.Add("Billy Joel");
            node.Nodes.Add("Elton John");
            node.Nodes.Add("Peter Gabriel");
            node.Nodes.Add("Paul McCartney");
            node.Nodes.Add("John Lennon");
            node.Nodes.Add("George Harrison");
            node.Nodes.Add("Bruce Hornsby");
            node.Nodes.Add("Bruce Springsteen");
            node.Nodes.Add("David Bowie");
        }
    }
}
