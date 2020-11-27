using System;
using System.Collections.Generic;
using System.Text;

namespace L15_HomeWork
{
	public class LogWriterFactory
	{
		public ILogWriter GetLogWriter<T>(object parameters) where T:ILogWriter
		{
			ILogWriter writer;


			return writer;
		}
	}
}
