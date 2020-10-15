using System;
using System.Globalization;

namespace L05_HomeWork
{
	class Program
	{
		enum Figure
		{
			None,
			Circle,
			EquilateralTriangle,
			Rectangle
		}
		static void Main(string[] args)
		{
			int selectedFigure;
			string delimiter;
			string delimiterString;
			string inpute;
			string figureString;
			string figurePart;
			string parameterPart;
			double firstParameter;
			double secondParameter;
			double planeArea;
			double perimeter;
			Figure typeFigure;
			
			selectedFigure = 0;
			planeArea = double.NaN;
			perimeter = double.NaN;
			firstParameter = double.NaN;
			secondParameter = double.NaN;
			parameterPart = string.Empty;
			figurePart = string.Empty;
			figureString = string.Empty;
			typeFigure = Figure.None;
			delimiter = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			delimiterString = $"Примечание: в качестве десятичного разделителя используйте \'{delimiter}\'";

			Console.Write("Введите тип фигуры(1 - круг, 2 - равносторонний треугольник, 3 - прямоугольник): ");

			try
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				inpute = Console.ReadLine();
				Console.ResetColor();
				typeFigure = (Figure)int.Parse(inpute);
				selectedFigure = int.Parse(inpute);
			}
			catch (FormatException)
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Ошибка! Введено нечисловое значение " +
					"или число нецелое!");
				Console.ResetColor();
			}

			if (selectedFigure > 3 || selectedFigure < 1)
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Введите целое число в диапазоне от 1 до 3");
				Console.ResetColor();
				return;
			}

			switch (typeFigure)
			{
				case (Figure.Circle):
					parameterPart = " длину";
					figurePart = " диаметра";
					figureString = " круга: ";
					break;
				case (Figure.EquilateralTriangle):
					parameterPart = " длину";
					figurePart = " стороны";
					figureString = " треугольника: ";
					break;
				case (Figure.Rectangle):
					parameterPart = " длину";
					figureString = " прямоугольника: ";
					break;
			}

			Console.WriteLine($"Введите{parameterPart}{figurePart}{figureString}");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine(delimiterString);
			Console.ResetColor();

			try
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.SetCursorPosition("Введите".Length + parameterPart.Length + 
					figurePart.Length + figureString.Length, 1);
				inpute = Console.ReadLine();
				firstParameter = double.Parse(inpute);
				Console.ResetColor();
			}
			catch (FormatException)
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Ошибка! Введено нечисловое значение " +
					"или использован неверный разделитель!");
				Console.ResetColor();
				return;
			}

			if (typeFigure == Figure.Rectangle)
			{
				parameterPart = " ширину";
				Console.SetCursorPosition(0, 3);
				Console.WriteLine($"Введите{parameterPart}{figureString}");
				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine(delimiterString);
				
				try
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.SetCursorPosition("Введите".Length + parameterPart.Length + 
						figurePart.Length + figureString.Length, 3);
					inpute = Console.ReadLine();
					secondParameter = double.Parse(inpute);
					Console.ResetColor();
				}
				catch (FormatException)
				{
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.WriteLine("Ошибка! Введено нечисловое значение " +
						"или использован неверный разделитель!");
					Console.ResetColor();
					return;
				}
			}

			if (firstParameter <= 0 || secondParameter <= 0)
			{
				Console.SetCursorPosition(0, 5);
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Введено отрицательное или равное нулю значение!");
				Console.ResetColor();
				return;
			}

			switch (typeFigure)
			{
				case (Figure.Circle):
					Console.SetCursorPosition(0, 3);
					planeArea = Math.Round(Math.Pow(firstParameter, 2) * Math.PI, 2);
					perimeter = Math.Round(firstParameter * Math.PI, 2);
					break;
				case (Figure.EquilateralTriangle):
					Console.SetCursorPosition(0, 3);
					planeArea = Math.Round(Math.Pow(firstParameter, 2) * Math.Sqrt(3) / 4, 2);
					perimeter = Math.Round(firstParameter * 3, 2);
					break;
				case (Figure.Rectangle):
					Console.SetCursorPosition(0, 5);
					planeArea = Math.Round(firstParameter * secondParameter, 2);
					perimeter = Math.Round((firstParameter + secondParameter) * 2, 2);
					break;
			}

			Console.Write($"Площадь {figureString}");
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine($"{planeArea}");
			Console.ResetColor();
			Console.Write($"Периметр {figureString}");
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine($"{perimeter}");
			Console.ResetColor();
		}
	}
}
