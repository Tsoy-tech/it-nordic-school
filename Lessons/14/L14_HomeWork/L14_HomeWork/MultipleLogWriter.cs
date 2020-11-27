using System;
using System.Collections.Generic;

namespace L14_HomeWork
{
	public class MultipleLogWriter : IDisposable, ILogWriter
	{
		private static MultipleLogWriter _multiLogInstance;
		private List<ILogWriter> _logWriters;

		public List<ILogWriter> LogWriters
		{
			get
			{
				return _logWriters;
			}
			set
			{
				_logWriters = value;
			}
		}

		private  MultipleLogWriter() { }

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

		public static MultipleLogWriter GetInstance()
		{
			if (_multiLogInstance == null)
			{
				_multiLogInstance = new MultipleLogWriter();
			}

			return _multiLogInstance;
		}
	}
}
