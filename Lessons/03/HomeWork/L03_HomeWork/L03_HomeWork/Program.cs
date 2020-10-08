using System;

namespace L03_HomeWork
{
	class Program
	{
		static void Main()
		{
			const int index = 10;

			int[] verticalMultipliers = new int[index];
			int[] horizontalMultipliers = new int[index];
			
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Write("*".PadLeft(5));

			for (int i = 0; i < index; i++) 
			{
				verticalMultipliers[i] = i + 1;
				horizontalMultipliers[i] = i + 1;

				Console.Write(horizontalMultipliers[i].ToString().PadLeft(5));
			}

			Console.ForegroundColor = ConsoleColor.White;
			Console.Write('\n');

			for (int i = 0; i < index; i++)
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write(verticalMultipliers[i].ToString().PadLeft(5));
				Console.ForegroundColor = ConsoleColor.White;

				for (int j = 0; j < index; j++)
				{
					Console.Write((horizontalMultipliers[j] * verticalMultipliers[i]).ToString().PadLeft(5));
				}
				Console.Write('\n');
			}
		}
	}
}
