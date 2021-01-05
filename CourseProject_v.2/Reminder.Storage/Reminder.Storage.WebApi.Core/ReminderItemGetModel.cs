using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Storage.WebApi.Core
{
    public class ReminderItemGetModel
    {
		public Guid Id { get; }

		/// <summary>
		/// Gets chat the reminder relates to
		/// At the moment the only Telegram implemented
		/// </summary>
		
		public Chat Chat { get; }
		public string AccountId { get; set; }
		public DateTimeOffset Date { get; set; }
		public string Message { get; set; }

		/// <summary>
		/// Gets time period before reminder should fire.
		/// Negative for dates in the past.
		/// </summary>
		public TimeSpan TimeToAlarm => Date.Subtract(DateTimeOffset.Now);

		/// <summary>
		/// Gets the value indicating whether the event already happened.
		/// </summary>
		public bool IsTimeToSend => TimeToAlarm <= TimeSpan.Zero;
		public ReminderItemStatus Status { get; set; }

		public ReminderItemGetModel() { }
		public ReminderItemGetModel(ReminderItem reminderItem)
		{
			Id = reminderItem.Id;
			Chat = reminderItem.Chat;
			AccountId = reminderItem.AccountId;
			Date = reminderItem.Date;
			Message = reminderItem.Message;
			Status = reminderItem.Status;
		}

		public ReminderItem ToReminderItem()
		{
			return new ReminderItem(Id, Date, Message, AccountId, Status);
		}
	}
}
