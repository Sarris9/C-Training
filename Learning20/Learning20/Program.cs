namespace Learning20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<GameObject> objects = new List<GameObject>();
            objects.Add(new Ship { ID = 1, X = 0, Y = 0, HP = 50, MaxHP = 100, PlayerID = 1 });
            objects.Add(new Ship { ID = 2, X = 4, Y = 2, HP = 75, MaxHP = 100, PlayerID = 1 });
            objects.Add(new Ship { ID = 3, X = 9, Y = 3, HP = 0, MaxHP = 100, PlayerID = 2 });

            List<Player> players = new();
            players.Add(new Player(1, "Player 1", "Red"));
            players.Add(new Player(2, "Player 2", "Blue"));

            IEnumerable<GameObject> everything = from o in objects select o;
            var ids = from o in objects select o.ID;
            //var healtText = from o in objects select $"{o.HP}/{o.MaxHP}";
            var healtText = from o in objects select (o,$"{o.HP}/{o.MaxHP}");
            //var aliveObjects = from o in objects where o.HP > 0 select o;
            var aliveObjects = from o in objects orderby o.MaxHP select o;
            // Method call syntax
            var results = objects.
                Where(o => o.HP > 0).
                OrderBy(o => o.HP).
                Select(o => o.HP / o.MaxHP);

            IEnumerable<Ship> ships = from Ship s in objects select s;

            var intersections = from o1 in objects from o2 in objects where o1 != o2 where o1.CollidingWith(o2) select (o1, o2);

            var objectColors = from o in objects join p in players on o.PlayerID equals p.ID select (o, p.TeamColor);

            var statuses = from o in objects let persentHealth = o.HP / o.MaxHP * 100 select $"{o.ID} is at {persentHealth}%.";

            // Continuation Clauses
            var deadStrongObjectIds = from o in objects where o.MaxHP > 50 select (o.ID, o.HP, o.MaxHP, o.HP / o.MaxHP) into objectHealth where objectHealth.HP == 0 select objectHealth.ID;

            //Grouping
            IEnumerable<IGrouping<int, GameObject>> groups = from o in objects group o by o.PlayerID;
            // Console.WriteLine(groups);
            ////
            ///
            var problemInput = new[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };
            IEnumerable<int> object1( int[] ints)
            {
                List<int> result = new List<int>();

                foreach (int i in ints)
                {
                    if(i % 2 == 0)
                    {
                        var doubleNumber = i * 2;
                        result.Add(doubleNumber);
                    }
                    //return result;
                }
                result.Sort();
                return result;
            }
            IEnumerable<int> object2(int[] ints)
            {
                //var result = from i in ints let finalResult = (i * 2) % 2 select i;
                var result = from i in ints where i % 2 == 0  orderby i select i * 2 ;

                return result;
            }
            IEnumerable<int> object3(int[] ints)
            {
                var result = ints
                    .Where(i => i % 2 == 0)
                    .OrderBy(i => i)
                    .Select(i => i * 2);
                return result;
            }

            object1(problemInput);
            object2(problemInput);
            object3(problemInput);
        }
        public class GameObject
        {
            public int ID { get; set; }
            public double X { get; set; }
            public double Y { get; set; }
            public int MaxHP { get; set; }
            public int HP { get; set; }
            public int PlayerID { get; set; }

            public bool CollidingWith(GameObject gameObject) { return false; }
        }
        public class Ship : GameObject { }
        public record Player(int ID,string UserName,string TeamColor);

    }
}
