using System;
using System.Net;
using System.Security.Cryptography;

namespace L05_ClassWork
{
	class Program
	{
		/*enum DayOfWeek
		{
			Monday,
			Tuesday,
			Wednesday
		}

		[Flags]
		enum Months
		{
			None = 0,
			January = 0x1,
			February = 0x2,
			March = 0x4,
			April = 0x8,
			May = 0x10, //16
			June = 0x20, //32
			July = 0x40 //64
		}

		[Flags]
		enum Colors
		{
			None = 0, //
			Black = 1,
			Blue = 2,
			Cyan = 4,
			Grey = 8, //1 << 3 или 0x1 << 3
			Green = 16, //0x10
			Magenta = 32, //0x20
			Red = 64, //0x40
			White = 128, //0x80
			Yellow = 256 //0x100
		}*/
		static void Main(string[] args)
		{
			/*DayOfWeek firstWorkingDay = DayOfWeek.Monday;
			Months springMonths;

			springMonths = 0;
			springMonths |= Months.March; //OR
			springMonths |= Months.April;
			springMonths |= Months.May;

			Console.WriteLine($"Spring months are: {springMonths}");

			bool januaryIsSpringMonth = (springMonths & Months.January) > 0; // AND
			bool marchIsSpringMonth = (springMonths & Months.March) > 0; //

			Console.WriteLine(marchIsSpringMonth); //true
			//______________________________________________

			Months allMonth = (Months)(0x80 - 1);

			Months notSpringMonths = allMonth ^ springMonths;
			Console.WriteLine($"Not spring months are: {notSpringMonths}");

				//00011100
				//XOR
				//11111111
				//=
				//11100011
			*/

			/*Colors favouriteColors = 0;
			Colors notFavouriteColors = 0;
			//Colors allColors = (Colors)(512 - 1);
			Colors allColors = 0;

			foreach (Colors color in Enum.GetValues(typeof(Colors)))
			{
				allColors |= color;
			}

			Console.WriteLine($"Доступные цвета: {allColors}");
			Console.WriteLine("===================================================");

			for (int i = 0; i < 4; i++)
			{
				Console.Write($"Выберите {i + 1} цвет: ");
				favouriteColors |= Enum.Parse<Colors>(Console.ReadLine());
			}
			notFavouriteColors = allColors ^ favouriteColors;

			Console.WriteLine("===================================================");
			Console.WriteLine($"Любимые цвета: {favouriteColors}");
			Console.WriteLine("---------------------------------------------------");
			Console.WriteLine($"Нелюбимые цвета: {notFavouriteColors}");*/

			/*int howLong;
			string input;
			const string notification = "Договор аренды оформлен на период длительностью";

			Console.Write("Введите длительность договора аренды в годах: ");
			input = Console.ReadLine();
			howLong = int.Parse(input);

			if( howLong <= 30 && howLong > 0)
			{
				if( howLong == 1 || howLong == 21)
				{
					Console.WriteLine($"{notification} {howLong} год");
				}
				else if((howLong >= 2 && howLong <= 4) || (howLong >= 22 && howLong <= 24))
				{
					Console.WriteLine($"{notification} {howLong} года");
				}
				else
				{
					Console.WriteLine($"{notification} {howLong} лет");
				}
			}
			else
			{
				Console.WriteLine("Вы ввели неверное значение!");
			}*/


			/*int a = 10;
			int b = 12;
			string result;

			result = a > b
				? "A > B"
				: "A <= B";

			Console.WriteLine(result);

			//////////////////////////////////////////////
			
			Console.WriteLine( a > b 
				? "A > B" 
				: "A <= B");*/

			////////////////////////////////

			/*int number;
			string input;

			Console.Write("Введите число от 1 до 100: ");
			input = Console.ReadLine();
			number = int.Parse(input);

			Console.WriteLine(number > 50 
				? "Введенное число меньше 50" 
				: "Введенное число больше или равно 50");*/

			////////////////////////////////////////////////

			/*int howLong;
			string input;
			const string notification = "Договор аренды оформлен на период длительностью";

			Console.Write("Введите длительность договора аренды в годах: ");
			input = Console.ReadLine();
			howLong = int.Parse(input);

			if (howLong > 30 || howLong < 0)
			{
				Console.WriteLine("Вы ввели неверное значение!");
				return;
			}

			switch (howLong)
			{
				case 1:
				case 21:
					Console.WriteLine($"{notification} {howLong} год");
					break;
				case 2:
				case 3:
				case 4:
				case 22:
				case 23:
				case 24:
					Console.WriteLine($"{notification} {howLong} года");
					break;
				default:
					Console.WriteLine($"{notification} {howLong} лет");
					break;*/

			///////////////////////////////////////////////////////////////
			string str = Console.ReadLine();
			int a;
			try
			{
				a = int.Parse(str);
				Console.WriteLine($"{a * a}");
			}
			catch (Exception e)
			{
				Console.WriteLine("Вы ввели некорректное значение");
				Console.WriteLine($"{e.GetType()}: {e.Message}");
				throw; //
			}
		}
	}
}
