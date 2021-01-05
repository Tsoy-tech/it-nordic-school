using Reminder.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain
{
	public class AddingFailedEventArgs
	{
		public AddReminderModel Reminder { get; set; }

		public Exception Exception { get; set; }

		public AddingFailedEventArgs(AddReminderModel reminder, Exception exception)
		{
			Reminder = reminder;
			Exception = exception;
		}
	}
}
