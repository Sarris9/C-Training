using System.Security.Cryptography.X509Certificates;

namespace Learning6
{
    internal class Program
    {
        public class InventoryItem
        {
            public float Weight { get; set; }
            public float Volume { get; set; }

            public InventoryItem(float weight,float volume)
            {
                this.Weight = weight;
                this.Volume = volume;
            }
        }
        public class Arrow: InventoryItem
        {
            public Arrow() : base(0.1f, 0.05f)
            {
                
            }
            public override string ToString()
            {
                return "Arrow";
            }
        }
        public class Bow : InventoryItem
        {
            public Bow() : base(1f,4f)
            {

            }
            public override string ToString()
            {
                return "Bow";
            }
        }
        public class Rope : InventoryItem
        {
            public Rope() : base(0.1f, 1.5f)
            {

            }
            public override string ToString()
            {
                return "Rope";
            }
        }
        public class Water : InventoryItem
        {
            public Water() : base(2f, 3f)
            {

            }
            public override string ToString()
            {
                return "Water";
            }
        }
        public class FoodRations : InventoryItem
        {
            public override string ToString()
            {
                return "FoodRations";
            }
            public FoodRations() : base(1f, 0.5f)
            {
            }
        }
        public class Sword : InventoryItem
        {
            public Sword() : base(5f, 3f)
            {

            }
            public override string ToString()
            {
                return "Sword";
            }
        }
        public class Pack
        {
            public InventoryItem[]? Items { get; set; }
            public float MaxWeight { get; init; }
            public float MaxVolume { get; init; }
            public int MaxItems { get; init; }
            public float currentWeight  { get; protected set;}
            public float currentVolume { get; protected set; }
            public int currentItems { get; protected set; }
            public Pack(int item,float weight,float volume)//: base (item,weight,volume)
            {
                this.MaxItems = item;
                this.MaxWeight = weight;
                this.MaxVolume = volume;
                this.Items = new InventoryItem[MaxItems];
            }
            public bool Add(InventoryItem item)
            {
                if (MaxItems == 0 && MaxWeight == 0 && MaxVolume == 0)
                {
                    return false;
                }

                //foreach(InventoryItem itemCount in Items!)
                //{
                //    currentWeight += itemCount.Weight;
                //    currentVolume += itemCount.Volume;
                //    currentItems ++;
                //    Items.SetValue(itemCount,currentItems);
                //    Console.WriteLine($"{currentItems} | weight:{itemCount.Weight} | volume:{itemCount.Volume}");
                //}

                float newWeight = currentWeight + item.Weight;
                float newVolume = currentVolume + item.Volume;
                int newItemCount = currentItems + 1;

                if (newWeight > MaxWeight || newVolume > MaxVolume || newItemCount > MaxItems)
                {
                    return false;
                }

                Items![currentItems] = item;
                currentWeight = newWeight;
                currentVolume = newVolume;
                currentItems = newItemCount;

                //Console.WriteLine($"{currentItems} | weight:{item.Weight} | volume:{item.Volume}");
                return true;

            }
            public void ShowWeight()
            {
                Console.WriteLine($"Weight:{currentWeight} / {MaxWeight}");
            }
            public void ShowVolume()
            {
                Console.WriteLine($"Volume:{currentVolume} / {MaxVolume}");
            }
            public void ShowNumberOfItems()
            {
                Console.WriteLine($"Item:{currentItems} / {MaxItems}");
            }
            public override string ToString()
            {
                string showItem = null;
                for (int i = 0; i <= currentItems - 1; i++)
                {
                     showItem +=  $" {Items[i].ToString()}";
                }
                //var showItem = Items?[currentItems-1].ToString();
                Console.WriteLine();
                return "Pack Contain:" + showItem!;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("We need a pack.");
            Console.WriteLine();
            Console.WriteLine("Choose a size of pack.");
            Console.WriteLine();
            Pack NewPack;
            do
            {
                Console.WriteLine("1:Small , 2:Medium , 3:Large");
                var choosenPack = Convert.ToInt32(Console.ReadLine());
                if (choosenPack == 1)
                {
                    NewPack = new Pack(4, 3.36f, 4.01f);
                    break;
                }
                else if (choosenPack == 2)
                {
                    NewPack = new Pack(7, 6.72f, 8.02f);
                    break;
                }
                else if (choosenPack == 3)
                {
                    NewPack = new Pack(10, 10.1f, 12.05f);
                    break;
                }
                else
                {
                    Console.WriteLine("Choose a number from 1-3");
                }

            }
            while (true);
            bool full = true;
            do
            {
                //NewPack.Add((InventoryItem)Sword())
                Arrow ArrowItem = new Arrow();
                Bow BowItem = new Bow();
                Rope RopeItem = new Rope();
                Water WaterItem = new Water();
                FoodRations FoodRationsItem = new FoodRations();
                Sword SwordItem = new Sword();
                Console.WriteLine();
                Console.WriteLine("Choose an item to put in your pack");
                Console.WriteLine();
                Console.WriteLine("1:Arrow , 2:Bow , 3:Rope , 4:Water , 5:Food Ration , 6:Sword");
                var item = Convert.ToInt32(Console.ReadLine());
                switch (item)
                {
                    case 1:
                        {
                            full = NewPack.Add(ArrowItem);
                            break;
                        }
                    case 2:
                        {
                            full = NewPack.Add(BowItem);
                            break;
                        }
                    case 3:
                        {
                            full = NewPack.Add(RopeItem);
                            break;
                        }
                    case 4:
                        {
                            full = NewPack.Add(WaterItem);
                            break;
                        }
                    case 5:
                        {
                            full = NewPack.Add(FoodRationsItem);
                            break;
                        }
                    case 6:
                        {
                            full = NewPack.Add(SwordItem);
                            break;
                        }
                }
                Console.WriteLine();
                NewPack.ShowNumberOfItems();
                NewPack.ShowWeight();
                NewPack.ShowVolume();

                Console.WriteLine(NewPack.ToString());
                if (!full)
                {
                    Console.WriteLine();
                    Console.WriteLine("Pack are full!");
                }
            }
            while (full);
            //FoodRations test = new FoodRations();
            //var testtest = test.ToString();
            //Console.WriteLine(testtest);
            //Arrow ArrowItem = new Arrow();
            //Bow BowItem = new Bow();
            //NewPack = new Pack(7, 6.72f, 8.02f);

            //NewPack.Add(ArrowItem);
            //Console.WriteLine(NewPack.ToString());


        }
    }
}
