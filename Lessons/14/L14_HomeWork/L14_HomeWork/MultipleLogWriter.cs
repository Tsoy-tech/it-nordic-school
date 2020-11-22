using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace L14_HomeWork
{
	public class MultipleLogWriter : AbstractLogWriter, ILogWriter
	{
		//Fields
		private static MultipleLogWriter _multiLogInstance;
		public List<ILogWriter> _logWriter;

		//Properties
		public List<ILogWriter> LogWriter
		{
			get 
			{
				return _logWriter; 
			}
			set 
			{ 
				_logWriter = value;
			}
		}

		//Constructor
		private MultipleLogWriter() { }

		//Methods
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

		//Singleton
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
