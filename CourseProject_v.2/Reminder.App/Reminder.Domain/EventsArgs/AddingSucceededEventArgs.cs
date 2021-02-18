using Reminder.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain
{
	public class AddingSucceededEventArgs
	{
		public AddReminderModel Reminder { get; set; }

		public Guid NewReminderId { get; set; }

		public AddingSucceededEventArgs(AddReminderModel reminder, Guid newReminderId)
		{
			Reminder = reminder;
			NewReminderId = newReminderId;
		}
	}
}
