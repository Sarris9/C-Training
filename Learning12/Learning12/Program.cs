//using static System.Math;


using System.Runtime.CompilerServices;

namespace Learning12
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Random random = new Random();
            Console.WriteLine(random.Next(10, 15));
            Console.WriteLine(random.NextDouble() * 20 - 10);

            DateTime time1 = new DateTime();
            DateTime nowLocal = DateTime.Now;
            DateTime nowUtc = DateTime.UtcNow;

            TimeSpan timeSpan1 = new TimeSpan(1, 30, 0); // 1 hour, 30 minutes, 0 seconds.
            TimeSpan timeSpan2 = new TimeSpan(2, 12, 0, 0); // 2 days, 12 hours.
            TimeSpan timeSpan3 = new TimeSpan(0, 0, 0, 0, 500); // 500 milliseconds.
            TimeSpan timeSpan4 = new TimeSpan(10); // 10 "ticks" == 1 microsecond

            TimeSpan aLittleWhile = TimeSpan.FromSeconds(3.5);
            TimeSpan quiteAWhile = TimeSpan.FromHours(1.21);
            TimeSpan timeLeft = new TimeSpan(1, 30, 0);
            Console.WriteLine($"{timeLeft.Days}d {timeLeft.Hours}h  {timeLeft.Minutes}m");

            Guid id = Guid.NewGuid();

            List<string> words = new List<string>();
            words.AddRange(["apple", "durian"]);
            words.InsertRange(1, ["banana", "corn"]);
            Console.WriteLine(words[2]);
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            int index = words.IndexOf("bananas");
            Console.WriteLine(index);
            IEnumerator<string> iterator = words.GetEnumerator();
            Dictionary<int, Test> testObject = new Dictionary<int, Test>();
            Test testtest = new Test { ID = 1, Name = "manual" };
            testObject[testtest.ID] = testtest;
            Console.WriteLine(testObject[1]);
            Nullable<int> maybeNumber = new Nullable<int>(3);
            int? maybe = 3;
            int? maybe1 = null;
            double x = System.Math.PI;
            Test test = new Test();
            test.ID = 1;
            test.Name = "bob";

            //IField.Pig pig = new IField.Pig();
            //McDroid.Pig pig2 = new();
            IField.Pig poo = new();
            McDroid.Pig pip = new();


            Lola lola = new();
            var lola1 = lola.RollDie();
            var lola2 =lola.RollDie(10);
            Console.WriteLine(lola1);
            Console.WriteLine(lola2);
            void DisplayNumber(ref int x)
            {
                Console.WriteLine(x);
            }
            int y = 3;
            DisplayNumber(ref y);
            void gogogo<T>(ref T task)
            {
                Console.WriteLine(task);
            }
            gogogo(ref lola);
            void SetupNumber(bool useBigNumber, out double value)
            {
                value = useBigNumber ? 1000000 : 1;
            }
            double p;
            SetupNumber(true, out p);
            double r;
            SetupNumber(false, out r);
            Console.WriteLine(p);
            Console.WriteLine(r);
            SetupNumber(true, out _);
            ref var e = ref r;

            void testing(bool bol,in string kone)
            {
                Console.WriteLine($"Bool: {bol}, String: {kone}");
            }

            //void Deconstruct(out float x , out float y)
            //{
            //    x = X;
            //    y = Y;
            //}
            string message = "Hello, World";
            Console.WriteLine(message.ToAlternating());
            //var eebvee = StringExtensions.ToAlternating(message);

            void DoSomething(int x,params int[] number)
            {

            }
        }
        public class Lola
        {
            private Random _random = new Random();
            //public int RollDie(int sides)
            //{
            //    return _random.Next(sides) + 1; 
            //}
            public int RollDie()
            {
                return RollDie(6);
            }
            public int RollDie(int sides = 6)
            {
                return _random.Next(sides) +1;
            }
        }
    }
    public static class StringExtensions
    {
        public static string ToAlternating(this string text)
        {
            string result = "";
            bool isCapital = true;
            foreach (char letter in text)
            {
                result += isCapital ? char.ToUpper(letter) : char.ToLower(letter);
                isCapital = !isCapital;
            }
            return result;
        }
    }
    namespace IField
    {
        public class Pig;
        public class Sheep;

    }
    namespace McDroid
    {
        public class Pig;
        public class Cow;
    }
}

