using System;
using System.Globalization;

namespace L04_ClassWork
{
    class Program
    {
        [Flags] // [] - атрибут
        enum DayTime 
        { 
            Night, 
            Morning, 
            Noon, 
            Evening
        }

        enum CarType : byte
        {
            None = 0,
            SUV = 1,
            Sedan = 2,
            Truck = 4,

        }

        static void Main(string[] args)
        {
            var myCareType = CarType.Sedan;

            CarType supportedCars =
                CarType.SUV
                | CarType.Sedan
                | CarType.Truck;

            WriteByteValueWithBits((Byte)supportedCars);

            /*var myCar = Enum.Parse(typeof(CarType), Console.ReadLine());
            Console.WriteLine("Your car is supported: " + 
                (((byte)myCar & (byte)supportedCars) > 0);????*/

            /*var currentDayTime = Enum.Parse(typeof(DayTime), Console.ReadLine());
            Console.WriteLine((DayTime)((int)currentDayTime + 1));*/

            /*DayTime currentDayTime = DayTime.Noon;
            Console.WriteLine(currentDayTime);*/

            /*CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

            Console.ForegroundColor = ConsoleColor.DarkRed;

            /*double a = 11/3;
            Console.WriteLine(a);

            double b = 11.0 / 3;
            Console.WriteLine(b);*/

            /*int i = 0;
            int j = ++i;
            Console.WriteLine(j);

            bool canSkipOperation = true; //bool всегда утверждение!!!| is, should, must, can - добавлять в начало названия!!!

            if(canSkipOperation)
            { 
                Console.WriteLine("Operation skipped"); 
            }*/

            /*int a = 10;
            int b = a++;

            Console.WriteLine(a = b); //10
            Console.WriteLine(a != b); //false
            Console.WriteLine(a > b); // false
            Console.WriteLine(a < b); // false
            Console.WriteLine(a >= b); // true
            Console.WriteLine(a <= b); // true

            */

            //implicit casting | im - скрытое(неявное) приведение типов

            /*int a = 10;
            double b = a;
            Console.WriteLine(b);*/

            /*double g = 9.8;
            int c = (int)g;
            Console.WriteLine(c);

            long veryBigNumber = long.MaxValue;
            int notSoBigNumber = (int)veryBigNumber;
            Console.WriteLine(notSoBigNumber);*/

            /*int a = int.MaxValue;
            int b = int.MaxValue;
            float c = (float)a * b;
            Console.WriteLine(c);

            double j = 9.5; //Число не четное - округляется в МИНУС!
            double l = 10.5; //Число четное - округляется в ПЛЮС!

            Console.WriteLine(Convert.ToInt32(j));
            Console.WriteLine(Convert.ToInt32(l));

            Console.WriteLine(Math.Round(l, MidpointRounding.ToEven)); //в меньшую сторону
            Console.WriteLine(Math.Round(l, MidpointRounding.AwayFromZero)); //в большую сторону

            Console.WriteLine(Convert.ToByte('S'));
            Console.ForegroundColor = ConsoleColor.White;*/
            

            //Console.ForegroundColor = ConsoleColor.Green;

            /*double d = 10.9;
            Console.WriteLine(Math.Sqrt(d));

            float f = 10.9F;
            Console.WriteLine(MathF.Sqrt(f));

            var a = Math.Max(
                Math.Sqrt(d), 
                Math.Sqrt(f));
            Console.WriteLine(a);*/

            /*float a = 10.5F;
            float b = 30.21F;

            float c = MathF.Sqrt(a * a + MathF.Pow(b, 2)); //гипотенуза
            Console.WriteLine(c);*/

            /*string inputeA;
            string inputeH;
            string inputeN;

            double a;
            double h;
            double n;

            inputeA = Console.ReadLine();
            inputeH = Console.ReadLine();
            inputeN = Console.ReadLine();

            a = double.Parse(inputeA);
            h = double.Parse(inputeH);
            n = double.Parse(inputeN);

            double m = (a / (2 * Math.Tan(Math.PI / n)));

            double sFull = ((n * a) / 2) * 
                (m + Math.Sqrt(Math.Pow(h, 2) + 
                Math.Pow(m,2)));
            Console.WriteLine(sFull);

            double sSide = (n * a) / 
                2 * Math.Sqrt(Math.Pow(h, 2) + 
                Math.Pow(m, 2));
            Console.WriteLine(sSide);

            double volume = h * n * a * m * (1.0 / 6); // 1.0, в противном случае 0!!!
            Console.WriteLine(volume);*/

            /*string delimiter = 
                CultureInfo
                .CurrentCulture
                .NumberFormat
                .NumberDecimalSeparator;
            Console.Write($"Enter floating number, " +
                $"use {delimiter} as number decimal separator:");

            string strFloat = Console.ReadLine();
            float f = Single.Parse(strFloat);
            Console.WriteLine(f * 2);*/


           /* string strFloat2 = Console.ReadLine();
            float f2 = Single.Parse(strFloat2, 
                provider:CultureInfo.GetCultureInfo("ru-RU"));
            Console.WriteLine(f2 * 2);*/

            //Console.ForegroundColor = ConsoleColor.White;
        }
        static void WriteByteValueWithBits(byte value)
        {
            Console.WriteLine(
                "0x{0}\t({1})\t{2}",
                value.ToString("X").PadLeft(2, '0'),
                Convert.ToString(value, 2).PadLeft(8, '0'),
                value.ToString().PadLeft(3, '0'));
        }
    }
}
