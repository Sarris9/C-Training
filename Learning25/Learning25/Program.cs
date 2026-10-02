using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;

namespace Learning25
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IEnumerable<int> SingleDigits()
            {
                for (int number = 1; number <= 10; number++)
                    yield return number;
            }
            foreach (int number in SingleDigits())
                Console.WriteLine(number);
            //
            string[] urls = new string[] { "http://google.com", "http://amazon.com", "http://microsoft.com" };
            var program = new Program();
            await foreach (string url in program.GetManySiteContents(urls))
                Console.WriteLine(url);
            //
            double x = TwowPi;
            //
            program.OldDeadMethod();
            //
            //var constructor = typeof(Point).GetConstructors()[0];
            //var attributes = constructor.GetCustomAttributes(typeof(SampleAttribute),inherit:false);
            //foreach(var atribute in attributes)
            //{
            //    if(atribute is SampleAttribute sampleAttribute)
            //    {
            //    Console.WriteLine(sampleAttribute.Number);
            //    }
            //}
            Type type = typeof(int);
            Type typeOfClass = typeof(Point);

            Point point = new Point(2, 3);
            Type type1 = point.GetType();

            ConstructorInfo[] constructors = type1.GetConstructors();
            MethodInfo[] methods = type1.GetMethods();

            ConstructorInfo? constructor = type1.GetConstructor(new Type[] { typeof(int), typeof(int) });
            MethodInfo? method = type1.GetMethod("MethodName", new Type[] { typeof(int) });

            //object? newObject = constructor.Invoke(new object[] {17});
            //method?.Invoke(newObject, new Object[] {4});
            //
            //void DisplayNumbers(int a,int b)
            //{
            //    Console.WriteLine($"a={a} and b={b}");
            //}
            //void DisplayNumbers(int first, int second)
            //{
            //    Console.WriteLine($"a={first} and b={second}");
            //}
            void DisplayNumbers(int first, int second)
            {
                Console.WriteLine($"{nameof(first)} = {first} and {nameof(second)} = {second}");
            }
            DisplayNumbers(4, 5);
            //
            int controllerState = 0b00010001;
            int shiftedLeft = controllerState << 2;
            int shiftedRight = controllerState >> 3;

            int downButton = 0b00000010;
            int controllerState1 = 0b01000010;
            int isDownPressed = controllerState1 & downButton;

            Buttons state = Buttons.Up | Buttons.A;
            Console.WriteLine(state.ToString());
            bool aButtonIsPressed = state.HasFlag(Buttons.A);
            //
            //FileStream stream = null;
            //try
            //{
            //    stream = File.Open("Settings.txt", FileMode.Open);
            //    while (stream.ReadByte() > 0)
            //    {
            //        Console.WriteLine("Read in a byte");
            //    }
            //    stream.Close();
            //}
            //finally
            //{
            //    stream?.Dispose();
            //}
            //using FileStream stream1 = File.Open("Settings.txt", FileMode.Open);
            //while (stream1.ReadByte() > 0)
            //{
            //    Console.WriteLine("Read in a byte");
            //}
            //stream1.Close();
            //
#warning Enter whatever message you want after.
            // #error This tex will show ip in the Errors list if you try to complile.

            Console.WriteLine("Helllo");
#if DEBUG
            Console.WriteLine("World!");
#endif
            //
            //int a = Convert.ToInt32(args[0]);
            //int b = Convert.ToInt32(args[1]);
            //Console.WriteLine(a + b);
            //
            int numbers = 0;
        Top:
            Console.WriteLine(numbers);
            numbers++;
            if(numbers<10)
            {
                goto Top;
            }
            //
            GameObject gameObject = new Ship();
            gameObject.Add(new Ship());
            //List<GameObject> objects = new List<Ship> { new Ship(), new Ship(), new Ship() };
            IEnumerable<Ship> ships = new List<Ship>();
            IEnumerable<GameObject> games = ships;
            //
            int m = int.MaxValue;
            Console.WriteLine(checked(m+1));
        }
        public async Task<string> GetSiteContents(string url) { return await Task.Run(() => url); }
        public async IAsyncEnumerable<string> GetManySiteContents(string[] manyUrls)
        {
            foreach (string url in manyUrls)
            {
                yield return await GetSiteContents(url);
            }
        }
        //
        public static class Math
        {
            public const double PI = 3.1415926535897931;
        }

        public const double TwowPi = Math.PI * 2;
        //
        //[Obsolete("Use NewDeadMethod instead.",true)]
        [method: Obsolete]
        public void OldDeadMethod() { }
        //[return: Tasty]
        private int MakeTastyNumbers() { return 0; }

        [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = true)]
        public class SampleAttribute : Attribute
        {
            public int Number { get; set; }
        }
        public class Point
        {
            public double a { get; set; }
            public double b { get; set; }
            [Sample(Number = 2)]
            [Sample(Number = 3)]
            public Point(double a, double b)
            {

            }
            public void Test() => Console.WriteLine("Test");
        }
        //
        public class Door
        {
            private enum DoorState { open, closed, locked };
            private DoorState _doorState = DoorState.closed;
            public bool IsOpen => _doorState == DoorState.open;
            public bool IsLocked => _doorState == DoorState.locked;
        }
        [Flags]
        public enum Buttons : byte
        {
            Up = 1 << 0,//00000001
            Down = 1 << 1,//00000010
            Left = 1 << 2,//00000100
            Right = 1 << 3,//00001000
            A = 1 << 4,//00010000
            B = 1 << 5,//00100000
            Start = 1 << 6,//01000000
            Select = 1 << 7//10000000
        }
        //
        #region The region where AwesomeClass is defined.
        public class AwesomeClass
        {

        }
        #endregion
        //
        public partial class SomeClass
        {
            //public void DoSomething() { }
            public partial void Log(string message);
            public void DoStuff()
            {
                Log("I did stuff");
            }
        }
        public partial class SomeClass
        {
            //public void DoSomethingElse() { }
            public partial void Log(string message)
            {
                Console.WriteLine(message);
            }
        }
        //
        public class GameObject
        {
            public float X { get; set; }
            public float Y { get; set; }
            public void Add(GameObject toAdd)
            {

            }
        }
        public class Ship:GameObject
        {
            public string? Name { get; set; }

        }

        public interface IstringMaker<in T>
        {
            string MakeString(T Value);
        }
    }
}
