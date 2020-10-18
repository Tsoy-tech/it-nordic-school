using System;

namespace L06_HomeWork
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = string.Empty;
			int inputNumber = 0;
			int evenDigits = 0;

			//Input

			Console.WriteLine($"Введите положительное натуральное число не более 2 миллиардов:");

			do
			{
				try
				{
					input = Console.ReadLine();
					inputNumber = int.Parse(input);

					if (inputNumber <= 0)
					{
						Console.WriteLine("Введено неверное значение! Попробуйте ещё раз:");
						continue;
					}
				}
				catch (System.OverflowException e)
				{
					Console.WriteLine($"Ошибка {e.GetType()}! Попробуйте ещё раз:");
					continue;
				}
				catch (System.FormatException e)
				{
					Console.WriteLine($"Ошибка {e.GetType()}! Попробуйте ещё раз:");
					continue;
				}

				if (inputNumber <= 2000000000 && inputNumber >= 0)
					break;
			}
			while (true);

			//Calculations

			foreach(char digit in inputNumber.ToString())
			{
				int a = int.Parse(digit.ToString());

				if (a % 2 == 0)
					evenDigits++;
			}

			//Output

			Console.WriteLine($"В числе {inputNumber} содержится следующее количество четных цифр: {evenDigits}.");
		}
	}
}
