namespace Learning21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Thread thread1 = new Thread(CountTo100);
            //thread1.Start();
            //Thread thread2 = new Thread(CountTo100);
            //thread2.Start();

            //thread1.Join();
            //thread2.Join();
            //Console.WriteLine("Main Thread Done"); ;

            //void CountTo100()
            //{
            //    for (int index = 0; index < 100; index ++)
            //        Console.WriteLine(index+1);
            //}
            //MultiplicationProblem problem = new MultiplicationProblem { A = 2, B = 3 };
            //Thread thread = new Thread(Multiply);
            //thread.Start(problem);
            //thread.Join();
            //Console.WriteLine(problem.Result);

            //void Multiply(object obj)
            //{
            //    if (obj == null)
            //        return;
            //    MultiplicationProblem problem = (MultiplicationProblem)obj;
            //    problem.Result = problem.A * problem.B;
            //}

            //// Lock thread
            //SharedData sharedData = new SharedData();
            //Thread thread1 = new Thread(sharedData.Increment);
            //thread1.Start();

            //sharedData.Increment();

            //thread1.Join();
            //Console.WriteLine(sharedData.Number);
            ////
            ///
            bool isEqual = false;
            RecentNumbers recent = new RecentNumbers();
            Thread thread = new Thread(recent.InfiniteNumbers);
            thread.Start();
            //while (recent.IsRepeat())
            //{
                
            //    //var firstNumber = recent.NumberA;
            //    //recent.InfiniteNumbers();
            //    //thread.Join();
            //    //var secondNumber = recent.NumberA;
            //    Console.ReadKey();
            //    //if(firstNumber == secondNumber)
            //    //{
            //    //    isEqual = true;
            //    //}
            //}
            while(true)
            {
                Console.WriteLine("Press any key if its the same number");
                Console.ReadKey(true);

                if(recent.IsRepeat())
                {
                    Console.WriteLine("Its correct");
                }
                else
                {
                    Console.WriteLine("Its not.");
                }
            }

            //Console.WriteLine(recent.NumberA);
        }
        //public class MultiplicationProblem
        //{
        //    public double A { get; set; }
        //    public double B { get; set; }
        //    public double Result { get; set; }
        //}
        //public class SharedData
        //{
        //    private readonly object _numberLock = new object();
        //    private int _number;
        //    public int Number
        //    {
        //        get
        //        {
        //            lock(_numberLock)
        //            {
        //                return _number;
        //            }
        //        }
        //    }
        //    public void Increment()
        //    {
        //        lock(_numberLock)
        //        {
        //            _number++;
        //        }
        //    }
        //}
        public class RecentNumbers
        {
            private readonly object _numberLock = new object();
            private int _numberA;
            private int _numberB;

            public int NumberA
            {
                get
                {
                    lock(_numberLock)
                    {
                        return _numberA;
                    }
                }
            }
            public int NumberB
            {
                get
                {
                    lock (_numberLock)
                    {
                        return _numberB;
                    }
                }
            }
            public void InfiniteNumbers()
            {
                while (true)
                {
                    lock (_numberLock)
                    {
                        Random random = new();
                        _numberA = _numberB;
                        _numberB = random.Next(0, 10);
                        Console.WriteLine(_numberB);
                    }
                    Thread.Sleep(1000);
                }
            }
            public bool IsRepeat()
            {
                lock(_numberLock)
                {
                    return _numberA == _numberB;
                }
            }
        }
    }
}
