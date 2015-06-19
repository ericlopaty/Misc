using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;

namespace dissolve
{
    /// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer timer;
		private System.ComponentModel.IContainer components;

		private Graphics dc;
		private Random r=new Random(DateTime.Now.Millisecond);
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private ArrayList coord=new ArrayList();
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(478, 690);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(478, 690);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		}

		private void timer_Tick(object sender, System.EventArgs e)
		{
			if (coord.Count==0)
			{
				timer.Enabled=false;
			}
			else
			{
				int i=r.Next(coord.Count);
				Coord c=(Coord)coord[i];
				dc.FillRectangle(Brushes.Black,c.X,c.Y,1,1);
				coord.RemoveAt(i);
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				int blockSize=1;
				button1.Visible=false;
				this.FormBorderStyle=FormBorderStyle.None;
				Application.DoEvents();
				dc=pictureBox1.CreateGraphics();
				for (int x=0;x<this.Width;x+=blockSize)
				{
					for (int y=0;y<this.Height;y+=blockSize)
					{
						Coord c=new Coord(x,y);
						coord.Add(c);
					}
				}
				Application.DoEvents();
				while (coord.Count>0)
				{
					Application.DoEvents();
					if (coord.Count==0)
					{
						return;
					}
					else
					{
						int i=r.Next(coord.Count);
						Coord c=(Coord)coord[i];
						dc.FillRectangle(Brushes.White,c.X,c.Y,blockSize,blockSize);
						coord.RemoveAt(i);
						//this.Text=coord.Count.ToString();
					}
				}
			}
			catch (System.Exception x)
			{
				MessageBox.Show(x.Message);
			}
			finally
			{
				button1.Visible=true;
			}
		}
	}

    public class Coord
    {
        private int x, y;

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X { get { return x; } }
        public int Y { get { return y; } }
    }
}
