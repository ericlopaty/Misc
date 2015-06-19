using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileDump
{
    public partial class FormMain : Form
    {
        string fileName;

        public FormMain()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Exception x)
            {
                MessageBox.Show(string.Format("ERROR: {0}", x.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (System.Exception x)
            {
                MessageBox.Show(string.Format("ERROR: {0}", x.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.InitialDirectory = @"c:\";
                DialogResult result = openFileDialog.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                fileName = openFileDialog.FileName;
                LoadFile(fileName);
            }
            catch (System.Exception x)
            {
                MessageBox.Show(string.Format("ERROR: {0}", x.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFile(string fileName)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                rtbDisplay.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                rtbDisplay.Clear();
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                FileInfo fi = new FileInfo(fileName);
                byte[] buffer = null;
                long dumped = 0;
                string b;
                StringBuilder contents = new StringBuilder((int)(fi.Length / 16 + 1) * 76);
                StringBuilder line = null;
                while (dumped < fs.Length)
                {
                    line = new StringBuilder();
                    long bufLen = Math.Min(16, fs.Length - dumped);
                    buffer = new byte[bufLen];
                    fs.Read(buffer, 0, (int)bufLen);
                    line.Append(string.Format("{0,6:X}: |", dumped));
                    dumped += bufLen;
                    for (int i = 0; i < 16; i++)
                    {
                        if (i > 0) line.Append(" ");
                        if (i < bufLen)
                            b = string.Format("{0:X}", buffer[i]).PadLeft(2, '0');
                        else
                            b = "";
                        line.Append(string.Format("{0,2}", b));
                    }
                    line.Append("|");
                    for (int i = 0; i < 16; i++)
                    {
                        if (i < bufLen)
                        {
                            if (buffer[i] >= 32 && buffer[i] <= 127)
                                line.Append(string.Format("{0,1}", (char)buffer[i]));
                            else
                                line.Append(" ");
                        }
                        else
                        {
                            line.Append(" ");
                        }
                    }
                    line.Append("|");
                    contents.AppendLine(line.ToString());
                }
                rtbDisplay.Text = contents.ToString();
                statusLabel.Text = string.Format("File: {0}, Size: {1:#,###}", fi.Name, fi.Length);
            }
            catch (System.Exception x)
            {
                MessageBox.Show(string.Format("ERROR: {0}", x.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                rtbDisplay.Cursor = Cursors.Default;
                Application.DoEvents();
            }
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fi = new FileInfo(fileName);
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(fileName);
                DialogResult result = saveFileDialog.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                rtbDisplay.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
            }
            catch (System.Exception x)
            {
                MessageBox.Show(string.Format("ERROR: {0}", x.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            try
            {
                AboutBox about = new AboutBox();
                about.ShowDialog(this);
            }
            catch (System.Exception x)
            {
                MessageBox.Show(string.Format("ERROR: {0}", x.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
