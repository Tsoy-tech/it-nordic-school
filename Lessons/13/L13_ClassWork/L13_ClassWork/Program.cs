using System;

namespace L13_ClassWork
{
	class Program
	{
		static void Main(string[] args)
		{
			/*Plane superPlane = new Plane(1000, 5);
			Helicopter superHelicopter = new Helicopter(500, 6);

			DoFlyerTest(superPlane);
			DoFlyerTest(superHelicopter);

			/*superPlane.TakeUpper(5000);
			superHelicopter.TakeUpper(100);

			superPlane.WriteAllProperties();
			superHelicopter.WriteAllProperties();*/

			/*using ConsoleWriter writer = new ConsoleWriter();
			writer.Write("Hello world!\n");*/
			//writer.Dispose();

			SimpleNumbersValidator v = new SimpleNumbersValidator();

			bool ok = v.Check(new[] { 1, 3, 5, 7, 9, 11, 13});

			Console.WriteLine(ok);
		}

		public static void DoFlyerTest(IFlyer flyer)
		{
			flyer.TakeUpper(100);
			flyer.TakeLower(50);
			flyer.TakeLower(50);
		}
	}
}
