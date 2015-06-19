using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Navigator
{
    public partial class FormNavigator : Form
    {
        public FormNavigator()
        {
            InitializeComponent();
        }

        private void FormNavigator_Load(object sender, EventArgs e)
        {
            tree.Nodes.Clear();
            string[] drives = Environment.GetLogicalDrives();
            foreach (string drive in drives)
            {
                DirectoryInfo di = new DirectoryInfo(drive);
                TreeNode node=new TreeNode(di.Name);
                node.Tag=di;
                tree.Nodes.Add(node);
            }
        }
    }
}
