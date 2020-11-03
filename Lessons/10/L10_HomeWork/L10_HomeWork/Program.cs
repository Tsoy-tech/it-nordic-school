using System;
using System.Data;
using System.Linq;

namespace L10_HomeWork
{
	class Person
	{
		private byte _age;

		public string Name;

		public byte Age
		{
			get { return _age; }
			set
			{
				if (value >= 150 || value <= 0)
					throw new Exception("Age should be less or equals to 150");
				
				_age = value;
			}
		}

		private byte AgeAfterFourYears
		{
			get { return _age += 4; }
		}

		public string Description
		{
			get { return $"Name: {Name}, age in 4 years: {AgeAfterFourYears}."; }
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			const int quantity = 3;
			string input = string.Empty;

			Person[] persons = new Person[quantity];

			for(int i = 0; i < quantity; i++)
			{
				persons[i] = new Person();

				Console.Write($"Enter name {i}: ");
				input = Console.ReadLine();

				foreach (char symbol in input)
				{
					if (!char.IsLetter(symbol))
						throw new Exception("Field \"Name\" should contain only letters");
				}

				persons[i].Name = input;

				Console.Write($"Enter age {i}: ");
				input = Console.ReadLine();

				foreach(char symbol in input)
				{
					if (!char.IsDigit(symbol))
						throw new Exception("Field \"Age\" should contain only digits");
				}

				try
				{
					persons[i].Age = byte.Parse(input);
				}
				catch (OverflowException e)
				{
					throw e;
				}
			}

			for (int i = 0; i < persons.Count(); i++)
			{
				Console.WriteLine(persons[i].Description);
			}
			Console.WriteLine( "Press any key to continue...");
		}
	}
}
