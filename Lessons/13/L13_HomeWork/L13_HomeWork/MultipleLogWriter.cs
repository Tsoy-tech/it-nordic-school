using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace L13_HomeWork
{
	public class MultipleLogWriter : AbstractLogWriter, ILogWriter
	{
		public List<ILogWriter> _logWriter;

		public MultipleLogWriter(ILogWriter logWriter)
		{
			_logWriter = new List<ILogWriter>();
			_logWriter.Add(logWriter);
		}
		public MultipleLogWriter(List<ILogWriter> logWriter)
		{
			_logWriter = logWriter;
		}

		public void WriteLog(MessageType messageType, string message)
		{
			foreach (object writer in _logWriter)
			{
				if (writer is FileLogWriter)
				{
					switch (messageType)
					{
						case MessageType.Error:
							(writer as FileLogWriter).LogError(message);
							break;
						case MessageType.Info:
							(writer as FileLogWriter).LogInfo(message);
							break;
						case MessageType.Warning:
							(writer as FileLogWriter).LogInfo(message);
							break;
					}
				}
				if(writer is ConsoleLogWriter)
				{
					switch (messageType)
					{
						case MessageType.Error:
							(writer as ConsoleLogWriter).LogError(message);
							break;
						case MessageType.Info:
							(writer as ConsoleLogWriter).LogInfo(message);
							break;
						case MessageType.Warning:
							(writer as ConsoleLogWriter).LogInfo(message);
							break;
					}
				}
			}
		}

		public override void LogError(string message) { }
		public override void LogInfo(string message) { }
		public override void LogWarning(string message) { }
	}
}
