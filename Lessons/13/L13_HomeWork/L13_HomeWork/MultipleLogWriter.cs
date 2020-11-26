using System;
using System.Collections.Generic;

namespace L13_HomeWork
{
	public class MultipleLogWriter : IDisposable, ILogWriter
	{
		private List<ILogWriter> _logWriters;

		public MultipleLogWriter(ILogWriter logWriter)
		{
			_logWriters = new List<ILogWriter>();
			_logWriters.Add(logWriter);
		}
		public MultipleLogWriter(List<ILogWriter> logWriters)
		{
			_logWriters = logWriters;
		}

		public void LogInfo(string message)
		{
			foreach (var writer in _logWriters)
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
			foreach (var writer in _logWriters)
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
			foreach (var writer in _logWriters)
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
			foreach (object writer in _logWriters)
			{
				if (_logWriters is IDisposable)
				{
					(_logWriters as IDisposable).Dispose();
				}
			}
		}
	}
}
