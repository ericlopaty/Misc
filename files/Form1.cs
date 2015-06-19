using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace files
{
    public partial class Form1 : Form
    {
        private int fileCount = 0;
        private int folderCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            tree.Nodes.Clear();
            fileCount = 0;
            folderCount = 0;
            DirectoryInfo dirRoot = new DirectoryInfo(@"H:\DEV\ImagePublisherTrial");
            TreeNode treeRoot = tree.Nodes.Add(dirRoot.FullName, dirRoot.Name, 0, 0);
            treeRoot.Tag = "Folder";
            WalkTree(treeRoot, dirRoot);
            this.Cursor = Cursors.Default;
        }

        private void WalkTree(TreeNode root, DirectoryInfo parent)
        {
            foreach (DirectoryInfo folder in parent.GetDirectories())
            {
                TreeNode node = root.Nodes.Add(folder.FullName, folder.Name, 0, 0);
                node.Tag = "Folder";
                folderCount++;
                WalkTree(node, folder);
                status.Text = string.Format("{0} folders, {1} files", folderCount, fileCount);
                Application.DoEvents();
            }
            foreach (FileInfo file in parent.GetFiles())
            {
                TreeNode fileNode = root.Nodes.Add(file.FullName, file.Name, 2, 2);
                fileNode.Tag = "File";
                fileCount++;
                status.Text = string.Format("{0} folders, {1} files", folderCount, fileCount);
                Application.DoEvents();
            }
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            TreeNode root = tree.Nodes[0];
            DeleteTree(root);

        }

        private void DeleteTree(TreeNode node)
        {
            if (node.Nodes.Count > 0)
            {
                while (node.Nodes.Count > 0)
                {
                    string nodeType = (string)node.Nodes[0].Tag;
                    if (string.Compare(nodeType, "folder", true) == 0)
                    {
                        DeleteTree(node.Nodes[0]);
                        Directory.Delete(node.Nodes[0].Name);
                        folderCount--;
                    }
                    if (string.Compare(nodeType, "file", true) == 0)
                    {
                        File.Delete(node.Nodes[0].Name);
                        fileCount--;
                    }
                    node.Nodes.RemoveAt(0);
                    status.Text = string.Format("{0} folders, {1} files", folderCount, fileCount);
                    Application.DoEvents();
                    deThread.Sleep(1000);
                }
            }
        }
    }
}
