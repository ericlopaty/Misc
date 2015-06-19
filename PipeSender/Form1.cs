using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Toolbox;

namespace PipeSender
{
    public partial class Form1 : Form
    {
        Random r = new Random(DateTime.Now.Millisecond);
        Toolbox.Channel channel = new Toolbox.Channel("Sender", "Receiver", null);
        int received = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPrepList_Click(object sender, EventArgs e)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            string alpha = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz1234567890";
            lbToBeSent.Items.Clear();
            for (int i = 0; i < 10000; i++)
            {
                int len = r.Next(10, 50);
                StringBuilder s = new StringBuilder();
                s.Append(string.Format("Message {0,4:0000}: ", i));
                for (int j = 0; j < len; j++)
                    s.Append(alpha[r.Next(0, alpha.Length)]);
                lbToBeSent.Items.Add(s.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            channel.Notify += new Channel.ChannelEventHandler(channel_Notify);
            channel.StartListener();
        }

        private delegate void ItemAddDelegate(string item);

        private void ItemAdd(string item)
        {
            if (lbReceipts.InvokeRequired)
                lbReceipts.Invoke(new ItemAddDelegate(ItemAdd), new object[] { item });
            else
                lbReceipts.Items.Add(item);
        }

        private void channel_Notify(object sender, Channel.ChannelEventArgs e)
        {
            ItemAdd(e.Data);
            received++;
            tbReceived.SetText(received.ToString());
        }

        private void btnStartSending_Click(object sender, EventArgs e)
        {
            lbReceipts.Items.Clear();
            received = 0;
            tbReceived.Text = received.ToString();
            while (lbToBeSent.Items.Count > 0)
            {
                int index = r.Next(0, lbToBeSent.Items.Count);
                string s = lbToBeSent.Items[index].ToString();
                lbToBeSent.Items.RemoveAt(index);
                tbSendCount.Text = lbToBeSent.Items.Count.ToString();
                channel.Send(s);
                Application.DoEvents();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            channel.Dispose();
        }
    }
}
