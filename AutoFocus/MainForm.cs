using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AutoFocus
{
    public partial class MainForm : Form
    {
        private string localAppData = null;
        private Font normal = null;
        private Font finished = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            localAppData = System.Environment.GetEnvironmentVariable("LOCALAPPDATA");
            string path = System.IO.Path.Combine(localAppData, "AutoFocus.rtf");
            if (File.Exists(path))
                rtbTasks.LoadFile(path);
            Font f = rtbTasks.Font;
            normal = new Font(f, FontStyle.Regular);
            finished = new Font(f, FontStyle.Strikeout);
            MoveToEnd();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = System.IO.Path.Combine(localAppData, "AutoFocus.rtf");
            rtbTasks.SaveFile(path);
        }

        private void btnReEnter_Click(object sender, EventArgs e)
        {
            rtbTasks.SelectionStart=rtbTasks.GetFirstCharIndexOfCurrentLine();
            rtbTasks.SelectionLength=rtbTasks.Lines[rtbTasks.GetLineFromCharIndex(rtbTasks.SelectionStart)].Length;
            string task = rtbTasks.SelectedText;
            if (!task.EndsWith("\n"))
                task+="\n";
            rtbTasks.SelectionFont = finished;
            MoveToEnd();
            if (!rtbTasks.Text.EndsWith("\n"))
                rtbTasks.AppendText("\n");
            rtbTasks.AppendText(task);
            MoveToEnd();
        }

        private void btnDismiss_Click(object sender, EventArgs e)
        {
            rtbTasks.SelectionStart = rtbTasks.GetFirstCharIndexOfCurrentLine();
            rtbTasks.SelectionLength = rtbTasks.Lines[rtbTasks.GetLineFromCharIndex(rtbTasks.SelectionStart)].Length;
            rtbTasks.SelectionBackColor = Color.Yellow;
            MoveToEnd();
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            rtbTasks.SelectionStart = rtbTasks.GetFirstCharIndexOfCurrentLine();
            rtbTasks.SelectionLength = rtbTasks.Lines[rtbTasks.GetLineFromCharIndex(rtbTasks.SelectionStart)].Length;
            rtbTasks.SelectionFont = finished;
            MoveToEnd();
        }

        private bool CheckSelection()
        {
            if (rtbTasks.SelectionLength == 0)
            {
                MessageBox.Show("Select a line or block of text.", "No Task Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void MoveToEnd()
        {
            Font f = rtbTasks.Font;
            normal = new Font(f, FontStyle.Regular);
            rtbTasks.SelectionStart = rtbTasks.Text.Length;
            rtbTasks.SelectionLength = 0;
            rtbTasks.SelectionFont = normal;
            rtbTasks.SelectionBackColor = SystemColors.Window;
        }

        private void rtbTasks_TextChanged(object sender, EventArgs e)
        {
            if (rtbTasks.Text.Length == 0)
                MoveToEnd();
        }
    }
}
