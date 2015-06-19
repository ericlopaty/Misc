using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Compare
{
    class ListViewItemComparer : System.Collections.IComparer
    {
        private static int lastColumn = -1;
        private static bool ascending = true;
        private int col;

        private int CountPathChars(string s)
        {
            int i = 0;
            for (int t = 0; t < s.Length; t++)
                i += (s[t] == Path.DirectorySeparatorChar) ? 1 : 0;
            return i;
        }

        public ListViewItemComparer(int col)
        {
            this.col = col;
            if (col == lastColumn)
            {
                ascending = !ascending;
            }
            else
            {
                ascending = true;
                lastColumn = col;
            }
        }

        public int Compare(object x, object y)
        {
            ListViewItem left = (ListViewItem)x;
            ListViewItem right = (ListViewItem)y;
            DateTime lDate, rDate;

            switch (col)
            {
                case 0:
                case 1:
                    bool isLeftTop = CountPathChars(left.SubItems[col].Text) == 0;
                    bool isRightTop = CountPathChars(right.SubItems[col].Text) == 0;
                    if (ascending)
                    {
                        if (isLeftTop && !isRightTop)
                            return -1;
                        if (!isLeftTop && isRightTop)
                            return 1;
                        return string.Compare(left.SubItems[col].Text, right.SubItems[col].Text, true);
                    }
                    else
                    {
                        if (isLeftTop && !isRightTop)
                            return 1;
                        if (!isLeftTop && isRightTop)
                            return -1;
                        return string.Compare(right.SubItems[col].Text, left.SubItems[col].Text, true);
                    }
                case 2:
                case 3:
                    string l = left.SubItems[col].Text;
                    string r = right.SubItems[col].Text;
                    if (ascending)
                    {
                        if (l.Length == 0) return 1;
                        if (r.Length == 0) return -1;
                        lDate = DateTime.Parse(l);
                        rDate = DateTime.Parse(r);
                        return DateTime.Compare(lDate, rDate);
                    }
                    else
                    {
                        if (l.Length == 0) return -1;
                        if (r.Length == 0) return 1;
                        lDate = DateTime.Parse(l);
                        rDate = DateTime.Parse(r);
                        return DateTime.Compare(rDate, lDate);
                    }
            }
            return 0;
        }
    }
}
