using System;

namespace Calculator.Operation
{
    public class CircleOperation
    {
		public double Perimeter(double r)
		{
			double result = double.NaN;
			result = 2 * Math.PI * r;
			return result;
		}
		public double Square(double r)
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
