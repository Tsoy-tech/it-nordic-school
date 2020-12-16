using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.Model
{
    public class AddReminderModel
    {
		public string AccountId { get; set; }
		public DateTimeOffset Date { get; set; }
		public string Message { get; set; }

		public AddReminderModel() { }

		public AddReminderModel(ReminderItem reminderItem)
		{
			Date = reminderItem.Date;
			Message = reminderItem.Message;
			AccountId = reminderItem.AccountId;
		}

		public AddReminderModel(DateTimeOffset date, string message, string accountId)
		{
			Date = date;
			Message = message;
			AccountId = accountId;
		}

		public ReminderItem ToReminderItem()
		{
			return new ReminderItem(Date, Message, AccountId);
		}
	}
}
