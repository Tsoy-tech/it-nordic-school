using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace L14_HomeWork
{
	public class FileLogWriter : BaseLogWriter, IDisposable
	{
		private static FileLogWriter _fileLogInstance;
		private StreamWriter _logFileWriter;
		private string _fileName;

		public string FileName 
		{
			get 
			{
				return _fileName;
			}
			set
			{
				_fileName = value + ".txt";
			}	
		}

		private FileLogWriter() { }

		protected override void WriteLog(string line)
		{
			_logFileWriter = new StreamWriter(File.Open(_fileName, FileMode.Append, FileAccess.Write));
			_logFileWriter.WriteLine(line);
			_logFileWriter.Flush();
			_logFileWriter.Dispose();
		}

		public void Dispose()
		{
			if(_logFileWriter != null)
				_logFileWriter.Dispose();
		}

		public static FileLogWriter GetInstance()
		{
			if (_fileLogInstance == null)
			{
				_fileLogInstance = new FileLogWriter();
			}

			return _fileLogInstance;
		}
	}
}
