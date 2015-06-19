using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace stuff
{
    public partial class EventEntry : Form
    {
        public EventEntry()
        {
            InitializeComponent();
        }

        private void Events_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader reader = File.OpenText("events.txt"))
                    tbEvents.Text = reader.ReadToEnd();
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (File.Exists("events.txt")) File.Delete("events.txt");
            File.AppendAllText("events.txt", tbEvents.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
