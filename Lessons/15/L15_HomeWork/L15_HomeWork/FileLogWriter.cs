using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace L15_HomeWork
{
	public class FileLogWriter : BaseLogWriter, IDisposable
	{
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

		public FileLogWriter(string fileName)
		{
			FileName = fileName;
			_logFileWriter = new StreamWriter(File.Open(_fileName, FileMode.Append, FileAccess.Write));
		}

		protected override void WriteLog(string line)
		{
			_logFileWriter.WriteLine(line);
			_logFileWriter.Flush();
		}
		public void Dispose()
		{
			if(_logFileWriter != null)
				_logFileWriter.Dispose();
		}

	}
}
