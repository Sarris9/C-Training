using FinalBattle.Backpack;
using FinalBattle.Characters;

namespace FinalBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a name for you hero True Programmer");
            string? name = Console.ReadLine();
            Console.Clear();
            TrueProgrammer hero = new(name);
            VinFletcher vin = new();
            Skeleton skeleton = new();
            GameRule game = new();
            skeleton.WeaponGear = new Dagger();
            StoneAmarok stoneAmarok = new StoneAmarok();
            TheUncodedOne theUncodedOne = new TheUncodedOne();
            MylaraAndSkorin mylaraAndSkorin = new MylaraAndSkorin();
            mylaraAndSkorin.ArmorGear = new BinaryHelm();
            game.HeroesParty.Add(hero);
            //game.HeroesParty.Add(mylaraAndSkorin);
            //game.HeroesParty.Add(vin);
            //game.MonstersParty.Add(theUncodedOne);
            //game.MonstersParty.Add(skeleton);
            //game.MonstersParty.Add(stoneAmarok);
            game.Battle();
        }
    }
}
