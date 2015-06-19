using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace printing
{
    public partial class Form1 : Form
    {
        Image document;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            document=new Bitmap(543,696);
            Graphics g = Graphics.FromImage(document);
            Font f = new Font(label1.Font.Name, label1.Font.Size, label1.Font.Style, label1.Font.Unit);
            g.Clear(Color.White);
            int x=0,y=0;
            for (int i = 0; i < 10; i++)
            {
                g.DrawString(string.Format("Hello{0}", i), f, Brushes.Black, x, y);
                y += (int)g.MeasureString("1", f).Height;
            }
            document.Save("c:\\temp\\document.bmp");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument doc=new PrintDocument()

        }
    }
}


/*
    picDocument.AutoRedraw = True
    picDocument.AutoSize = True
    picDocument.BackColor = vbWhite
    picDocument.FontName = "MS Sans Serif"
    picDocument.FontBold = False
    picDocument.FontSize = 10
    picDocument.Width = 8200 '9732
    picDocument.Height = 10500 '13000
    
    Dim i As Integer
    For i = 1 To 10
        picDocument.Print "Hello" & i
    Next
    SavePicture picDocument.Image, "c:\temp\document.bmp"*/