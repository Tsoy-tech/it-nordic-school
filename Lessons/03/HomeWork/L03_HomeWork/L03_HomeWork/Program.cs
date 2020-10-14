using System;
using System.Threading;

namespace L03_HomeWork
{
	class Program
	{
		static void Main()
		{
			const int indexVertical = 10;
			const int indexHorizontal = 10;
			const int startNumberVertical = 1;
			const int startNumberHorizontal = 1;
			const int stepChangeVertical = 1;
			const int stepChangeHorizontal = 1;
			int[] verticalMultipliers = new int[indexVertical];
			int[] horizontalMultipliers = new int[indexHorizontal];
			int[,] allMultipliers = new int[indexVertical, indexHorizontal];

			for (int i = 0; i < indexVertical; i++)
			{
				verticalMultipliers[i] = startNumberVertical + stepChangeVertical * i ;
			}
			for (int j = 0; j < indexHorizontal; j++)
			{
				horizontalMultipliers[j] = startNumberHorizontal  + stepChangeHorizontal * j;
			}
			for (int i = 0; i < indexVertical; i++)
			{
				for (int j = 0; j < indexHorizontal; j++)
				{
					allMultipliers[i,j] = horizontalMultipliers[j] * verticalMultipliers[i];
				}
			}

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Write("*".PadLeft(5));
			for (int j = 0; j < indexHorizontal; j++)
			{
				Console.Write(horizontalMultipliers[j].ToString().PadLeft(5));
			}
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write('\n');
			for (int i = 0; i < indexVertical; i++)
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write(verticalMultipliers[i].ToString().PadLeft(5));
				Console.ForegroundColor = ConsoleColor.White;
				for (int j = 0; j < indexHorizontal; j++)
				{
					Console.Write(allMultipliers[i, j].ToString().PadLeft(5));
				}
				Console.Write('\n');
			}
		}
	}
}