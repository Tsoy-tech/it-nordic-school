using System;

namespace L11_HomeWork
{
	class Program
	{
		static void Main(string[] args)
		{
			ReminderItem breakfastReminder = new ReminderItem(
				DateTimeOffset.Parse("2020-11-09 07:15:00"), 
				"It's time for breakfast!");

			ReminderItem lunchReminder = new ReminderItem(
				DateTimeOffset.Parse("2020-11-20 12:00:00"),
				"It's time for lunch!");

			breakfastReminder.WriteProperties();
			lunchReminder.WriteProperties();
		}
	}
}
