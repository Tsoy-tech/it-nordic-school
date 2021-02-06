using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.Core
{
	public class ReminderItem
    {
		private Guid reminderItemId;
		private DateTimeOffset expectedDate;
		private string expectedAccountId;
		private ReminderItemStatus expectedStatus;

		//Properties
		public Guid Id { get; }
		public Chat Chat { get; }
		public string AccountId { get; set; }
		public DateTimeOffset Date { get; set; }
		public string Message { get; set; }
		public TimeSpan TimeToAlarm => Date.Subtract(DateTimeOffset.Now);
		public bool IsTimeToSend => TimeToAlarm <= TimeSpan.Zero;
		public ReminderItemStatus Status { get; set; }

		public ReminderItem(DateTimeOffset date, string message, string accountId, ReminderItemStatus status) : this(Guid.NewGuid(), date, message, accountId, status) { }

		public ReminderItem(Guid id, DateTimeOffset date, string message, string accountId, ReminderItemStatus status)
		{
			Id = id;
			Chat = Chat.Telegram;
			Date = date;
			Message = message;
			AccountId = accountId;
			Chat = Chat.Telegram;
			Status = status;
		}
	}
}
