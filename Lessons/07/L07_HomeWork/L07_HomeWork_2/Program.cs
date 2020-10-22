using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace L07_HomeWork_2
{
	class Program
	{
		static void Main(string[] args)
		{
			string inputText = string.Empty;
			StringBuilder reverseText = new StringBuilder(50);

			//Input

			Console.WriteLine("Введите непустую строку:");
			try
			{
				do
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					inputText = Console.ReadLine();
					Console.ResetColor();

					if (string.IsNullOrWhiteSpace(inputText) != true)
						break;

					Console.WriteLine("Вы ввели пустую строку :( Попробуйте ещё раз:");
				} while (true);
			}
			catch (Exception e)
			{
				Console.WriteLine($"Ошибка {e.GetType()}!");
				throw;
			}

			//Calculations

			inputText = inputText.ToLowerInvariant();

			for (int lastIndexOfLetter = inputText.Length - 1;
				0 <= lastIndexOfLetter && lastIndexOfLetter < inputText.Length;
				lastIndexOfLetter--)
			{
				reverseText.Append(new char[] { inputText[lastIndexOfLetter] });
			}

			//Output

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(reverseText);
			Console.ResetColor();
			Console.WriteLine("\n" + "Нажмите любую клавишу для выхода…");
		}
	}
}
