namespace Learning16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int [] numbers = [2, 3, 4];
            //var test = (string a, string b) => a + b;
            //var test2 = bool (int n) => n % 2 == 0;
            //var result = test ("lok", "lel");
            //Console.WriteLine(result);//or
            //Console.WriteLine(test("lok", "lel"));
            ////discard
            //var test3 = (int _,int _ ,int _) => 1;
            //var result2 = test3(3, 2,0);
            //Console.WriteLine(result2);

            //var test4 = Count(numbers, n => { return n % 2 == 0; });//or
            //var test5 = Count(numbers, n => { Console.WriteLine(n); return n % 2 == 0; });
            //Console.Clear();
            //Console.WriteLine(test5);
            ////
            //int threshold = 3;
            //var test6 = Count(numbers, x => x < threshold);
            //Console.WriteLine(test6);

            //Action[] actionsToDo = new Action[10];

            //for (int index = 0; index < 10; index++)
            //    actionsToDo[index] = () => Console.WriteLine(index);

            //foreach (Action action in actionsToDo)
            //    action();

            //for( int index = 0;index< 10; index++)
            //{
            //    int temp = index;
            //    actionsToDo[index] = () => Console.WriteLine(temp);
            //}

            //var test7 = Count(new int[] { 1, 2, 3 }, static n => { return n % 2 == 0; });
            //Console.WriteLine(test7);

            //var test8 = bool (int n) => n < 0;
            //var test9 =  ( int x) => x < 0;
            ///
            /////
            //bool EvenNumbers(int number)
            //{
            //    bool result = false;
            //    if (number / 2 == 0)
            //    {
            //        result = true;
            //    }
            //    return result;
            //}
            //bool PositiveNumber(int number)
            //{
            //    bool result = false;
            //    if (number > 0)
            //    {
            //        result = true;
            //    }
            //    return result;
            //}
            //bool MultipleNumber(int number)
            //{
            //    bool result = false;
            //    if (number % 10 == 0)
            //    {
            //        result = true;
            //    }
            //    return result;
            //}
            Console.WriteLine("Choose 1 filter");
            Console.WriteLine();
            Console.WriteLine("1:Even Numbers , 2:Positive NUmbers , 3:Multiples of 10");
            Sieve sieve = null;
            bool succeedFilter = false;
            while (!succeedFilter)
            {
                var filter = Convert.ToInt64(Console.ReadLine());

                switch (filter)
                {
                    case 1:
                        {
                            sieve = new Sieve(bool (int x) => x / 2 == 0);
                            succeedFilter = true;
                            break;
                        }
                    case 2:
                        {
                            sieve = new Sieve(bool (int x) => x > 0);
                            succeedFilter = true;
                            break;
                        }
                    case 3:
                        {
                            sieve = new Sieve(bool(int x) => x % 10 == 0);
                            succeedFilter = true; 
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Choose 1 from the filters");
                            break;
                        }
                }
            }
            bool gameEnd = false;
            string playerNumber = null;
            while (!gameEnd)
            {

                Console.WriteLine("Write a number");
                bool succedNumber = false;
                int parsedNumber = 0;
                while (!succedNumber)
                {
                    playerNumber = Console.ReadLine();

                    if (playerNumber == "stop")
                    {
                        gameEnd = true;
                        break;
                    }

                    succedNumber = int.TryParse(playerNumber, out parsedNumber);
                    if (!succedNumber)
                    {
                        Console.WriteLine("This is not a number.Write a number!");
                    }
                    else
                    {
                        break;
                    }
                }

                string showResults = sieve.IsGood(parsedNumber) ? showResults = "good" : showResults = "bad";
                Console.WriteLine();
                Console.WriteLine($"The {parsedNumber} are {showResults}");
            }
        }
        public delegate int NumberDelegate(int number);
        //
        public delegate bool CheckNumbers(int number);
        public class Sieve
        {
            private readonly CheckNumbers _operation;
            //private readonly (Func<int, bool> _operation;

            public bool IsGood(int number)
            {
                return _operation(number);
            }
            public Sieve(CheckNumbers operation)
            {
                _operation = operation;
            }
        }
        
        //public static int Count(int[] input, Func<int, bool> countFunction)
        //{
        //    int count = 0;
        //    foreach (int number in input)
        //        if (countFunction(number))
        //            count++;
        //    return count;
        //}

    }
}
