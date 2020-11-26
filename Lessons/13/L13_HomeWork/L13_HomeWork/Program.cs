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
			var consoleLog = new ConsoleLogWriter();
			using var fileLog = new FileLogWriter("Logs");

			List<ILogWriter> listOfLogWriters = new List<ILogWriter> 
			{ 
				consoleLog, 
				fileLog
			};

			MultipleLogWriter multiple = new MultipleLogWriter(listOfLogWriters);
			multiple.LogInfo("There is some information from Multiple Log Writer!");
			multiple.LogError("Error!!!");
			multiple.LogWarning("Warning!!!");
			
		}
	}
}
