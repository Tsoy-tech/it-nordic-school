using System;
using System.Collections.Generic;

namespace L12_HomeWork
{
	class Program
	{
		static void Main(string[] args)
		{
			List<object> reminder = new List<object>() { };

			reminder.Add(new ReminderItem(DateTimeOffset.Parse("2020-11-09 07:15:00"),
				"It's time for breakfast!"));
			reminder.Add(new PhoneReminderItem("8846545489", DateTimeOffset.Parse("2020-11-20 12:00:00"),
				"It's time for lunch!"));
			reminder.Add(new ChatReminderItem("Work", "John", DateTimeOffset.Parse("2020-11-25 10:00:00"),
				"Good morning! How have you been doing?"));
			reminder.Add(new ChatReminderItem("Home", "John", DateTimeOffset.Parse("2020-11-18 15:32:00"),
				"Hi! Could you please get some milk?"));

			foreach (ReminderItem item in reminder)
			{
				item.WriteProperties();
			}
		}
	}
}
