using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace stuff
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private List<Event> events;

        private void btnEditEvents_Click(object sender, EventArgs e)
        {
            EventEntry f = new EventEntry();
            f.ShowDialog();
            LoadEvents();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadEvents();
            timerEvents_Tick(null, null);
        }

        private void LoadEvents()
        {
            try
            {
                events = new List<Event>();
                using (StreamReader input = File.OpenText("events.txt"))
                {
                    string s;
                    while ((s = input.ReadLine()) != null)
                        if (s.Trim().Length > 0)
                        {
                            int i = s.IndexOf(';');
                            string name = s.Substring(0, i).Trim();
                            DateTime date = DateTime.Parse(s.Substring(i + 1).Trim());
                            Event e = new Event(name, date);
                            events.Add(e);
                        }
                    input.Close();
                }
            }
            catch
            {
            }
        }

        private void timerEvents_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (listEvents.Items.Count == 0)
            {
                foreach (Event item in events)
                {
                    int d = (int)Math.Ceiling(item.Date.Subtract(now).TotalDays);
                    if (d > 0)
                    {
                        listEvents.Items.Add(new ListViewItem(new string[] { item.Name, d.ToString() }));
                    }
                }
            }
            else
            {
                foreach (Event item in events)
                {
                    double d = item.Date.Subtract(now).TotalDays;
                    bool remove = d <= 0;
                    bool found = false;
                    foreach (ListViewItem lvi in listEvents.Items)
                    {
                        if (string.Compare(lvi.SubItems[0].ToString(), item.Name, true) == 0)
                        {
                            if (remove)
                                lvi.Remove();
                            else
                                lvi.SubItems[1].Text = string.Format("{0:#.#}", d);
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        listEvents.Items.Add(new ListViewItem(new string[] { item.Name, d.ToString() }));
                    }
                }
            }
        }
    }
}
