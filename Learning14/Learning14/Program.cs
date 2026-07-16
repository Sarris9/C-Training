using System.ComponentModel.DataAnnotations;
using static Learning14.Program;

namespace Learning14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int AddOne(int number)
            {
                return number + 1;
            }
            int SubtractOne(int number) => number - 1;
            int Double(int number) => number * 2;

            int[] ChangeArrayElements(int[] numbers, NumberDelegate operation)
            {
                int[] result = new int[numbers.Length];
                for (int index = 0; index < result.Length; index++)
                {
                    //result[index] = operation(numbers[index]);
                    result[index] = operation.Invoke(numbers[index]);
                }
                return result;
            }
            ChangeArrayElements(new int[] { 1, 2, 3, 4 }, AddOne);
            //
            //
            bool EvenNumbers(int number)
            {
                bool result = false;
                if (number / 2 == 0)
                {
                    result = true;
                }
                return result;
            }
            bool PositiveNumber(int number)
            {
                bool result = false;
                if (number > 0)
                {
                    result = true;
                }
                return result;
            }
            bool MultipleNumber(int number)
            {
                bool result = false;
                if (number % 10 == 0)
                {
                    result = true;
                }
                return result;
            }
            Console.WriteLine("Choose 1 filter");
            Console.WriteLine();
            Console.WriteLine("1:Even Numbers , 2:Positive NUmbers , 3:Multiples of 10");
            //var methods = EvenNumbers();
            Sieve sieve = null;
            bool succeedFilter = false;
            while (!succeedFilter)
            {
                var filter = Convert.ToInt64(Console.ReadLine());

                switch (filter)
                {
                    case 1:
                        {
                            sieve = new Sieve(EvenNumbers);
                            succeedFilter = true;
                            break;
                        }
                    case 2:
                        {
                            sieve = new Sieve(PositiveNumber);
                            succeedFilter = true;
                            break;
                        }
                    case 3:
                        {
                            sieve = new Sieve(MultipleNumber);
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
    }
}
