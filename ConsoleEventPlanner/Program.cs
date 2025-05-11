namespace ConsoleEventPlanner;

class Program
{
    static void Main(string[] args)
    {
        List<Event> listEvents = new List<Event>(){
            new Event("EVENT;Birthday Party;2025-07-15"),
            new Event("EVENT;Conference;2025-06-01"),
            new Event("EVENT;Wedding;2025-09-10")
        };

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
                Event newEvent = new Event(input);
                listEvents.Add(newEvent);
                Console.WriteLine("The event was added.");
            }
            else
            {
                switch (input.ToUpper())
                {
                    case "LIST":
                        showListEvents(listEvents);
                        break;

                    case "STATS":
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
    public static void showListEvents(List<Event> listEvents)
    {
        DateTime actualDate = DateTime.Now;

        foreach (var e in listEvents.OrderBy(ev => ev.getDate()))
        {
            double remaining = (e.getDate() - actualDate).Days;
            if (remaining >= 0)
            {
                Console.WriteLine($"Event {e.getTitle()} with date {e.getDate().ToString("yyyy-MM-dd")} with happen in {remaining} days");
            }
        }
    }
}
