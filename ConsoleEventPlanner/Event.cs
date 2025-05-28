using System.Globalization;

namespace ConsoleEventPlanner
{
    public class Event
    {
        public string Title { get; }
        public DateTime Date { get; }

        public Event(string input)
        {
            string[] parts = input.Split(";", StringSplitOptions.TrimEntries);

            if (parts.Length != 3)
            {
                throw new ArgumentException("Invalid event format. Expected: EVENT;event name;YYYY-MM-DD.");
            }

            Title = parts[1];

            if (!DateTime.TryParseExact(parts[2], "yyyy-MM-dd", null, DateTimeStyles.None, out DateTime parsedDate))
            {
                throw new ArgumentException("Invalid date format. Please use YYYY-MM-DD.");
            }
            Date = parsedDate;
        }
    }
}