using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Imager
{
    public partial class Form1 : Form
    {
        private string selectedPath;
        private FileInfo[] images = null;
        private int imageIndex = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void menuSelectPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowNewFolderButton = false;
            folderBrowserDialog.SelectedPath = "c:\\docs\\download";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                selectedPath = folderBrowserDialog.SelectedPath;
        }

        private void menuStart_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            DirectoryInfo di=new DirectoryInfo(selectedPath);
            images = di.GetFiles("*.jpg");
        }

        private void menuStop_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            imageIndex++;
            if (images != null)
                if (imageIndex < images.Length)
                    pictureBox.Load(images[imageIndex].FullName);
        }
    }
}
