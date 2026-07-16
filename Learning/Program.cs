using System.Diagnostics.Metrics;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pilot;
            int boomer;
            int turns = 0;
            int manticore = 10;
            int cityHPs = 15;
            int SpaceManticore = 10;
            Random random = new Random();
            pilot = random.Next(0,101);

            //Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore?");
            //do
            //{
            //    Console.WriteLine("Choose a number from 1 to 100");
            //    pilot = Convert.ToInt32(Console.ReadLine());
            //}
            //while (pilot < 0 || pilot > 100);

            Console.WriteLine(pilot);

            for( int cityHP = 15; cityHP >= 0; cityHP--)
            {
                turns++;
                int dmg = ShotDMG(turns);
                Console.WriteLine($"STATUS: Round:{turns} City:{cityHP}/{cityHPs} Manticore:{SpaceManticore}/{manticore}");
                Console.WriteLine($"The cannon is expected to deal {dmg} this round");
                Console.WriteLine("Enter desire cannon range:");
                boomer = Convert.ToInt32(Console.ReadLine());
                bool dierectHit = CannonRange(boomer, pilot);
                if (dierectHit)
                {
                    SpaceManticore -= dmg;
                }
                Console.WriteLine("------------------------");
                if (SpaceManticore <= 0)
                {
                    Console.WriteLine("You WON.You killed the evil Manticore.");

                    break;
                }
               if(cityHP == 0)
                {
                    Console.WriteLine("City has fallen");
                }
            }
            int ShotDMG(int turn)
            {
                int dmg = 1;
                if(turn % 3 ==0 && turn %5 ==0)
                {
                    dmg = 10;
                }
                else if (turn % 3 == 0 || turn % 5 == 0)
                {
                    dmg = 3;
                }
                return dmg;
            }
            bool CannonRange(int range,int target)
            {
                bool hit = false;
                if(range > target)
                {
                    Console.WriteLine("That round OVERSHOT the target");
                    
                }
                else if(range < target)
                {
                    Console.WriteLine("That round FELL SHORT of the target. ");
                    
                }
                else if(range == target)
                {
                    Console.WriteLine("That round was a DIRECT HIT! ");
                    hit = true;   
                }
                return hit;
            }
        }
    }
}
