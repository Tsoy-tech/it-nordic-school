using System;
using System.Collections.Generic;
using System.Text;

namespace L13_ClassWork
{
	public class ConsoleWriter : IWriter
	{
		public void Dispose()
		{
			Console.WriteLine("Освобождение ресурсов...");
		}

		public void Write(string content)
		{
			Console.Write(content);
		}
	}
}
