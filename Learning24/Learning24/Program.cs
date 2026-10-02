using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Learning24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x;
            unsafe
            {
                //Address-Of Operator.Gets the address of something an returns it.
                //This gets the address of 'x' and puts it in 'pointerToX'.
                int* pointerToX = &x;
                //Indirection Operator:Dereferences the pointer,giving you the object at the location pointed to by a pointer.
                //This puts a 3 in memory location pointerToX points at(the original 'x' variable).
                *pointerToX = 3;
                //Pointer Member Access Operator: allows access to members through a pointer.
                pointerToX-> GetType();
            }
            Console.WriteLine(x.GetType());
            Console.WriteLine(x);

            Point p = new Point();
            unsafe
            {
                fixed (double* px = &p.X)
                {
                    (*px)++;
                }
            }

            byte[] byteArray = new byte[sizeof(int) * 4];
            Console.WriteLine(sizeof(double));

            nuint test;//native int
            nint tes1;// native uint


        }
        public unsafe void DoSomethingUnsafe() 
        {
            int* numbers = stackalloc int[10];
        }

        public unsafe class UnsafeClass { };

        public class Point
        {
            public double X;
            public double Y;
        }
        //fixed-size array or fixed-size buffer, which must always be the same size,
        //but that stores its data within the struct instead of elsewhere on the heap
        public unsafe struct S
        {
            public int Value1;
            public int Value2;
            public fixed int MoreValues[10];
        }
        //Produce a wrapper from C to C#
        public static class DllWrapper
        {
            [DllImport("MyDll.dll", EntryPoint = "add")]
            internal static extern int Add(int a, int b);
        }
    }
}
