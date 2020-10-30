using System;
using System.Collections.Generic;

namespace L08_HomeWork_independent
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = string.Empty;
			Stack<int> dishes = new Stack<int>();

			Console.WriteLine("Выберите операцию(Помыть, Вытереть, Выйти): ");

			do
			{
				//Input

				input = Console.ReadLine().ToLowerInvariant().Trim();

				//Calculations

				switch (input)
				{
					case "помыть":
						dishes.Push(1);
						break;
					case "вытереть":
						if (dishes.Count > 0)
							dishes.Pop();
						break;
				}

				//Output

				if(dishes.Count > 0)
				Console.WriteLine("Текущее количество тарелок: " + dishes.Count);
				else
				{
					Console.WriteLine("Стопка тарелок пуста!");
				}
				if (input == "выйти")
					break;
			} while (true);
		}
	}
}
