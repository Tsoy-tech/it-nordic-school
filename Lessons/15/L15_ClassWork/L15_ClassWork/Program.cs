using System;

namespace L15_ClassWork
{
	class Program
	{
		static void Main(string[] args)
		{
			var acc1 = new Account<int>(1, "Vasiliy");
			var acc2 = new Account<string>("ID2946789", "Aleksei");
			var acc3 = new Account<Guid>(Guid.NewGuid(), "John");

			acc1.WriteProperties();
			acc2.WriteProperties();
			acc3.WriteProperties();
		}
	}
}
