using System;
using Rectangle.Utility;

namespace Rectangle.DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var rect1 = new Rectangle<short>(2000, 1000);
            short square = rect1.Calculate((short x, short y) => checked((short)(x * y)));

            Console.WriteLine(square);
        }
    }
}
