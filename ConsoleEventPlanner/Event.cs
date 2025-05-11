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

            if (parts.Length != 3)
            {
                throw new ArgumentException("Invalid event format. Expected: EVENT;event name;YYYY-MM-DD.");
            }

            Title = parts[1].Trim();

            if (!DateTime.TryParse(parts[2], out DateTime parsedDate))
            {
                throw new ArgumentException("Invalid date format. Please use YYYY-MM-DD.");
            }
            Date = parsedDate;
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