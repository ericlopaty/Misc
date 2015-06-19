using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rpn
{
    public partial class formRPN : Form
    {
        string x = "", y = "", z = "", t = "";
        int f = 4;
        StringBuilder operand = new StringBuilder();
        bool push = false;

        private string Template()
        {
            return "{0:#,###." + "".PadRight(f, '0') + "}";
        }

        public formRPN()
        {
            InitializeComponent();
        }

        private void Lift()
        {
            //lblT.Text = lblZ.Text;
            //lblZ.Text = lblY.Text;
            //lblY.Text = lblX.Text;
            //lblX.Text = "";
            //operand = new StringBuilder();
        }

        private void Drop()
        {
            //lblX.Text = lblY.Text;
            //operand = new StringBuilder(lblX.Text);
            //x = double.Parse(operand.ToString());
            //lblY.Text = lblZ.Text;
            //lblZ.Text = lblT.Text;
        }

        private void formRPN_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    Lift();
            //    e.Handled = true;
            //}
        }

        private string NumDisplay(double x)
        {
            string template = "{0:#,##0." + "".PadRight(f, '0') + "}";
            return string.Format(template, x);
        }

        private void formRPN_KeyPress(object sender, KeyPressEventArgs e)
        {
            //switch (e.KeyChar)
            //{
            //    case 'c':
            //    case 'C':
            //        x = y = z = t = 0;
            //        lblX.Text = "0";
            //        lblY.Text = "";
            //        lblZ.Text = "";
            //        lblT.Text = "";
            //        e.Handled = true;
            //        operand = new StringBuilder();
            //        break;
            //    case '1':
            //    case '2':
            //    case '3':
            //    case '4':
            //    case '5':
            //    case '6':
            //    case '7':
            //    case '8':
            //    case '9':
            //    case '0':
            //        operand.Append(e.KeyChar);
            //        x = double.Parse(operand.ToString());
            //        lblX.Text = operand.ToString();
            //        break;
            //    case '.':
            //        if (!operand.ToString().Contains('.'))
            //            if (operand.Length == 0)
            //                operand.Append("0.");
            //            else
            //                operand.Append(".");
            //        lblX.Text = operand.ToString();
            //        break;
            //    case (char)Keys.Back:
            //        int i = operand.Length;
            //        operand.Remove(i - 1, 1);
            //        lblX.Text = operand.ToString();
            //        x = double.Parse(lblX.Text);
            //        break;
            //}
        }


        // operators
        // + - * / \ % ! 

        private void formRPN_Load(object sender, EventArgs e)
        {
            x = "0";
            y = "0";
            z = "0";
            t = "0";
            tbX.Text = string.Format(Template(), double.Parse(x));
        }

        private void tbX_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbX_KeyPress(object sender, KeyPressEventArgs e)        
        {
            switch (e.KeyChar)
            {
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
                case '.':
                    x = x + e.KeyChar;
                    double dx = double.Parse(x);
                    tbX.Text = string.Format(Template(), dx);
                    break;
            }
        }

        private void tbX_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tbX_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
