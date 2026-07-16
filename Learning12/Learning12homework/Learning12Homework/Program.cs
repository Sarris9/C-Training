using System.Threading.Channels;

namespace Learning12Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1)

            //bool isNumber = false;
            //bool isBool = false;
            //bool isDouble = false;
            //while(!isNumber)
            //{
            //Console.WriteLine("Put a number");
            //string? inputN = Console.ReadLine();
            ////if(int.TryParse(input,out int value))
            ////{
            //isNumber = int.TryParse(inputN, out int value) ? true : false;
            //}
            //while (!isDouble)
            //{
            //    Console.WriteLine("Put a double");
            //    string? inputD = Console.ReadLine();
            //    isDouble = double.TryParse(inputD, out double valueD) ? true : false;
            //}

            //while (!isBool)
            //{
            //    Console.WriteLine("Put a boolean");
            //    string? inputD = Console.ReadLine();
            //    isBool = bool.TryParse(inputD, out bool valueD) ? true : false;
            //}
            //2)

            Random test = new Random();
            double pop = 0;
            Console.WriteLine(pop.NextDouble(5));

            Direction direct = new();
            var direct1 = direct.GetType().GetEnumValues();
            var direction = Enum.GetValues(typeof(Direction));
            string[] enumerator = new string[direction.Length];
            for(int i = 0; i< direction.Length; i++)
            {                
                //Console.WriteLine(direction.GetValue(i));
                enumerator[i] = direction.GetValue(i)!.ToString()!;
            }
            string randomString = RandomExtensions.NextString(enumerator);
            Console.WriteLine(randomString);

            bool coin = RandomExtensions.CoinFlip();
            Console.WriteLine(coin);

            bool coin2 = RandomExtensions.CoinFlip(0.3);
            Console.WriteLine(coin2);
        }
       
    }
    public static class RandomExtensions
    {
        public static double NextDouble(this double number, int choosenNumber)
        {
            //var random = new Random();
            Random random = new();
            //double result = 0;
            double result = random.Next(choosenNumber *10);
            //result = Convert.ToDouble(random);
            return result  / 10;
        }
        public static string NextString(params string[] texts)//,in Direction direction )
        {
            //var choices = Convert.ToString(direction);
            //foreach (string text in texts)
            //{
            //    //var result = Convert.ToString(choice);
            //}
            Random random = new();
            var randomText = random.Next(texts.Length);
            return texts[randomText];
        }
        public static bool CoinFlip()
        {
            Random random = new Random();
            var randomNumber = random.Next(2); //? true : false;
            //var checkChance = (random.NextDouble(), 1);
            //var checkChance = Math.Round(random.NextDouble(),1);
            //bool check = Convert.ToBoolean(checkChance + (chance - 0.5) >= 0.5)  ? true : false;
            //Console.WriteLine(checkChance);
            //Console.WriteLine(checkChance + (chance - 0.5));
            bool result = Convert.ToBoolean(randomNumber) ? true : false;
            return result;

        }
        public static bool CoinFlip(double chance = 0.5)
        {
            Random random = new();
            var checkChance = Math.Round(random.NextDouble(),1);
            var newRandom = (checkChance + (chance - 0.5));
            var setChance = Math.Clamp(newRandom, 0.0, 1.0);
            var setWin = (setChance >= 0.5)? true : false;
            return setWin;
        }
    }
    enum Direction
    {
        up,
        down,
        left,
        right

    }
}
