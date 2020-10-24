using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Dictionary_2
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                Dictionary<string, string> countries = new Dictionary<string, string>
                {
                    { "Россия", "Москва" },
                    { "Британия","Лондон" },
                    { "США","Вашингтон" },
                    { "Канада", "Оттава" }
                };

                do
                {
                    int index = new Random().Next(countries.Count);
                    KeyValuePair<string, string> kvp = countries.ElementAt(index);
                    Console.WriteLine($"Назовите столицу {kvp.Key}:");
                    string answer = Console.ReadLine().Trim();

                    if (answer.Equals(kvp.Value, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Верно!");
                    }
                    break;
                }
                while (true);



            }
        }
    }
}

