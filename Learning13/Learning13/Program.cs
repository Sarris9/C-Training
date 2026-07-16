using System.Security.Cryptography.X509Certificates;

namespace Learning13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    string responce = "";
            //    int number;
            //    try
            //    {
            //        number = Convert.ToInt32(responce);
            //    }
            //    catch(FormatException)
            //    {
            //        Console.WriteLine($"I dont understand {responce}");
            //    }

            //    Console.WriteLine("Name an animal");
            //    string? animal = Console.ReadLine();
            //    if (animal == "snake") throw new Exception();

            Game games = new Game();
            games.RandomNumber();
            try
            {

                while (true)
                {
                    Console.WriteLine("Choose a number between 0 and 9");
                    var playerNumber = Convert.ToInt32(Console.ReadLine());
                    games.CheckNumbers(playerNumber);
                    //if (games.OatCookie == playerNumber) throw new Exception("You found the Oat Cookie");
                }
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
    }
    public class Game
    {
        public List<int>? PickingNumber { get; set; } = new List<int>();
        public int OatCookie { get; set; }
        public void RandomNumber()
        {
            Random randoms = new Random();
            OatCookie = randoms.Next(0, 10);
            PickingNumber.Add(OatCookie);
        }
        public bool CheckNumbers(int number)
        {
            if(OatCookie == number) throw new Exception("You found the Oat Cookie");

            if (PickingNumber.Contains(number))
            {
                Console.WriteLine("This number exist");
                return false;
            }
            else
            {
                PickingNumber.Add(number);
            }

            return true;
        }
    }
}
