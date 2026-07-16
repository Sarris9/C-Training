using System.Diagnostics;

namespace Learning10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> numbers = new ();
            //numbers.Add(1);
            //numbers.Add(2);
            //Console.WriteLine(numbers);
            Sword sword = new Sword();
            Bow bow = new Bow();
            Axe axe = new Axe();
            ColoredItem<Sword> blueSword = new ColoredItem<Sword>(sword,ConsoleColor.Blue);
            ColoredItem<Bow> redBow = new ColoredItem<Bow>(bow, ConsoleColor.Red);
            ColoredItem<Axe> greenAxe = new ColoredItem<Axe>(axe, ConsoleColor.Green);

            Console.WriteLine();
            blueSword.Display();
            Console.WriteLine();
            redBow.Display();
            Console.WriteLine();
            greenAxe.Display();

        }
        //public class Test { }
        //public class Test2 { }
        //public class GenericType<T,U,M> where T:class where U :struct where M:new ()
        //{

        //}
        //public class Generic<T,U> where T:U where U:IGenericInterface<T>
        //{

        //}
        //public static List<T> Repeat<T>(T value ,int times) where T : class { return  new List<T>(); }
        //public interface IGenericInterface<T> { }
        ////
        ///
        public class Sword 
        {
            public override string ToString()
            {
                return "Sword";
            }
        }
        public class Bow 
        {
            public override string ToString()
            {
                return "Bow";
            }
        }
        public class Axe 
        {
            public override string ToString()
            {
                return "Axe";
            }
        }
        public class ColoredItem<T>
        {
            public T? Item {get;set;}
            public ConsoleColor ConsoleColor { get; set; }
            public void Display()
            {
                Console.ForegroundColor = ConsoleColor;
                Console.WriteLine(Item);
                Console.ResetColor();
            }
            public ColoredItem (T item,ConsoleColor color)
            {
                Item = item;
                ConsoleColor = color;
            }

        }
    }
}
