using System;
using System.Threading;

namespace L01_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();
            Thread.Sleep(5000);
            Console.WriteLine($"Здравствуйте, {name}!");
            Thread.Sleep(5000);
            Console.WriteLine($"Всего доброго, {name}!");
            Console.ReadKey();
        }
    }
}

