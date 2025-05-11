namespace ConsoleEventPlanner;

class Program
{
    static void Main(string[] args)
    {
        Event myEvent = new Event("EVENT;Lekce Czechitas;2025-05-15");
        Console.WriteLine($"{myEvent.getTitle()}; {myEvent.getDate().ToString("yyyy-MM-dd")}");
    }
}
