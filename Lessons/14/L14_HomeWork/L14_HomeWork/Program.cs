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
			using var fileLog = FileLogWriter.GetInstance();
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
