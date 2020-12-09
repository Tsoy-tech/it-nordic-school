using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.Model
{
    public class SendReminderModel
    {
		public string AccountId { get; set; }
		public DateTimeOffset Date { get; set; }
		public string Message { get; set; }

		public SendReminderModel()
		{ }

		public SendReminderModel(ReminderItem reminderItem)
		{
			AccountId = reminderItem.AccountId;
			Date = reminderItem.Date;
			Message = reminderItem.Message;
		}
	}
}
