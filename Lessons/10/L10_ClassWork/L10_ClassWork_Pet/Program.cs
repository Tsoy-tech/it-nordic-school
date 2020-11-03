using System;

namespace L10_ClassWork_Pet
{
	enum PetKind
	{
		Mouse,
		Cat,
		Dog
	}
	class Pet
	{
		private string _birthPlace;
		private char _sex;
		private byte _age;

		public PetKind kind;
		public string Name;

		public char Sex 
		{ 
			get { return _sex; } 
			set 
			{
				if (value == 'M' || value == 'm' ||
					value == 'F' || value == 'f')
				{ 
					_sex = char.ToUpper(value);
				}
				else
				{
					throw new Exception("Sex should be one of two options: M/F.");
				}
			} 
		}
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

		public void SetBirthPlace(string birthPlace)
		{
			if (birthPlace == null)
			{
				throw new ArgumentNullException(nameof(birthPlace));
			}

			if(_birthPlace == null)
				throw new Exception("Birth place can not be overriden");
			_birthPlace = birthPlace; 
		}

		public string Description
		{
			get 
			{
				return $"{Name} is a {kind}({Sex}) of {Age} years old.";
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Pet pet1 = new Pet();
			pet1.Name = "Tom";
			pet1.kind = PetKind.Cat;
			pet1.Age = 5;
			pet1.Sex = 'M';
			pet1.SetBirthPlace("Moscow");

			Pet pet2 = new Pet
			{
				Name = "Minnie",
				kind = PetKind.Mouse,
				Sex = 'F',
				Age = 2

			};

			Console.WriteLine(pet1.Description);
			Console.WriteLine(pet2.Description);
		}
	}
}
