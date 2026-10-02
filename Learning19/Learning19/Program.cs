using System.Drawing;

namespace Learning19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Point a = new Point(2, 3);
            //Point b = new Point(1, 8);
            //Point result = a + b;
            //Console.WriteLine($"{result.X}, {result.Y}");
            //Point p = new Point(1, 3);
            //Point q = p * 3;
            //Point r = 3 * p ;
            //Console.WriteLine($"the q:{q}, the r:{r}");
            //Point c = new Point(3, 4);
            //Point test = -c;
            //Console.WriteLine($"{test.X},{test.Y}");

            //Pair pair = new Pair()
            //{
            //    [0] = 1,
            //    [1] = -4
            //};
            ////Dictionary<string, Color> namedColors = new Dictionary<string, Color>
            ////{
            ////    ["red"] =  Color.FromArgb(1.0, 0.0, 0.0),

            ////};
            ////int a = (int)3.0;
            ////double b = 3;

            ////int a = 0;
            ////long b = a; //Implicit cast
            ////int c = (int)b; //Explicit cast 

            //Point2 a = new Point2(1, 2);
            //Point3 b = a;

            //Point3 c = new Point3(1, 2, 3);
            //Point2 d = (Point2)c;

            //void MoveLeft(Point3 p) => p.X--;
            ////
            ///
            BlockCoordinate blockCoordinate = new BlockCoordinate(2, 4);
            BlockOffset blockOffset = new BlockOffset(3, 4);
            BlockCoordinate block = blockCoordinate + blockOffset;
            Console.WriteLine($"{block.Row} , {block.Column}" );
            BlockCoordinate move = blockCoordinate + Direction.South;
            Console.WriteLine($"{move.Row} , {move.Column}");
            Console.WriteLine(blockCoordinate[0]);
            Console.WriteLine(blockCoordinate[1]);
            BlockOffset test = (BlockOffset)Direction.West;
            Console.WriteLine($"{test.RowOffset}, {test.ColumnOffset}");
            BlockCoordinate test2 = blockCoordinate + (BlockOffset)Direction.West;
            Console.WriteLine($"{test2.Row}, {test2.Column}");
        }
        //public record Point(double X,double Y)
        //{
        //    public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
        //    public static Point operator *(Point p, double scalar) => new Point(p.X * scalar, p.Y * scalar);
        //    public static Point operator *(double scalar, Point p) => p * scalar;
        //    public static Point operator -(Point p) => new Point(-p.X, -p.Y);

        //}
        //public class Pair
        //{
        //    public int First { get; set; }
        //    public int Second { get; set; }

        //    public int this[int index]
        //    {
        //        get
        //        {
        //            if (index == 0) return First;
        //            else return Second;
        //        }
        //        set
        //        {
        //            if (index == 0) First = value;
        //            else Second = value;
        //        }
        //    }
        //}
        //public record Point2(double X ,double Y)
        //{
        //    public static explicit operator Point2(Point3 p) => new Point2(p.X, p.Y);
        //}
        //public record Point3(double X, double Y, double Z)
        //{
        //    public static implicit operator Point3(Point2 p) => new Point3(p.X, p.Y, 0);
        //    public Point3 ToPoint3() => new Point3(X, Y, 0);
        //}
        ////
        ///
        public record BlockCoordinate(int Row, int Column)
        {
            public static BlockCoordinate operator +(BlockCoordinate a, BlockOffset b) => new BlockCoordinate(a.Row + b.RowOffset, a.Column + b.ColumnOffset);
            public static BlockCoordinate operator +(BlockCoordinate a, Direction d) => a + d switch
            {
                Direction.North => new BlockOffset(+1, 0),
                Direction.East => new BlockOffset(0, +1),
                Direction.South => new BlockOffset(-1, 0),
                Direction.West => new BlockOffset(0, -1),
                _ => throw new ArgumentOutOfRangeException(nameof(d), d,null)
            };
            public int this[int index]
            {
                get
                {
                    if (index == 0) return Row;
                    else return Column;
                }
            }
                
        }
        public record BlockOffset(int RowOffset,int ColumnOffset)
        {
            public static explicit operator BlockOffset(Direction direction)
            {
                return direction switch
                {
                    Direction.North => new BlockOffset(+1, 0),
                    Direction.East => new BlockOffset(0, +1),
                    Direction.South => new BlockOffset(-1, 0),
                    Direction.West => new BlockOffset(0, -1),
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
                };

            }
        }
        public enum Direction { North,East,South,West};
    }
}
