using System;
using System.Collections.Generic;
using System.Text;

namespace L13_HomeWork
{
	public abstract class BaseLogWriter : ILogWriter
	{
		public enum MessageType
		{
			Info,
			Warning,
			Error
		}

		protected DateTimeOffset _dateOfLog;
		protected MessageType _typeOfLog;
		private string _format = "{0:yyyy-MM-dd HH:mm:ss %K}\t{1}\t{2}";

		protected BaseLogWriter() 
		{
			_dateOfLog = DateTimeOffset.Now;
		}
		protected BaseLogWriter(DateTimeOffset dateTime) 
		{
			_dateOfLog = dateTime;
		}

		public virtual void LogInfo(string message) 
		{
			_typeOfLog = MessageType.Info;
			WriteLog(GetLog(message));
		}
		public virtual void LogWarning(string message) 
		{
			_typeOfLog = MessageType.Warning;
			WriteLog(GetLog(message));
		}
		public virtual void LogError(string message) 
		{
			_typeOfLog = MessageType.Error;
			WriteLog(GetLog(message));
		}
		protected abstract void WriteLog(string line);
		protected string GetLog(string message)
		{
			return string.Format(_format, _dateOfLog, _typeOfLog, message);
		}
	}
}
