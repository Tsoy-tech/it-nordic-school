using System;

namespace L16_indep
{
    class Program
    {
		static void Main(string[] args)
		{
			double radius = 1.5;
			var circle = new Circle(radius);

			Write(radius, circle);
		}

		//public static Func<double, double> Perimeter = r => 2 * Math.PI * r;
		//public static Func<double, double> Square = r => Math.PI * Math.Pow(r, 2);

		/*public static double Perimeter(double r)
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
		}*/

		public static void Write(double radius, Circle circle)
		{
			string result = $"For the circle with {radius}\n" +
				$"Perimeter is {circle.Calculate(radius => 2 * Math.PI * radius)}\n" +
				$"Square is {circle.Calculate(radius => Math.PI * Math.Pow(radius, 2))}";
			Console.WriteLine(result);
		}
	}
}
