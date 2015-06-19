using System;
//using System.Collections.Generic;
//using System.Text;
using System.Collections;
using System.Windows.Forms;
//using System.Globalization;

namespace Manifest
{
    class ListViewItemComparer: IComparer
    {
        private static int lastColumn = -1;
        private static bool ascending = true;
        private int col;

        private int ParseText(string s)
        {
            string s2 = "";
            for (int i = 0; i < s.Length; i++)
                if (s[i] != ',') s2 += s[i];
            return int.Parse(s2);
        }

        public ListViewItemComparer()
        {
            this.col = 0;
            lastColumn = col;
        }

        public ListViewItemComparer(int col)
        {
            this.col = col;
            if (col == lastColumn)
                ascending = !ascending;
            else
                ascending = true;
            lastColumn = col;
        }

        public int Compare(object x, object y)
        {
            ListViewItem left = (ListViewItem)x;
            ListViewItem right = (ListViewItem)y;
            int result = 0;

            switch (col)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    if (ascending)
                        result = string.Compare(left.SubItems[col].Text, right.SubItems[col].Text, true);
                    else
                        result = string.Compare(right.SubItems[col].Text, left.SubItems[col].Text, true);
                    break;
                case 5:
                    if (ascending)
                        result = (DateTime.Compare(DateTime.Parse(left.SubItems[col].Text), DateTime.Parse(right.SubItems[col].Text)));
                    else
                        result = (DateTime.Compare(DateTime.Parse(right.SubItems[col].Text), DateTime.Parse(left.SubItems[col].Text)));
                    break;
            }
            return result;
        }
    }
}
