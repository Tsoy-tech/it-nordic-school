using System;
using System.Collections.Generic;
using System.Text;

namespace L13_ClassWork
{
	class Plane: AirObject
	{
		protected byte EnginesCount { get; private set; }

		public Plane(int maxHeight, byte enginesCount) : base(maxHeight, 0)
		{
			EnginesCount = enginesCount;

			Console.WriteLine("It's a plane, welcome abroad!\n");
		}

		public override void WriteAllProperties()
		{
			base.WriteAllProperties();
			Console.WriteLine($"{nameof(EnginesCount)}:{EnginesCount}\n");
		}
	}
}
