using System;
using System.Collections.Generic;
using System.Text;

namespace L13_HomeWork
{
	public abstract class AbstractLogWriter : ILogWriter
	{
		public enum MessageType
		{
			Info,
			Warning,
			Error
		}

		protected DateTimeOffset _dateOfLog;
		protected MessageType _type;

		public AbstractLogWriter() 
		{
			_dateOfLog = DateTimeOffset.Now;
		}

		public AbstractLogWriter(DateTimeOffset dateTime) 
		{
			_dateOfLog = dateTime;
		}

		public virtual void LogInfo(string message) 
		{
			_type = MessageType.Info;
		}
		public virtual void LogWarning(string message) 
		{
			_type = MessageType.Warning;
		}
		public virtual void LogError(string message) 
		{
			_type = MessageType.Error;
		}

		public virtual string LogOutputFormat()
		{
			return $"{_dateOfLog:yyyy-MM-dd HH:mm:ss % K}	{_type}	";
		}
	}
}
