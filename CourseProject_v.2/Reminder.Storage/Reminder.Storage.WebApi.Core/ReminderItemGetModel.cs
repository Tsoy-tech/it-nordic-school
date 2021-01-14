using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Storage.WebApi.Core
{
    public class ReminderItemGetModel
    {
		/// <summary>
		/// Gets or sets the unique identifier.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets chat the reminder relates to.
		/// At the moment the only Telegram implemented.
		/// </summary>
		public Chat Chat { get; }

		/// <summary>
		/// Gets or sets the date and time the reminder item scheduled for sending.
		/// </summary>
		public DateTimeOffset Date { get; set; }

		/// <summary>
		/// Gets or sets contact identifier in the target sending system.
		/// </summary>
		public string AccountId { get; set; }

		/// <summary>
		/// Gets or sets the message of the reminder item for sending to the recipient.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the status of the recipient.
		/// </summary>
		public ReminderItemStatus Status { get; set; }

		/// <summary>
		/// Gets time period before reminder should fire.
		/// Negative for dates in the past.
		/// </summary>
		public TimeSpan TimeToAlarm => Date.Subtract(DateTimeOffset.UtcNow);

		/// <summary>
		/// Gets the value indicating whether the event already happened.
		/// </summary>
		public bool IsTimeToSend => TimeToAlarm <= TimeSpan.Zero;

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
