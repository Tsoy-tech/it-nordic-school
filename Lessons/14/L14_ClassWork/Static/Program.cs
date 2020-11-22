using System;

namespace L14_ClassWork.Static
{
    class Program
    {
        static void Main(string[] args)
        {
            var singleton1 = ConsoleWriter.GetInstance();
            var singleton2 = ConsoleWriter.GetInstance();

            Console.WriteLine(singleton1.Equals(singleton2));
        }
    }
}
