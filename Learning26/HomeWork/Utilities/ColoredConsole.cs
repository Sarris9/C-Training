namespace Utilities
{
    public static class ColoredConsole
    {
            public static string Prompt(string question)
            {
                Console.Write($"{question} ");
                var color = ConsoleColor.Cyan;
                Console.ForegroundColor = color;
                var answer = Console.ReadLine();
                return answer;
            }
            public static void WriteLine(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(text);
            }
            public static void Write(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.Write(text);
            }
        }
    }

