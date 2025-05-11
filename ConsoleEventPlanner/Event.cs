using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleEventPlanner
{
    public class Event
    {
        private string Title { get; set; }
        private DateTime Date { get; set; }

        public Event(string input)
        {
            string[] parts = input.Split(";");

            if (parts.Length == 3)
            {
                Title = parts[1];
                Date = DateTime.Parse(parts[2]);
            }
        }

        public string getTitle()
        {
            return Title;
        }

        public DateTime getDate()
        {
            return Date;
        }
    }
}