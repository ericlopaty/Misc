using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PhotoDups
{
    public partial class PhotoDups : Form
    {
        List<FileInfo> files = new List<FileInfo>();

        public PhotoDups()
        {
            InitializeComponent();
        }

        private void btnAddPath_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
                lstPaths.Items.Add(folderBrowser.SelectedPath);
        }

        private void listDups_Click(object sender, EventArgs e)
        {
        }

        private void listDups_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] files = ((string)listDups.SelectedItem).Split('~');
                pictureOne.Load(files[0].Trim());
                tbOne.Text = files[0].Trim();
                pictureTwo.Load(files[1].Trim());
                tbTwo.Text = files[1].Trim();
            }
            catch
            {
            }
        }

        private void btnRemove1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] files = ((string)listDups.SelectedItem).Split('~');
                string fileName = files[0].Trim();
                File.Move(fileName, fileName + "DELETE ");
                listDups.Focus();
                listDups.SelectedIndex += 1;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btnRemove2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] files = ((string)listDups.SelectedItem).Split('~');
                string fileName = files[1].Trim();
                File.Move(fileName, fileName + " DELETE");
                listDups.Focus();
                listDups.SelectedIndex += 1;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            lstPaths.Items.Clear();
        }

        private void Scan(DirectoryInfo path)
        {
            FileInfo[] pix = path.GetFiles("*.jpg");
            files.AddRange(pix);
        }

        private void btnScanFiles_Click(object sender, EventArgs e)
        {
            files = new List<FileInfo>();
            for (int i = 0; i < lstPaths.Items.Count; i++)
            {
                string path = lstPaths.Items[i].ToString();
                DirectoryInfo di = new DirectoryInfo(path);
                Scan(di);
            }
            listDups.Items.Clear();
            for (int i = 0; i < files.Count; i++)
            {
                lblStatus.Text = string.Format("{0}/{1}", i, files.Count);
                Application.DoEvents();
                for (int j = i + 1; j < files.Count; j++)
                {
                    if (i < j && files[i].Length == files[j].Length)
                        listDups.Items.Add(
                            string.Format("{0} ~ {1}", files[i].FullName, files[j].FullName));
                }
            }
            lblStatus.Text = "";
        }
    }
}
