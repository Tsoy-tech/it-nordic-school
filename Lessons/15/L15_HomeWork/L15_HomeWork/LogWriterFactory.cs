using System;
using System.Collections.Generic;

namespace L15_HomeWork
{
	public static class LogWriterFactory
	{
		public static ILogWriter GetLogWriter<T>(object parameter = null) where T : ILogWriter
		{
			if (typeof(T).Equals(typeof(FileLogWriter)) && parameter != null &&
				parameter.GetType().Equals(typeof(string)))
			{
				string result = (string)parameter;
				return new FileLogWriter(result);
			}

			if (typeof(T).Equals(typeof(MultipleLogWriter)) && parameter != null &&
				parameter.GetType().Equals(typeof(List<ILogWriter>)))
			{
				List<ILogWriter> result = (List<ILogWriter>)parameter;
				return new MultipleLogWriter(result);
			}

			if (typeof(T).Equals(typeof(ConsoleLogWriter)))
			{
				return new ConsoleLogWriter();
			}

			//Exceptions
			var e = new Exception($"Ошибка: Неверный тип данных!\n" +
				$"\"parameter\" не может быть null для \"FileLogWriter\" и \"MultipleLogWriter\", " +
				$"и должен быть \"System.String\" для \"FileLogWriter\" или \"List<ILogWriter>\" для \"MultipleLogWriter\"");
			Console.WriteLine(e.Message);
			throw e;
		}
	}
}
