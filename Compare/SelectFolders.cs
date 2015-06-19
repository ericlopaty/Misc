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
    public partial class SelectFolders : Form
    {
        public string LeftFolder
        {
            get { return tbLeft.Text; }
            set { tbLeft.Text = value; }
        }

        public string RightFolder
        {
            get { return tbRight.Text; }
            set { tbRight.Text = value; }
        }

        public bool IncludeSubfolders
        {
            get { return cbSubFolders.Checked; }
            set { cbSubFolders.Checked = value; }
        }

        public SelectFolders()
        {
            InitializeComponent();
        }

        private bool ValidateFolders()
        {
            if (tbLeft.Text.Length > 0 && tbRight.Text.Length > 0)
                if (Directory.Exists(tbLeft.Text) && Directory.Exists(tbRight.Text))
                    return true;
            return false;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            DialogResult r = folderBrowserDialog.ShowDialog();
            if (r == DialogResult.Cancel)
                return;
            tbLeft.Text = folderBrowserDialog.SelectedPath;
            btnOK.Enabled = ValidateFolders();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            DialogResult r = folderBrowserDialog.ShowDialog();
            if (r == DialogResult.Cancel)
                return;
            tbRight.Text = folderBrowserDialog.SelectedPath;
            btnOK.Enabled = ValidateFolders();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateFolders())
                MessageBox.Show("Missing/Invalid Folders", "Select Folders", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
