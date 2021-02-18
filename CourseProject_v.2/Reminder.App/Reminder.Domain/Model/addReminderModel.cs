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
		public ReminderItemStatus Status { get; set; }

		public AddReminderModel() { }

		public AddReminderModel(ReminderItemRestricted reminderItem)
		{
			Date = reminderItem.Date;
			Message = reminderItem.Message;
			AccountId = reminderItem.AccountId;
			Status = reminderItem.Status;
		}

		public AddReminderModel(DateTimeOffset date, string message, string accountId, ReminderItemStatus status)
		{
			Date = date;
			Message = message;
			AccountId = accountId;
			Status = status;
		}

		public ReminderItem ToReminderItem()
		{
			return new ReminderItem(Date, Message, AccountId, Status);
		}
	}
}
