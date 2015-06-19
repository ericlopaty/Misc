using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DirMonitor
{
    public partial class Form1 : Form
    {
        long files = 0, folders = 0, fileSize = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Scan(DirectoryInfo di)
        {
            folders++;
            textBox2.Text = string.Format("{0:#,###}", folders);
            Application.DoEvents();
            DirectoryInfo[] folderList = di.GetDirectories();
            FileInfo[] fileList = di.GetFiles();
            files += fileList.Length;
            foreach (FileInfo fi in fileList)
                fileSize += fi.Length;
            textBox3.Text = string.Format("{0:#,###}", files);
            textBox4.Text = string.Format("{0:#,###}", fileSize);
            Application.DoEvents();
            foreach (DirectoryInfo folder in folderList)
                Scan(folder);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.path;
            files = 0;
            folders = 0;
            DirectoryInfo di = new DirectoryInfo(textBox1.Text);
            Scan(di);
            fileSystemWatcher.Path = textBox1.Text;
            fileSystemWatcher.IncludeSubdirectories = true;
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(e.FullPath);
                folders++;
                textBox2.Text = string.Format("{0:#,###}", folders);
                Application.DoEvents();
            }
            catch
            {
            }
            try
            {
                FileInfo fi = new FileInfo(e.FullPath);
                files++;
                fileSize += fi.Length;
                textBox3.Text = string.Format("{0:#,###}", files);
                textBox4.Text = string.Format("{0:#,###}", fileSize);
                Application.DoEvents();
            }
            catch
            {
            }
        }
    }
}
