using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compare
{
    public partial class SelectViewer : Form
    {
        public string FileViewer
        {
            get { return tbViewer.Text; }
            set { tbViewer.Text = value; }
        }

        public bool AcceptMultipleFiles
        {
            get { return cbMultiple.Checked; }
            set { cbMultiple.Checked = value; }
        }

        public bool UseNotepad
        {
            get { return cbUseNotepad.Checked; }
            set { cbUseNotepad.Checked = value; }
        }

        public SelectViewer()
        {
            InitializeComponent();
        }

        private void cbUseNotepad_CheckedChanged(object sender, EventArgs e)
        {
            tbViewer.Enabled = !cbUseNotepad.Checked;
            btnSelectViewer.Enabled = !cbUseNotepad.Checked;
            cbMultiple.Enabled = !cbUseNotepad.Checked;
            if (cbUseNotepad.Checked)
            {
                cbMultiple.Checked = false;
                tbViewer.Text = "NOTEPAD.EXE";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSelectViewer_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.Filter = "Program Files (*.exe)|*.exe";
                openFileDialog.Title = "Select File Viewer";
                openFileDialog.Multiselect = false;
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    tbViewer.Text = openFileDialog.FileName;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
