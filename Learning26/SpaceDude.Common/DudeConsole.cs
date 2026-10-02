namespace SpaceDude.Common
{
    public class DudeConsole
    {
        public static void Writeline(string message)
        {
            Console.WriteLine($"{message}, dudes!");
        }
        public static void Write(string message)
        {
            Console.Write($"{message}, dude");
        }

    }
}
