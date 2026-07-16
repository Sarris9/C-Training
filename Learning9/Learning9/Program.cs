using System.Drawing;

namespace Learning9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sword sword1 = new Sword((Material)3, 0, 0, 0);
            //var test = sword1.ToString();
            //Console.WriteLine(test);
            Sword sword2 = sword1 with { Material = Material.Bronze, Gemstone = Gemstone.Amber, Lenght = 10, Width = 5 };
            Sword sword3 = sword1 with { Material = Material.Wood, Gemstone = Gemstone.Diamond, Lenght = 6, Width = 9 };
            Console.WriteLine(sword1);
            Console.WriteLine(sword2);
            Console.WriteLine(sword3);
        }
        public enum Material
        {
            Wood,
            Bronze,
            Iron,
            Steel,
            Binarium
        }
        public enum Gemstone
        {
            NoGemstone,
            Emerald,
            Amber,
            Sapphire,
            Diamond,
            Bitstone
        }
        public record Sword(Material Material, Gemstone Gemstone, float Lenght, float Width);

    }
}
