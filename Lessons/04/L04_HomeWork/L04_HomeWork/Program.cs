using System;
using System.Drawing;
using System.Dynamic;
using System.Globalization;
using System.Security.Authentication;

namespace L04_HomeWork
{
	class Program
	{ 
		enum JuiceСontainers
		{
			One = 1,
			Five = 5,
			Twenty = 20
		};
		static void Main(string[] args)
		{				
			int howManyTwenty;
			int howManyFive;
			int howManyOne;
			int remainderAfterTwenty;
			int remainderAfterFive;

			float volume;

			string inputeVolume;

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

			howManyTwenty = (int)Math.Ceiling(volume) / (int)JuiceСontainers.Twenty;

			remainderAfterTwenty = (int)Math.Ceiling(volume) % (int)JuiceСontainers.Twenty;
			howManyFive = remainderAfterTwenty / (int)JuiceСontainers.Five;

			remainderAfterFive = remainderAfterTwenty % (int)JuiceСontainers.Five;
			howManyOne = remainderAfterFive / (int)JuiceСontainers.One;

			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.SetCursorPosition(0, 4);
			if (howManyTwenty > 0)
			{
				Console.WriteLine($"{((int)JuiceСontainers.Twenty).ToString()}".PadLeft(3) +
					" л: ".PadRight(1) +
					howManyTwenty.ToString() + " шт.") ;
			}

			if (howManyFive > 0)
			{
				Console.WriteLine($"{((int)JuiceСontainers.Five).ToString()}".PadLeft(3) + 
					" л: ".PadRight(1) + 
					howManyFive.ToString() + " шт.");
			}

			if (howManyOne > 0)
			{
				Console.WriteLine($"{((int)JuiceСontainers.One).ToString()}".PadLeft(3) + 
					" л: ".PadRight(1) + 
					howManyOne.ToString() + " шт.");
			}
			Console.ForegroundColor = ConsoleColor.DarkGray;
		}
	}
}
