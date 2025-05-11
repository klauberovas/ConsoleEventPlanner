using System.ComponentModel;

namespace ConsoleEventPlanner;

class Program
{
    static void Main(string[] args)
    {
        List<Event> listEvents = new List<Event>(){
            new Event("EVENT;Birthday Party;2025-07-15"),
            new Event("EVENT;Czechitas Party;2025-07-15"),
            new Event("EVENT;Conference;2025-06-01"),
            new Event("EVENT;Wedding;2025-09-10")
        };

        Dictionary<DateTime, int> dictionaryStats = new Dictionary<DateTime, int>();

        while (true)
        {
            Console.WriteLine("============== EVENT PLANNER ===============");
            Console.WriteLine("Enter a command in the following format:");
            Console.WriteLine("  EVENT;event name;YYYY-MM-DD");
            Console.WriteLine("  LIST   - displays all stored events");
            Console.WriteLine("  STATS  - shows event statistics by date");
            Console.WriteLine("  END    - exits the program");
            Console.WriteLine("===========================================");
            string input = Console.ReadLine().Trim();

            if (input.ToUpper().StartsWith("EVENT;"))
            {
                try
                {
                    Event newEvent = new Event(input);
                    listEvents.Add(newEvent);
                    Console.WriteLine("The event was added.");
                }
                catch (ArgumentException exception)
                {

                    Console.WriteLine($"Error: {exception.Message}");
                }
            }
            else
            {
                switch (input.ToUpper())
                {
                    case "LIST":
                        ShowListEvents(listEvents);
                        break;

                    case "STATS":
                        DisplayEventStatistics(listEvents);
                        break;

                    case "END":
                        return;

                    default:
                        Console.WriteLine("Unknown command. Please try again.");
                        break;
                }
            }

        }
    }
    public static void ShowListEvents(List<Event> listEvents)
    {
        DateTime actualDate = DateTime.Now;

        foreach (var e in listEvents.OrderBy(ev => ev.GetDate()))
        {
            double remaining = (e.GetDate() - actualDate).Days;
            if (remaining >= 0)
            {
                Console.WriteLine($"Event {e.GetTitle()} with date {e.GetDate().ToString("yyyy-MM-dd")} with happen in {remaining} days");
            }
        }
    }

    public static void DisplayEventStatistics(List<Event> listEvents)
    {
        foreach (var item in listEvents.GroupBy(e => e.GetDate()))
        {
            Console.WriteLine($"Date: {item.Key.ToString("yyyy-MM-dd")}: events: {item.Count()}");
        }
    }
}
