namespace Learning3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool predifined = false;
            Console.WriteLine("Hello Customer.Do you need 1:Pre-defined arrow or 2:Custom one?");
            var arrowType = Convert.ToInt32(Console.ReadLine());
            if(arrowType == 1)
            {
                predifined = true;
            }

            if (predifined == true)
            {
                Console.WriteLine("We have 3 choices:1) Elite Arrow,2) Begginer Arrow,3) Marksman Arrow");
                var playerArrow = Convert.ToInt32(Console.ReadLine());
                switch (playerArrow)
                {
                    case 1:
                        {
                            var arrow = Arrow.CreateEliteArrow();
                            var cost = GetCost(arrow);
                            Console.WriteLine($"Your arrow will cost: {cost}");
                            break;
                        }
                    case 2:
                        {
                            var arrow = Arrow.CreateBeginnerArrow();
                            var cost = GetCost(arrow);
                            Console.WriteLine($"Your arrow will cost: {cost}");
                            break;
                        }
                    case 3:
                        {
                            var arrow = Arrow.CreateMarksmanArrow();
                            var cost = GetCost(arrow);
                            Console.WriteLine($"Your arrow will cost: {cost}");
                            break;
                        }
                }                
            }
            else
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
                    Console.WriteLine("Choose the Shaft lenght between 60 - 100 cm");
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
                    fletchingChoose = Fletching.plastic;
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
        }
        public enum Arrowhead { steel, wood, obsidian }
        public enum Fletching { plastic, turkeyFeather, gooseFeather }
        public class Arrow
        {
            //public Arrowhead Arrowheads { get; set; }
            public  Arrowhead arrowheads { get; set; }
            public  double lenght { get; set; }
            public  Fletching fletchings { get; set; }
            //public static Arrow EliteArrow

            public Arrow(Arrowhead arrowhead, double lenght, Fletching fletching)
            {
                this.arrowheads = arrowhead;
                this.lenght = lenght;
                this.fletchings = fletching;
            }

            //public Arrowhead GetArrowhead() => _arrowheads;
            //public double GetLenght() => _lenght;
            //public Fletching GetFletching() => _fletchings;

             public static  Arrow CreateEliteArrow()
            {
                return new Arrow(Arrowhead.steel, 95, Fletching.plastic);
            }

            public static Arrow CreateBeginnerArrow()
            {
                return new Arrow(Arrowhead.wood, 75, Fletching.gooseFeather);
            }

            public static Arrow CreateMarksmanArrow()
            {
                return new Arrow(Arrowhead.steel, 65, Fletching.gooseFeather);
            }

        }
        public static float GetCost(Arrow arrow)
        {
            float arrowCost = 0;
            if (arrow.arrowheads == Arrowhead.steel)
            {
                arrowCost += 10;
            }
            else if (arrow.arrowheads == Arrowhead.wood)
            {
                arrowCost += 3;
            }
            else if (arrow.arrowheads == Arrowhead.obsidian)
            {
                arrowCost += 5;
            }

            if (arrow.fletchings == Fletching.plastic)
            {
                arrowCost += 10;
            }
            else if (arrow.fletchings == Fletching.turkeyFeather)
            {
                arrowCost += 5;
            }
            else if (arrow.fletchings == Fletching.gooseFeather)
            {
                arrowCost += 3;
            }
            var arrowLenght = (float)(arrow.lenght * 0.05);
            arrowCost += arrowLenght;
            return arrowCost;
        }

    }
}
