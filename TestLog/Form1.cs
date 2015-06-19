using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Toolbox;
using System.Diagnostics;

namespace TestLog
{
    public partial class Form1 : Form
    {
        private Toolbox.Logger logger;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logger = new Logger(".", "TestLog", 5, 3, Logger.LogLevel.Trace);
        }

        private void buttonTrace_Click(object sender, EventArgs e)
        {
            logger.Trace("Trace event");
        }

        private void buttonDebug_Click(object sender, EventArgs e)
        {
            logger.Debug("Debug event");

        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            logger.Info("Information event");

        }

        private void buttonWarn_Click(object sender, EventArgs e)
        {
            logger.Warn("Warning event");

        }

        private void buttonError_Click(object sender, EventArgs e)
        {
            logger.Error("Error event");

        }

        private void buttonFatal_Click(object sender, EventArgs e)
        {
            logger.Fatal("Fatal event");
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
