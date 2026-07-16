namespace Learning_
{
    internal class Program
    {
        public void Main(string[] args)
        {
            var lenghtChoose = 0;
            Arrowhead arrowheadChoose = Arrowhead.steel;
            Fletching fletchingChoose = Fletching.plastic;
            Console.WriteLine($"Hello Customer.Choose the Arrowhead 1:{Arrowhead.steel},2:{Arrowhead.wood},3:{Arrowhead.obsidian}");
            var arrowChoose = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Choose the Fletching 1:{Fletching.plastic},2:{Fletching.turkeyFeather},3:{Fletching.gooseFeather}");
            var fletchChoose = Convert.ToInt32(Console.ReadLine());
            do
            {
                Console.WriteLine("Choose the Shaft lenght");
                 lenghtChoose = Convert.ToInt32(Console.ReadLine());
            }
            while (lenghtChoose < 60 || lenghtChoose > 100);

            if (arrowChoose == (int)Arrowhead.steel)
            {
                arrowheadChoose = Arrowhead.steel;
            }
            else if (arrowChoose == (int)Arrowhead.wood)
            {
                arrowheadChoose = Arrowhead.wood;
            }
            else if (arrowChoose == (int)Arrowhead.obsidian)
            {
                arrowheadChoose = Arrowhead.obsidian;
            }

            if (fletchChoose == (int)Fletching.plastic)
            {
                fletchingChoose  = Fletching.plastic;
            }
            else if (fletchChoose == (int)Fletching.turkeyFeather)
            {
                fletchingChoose = Fletching.turkeyFeather;
            }
            else if (fletchChoose == (int)Fletching.gooseFeather)
            {
                fletchingChoose = Fletching.gooseFeather;
            }

            Arrow userChoice = new Arrow(arrowheadChoose, lenghtChoose, fletchingChoose);
            var cost = GetCost(userChoice);
            Console.WriteLine($"Your arrow will cost: {cost}");

        }
        public enum Arrowhead { steel,wood,obsidian}
        public enum Fletching { plastic,turkeyFeather,gooseFeather}
        public class Arrow
        {
            //public Arrowhead Arrowheads { get; set; }
            public  Arrowhead Arrowheads;
            public double Lenght;
            public  Fletching Fletchings;

            public Arrow(Arrowhead arrowhead, double lentgh, Fletching fletching)
            {
                this.Arrowheads = arrowhead;
                this.Lenght = lentgh;
                this.Fletchings = fletching;
            }

        }
        public float GetCost(Arrow arrow)
        {
            float arrowCost = 0;
            if (arrow.Arrowheads == Arrowhead.steel)
            {
                arrowCost += 10;
            }
            else if (arrow.Arrowheads == Arrowhead.wood)
            {
                arrowCost += 3;
            }
            else if(arrow.Arrowheads == Arrowhead.obsidian)
            {
                arrowCost += 5;
            }

            if (arrow.Fletchings == Fletching.plastic)
            {
                arrowCost += 10;
            }
            else if (arrow.Fletchings == Fletching.turkeyFeather)
            {
                arrowCost += 5;
            }
            else if(arrow.Fletchings == Fletching.gooseFeather)
            {
                arrowCost += 3;
            }
            var arrowLenght = (float)(arrow.Lenght * 0.05);
            arrowCost += arrowLenght;
            return arrowCost;
        }
    }
}
