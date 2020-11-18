using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace L13_ClassWork
{
	public class SimpleNumbersValidator 
	{
		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public SimpleNumbersValidator() { }

		public bool Check(IEnumerable<int> numbers)
		{
			foreach(int n in numbers)
			{
				for(int i = 2; i < n - 1; i++)
				{
					if (n % i == 0)
						return false;
				}
			}

			return true;
		}
	}
}
