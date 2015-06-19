using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Toolbox;

namespace PipeReceiver
{
    public partial class Form1 : Form
    {
        Toolbox.Channel channel = new Toolbox.Channel("Receiver", "Sender", null);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            channel.Notify += new Toolbox.Channel.ChannelEventHandler(channel_Notify);
            channel.StartListener();
        }

        private void channel_Notify(object sender, Toolbox.Channel.ChannelEventArgs e)
        {
            tbReceived.SetText(e.Data);
            int i = int.Parse(e.Data.Substring(8, 4));
            channel.Send(string.Format("Received message {0,4:0000}", i));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            channel.Dispose();
        }
    }
}
