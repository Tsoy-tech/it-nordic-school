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

		private string _format = "{0:yyyy-MM-dd HH:mm:ss %K}\t{1}\t{2}";

		protected BaseLogWriter() { }

		public virtual void LogInfo(string message)
		{
			WriteLog(GetLog(MessageType.Info, message));
		}
		public virtual void LogWarning(string message)
		{
			WriteLog(GetLog(MessageType.Warning, message));
		}
		public virtual void LogError(string message)
		{
			WriteLog(GetLog(MessageType.Error, message));
		}
		protected abstract void WriteLog(string line);
		protected string GetLog(MessageType typeOfLog, string message)
		{
			return string.Format(_format, DateTimeOffset.Now, typeOfLog, message);
		}
	}
}
