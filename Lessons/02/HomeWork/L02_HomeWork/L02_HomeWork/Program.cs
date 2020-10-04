using System;

namespace L02_HomeWork
{
    public static class Program
    {
        public static void Main()
        {
            Console.Write("Введите первое число:");
            string firstNumber = Console.ReadLine();
            Console.Write("Введите второе число:");
            string secondNumber = Console.ReadLine();
            Console.WriteLine("Выберите тип операции: 1. Сложение, 2. Вычитание, " +
                "3. Умножение, 4. Деление, 5. Остаток от деления, " +
                "6. Возведение в степень");
            string operation = Console.ReadLine();
            if(operation == "1")
            {
                Console.WriteLine($"Сложение: {firstNumber} + {secondNumber} = " +
                    $"{double.Parse(firstNumber) + double.Parse(secondNumber)}");
            }
            else if(operation == "2")
            {
                Console.WriteLine($"Вычитание: {firstNumber} - {secondNumber} = " +
                    $"{double.Parse(firstNumber) - double.Parse(secondNumber)}");
            }
            else if (operation == "3")
            {
                Console.WriteLine($"Умножение: {firstNumber} * {secondNumber} = " +
                    $"{double.Parse(firstNumber) * double.Parse(secondNumber)}");
            }
            else if (operation == "4")
            {
                Console.WriteLine($"Деление: {firstNumber} / {secondNumber} = " +
                    $"{double.Parse(firstNumber) / double.Parse(secondNumber)}");
            }
            else if (operation == "5")
            {
                Console.WriteLine($"Остаток от деления: {double.Parse(firstNumber) % double.Parse(secondNumber)}");
            }
            else if (operation == "6")
            {
                Console.WriteLine($"{firstNumber}^{secondNumber} = " +
                    $"{Math.Pow(double.Parse(firstNumber), double.Parse(secondNumber))}");
            }
            else {}
        }
    }
}
