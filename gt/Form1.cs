using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace gt
{
    public partial class Form1 : Form
    {
        private Random r = new Random(DateTime.Now.Day);
        private int size = Program.Width * Program.Height;
        private int sum = 0;
        private List<Item> items = null;
        private List<int> intItems = null;
        private Bitmap bmp;
        private int borderWidth=3;
        private int titleHeight=25;
        int ladderInterval = 25;
        private int zero = -1;
        string caption = "";
        int ladderIndex, ladderStep;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(Program.Width * Program.Scale, Program.Height * Program.Scale);
            image.Left = 0;
            image.Top = 0;
            image.Width = bmp.Width;
            image.Height = bmp.Height;
            this.Width = image.Width + (borderWidth*2);
            this.Height = image.Height + borderWidth + titleHeight;
            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                    bmp.SetPixel(x, y, Color.FromArgb(Program.COLOR_MAX, Program.COLOR_MAX, Program.COLOR_MAX));
            items = new List<Item>();
            intItems = new List<int>();
            for (int i = 0; i < size; i++)
            {
                items.Add(new Item(i, Program.MAX));
                intItems.Add(Program.MAX);
            }
            image.Image = bmp;
            sum = size * Program.MAX;
            timer.Enabled = true;
            ladderIndex = items.Count - 1;
            ladderStep = 0;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            switch (Program.Display)
            {
                case 'L':
                    WaterfallLadder();
                    break;
                case 'C':
                    WaterfallCollapse();
                    break;
                case 'S':
                    WaterfallStatic();
                    break;
            }
        }

        void WaterfallStatic()
        {
            int timeLeft = (int)Program.Target.Subtract(DateTime.Now).TotalSeconds;
            timer.Enabled = false;
            while (sum > timeLeft)
            {
                int i = r.Next(items.Count);
                items[i].Value--;
                items[i].Write(bmp);
                if (items[i].Value == 0)
                    items.RemoveAt(i);
                sum--;
                image.Image = bmp;
                caption = string.Format("{0:#,##0} ({1:#,##0})", sum,Math.Ceiling((double)sum/60));
                if (this.Text.CompareTo(caption) != 0) this.Text = caption;
                Application.DoEvents();
            }
            timer.Enabled = sum > 0;
        }

        void WaterfallDrop()
        {
            int timeLeft = (int)Program.Target.Subtract(DateTime.Now).TotalSeconds;
            timer.Enabled = false;
            while (sum > timeLeft)
            {
                int i = r.Next(items.Count);
                items[i].Value--;
                items[i].Write(bmp);
                if (items[i].Value == 0)
                    items.RemoveAt(i);
                sum--;
                image.Image = bmp;
                caption = string.Format("{0:#,##0} ({1:#,##0})", sum, Math.Ceiling((double)sum / 60));
                if (this.Text.CompareTo(caption) != 0) this.Text = caption;
                Application.DoEvents();
            }
            timer.Enabled = sum > 0;
        }

        public void Write(int position, int value)
        {
            int left = (position % Program.Width) * Program.Scale;
            int top = (position / Program.Width) * Program.Scale;
            int idx = 0;
            int v;
            for (int x = 0; x < Program.Scale; x++)
                for (int y = 0; y < Program.Scale; y++)
                {
                    v = (Program.Vectors[value, idx++] == 0) ? 0 : Program.COLOR_MAX;
                    bmp.SetPixel(left + x, top + y, Color.FromArgb(v, v, v));
                }
        }

        void WaterfallCollapse()
        {
            int timeLeft = (int)Program.Target.Subtract(DateTime.Now).TotalSeconds;
            timer.Enabled = false;
            while (sum > timeLeft)
            {
                if (zero >= 0)
                {
                    for (int j = zero; j < items.Count; j++)
                        Write(j, items[j].Value);
                    Write(items.Count, 0);
                    zero = -1;
                }
                int i = r.Next(items.Count);
                items[i].Value--;
                Write(i, items[i].Value);
                if (items[i].Value == 0)
                {
                    zero = i;
                    items.RemoveAt(i);
                }
                sum--;
                image.Image = bmp;
                caption = string.Format("{0:#,##0} ({1:#,##0})", sum, Math.Ceiling((double)sum / 60));
                if (this.Text.CompareTo(caption) != 0) this.Text = caption;
                int newHeight = Math.Max(items.Count / Program.Width + 1, 1) * Program.Scale;
                this.Height = Math.Min(newHeight + 28, this.Height);
                Application.DoEvents();
            }
            timer.Enabled = sum > 0;
        }

        void WaterfallLadder()
        {
            int timeLeft = (int)Program.Target.Subtract(DateTime.Now).TotalSeconds;
            timer.Enabled = false;
            while (sum > timeLeft)
            {
                items[ladderIndex + ladderStep].Value--;
                items[ladderIndex + ladderStep].Write(bmp);
                if (items[ladderIndex + ladderStep].Value == 0)
                    items.RemoveAt(ladderIndex + ladderStep);
                ladderStep += ladderInterval;
                if ((ladderIndex + ladderStep) > (items.Count - 1))
                {
                    ladderStep = 0;
                    ladderIndex--;
                    if (ladderIndex < 0) ladderIndex = ladderInterval - 1;
                }
                sum--;
                image.Image = bmp;
                caption = string.Format("{0:#,##0} ({1:#,##0})", sum, Math.Ceiling((double)sum / 60));
                if (this.Text.CompareTo(caption) != 0) this.Text = caption;
                int newHeight = Math.Max(items.Count / Program.Width + 1, 1) * Program.Scale;
                this.Height = Math.Min(newHeight + 28, this.Height);
                Application.DoEvents();
            }
            timer.Enabled = sum > 0;
        }
    }

    class Item
    {
        public int Value;
        public int Position;

        public Item(int position, int value)
        {
            this.Position = position;
            this.Value = value;
        }
        public void Write(Bitmap bmp)
        {
            int left = (Position % Program.Width) * Program.Scale;
            int top = (Position / Program.Width) * Program.Scale;
            int idx = 0;
            int v = 0;
            for (int x = 0; x < Program.Scale; x++)
                for (int y = 0; y < Program.Scale; y++)
                {
                    v = (Program.Vectors[Value, idx++] == 0) ? 0 : Program.COLOR_MAX;
                    bmp.SetPixel(left + x, top + y, Color.FromArgb(v, v, v));
                }
        }
    }
}