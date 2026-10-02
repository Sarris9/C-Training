using System.Drawing;
using System.Threading.Channels;

namespace Learning15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CharberryyTree tree = new CharberryyTree();
            //Notifier notifier = new Notifier(tree);
            //Harvest harvest = new Harvest(tree);
            //while (true)
            //{
            //    tree.MaybeGrow();
            //    //Console.WriteLine(tree.Ripe);
            //}
            ////
            ///

            CharberryTree1 tree1 = new CharberryTree1();
            Notifier1 notifier1 = new Notifier1(tree1);
            Harvester1 harvester1 = new Harvester1(tree1);
            while(true)
            {
                tree1.MaybeGrow();
                Console.WriteLine(tree1.Ripe);

            }
        }
        /// <summary>
        /// test
        /// </summary>
        public event Action<int>? EventTest;

        public delegate void EventHandler(object sender, EventArgs e);

        public event EventHandler<ExplosionEventArgs>? ShipExploded;
        public class ExplosionEventArgs :EventArgs
        {
            public Point Location { get; }
            public ExplosionEventArgs(Point location)
            {
                Location = location;
            }
            

        }
        //////////
        public class CharberryyTree
        {
            public event Action<CharberryyTree>? Ripened;

            private Random _random = new Random();
            public bool Ripe { get; set; }

            public void MaybeGrow()
            {
                var chance = _random.NextDouble();
                if(chance < 0.00000001 && !Ripe)
                {
                    //Console.WriteLine(chance);
                    Ripe = true;
                    Ripened(this);
                }
            }
        }
        public class Notifier
        {
            public void RipeFruit(CharberryyTree tree)
            {
                Console.WriteLine("A charberry fruit has ripened!");
            }
            public Notifier(CharberryyTree tree)
            {
                tree.Ripened += RipeFruit;
            }
        }
        public class Harvest
        {
            public bool SetFruit { get; set; }
            public void ResetFruit(CharberryyTree tree)
            {
                //CharberryyTree tree = new();
                tree.Ripe = false;               
            }
            public Harvest(CharberryyTree tree)
            {
                tree.Ripened += ResetFruit;
            }
        }
        ///////////
        ////
        /// solution part 2
        /// 
        public class FruitEventArgs:EventArgs
        {
            public bool FruitRiped { get; set; }

            public FruitEventArgs(bool fruit)
            {
                FruitRiped = fruit;
            }
        }

        public class CharberryTree1
        {
            public event EventHandler<FruitEventArgs>? Ripened;
            private Random _random = new ();
            public bool Ripe { get; set; }

            public void MaybeGrow()
            {
                var number = _random.NextDouble();
                if (number < 0.00000001 && !Ripe)
                {
                    Ripe = true;
                    Ripened?.Invoke(this, new FruitEventArgs(Ripe));
                }
                Console.WriteLine(number);

            }
        }
        public class Notifier1
        {
            //public void RipeFruit(object sender,FruitEventArgs args)
            //{
            //    Console.WriteLine("A charberry fruit has ripened!");
            //}
            //public Notifier(object sender, FruitEventArgs args)
            //{
            //    tree.Ripened += RipeFruit;
            //}
            public void OnFruitGrow(object sender, FruitEventArgs args)
            {
                Console.WriteLine("A charberry fruit has ripened!");
            }
            public Notifier1(CharberryTree1 tree)
            {
                tree.Ripened += OnFruitGrow;
            }
        }
        public class Harvester1
        {
            public void OnFruitRipped(object sender, FruitEventArgs args)
            {
                if (sender is CharberryTree1 tree)
                {
                    tree.Ripe = false;
                }
            }
            public Harvester1(CharberryTree1 tree)
            {
                tree.Ripened += OnFruitRipped;
            }
        }
    }
}
