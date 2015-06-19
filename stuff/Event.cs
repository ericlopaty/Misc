using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stuff
{
    class Event
    {
        private string name;
        private DateTime date;

        public Event(string name, DateTime date)
        {
            this.name = name;
            this.date = date;
        }

        public string Name { get { return this.name; } }
        public DateTime Date { get { return this.date; } }
    }
}
