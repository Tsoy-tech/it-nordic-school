using System;

namespace L15_indWork
{
	class Program
	{
		static void Main(string[] args)
		{
			double radius = 1.5;
			var c1 = new Circle(radius);

			Write(radius, c1);
		}

		public static double Perimeter(double r)
		{
			double result = double.NaN;
			result = 2 * Math.PI * r;
			return result;
		}
		public static double Square(double r)
		{
			double result = double.NaN;
			result = Math.PI * Math.Pow(r, 2);
			return result;
		}
		public static void Write(double radius, Circle circle)
		{
			string result = $"For the cicle with {radius}\n" +
				$"{nameof(Perimeter)} is {circle.Calculate(Perimeter)}\n" +
				$"{nameof(Square)} is {circle.Calculate(Square)}";
			Console.WriteLine(result);
		}
	}
}
