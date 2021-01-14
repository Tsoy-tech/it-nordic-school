using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Storage.WebApi.Core
{
    public class ReminderItemUpdateModel
    {
		/// <summary>
		/// Gets or sets contact identifier in the target sending system.
		/// </summary>
		[Required]
		public string AccountId { get; set; }

		/// <summary>
		/// Gets or sets the date and time the reminder item scheduled for sending.
		/// </summary>
		[Required]
		public DateTimeOffset Date { get; set; }

		/// <summary>
		/// Gets or sets the message of the reminder item for sending to the recipient.
		/// </summary>
		[Required]
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the status of the recipient.
		/// </summary>
		[Required]
		public ReminderItemStatus Status { get; set; }

		public ReminderItemUpdateModel() { }

		public ReminderItemUpdateModel(ReminderItem reminderItem) 
		{
			AccountId = reminderItem.AccountId;
			Date = reminderItem.Date;
			Message = reminderItem.Message;
			Status = reminderItem.Status;
		}

		public void UpdateReminderItem(ReminderItem reminderItem)
		{
			reminderItem.AccountId = AccountId;
			reminderItem.Date = Date;
			reminderItem.Message = Message;
			reminderItem.Status = Status;
		}
	}
}
