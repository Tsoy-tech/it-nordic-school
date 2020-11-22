using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace L13_HomeWork
{
	public class FileLogWriter : AbstractLogWriter, ILogWriter, IDisposable
	{
		//Fields
		private readonly FileStream _fileStream;
		private readonly Encoding _encoding;
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
				const string placement = @"B:\Git\it-nordic-school\Lessons\13\L13_HomeWork\Logs\";
				_fileName = placement + value + ".txt";
			}
		}

		//Constructors
		public FileLogWriter(string fileName)
		{
			FileName = fileName;
			_encoding = Encoding.UTF8;
			_fileStream = File.Open(_fileName, FileMode.Append, FileAccess.Write);
		}
		public FileLogWriter(string fileName, Encoding encoding)
		{
			FileName = fileName;
			_encoding = encoding;
			_fileStream = File.Open(_fileName, FileMode.Append, FileAccess.Write);
		}
		public FileLogWriter(string fileName, DateTimeOffset dateTime) : base(dateTime)
		{
			FileName = fileName;
			_encoding = Encoding.UTF8;
			_fileStream = File.Open(_fileName, FileMode.Append, FileAccess.Write);
		}
		public FileLogWriter(string fileName, Encoding encoding, DateTimeOffset dateTime) : base(dateTime)
		{
			FileName = fileName;
			_encoding = encoding;
			_fileStream = File.Open(_fileName, FileMode.Append, FileAccess.Write);
		}

		//Methods
		public override void LogError(string message)
		{
			byte[] log = _encoding.GetBytes(LogOutputFormat() + message + '\n');

			_fileStream.Write(log);
		}
		public override void LogInfo(string message)
		{
			byte[] log = _encoding.GetBytes(LogOutputFormat() + message + '\n');

			_fileStream.Write(log);
		}
		public override void LogWarning(string message)
		{
			byte[] log = _encoding.GetBytes(LogOutputFormat() + message + '\n');

			_fileStream.Write(log);
		}

		public void Dispose()
		{
			_fileStream.Dispose();
		}

	}
}
