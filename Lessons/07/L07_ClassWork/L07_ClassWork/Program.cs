using System;
using System.Globalization;
using System.Text;
using System.Text.Unicode;

namespace L07_ClassWork
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;

			/*double i = 15;
			double j = Math.PI;

			double s = i * i * j;

			string outputResult = string.Format("Square of the circle with the radius {0:#.0##} equals to {1:#.000}", i, s);//форматирование
			string radius = i.ToString("C", CultureInfo.GetCultureInfo("en-GB")) ; //знак фута

			Console.WriteLine(radius); 
			Console.WriteLine(outputResult);

			Console.WriteLine("Square of the circle with the radius " + 
				i + " equals to " + Math.Round(s, 3));// конкатинация

			/*DateTime now = DateTime.Now;
			string result2 = String.Format("Now is {0:dd.MM.yyyy HH:mm}", now);
			Console.WriteLine(result2); // Now is 05.02.2019 12:00*/

			/*DateTime now = DateTime.Now;
			string result = $"Now is {now:dd.MM.yyyy HH:mm}"; //интерполяция
			Console.WriteLine(result); // Now is 29.01.2019 14:00*/

			/*double firstNumber = 0;
			double secondNumber = 0;
			string input = string.Empty;

			Console.Write("Введите число №1:");
			input = Console.ReadLine();
			firstNumber = double.Parse(input);

			Console.Write("Введите число №2:");
			input = Console.ReadLine();
			secondNumber = double.Parse(input);

			double multiplication = firstNumber * secondNumber;
			double sum = firstNumber + secondNumber;
			double subtraction = firstNumber - secondNumber;

			Console.WriteLine(firstNumber.ToString("0.#") + "*" + secondNumber.ToString("0.#") + '=' + multiplication.ToString("0.###"));
			Console.WriteLine("{0:0.###} + {1:0.###} = {2:0.###}", firstNumber, secondNumber, sum);
			Console.WriteLine($"{firstNumber:0.###} - {secondNumber:0.###} = {subtraction:0.###} ");*/

			/*string test = "test string";
			Console.WriteLine(test.Contains(" ")); //true
			Console.WriteLine(test.StartsWith("te")); //true
			Console.WriteLine(test.EndsWith("d")); //false
			
			Console.WriteLine(test.IndexOf("s")); //2
			Console.WriteLine(test.LastIndexOf("s")); //5*/

			/*int letterNumber = 0;

			Console.WriteLine("Введите слово: ");
			string word = Console.ReadLine();

			Console.WriteLine("Введите букву: ");
			string letter = Console.ReadLine();

			var indexOfLetter = 0;
			string resultReplace = word.Replace(letter, "*");

			do
			{
				indexOfLetter = word.IndexOf(letter, indexOfLetter);

				if (indexOfLetter < 0)
					break;

				Console.WriteLine(indexOfLetter);
				indexOfLetter++;

				/*if (letter == word[i].ToString())
				{
					letterNumber++;
				}
			} while (true);

			Console.WriteLine(resultReplace);
			Console.WriteLine($"Количество букв \"{letter}\" в слове \"{word}\" составляет: {letterNumber}");*/

			/*Console.WriteLine("Enter your email: ");
			string email = Console.ReadLine();
			Console.WriteLine(email.ToLower().Trim());

			Console.WriteLine("Enter cardholder name: ");
			string name = Console.ReadLine();
			Console.WriteLine(name.ToUpper());*/

			/*string text = " lorem ipsum dolor sit amet ";



			/*string[] textArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			
			//foreach (string word in textArray)
			
			textArray[1] = textArray[1].ToUpper();

			string result = string.Join(" ", textArray);

			Console.WriteLine(result);*/


			/*string[] words = "this is my great example".Split(' ');

			StringBuilder exampleBuilder = new StringBuilder(100);
			foreach (var word in words)
			{
				exampleBuilder
					.Append(word)
					.Append(", ");
			}

			exampleBuilder.Remove(exampleBuilder.Length - 2, 2);
			Console.WriteLine(exampleBuilder.ToString());
			//exampleBuilder.Replace(',', '*');*/

			string text = " lorem ipsum dolor sit amet ";
			var resultBuilder = new StringBuilder(text.Length);

			for(int i = 0; i < text.Length; i++)
			{
				if (text[i] != ' ')
					resultBuilder.Append(text[i]);
				if (resultBuilder[resultBuilder.Length - 1] == ' ') ;

			}
		}
	}
}
