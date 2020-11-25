using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace L15_ClassWork_SimpleCalcul
{
	public class SimpleCalculator
	{
		public int Sum(int x, int y)
		{
			Debug.WriteLine($"{nameof(Sum)} called");
			return x + y;
		}
		public int Multiply(int x, int y)
		{
			Debug.WriteLine($"{nameof(Multiply)} called");
			return x * y;
		}
	}
}
