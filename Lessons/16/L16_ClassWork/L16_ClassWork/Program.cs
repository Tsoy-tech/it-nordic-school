using System;

namespace L16_ClassWork
{
    class Program
    {
        delegate int GetNumbersFromNumbers(int[] numbers);//делегат как скелет метода
        static void Main(string[] args)
        {            
            var arrayForTest = new[] { 1, 2, 3, 4, 5 };

            //GetNumbersFromNumbers calculate;
            
            //calculate = Sum;
            //Console.WriteLine(calculate(arrayForTest));

            WriteNumbersFromNumbers(Sum, arrayForTest);

            //calculate = Average;
            //Console.WriteLine(calculate(arrayForTest));

            WriteNumbersFromNumbers(Average, arrayForTest);

            //lambda
            WriteNumbersFromNumbers(
                (array) =>
                {
                    int result = int.MinValue;

                    foreach (var number in array)
                    {
                        result = number > result
                        ? number
                        : result;
                    }

                    return result;
                }, arrayForTest);

            Func<int, bool> isPositiveOrZero = x => x >= 0;
            Func<int, bool> isNegativeOrZero = x => x <= 0;

        }

        static int Sum(int[] array)
        {
            int sum = 0;

            foreach(var number in array)
            {
                sum += number;
            }

            return sum;
        }
        static int Average(int[] array)
        {
            int result = 0;

            foreach (var number in array)
            {
                result += number;
            }

            return result/array.Length;
        }

        static void WriteNumbersFromNumbers(GetNumbersFromNumbers function, int[] arrayForTest)
        {
            Console.WriteLine(function(arrayForTest));
        }
    }
}
