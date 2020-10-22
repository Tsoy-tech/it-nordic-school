using System;

namespace L07_HomeWork_1
{
	class Program
	{
		static void Main(string[] args)
		{
			string inputText = string.Empty;
			string[] words = new string[] { };
			const char startingLetter = 'А';
			int numberOfStatingLetters = 0;

			//Input

			Console.WriteLine("Введите строку из нескольких слов:");
			try
			{
				do
				{
					inputText = Console.ReadLine();
					words = inputText.Split(" ", StringSplitOptions.RemoveEmptyEntries);

					if (words.Length > 1)
						break;

					Console.WriteLine("Слишком мало слов :( Попробуйте ещё раз:");
				} while (true);
			}
			catch(Exception e)
			{
				Console.WriteLine($"Ошибка {e.GetType()}!");
				throw;
			}

			//Calculations

			for (int i = 0; i < words.Length; i++)
			{
				if (words[i].StartsWith(startingLetter.ToString(), StringComparison.InvariantCultureIgnoreCase))
				{
					numberOfStatingLetters++;
				}
			}

			//Output

			Console.WriteLine($"Количество слов, начинающихся с буквы " +
				$"\'{startingLetter}\': {numberOfStatingLetters}");
			Console.WriteLine("\n" + "Нажмите любую клавишу для выхода…");
		}
	}
}
