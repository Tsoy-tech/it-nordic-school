using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace L13_HomeWork
{
	public class ConsoleLogWriter : BaseLogWriter
	{
		public ConsoleLogWriter() {}

		protected override void WriteLog(string line)
		{
			Console.WriteLine(line);
		}
	}
}
