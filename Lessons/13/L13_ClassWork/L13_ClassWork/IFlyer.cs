using System;
using System.Collections.Generic;
using System.Text;

namespace L13_ClassWork
{
	public interface IFlyer
	{
		int MaxHeight { get; } //"private set" отсутсвует
		int CurrentHeight { get; }

		void TakeUpper(int delta);
		void TakeLower(int delta);
	}
}
