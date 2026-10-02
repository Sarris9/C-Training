using Humanizer;
namespace HomeWorkPart2_26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"When is the Feast? {DateTime.UtcNow.AddHours(30)}");
            var date1 = DateTime.UtcNow.AddHours(2.5);
            var date2 = DateTime.UtcNow.AddHours(50);
            var result1 = date1.Humanize();
            var result2 = date2.Humanize();
            Console.WriteLine($"When is the Feast? {result1}");
            Console.WriteLine();
            Console.WriteLine($"When is the Feast? {result2}");

        }
    }
}
