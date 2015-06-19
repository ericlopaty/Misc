using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stack
{
    public partial class FormMain : Form
    {
        bool pushFlag = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Push()
        {
            label1.Text = label2.Text;
            label2.Text = label3.Text;
            label3.Text = label4.Text;
            label4.Text = textBox1.Text;
            textBox1.Text = "";
            pushFlag = false;
        }

        private string Pop()
        {
            string s = label4.Text;
            label4.Text = label3.Text;
            label3.Text = label2.Text;
            label2.Text = label1.Text;
            label1.Text = "";
            if (s.Length == 0)
                s = "0";
            return s;
        }

        private void Int()
        {
            double d = double.Parse(textBox1.Text);
            d = Math.Truncate(d);
            textBox1.Text = string.Format("{0}", d);
        }

        private void Add()
        {
            double d = double.Parse(textBox1.Text);
            d += double.Parse(Pop());
            textBox1.Text = string.Format("{0}", d);
            pushFlag = true;
        }

        private void Subtract()
        {
            double d = double.Parse(textBox1.Text);
            d -= double.Parse(Pop());
            textBox1.Text = string.Format("{0}", d);
            pushFlag = true;
        }

        private void Multiply()
        {
            double d = double.Parse(textBox1.Text);
            d *= double.Parse(Pop());
            textBox1.Text = string.Format("{0}", d);
            pushFlag = true;
        }

        private void Divide()
        {
            double d = double.Parse(textBox1.Text);
            d /= double.Parse(Pop());
            textBox1.Text = string.Format("{0}", d);
            pushFlag = true;
        }

        private void Round()
        {
        }

        private void Random()
        {
        }

        private void Fract()
        {
            double d = double.Parse(textBox1.Text);
            d -= Math.Truncate(d);
            textBox1.Text = string.Format("{0}", d);
        }

        private void Sign()
        {
            double d = double.Parse(textBox1.Text);
            d *= -1;
            textBox1.Text = string.Format("{0}", d);
        }

        private void Square()
        {
        }

        private void Cube()
        {
        }

        private void SquareRoot()
        {
        }

        private void CubeRoot()
        {
        }

        private void Sin()
        {
        }

        private void Cos()
        {
        }

        private void Tan()
        {
        }

        private void Deg2Rad()
        {
        }

        private void Rad2Deg()
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            switch (key)
            {
                case (char)Keys.Back:
                    e.Handled = false;
                    break;
                case (char)Keys.Escape:
                    textBox1.Text = "0";
                    e.Handled = true;
                    break;
                case (char)Keys.Enter:
                    Push();
                    break;
                case 's':
                case 'S':
                    Sign();
                    e.Handled = true;
                    break;
                case 'c':
                case 'C':
                    textBox1.Text = "0";
                    e.Handled = true;
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    if (pushFlag) Push();
                    e.Handled = false;
                    break;
                case '.':
                    if (textBox1.Text.Contains('.'))
                    {
                        e.Handled = true;
                        Console.Beep();
                    }
                    else
                    {
                        e.Handled = false;
                    }
                    break;
                case '+':
                    e.Handled = true;
                    Add();
                    break;
                case '-':
                    e.Handled = true;
                    Subtract();
                    break;
                case '*':
                    e.Handled = true;
                    Multiply();
                    break;
                case '/':
                    e.Handled = true;
                    Divide();
                    break;
                case 'i':
                case 'I':
                    e.Handled = true;
                    Int();
                    break;
                case 'f':
                case 'F':
                    e.Handled = true;
                    Fract();
                    break;
                default:
                    e.Handled = true;
                    break;
            }
            textBox1.SelectionStart = textBox1.Text.Length;
        }
    }
}
