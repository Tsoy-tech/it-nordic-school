using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Storage.WebApi.Core
{
    public class ReminderItemAddModel
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

		public ReminderItemAddModel() { }

		public ReminderItemAddModel(ReminderItemRestricted reminderItemRestricted) 
		{
			AccountId = reminderItemRestricted.AccountId;
			Date = reminderItemRestricted.Date;
			Message = reminderItemRestricted.Message;
			Status = reminderItemRestricted.Status;
		}
	}
}
