using System;
using System.Collections.Generic;

namespace L08_ClassWork_List2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            double digits = 0;
            double result = 0;

            List<double> doubleList = new List<double> { };

            Console.WriteLine("Введите число или \"stop\" для начала расчетов: ");

            do
            {
                try
                {
                    input = Console.ReadLine();

                    if (input.Equals("stop", StringComparison.CurrentCultureIgnoreCase))
                    {
                        if(doubleList.Count > 1)
                        break;

                        Console.WriteLine("Вы должны ввести хотя бы 2 числа!");
                        continue;
                    }

                    if (double.TryParse(input, out double number))
                    {
                        doubleList.Add(number);
                    }
                    else
                    {
                        Console.WriteLine("Вы можете вводить только дробные числа");
                    }
                }
                catch { Console.WriteLine("Ошибка!"); }

            } while (true);

            foreach (double digit in doubleList)
            {
                digits += digit;
            }

            result = digits/ doubleList.Count;

            Console.WriteLine($"Среднее значение: {result:0.##}");
            Console.WriteLine("Сумма: " + digits);
        }
    }
}
