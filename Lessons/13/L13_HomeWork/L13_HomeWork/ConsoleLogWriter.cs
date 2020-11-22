using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace L13_HomeWork
{
	public class ConsoleLogWriter : AbstractLogWriter, ILogWriter
	{
		public ConsoleLogWriter() {}
		public ConsoleLogWriter(DateTimeOffset dateTime) : base(dateTime) { }

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
	}
}
