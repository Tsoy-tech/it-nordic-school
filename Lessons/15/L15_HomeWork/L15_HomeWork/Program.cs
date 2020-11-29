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
			var fileLog = LogWriterFactory.GetLogWriter<FileLogWriter>("Logs");
			var consoleLog = LogWriterFactory.GetLogWriter<ConsoleLogWriter>();

			List<ILogWriter> listOfLogWriters = new List<ILogWriter>
			{
				fileLog,
				consoleLog
			};

			var multiple = LogWriterFactory.GetLogWriter<MultipleLogWriter>(listOfLogWriters);
			multiple.LogInfo("There is some information from Multiple Log Writer!");
			multiple.LogError("Error!!!");
			multiple.LogWarning("Warning!!!");
		}
	}
}
