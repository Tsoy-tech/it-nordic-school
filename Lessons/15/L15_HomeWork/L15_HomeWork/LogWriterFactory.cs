using System;
using System.Collections.Generic;
using System.Text;

namespace L15_HomeWork
{
	public class LogWriterFactory
	{
		public LogWriterFactory() { };

		public ILogWriter GetLogWriter<T>(object parameters, string fileName, List<ILogWriter> logWriters) where T:ILogWriter
		{
			switch (parameters)
			{
				case 1:
					return new ConsoleLogWriter();
					break;
				case 2:
					return new FileLogWriter(fileName);
					break;
				case 3:
					return new MultipleLogWriter(logWriters);
					break;
				default:
					return new MultipleLogWriter(logWriters);
					break;
			}
		}
	}
}
