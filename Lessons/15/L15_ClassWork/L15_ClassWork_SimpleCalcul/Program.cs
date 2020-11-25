using System;

namespace L15_ClassWork_SimpleCalcul
{
	class Program
	{
		public delegate int PerformCalculation(int a, int b);
		static void Main(string[] args)
		{
			var calc = new SimpleCalculator();
			int result;
			PerformCalculation calcReference;

			/*calcReference = calc.Sum;
			result = calcReference(10, 15);
			Console.WriteLine(result);*/

			//DoCalculation(10, 15, calc.Sum);
			//DoCalculation(10, 15, calc.Multiply);

			PerformCalculation first = calc.Sum;
			PerformCalculation second = calc.Multiply;
			second = (PerformCalculation)Delegate.Combine(first, second);

			result = second(10, 15);
			Console.WriteLine(result);

			result = second.Invoke(20, 20);
			Console.WriteLine(result);

			PerformCalculation emptyCalculation = null; //NullReferenceException
			result = emptyCalculation.Invoke(40, 40);
			Console.WriteLine(result);
		}

		public static void DoCalculation(int a, int b, PerformCalculation calculate)
		{
			int result = calculate(a, b);
			Console.WriteLine(result);
		}
	}
}
