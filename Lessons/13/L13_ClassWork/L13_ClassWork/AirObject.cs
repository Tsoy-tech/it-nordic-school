using System;
using System.Collections.Generic;
using System.Text;

namespace L13_ClassWork
{
	public abstract class AirObject : IFlyer, IPropertiesWriter
	{
		public int MaxHeight { get; private set; }
		public int CurrentHeight { get; private set; }

		public AirObject(int maxHeight, int currentHeight)
		{
			MaxHeight = maxHeight;
			CurrentHeight = currentHeight;
		}

		public void TakeUpper(int delta)
		{
			if (delta <= 0)
				throw new ArgumentOutOfRangeException();

			if (CurrentHeight + delta > MaxHeight)
			{
				CurrentHeight = MaxHeight;
			}
			else
			{
				CurrentHeight = CurrentHeight + delta;
			}
		}
		public void TakeLower(int delta)
		{
			if (delta <= 0)
				throw new ArgumentOutOfRangeException(nameof(delta), "");

			if (CurrentHeight - delta > 0)
			{
				CurrentHeight = CurrentHeight - delta;
			}
			else if (CurrentHeight - delta == 0)
			{
				CurrentHeight = 0;
			}
			else if (CurrentHeight - delta < 0)
				throw new InvalidOperationException("Crash");
		}

		public virtual void WriteAllProperties()
		{
			Type objectType = typeof(AirObject);

			Console.WriteLine($"Properties of {base.ToString().Substring(objectType.Namespace.Length + 1)}\n" +
				$"{nameof(MaxHeight)}:{MaxHeight}\n" +
				$"{nameof(CurrentHeight)}:{CurrentHeight}");
		}
	}
}
