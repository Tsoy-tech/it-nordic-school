using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace L14_HomeWork
{
	public class ConsoleLogWriter : AbstractLogWriter, ILogWriter
	{
		//Fields
		private static ConsoleLogWriter _consoleLogInstance;

		//Constructor
		private ConsoleLogWriter() {}

		//Methods
		public override void LogError(string message)
		{
			Console.WriteLine(LogOutputFormat() + message);
		}
		public override void LogInfo(string message)
		{
			Console.WriteLine(LogOutputFormat() + message);
		}
		public override void LogWarning(string message)
		{
			Console.WriteLine(LogOutputFormat() + message);
		}

		//Singleton
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
