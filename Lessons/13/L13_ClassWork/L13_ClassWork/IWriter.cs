using System;
using System.Collections.Generic;
using System.Text;

namespace L13_ClassWork
{
	public interface IWriter : IDisposable
	{
		void Write(string content);
	}
}
