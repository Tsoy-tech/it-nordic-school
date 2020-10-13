using System;
using System.Globalization;

namespace L04_HomeWork
{
	class Program
	{ 
		static void Main(string[] args)
		{
			int howManyLarge;
			int howManyMedium;
			int howManySmall;
			int remainderAfterTwenty;
			int remainderAfterFive;
			float volume;
			string inputeVolume;
			const int smallContainer = 1;
			const int mediumContainer = 5;
			const int largeContainer = 20;

			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("Какой объем сока (в литрах) требуется упаковать?\n" + "Объем:");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine($"Примечание: в качестве десятичного разделителя используйте " +
				$"\'{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}\'\n" +
				"---------------------------------------------------------------");
			Console.ResetColor();
			Console.SetCursorPosition(6, 1);
			inputeVolume = Console.ReadLine();
			volume = float.Parse(inputeVolume);

			howManyLarge = (int)Math.Ceiling(volume) / largeContainer;
			remainderAfterTwenty = (int)Math.Ceiling(volume) % largeContainer;
			howManyMedium = remainderAfterTwenty / mediumContainer;
			remainderAfterFive = remainderAfterTwenty % mediumContainer;
			howManySmall = remainderAfterFive / smallContainer;

			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.SetCursorPosition(0, 4);
			Console.WriteLine("Вам потребуются следующие контейнеры:");
			if (howManyLarge > 0)
			{
				Console.WriteLine($"{largeContainer.ToString()}".PadLeft(3) +
					" л: ".PadRight(1) +
					howManyLarge.ToString() + " шт.") ;
			}
			if (howManyMedium > 0)
			{
				Console.WriteLine($"{mediumContainer.ToString()}".PadLeft(3) + 
					" л: ".PadRight(1) + 
					howManyMedium.ToString() + " шт.");
			}
			if (howManySmall > 0)
			{
				Console.WriteLine($"{smallContainer.ToString()}".PadLeft(3) + 
					" л: ".PadRight(1) + 
					howManySmall.ToString() + " шт.");
			}

			Console.ForegroundColor = ConsoleColor.DarkGray;
		}
	}
}
