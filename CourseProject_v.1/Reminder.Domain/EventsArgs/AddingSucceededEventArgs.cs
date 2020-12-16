using Reminder.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain
{
	public class AddingSucceededEventArgs
	{
		public AddReminderModel Reminder { get; set; }

		public AddingSucceededEventArgs(AddReminderModel reminder)
		{
			Reminder = reminder;
		}
	}
}
