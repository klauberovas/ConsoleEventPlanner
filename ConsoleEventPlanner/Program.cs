namespace ConsoleEventPlanner;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("============== EVENT PLANNER ===============");
            Console.WriteLine("Enter a command in the following format:");
            Console.WriteLine("  EVENT;event name;YYYY-MM-DD");
            Console.WriteLine("  LIST   - displays all stored events");
            Console.WriteLine("  STATS  - shows event statistics by date");
            Console.WriteLine("  END    - exits the program");
            Console.WriteLine("===========================================");
            string input = Console.ReadLine();
            if (input.ToUpper() == "END")
            {
                return;
            }
        }
    }
}
