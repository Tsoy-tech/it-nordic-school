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
		//Properties
		public Guid Id { get; }

		/// <summary>
		/// Gets chat the reminder relates to
		/// At the moment the only Telegram implemented
		/// </summary>

		public Chat Chat { get; }
		[Required]
		public string AccountId { get; set; }
		[Required]
		public DateTimeOffset Date { get; set; }
		[Required]
		public string Message { get; set; }
		[Required]
		public ReminderItemStatus Status { get; set; }

		public ReminderItemAddModel() { }

		public ReminderItemAddModel(ReminderItem reminderItem) 
		{
			AccountId = reminderItem.AccountId;
			Date = reminderItem.Date;
			Message = reminderItem.Message;
			Status = reminderItem.Status;
		}
	}
}
