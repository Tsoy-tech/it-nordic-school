using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace L14_HomeWork
{
	public class FileLogWriter : AbstractLogWriter, ILogWriter, IDisposable
	{
		//Fields
		private static FileLogWriter _fileLogInstance;
		private FileStream _fileStream;
		private Encoding _encoding;
		private string _fileName;

		//Properties
		public string FileName
		{
			get 
			{
				return _fileName;
			}
			set
			{
				const string placement = @"B:\Git\it-nordic-school\Lessons\14\L14_HomeWork\Logs\";
				_fileName = placement + value + ".txt";
			}
		}

		//Constructors
		private FileLogWriter() { }

		//Methods
		public override void LogError(string message)
		{
			_encoding = Encoding.ASCII;
			_fileStream = File.Open(_fileName, FileMode.Append, FileAccess.Write);
			byte[] log = _encoding.GetBytes(LogOutputFormat() + message + '\n');

			_fileStream.Write(log);
		}
		public override void LogInfo(string message)
		{
			_encoding = Encoding.ASCII;
			_fileStream = File.Open(_fileName, FileMode.Append, FileAccess.Write);
			byte[] log = _encoding.GetBytes(LogOutputFormat() + message + '\n');

			_fileStream.Write(log);
		}
		public override void LogWarning(string message)
		{
			_encoding = Encoding.ASCII;
			_fileStream = File.Open(_fileName, FileMode.Append, FileAccess.Write);
			byte[] log = _encoding.GetBytes(LogOutputFormat() + message + '\n');

			_fileStream.Write(log);
		}
		public void Dispose()
		{
			_fileStream.Dispose();
		}

		//Singleton
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
