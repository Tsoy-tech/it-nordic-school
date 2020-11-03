using System;

namespace L10_ClassWork
{
	class CreditCard
	{
		private string _number;

		public string HolderName { get; set; }
		public string ValidBefore { get; set; }
		public ushort Cvc { get; set; }

		public string Number
		{
			get
			{
				//if (_number == null)
				//	return null;

				//string result = string.Empty;

				//for(int i = 0; i < _number.Length; i++)
				//{
				//	if (i > 0 && i % 4 == 0)
				//		result += " ";

				//	result += _number[i];
				//}

				//return result;

				return _number;
			}
			set
			{
				foreach (char ch in value)
				{
					if (!char.IsDigit(ch))
					{
						throw new Exception("Value should contain only digits.");
					}
				}
				_number = value;
			}
		}

		private bool NumberIsValid()
		{
			return Number != null 
				&& Number.Length >= 12 
				&& Number.Length <= 26;
		}

		private bool ValidBeforeIsValid()
		{
			return ValidBefore != null;
		}

		private bool CvcIsValid()
		{
			return Cvc < 1000;
		}

		public bool IsValid()
		{
			return NumberIsValid() 
				&& ValidBeforeIsValid() 
				&& CvcIsValid();

			if (Number == null || Number.Length < 12 || Number.Length > 26)
			{
				return false;
			}

			if(ValidBefore == null)
			{
				return false;
			}

			return true;
		}
	}

	//Инкапсуляция - заключение в одном классе нескольких свойств и методов объекта

	class Program
	{
		static void Main(string[] args)
		{
			CreditCard creditCard = new CreditCard();
			creditCard.HolderName = "Anyone";
			creditCard.Number = "11112222333344445555";
			creditCard.ValidBefore = "12/25";
			creditCard.Cvc = 123;

			Console.WriteLine(creditCard.Number);
			creditCard.Number += "9";
			Console.WriteLine(creditCard.IsValid()
				? "Credit card is VALID"
				: "Credit card is NOT VALID");

			CreditCard[] creditCards = new CreditCard[2];
			creditCards[0] = creditCard;
		}
	}
}
