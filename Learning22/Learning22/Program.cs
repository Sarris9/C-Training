using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Learning22
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //int result = AddOnEuropa(2, 3);
            //int result = 0;
            //Thread thread = new Thread(() => result = AddOnEuropa(2, 3));
            //thread.Start();

            //AddOnEuropa(2, 3, result => Console.WriteLine(result));
            //Console.WriteLine(result);



            //void AddOnEuropa(int a,int b,Action<int> callback)
            //{
            //    Thread thread = new Thread(() =>
            //    {
            //        Thread.Sleep(3000);
            //        int result = a + b;
            //        callback(result);
            //    });
            //    thread.Start();
            //}

            //Task<int> additionTask = AddOnEuropa(2, 3);
            //additionTask.Wait();
            //int result = additionTask.Result;
            //Task addAndDisplay = additionTask.ContinueWith(t => Console.WriteLine(t.Result));
            //Console.WriteLine(result);

            //Task<int> AddOnEuropa(int a, int b) 
            //{
            //    Task<int> task = new Task<int>(() =>
            //        {
            //            Thread.Sleep(3000);
            //            return a + b;
            //        });
            //    task.Start();
            //    return task;
            //int result = a + b;
            //return Task.FromResult(result);
            //}
            //int result = await AddOnEuropa(2, 3);
            //Console.WriteLine(result);

            //Task<int> AddOnEuropa(int a, int b)
            //{
            //    return Task.Run(() =>
            //    {
            //        Thread.Sleep(3000);
            //        return a + b;
            //    });
            //}
            //async Task DoWork()
            //{
            //    int result = await AddOnEuropa(2, 3);
            //    Console.WriteLine(result);
            //}

            //Task<int> firstAdd = AddOnEuropa(2, 3);
            //Task<int> secondAdd = AddOnEuropa(4, 5);
            //int results = await AddOnEuropa(await firstAdd, await secondAdd);
            //Console.WriteLine(results);

            //async Task AsynchronousMethod()
            //{
            //    Console.WriteLine("A");
            //    Task task = Task.Run(() => { Console.WriteLine("B"); });
            //    Console.WriteLine("C");
            //    await task;
            //    Console.WriteLine("D");
            //}
            //await AsynchronousMethod();
            ////
            ///
            async Task<int> RandomlyRecreate(string word)
            {
                return await Task.Run(() =>
                {
                    Random random = new();
                    int count = 0;
                    //TimeSpan result = new();
                    //DateTime starting = DateTime.Now;
                    while (true)
                    {
                        var finalWord = string.Empty;
                        count++;
                        for (int c = 0; c < word.Length; c++)
                        {
                            var newWord = (char)('a' + random.Next(26));
                            finalWord += newWord;
                        }
                        if (word == finalWord) break;
                        //DateTime ending = DateTime.Now;
                        //result = ending - starting;
                    }
                    //Console.WriteLine(count);
                    //Console.WriteLine($"The word: {word} Its tooked {result.TotalNanoseconds} Nanoseconds to finished");
                    return count;
                });
            }
            //async Task<List<int>> MoreWords(List<string> words)
            //{
            //    //List<int> results = new();
            //    List<Task<int>> tasks = new();
            //    foreach(string word in words)
            //    {
            //        //results.Add(await RandomlyRecreate(word));
            //        tasks.Add(RandomlyRecreate(word));
            //    }
            //    var results = await Task.WhenAll(tasks);
            //     return  results.ToList();
            //}

            async Task<int> RunWord(string word)
            {
                DateTime starting = DateTime.Now;
                int attempts = await Task.Run(() => RandomlyRecreate(word));
                DateTime ending = DateTime.Now;
                TimeSpan elapsed = ending - starting;
                Console.WriteLine($"The word: {word} Its tooked {attempts} and {elapsed.TotalNanoseconds} Nanoseconds to finished");
                return attempts;
            }

            //List<string> playerWords = new List<string>();
            while (true)
            {
                Console.WriteLine("Write a word");
                string playerWord = Console.ReadLine()!;
                //DateTime starting = DateTime.Now;
                //Console.WriteLine("The time start now!");
                //Console.WriteLine(starting);
                if (playerWord.Length > 5)
                {
                    Console.WriteLine("Not too big.Max 5 letters");
                    continue;
                }
                //else
                //{
                //    playerWords.Add(playerWord);
                //}
                //if (Console.ReadKey().Key.Equals(ConsoleKey.Enter)) break;
                _= await RunWord(playerWord);
            }
                //await MoreWords(playerWords);
                //DateTime ending = DateTime.Now;
                //var result = starting.CompareTo(ending);
                //Console.WriteLine($"The word :{playerWord} Its tooked {result} to finished");
        }
    }
}
