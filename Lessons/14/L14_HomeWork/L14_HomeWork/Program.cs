using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace L14_HomeWork
{
	class Program
	{
		static void Main()
		{
			var consoleLog = ConsoleLogWriter.GetInstance();
			consoleLog.DateOfLog = DateTimeOffset.Parse("2020-11-20 15:00:00");

			using var fileLog = FileLogWriter.GetInstance();
			fileLog.DateOfLog = DateTimeOffset.Parse("2020-12-31 23:59:59");
			fileLog.FileName = "Logs";

			List<ILogWriter> listOfLogWriters = new List<ILogWriter> 
			{ 
				consoleLog, 
				fileLog
			};

			var multiple = MultipleLogWriter.GetInstance();
			multiple.LogWriters = listOfLogWriters;
			multiple.LogInfo("There is some information from Multiple Log Writer!");
			multiple.LogWarning("Warning!!!");
			multiple.LogError("Error!!!");
		}
	}
}
