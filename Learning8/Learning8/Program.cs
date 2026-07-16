using System.Security.Cryptography.X509Certificates;

namespace Learning8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coordinate[] BigTest = new Coordinate[4];
            BigTest[0] = new Coordinate(2, 5);
            BigTest[1] = new Coordinate(4, 8);
            BigTest[2] = new Coordinate(1, 9);
            BigTest[3] = new Coordinate(2, 6);
            foreach (Coordinate coordinate in BigTest)
            {
                for (int i = 0; i < BigTest.Length; i++)
                {
                    coordinate.Determine(BigTest[i]);
                    //Console.WriteLine(BigTest[i].ToString());
                }

            }

        }
        public struct Coordinate
        {
            public readonly float Row;
            public readonly float Column;

            public Coordinate(float row, float column)
            {
                Row = row;
                Column = column;
            }
            public void Determine(Coordinate coordinate)
            {
                if ((coordinate.Row + 1 == Row || coordinate.Row - 1 == Row  || coordinate.Row == Row  && coordinate.Column == Column) ||
                    (coordinate.Column + 1 == Column || coordinate.Column - 1 == Column || coordinate.Column == Column && coordinate.Row == Row))
                {
                    Console.WriteLine("Its adjacent");
                }
                else
                {
                    Console.WriteLine(" its ok");
                }
                //return new Coordinate(coordinate.Row + 1, coordinate.Column + 1);
            }
        }
        //public void Determines(Coordinate co)
        //{
        //    new Coordinate {
        //        co.Row -= 1,
        //     }
        //}
        //public Coordinate Determines(Coordinate co)
        //{
            
        //    return new Coordinate(co.Row - 1, co.Column);
        //}
    }
}
