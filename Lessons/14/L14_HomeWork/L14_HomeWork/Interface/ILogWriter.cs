using System;
using System.Collections.Generic;
using System.Text;

namespace L14_HomeWork
{
	public interface ILogWriter
	{			
		public void LogInfo(string message);
		public void LogWarning(string message);
		public void LogError(string message);
	}
}
