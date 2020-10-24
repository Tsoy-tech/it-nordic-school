using System;
using System.Collections.Generic;

namespace _08_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> countries = new Dictionary<int, string>();

            countries.Add(1, "Russia");
            countries.Add(3, "Great Britain");
            countries.Add(2, "USA");

            countries[1] = "Россия";//Изменение значение элемента словаря


            foreach (KeyValuePair<int, string> country in countries)
            {
                Console.WriteLine($"{country.Key} - {country.Value}");
            }

            countries.Remove(1);
            countries.Add(1, "Russia");

            foreach (KeyValuePair<int, string> country in countries)
            {
                Console.WriteLine($"{country.Key} - {country.Value}");
            }

            if (!countries.ContainsKey(1))
                countries.Add(1, "XXX");

        }
    }
}
