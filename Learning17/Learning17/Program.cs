using System.Xml.Linq;

namespace Learning17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("What do you want me to tell you next time?");
            //string? message = Console.ReadLine();
            //File.WriteAllText("C:\\Users\\george.sarris\\source\\repos\\C-Training\\Learning17\\Message.txt", message);
            //string? prenious = File.ReadAllText("C:\\Users\\george.sarris\\source\\repos\\C-Training\\Learning17\\Message.txt");
            //Console.WriteLine(prenious);

            //Console.WriteLine("what do you want me to tell you next time?");
            //string? message = Console.ReadLine();
            //File.WriteAllText("C:\\Users\\george.sarris\\source\\repos\\C-Training\\Learning17\\Message.txt", message);

            //List<Score> MakeDefaultScores()
            //{
            //    return new List<Score>()
            //    {
            //        new Score("R2-D2",12420,15),
            //        new Score("C-3PO",8543,9),
            //        new Score("GONK",-1,1)
            //    };
            //}
            //void SaveScore(List<Score> scores)
            //{
            //    List<string> scoreStrings = new List<string>();
            //    foreach (Score score in scores)
            //        scoreStrings.Add($"{score.Name},{score.Points},{score.Level}");

            //    File.WriteAllLines("C:\\Users\\george.sarris\\source\\repos\\C-Training\\Learning17\\Message.txt", scoreStrings);
            //}
            //var test = MakeDefaultScores();
            //SaveScore(test);

            //string[] scorestrings = File.ReadAllLines("C:\\Users\\george.sarris\\source\\repos\\C-Training\\Learning17\\Message.txt");
            //Console.WriteLine(scorestrings[1]);
            //string first = scorestrings[0];
            //string[] tokens = first.Split(",");
            //Console.WriteLine(tokens[0]);

            //List<Score> LoadHighScores()
            //{
            //    string[] scorestrings = File.ReadAllLines("C:\\Users\\george.sarris\\source\\repos\\C-Training\\Learning17\\Message.txt");
            //    List<Score> scores = new List<Score>();
            //    foreach(string scoreString in scorestrings)
            //    {
            //        string[] tokens = scoreString.Split(",");
            //        Score score = new Score(tokens[0], Convert.ToInt32(tokens[1]), Convert.ToInt32(tokens[2]));
            //        scores.Add(score);
            //    }
            //    return scores;
            //}
            //LoadHighScores();
            ///////
            ///////
            ///

            string [] lastScores = File.ReadAllLines("C:\\Users\\george.sarris\\source\\repos\\C-Training\\Learning17\\Message.txt");
            if (lastScores == null || lastScores.Length == 0)
                lastScores = new string[1] { string.Empty };
            string lastScore = lastScores[0];
            string[] tokens = lastScore.Split(",");
           
            Console.WriteLine("Write your name.");

            string userName = string.Empty;
            int userPoint = 0;
            userName = Console.ReadLine();

            if (tokens[0] == userName)
                userPoint = Convert.ToInt32(tokens[1]);
            userPoint += userName.Count();

            Console.WriteLine();
            Console.WriteLine(userPoint);

            foreach (char c in userName)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                    break;
            }
            //UserPoints userPoints = new UserPoints ( userName, userPoint );
            string totalScore = userName + "," + userPoint;

            File.WriteAllText("C:\\Users\\george.sarris\\source\\repos\\C-Training\\Learning17\\Message.txt", totalScore);

        }
        //public record Score(string Name,int Points,int Level);
        /////
        ////
        ///
        public record UserPoints(string Name,int Points);


    }
}
