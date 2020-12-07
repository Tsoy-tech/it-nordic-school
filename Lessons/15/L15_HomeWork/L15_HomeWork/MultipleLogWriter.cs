using System;
using System.Collections.Generic;

namespace L15_HomeWork
{
	public class MultipleLogWriter : IDisposable, ILogWriter
	{
		private List<ILogWriter> LogWriters { get; set; }

		public MultipleLogWriter() { }
		public MultipleLogWriter(ILogWriter logWriter)
		{
			LogWriters = new List<ILogWriter>();
			LogWriters.Add(logWriter);
		}
		public MultipleLogWriter(List<ILogWriter> logWriters)
		{
			LogWriters = logWriters;
		}

		public void LogInfo(string message)
		{
			foreach (var writer in LogWriters)
			{
				if (writer is FileLogWriter)
				{
					(writer as FileLogWriter).LogInfo(message);
				}
				if (writer is ConsoleLogWriter)
				{
					(writer as ConsoleLogWriter).LogInfo(message);
				}
			}
		}
		public void LogWarning(string message)
		{
			foreach (var writer in LogWriters)
			{
				if (writer is FileLogWriter)
				{
					(writer as FileLogWriter).LogWarning(message);
				}
				if (writer is ConsoleLogWriter)
				{
					(writer as ConsoleLogWriter).LogWarning(message);
				}
			}
		}
		public void LogError(string message)
		{
			foreach (var writer in LogWriters)
			{
				if (writer is FileLogWriter)
				{
					(writer as FileLogWriter).LogError(message);
				}
				if(writer is ConsoleLogWriter)
				{ 
					(writer as ConsoleLogWriter).LogError(message);
				}
			}
		}
		public void Dispose()
		{
			foreach (object writer in LogWriters)
			{
				if (LogWriters is IDisposable)
				{
					(LogWriters as IDisposable).Dispose();
				}
			}
		}
	}
}
