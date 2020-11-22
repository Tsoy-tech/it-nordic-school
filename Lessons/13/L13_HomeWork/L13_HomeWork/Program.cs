using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace L13_HomeWork
{
	class Program
	{
		static void Main()
		{
			ConsoleLogWriter consoleLog = new ConsoleLogWriter(DateTimeOffset.Parse("2020-11-20 15:00:00"));
			using FileLogWriter fileLog = new FileLogWriter("Logs", Encoding.ASCII, DateTimeOffset.Parse("2020-12-31 23:59:59"));

			List<ILogWriter> listOfLogWriters = new List<ILogWriter> 
			{ 
				consoleLog, 
				fileLog
			};

			MultipleLogWriter multiple = new MultipleLogWriter(listOfLogWriters);
			multiple.WriteLog(MultipleLogWriter.MessageType.Info, "There is some information from Multiple Log Writer!");
		}
	}
}
