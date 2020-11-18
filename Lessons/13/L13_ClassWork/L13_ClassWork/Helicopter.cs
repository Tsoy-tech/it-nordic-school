using System;
using System.Collections.Generic;
using System.Text;

namespace L13_ClassWork
{
	class Helicopter : AirObject
	{
		protected byte BladesCount { get; private set; }

		public Helicopter(int maxHeight, byte bladesCount) : base(maxHeight, 0)
		{
			BladesCount = bladesCount;
			Console.WriteLine("It's a helicopter, welcome abroad!\n");
		}

		public override void WriteAllProperties()
		{
			base.WriteAllProperties();
			Console.WriteLine($"{nameof(BladesCount)}:{BladesCount}\n");
		}
	}
}
