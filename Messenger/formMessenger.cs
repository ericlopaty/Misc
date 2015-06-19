using System;
using System.Windows.Forms;
using Toolbox;

namespace Messenger
{
    public partial class formMessenger : Form
    {
        private Toolbox.Channel channel = null;

        public string SendFrom, ReceiveFrom;

        public formMessenger()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("Messaging from {0} to {1}", SendFrom, ReceiveFrom);
            channel = new Toolbox.Channel(SendFrom, ReceiveFrom, null);
            channel.Notify += new Toolbox.Channel.ChannelEventHandler(channel_Notify);
        }

        private delegate void notifyDelegate(object sender, Channel.ChannelEventArgs e);

        private void channel_Notify(object sender, Channel.ChannelEventArgs e)
        {
            if (tbReceive.InvokeRequired)
                tbReceive.Invoke(new notifyDelegate(channel_Notify), new object[] { sender, e });
            else
                tbReceive.Text = e.Data;
        }

        private void menuSend_Click(object sender, EventArgs e)
        {
            channel.Send(tbSend.Text);
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuClear_Click(object sender, EventArgs e)
        {
            tbSend.Text = "";
            tbReceive.Text = "";
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (channel != null)
                channel.Dispose();
        }
    }
}
