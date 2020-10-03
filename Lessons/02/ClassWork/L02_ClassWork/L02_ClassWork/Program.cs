using System;

namespace L02_ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello world!");

            char letter = 'A'; // declaring a single char variable
            Console.WriteLine(letter);

            string name = "Bob"; // declaring a string variable
            Console.WriteLine(name);

            int i = 0x00000001;
            float pi = 3.1415F;
            Console.WriteLine(i+pi);

            int parsedValue = int.Parse("15468");
            parsedValue = parsedValue + 1;
            Console.WriteLine(parsedValue);

            Console.Write("Введите ваш возраст: ");
            string inputAge = Console.ReadLine();
            int age = int.Parse(inputAge);
            Console.WriteLine($"Ваш возраст через 10 лет: {age + 10}");
        }
    }
}
