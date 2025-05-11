using System.ComponentModel;

namespace ConsoleEventPlanner;

class Program
{
    static void Main(string[] args)
    {
        var events = new List<Event>(){
            new Event("EVENT;Birthday Party;2025-07-15"),
            new Event("EVENT;Czechitas Party;2025-07-15"),
            new Event("EVENT;Conference;2025-06-01"),
            new Event("EVENT;Wedding;2025-09-10")
        };

        var stats = new Dictionary<DateTime, int>();

        foreach (var ev in events)
        {
            AddToStats(stats, ev);
        }

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
                    events.Add(newEvent);
                    AddToStats(stats, newEvent);
                    Console.WriteLine("Event added.");
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                switch (input.ToUpper())
                {
                    case "LIST":
                        ShowEvents(events);
                        break;

                    case "STATS":
                        ShowStats(stats);
                        // ShowStatsAlt(events);
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

    private static void AddToStats(Dictionary<DateTime, int> stats, Event ev)
    {
        var date = ev.Date;
        stats[date] = stats.TryGetValue(date, out int count) ? count + 1 : 1;
    }

    private static void ShowEvents(List<Event> listEvents)
    {
        DateTime today = DateTime.Now;

        foreach (var e in listEvents.OrderBy(ev => ev.Date))
        {
            int daysLeft = (e.Date - today).Days;
            if (daysLeft >= 0)
            {
                Console.WriteLine($"Event {e.Title} with date {e.Date:yyyy-MM-dd} with happen in {daysLeft} days");
            }
        }
    }

    public static void ShowStats(Dictionary<DateTime, int> stats)
    {
        foreach (var item in stats)
        {
            Console.WriteLine($"Date: {item.Key:yyyy-MM-dd}: events: {item.Value}");
        }
    }

    public static void ShowStatsAlt(List<Event> listEvents)
    {
        foreach (var item in listEvents.GroupBy(e => e.Date))
        {
            Console.WriteLine($"Date: {item.Key:yyyy-MM-dd}: events: {item.Count()}");
        }
    }
}
