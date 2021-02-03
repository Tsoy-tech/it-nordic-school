using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.Core
{
	public class ReminderItemRestricted
    {
		//Properties
		public Chat Chat { get; }
		public string AccountId { get; set; }
		public DateTimeOffset Date { get; set; }
		public string Message { get; set; }
		public TimeSpan TimeToAlarm => Date.Subtract(DateTimeOffset.Now);
		public bool IsTimeToSend => TimeToAlarm <= TimeSpan.Zero;
		public ReminderItemStatus Status { get; set; }

		public ReminderItemRestricted(DateTimeOffset date, string message, string accountId, ReminderItemStatus status)
		{
			Chat = Chat.Telegram;
			Date = date;
			Message = message;
			AccountId = accountId;
			Chat = Chat.Telegram;
			Status = status;
		}

		public ReminderItem ToReminderItem(Guid id)
		{
			return new ReminderItem(id, Date, Message, AccountId, Status);
		}
	}
}
