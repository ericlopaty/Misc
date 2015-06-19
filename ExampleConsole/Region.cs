using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleConsole
{
    class Region
    {
        private int left, top, length;
        private string format;

        public Region(int left, int top, int length, string format)
        {
            this.left = left;
            this.top = top;
            this.length = length;
            this.format = format;
        }

        public void Show(object value)
        {
            string display = string.Format(format, value);
            if (display.Length > length)
                display = display.Substring(0, length);
            Console.SetCursorPosition(left, top);
            Console.Write(display);
        }
    }
}
