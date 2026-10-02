using System.Dynamic;
namespace Learning23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dynamic mystery = "Hello Word";
            //Console.WriteLine(mystery.Length);
            //mystery = 2;
            //mystery += 13;
            //mystery *= 13;
            //Console.WriteLine(mystery);
            //dynamic test4test = "xristina";
            //test4test += 2;
            //Console.WriteLine(test4test.GetType());

            //Dictionary<string, object> flexible = new Dictionary<string, object>();
            //flexible["Name"] = "George";
            //flexible["Age"] = 21;
            //flexible["HaveABirthday"] = new Action(() => flexible["Age"] = (int)flexible["Age"] + 1);
            //((Action)flexible["HaveABirthday"])();

            //dynamic expando = new ExpandoObject();
            //expando.Name = "George";
            //expando.Age = 21;
            //expando.HaveABirthday = new Action(() => expando.Age++);
            //expando.HaveABirthday();

            //dynamic item = new CustomObject(new string[] { "Name", "Age" },
            //    new string[] { "HAL", "9001" });
            //Console.WriteLine($"{item.Name} is {item.Age} years old");
            ////
            ///
            //var testInt1 = Adds.NewAdd(2, 3);
            //Console.WriteLine(testInt1);
            //var testInt2 = Adds.NewAdd(4, 5);
            //Console.WriteLine(testInt2);
            //var testDouble1 = Adds.NewAdd(1.3, 4.6);
            //Console.WriteLine(testDouble1);
            //var testDouble2 = Adds.NewAdd(2.8, 5.1);
            //Console.WriteLine(testDouble2);
            //var testString1 = Adds.NewAdd("Test", "Test2");
            //Console.WriteLine(testString1);
            //var testString2 = Adds.NewAdd("Test4", "Test");
            //Console.WriteLine(testString2);
            //var testDate = Adds.NewAdd(DateTime.Now, TimeSpan.FromDays(2));
            //Console.WriteLine(testDate);

            bool CheckAnswer(string response)
            {
                if (response == "yes" || response == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Type 'yes' or 'no'.");
                    return true;
                }
            }

            int robotId = 0;
            bool spellChecking = true;
            string responce = string.Empty;
            dynamic RobotCreate = new ExpandoObject();
            while (true)
            {
                robotId++;
                spellChecking = true;
                RobotCreate.Id = robotId;
                Console.WriteLine($"You are producing robot #{robotId}");
                Console.WriteLine("Do you want to name this robot?");
                while (spellChecking)
                {
                    responce = Console.ReadLine();
                    spellChecking = CheckAnswer(responce!);
                }
                if (responce == "yes")
                {
                    Console.WriteLine("What is its name?");
                    responce = Console.ReadLine();
                    RobotCreate.Name = responce;
                }
                Console.WriteLine("Does this robot have a specific size?");
                spellChecking = true;
                while (spellChecking)
                {
                    responce = Console.ReadLine();
                    spellChecking = CheckAnswer(responce!);
                }
                if (responce == "yes")
                {
                    Console.WriteLine("What is its height?");
                    responce = Console.ReadLine();
                    RobotCreate.Height = responce;
                    Console.WriteLine("what is its width?");
                    responce = Console.ReadLine();
                    RobotCreate.Width = responce;
                }
                Console.WriteLine("Does this robot need to be a specific color?");
                spellChecking = true;
                while (spellChecking)
                {
                    responce = Console.ReadLine();
                    spellChecking = CheckAnswer(responce!);
                }
                if (responce == "yes")
                {
                    Console.WriteLine("What color?");
                    responce = Console.ReadLine();
                    RobotCreate.Color = responce;
                }
                foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)RobotCreate)
                    Console.WriteLine($"{property.Key}:{property.Value}");
            }
        }
        //public class CustomObject : DynamicObject
        //{
        //    private Dictionary<string, string> _data;
        //    public CustomObject(string[] names, string[] values)
        //    {
        //        _data = new Dictionary<string, string>();
        //        for (int index = 0; index < names.Length; index++)
        //        {
        //            _data[names[index]] = values[index];
        //        }
        //    }
        //    public override bool TryGetMember(GetMemberBinder binder, out object? result)
        //    {
        //        if(_data.ContainsKey(binder.Name))
        //        {
        //            result = _data[binder.Name];
        //            return true;
        //        }
        //        else
        //        {
        //            result = null;
        //            return false;
        //        }
        //    }
        //    public override bool TrySetMember(SetMemberBinder binder, object? value)
        //    {
        //        if (!_data.ContainsKey(binder.Name)) return false;
        //        _data[binder.Name] = value!.ToString()!;
        //        return true;
        //    }
        //}
        ////
        ///
        public static class Adds
        {
            //public static int Add(int a, int b) => a + b;
            //public static double Add(double a, double b) => a + b;
            //public static string Add(string a, string b) => a + b;
            //public static DateTime Add(DateTime a, TimeSpan b) => a + b;
            public static dynamic NewAdd(dynamic a, dynamic b) => a + b;
        }
    }
}
