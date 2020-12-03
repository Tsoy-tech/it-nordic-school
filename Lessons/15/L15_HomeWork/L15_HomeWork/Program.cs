using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace L15_HomeWork
{
	class Program
	{
		static void Main()
		{
			var factory = LogWriterFactory.GetInstance();

			var fileLog = factory.GetLogWriter<FileLogWriter>("Logs");
			var consoleLog = factory.GetLogWriter<ConsoleLogWriter>();

			List<ILogWriter> listOfLogWriters = new List<ILogWriter>
			{
				fileLog,
				consoleLog
			};

			var multiple = factory.GetLogWriter<MultipleLogWriter>(listOfLogWriters);

			multiple.LogInfo("There is some information from Multiple Log Writer!");
			multiple.LogError("Error!!!");
			multiple.LogWarning("Warning!!!");
		}
	}
}
