using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace L14_HomeWork
{
	public class ConsoleLogWriter : BaseLogWriter
	{
		private static ConsoleLogWriter _consoleLogInstance;

		private ConsoleLogWriter() {}

		protected override void WriteLog(string line)
		{
			Console.WriteLine(line);
		}

		public static ConsoleLogWriter GetInstance()
		{
			if (_consoleLogInstance == null)
			{
				_consoleLogInstance = new ConsoleLogWriter();
			}

			return _consoleLogInstance;
		}
	}
}
