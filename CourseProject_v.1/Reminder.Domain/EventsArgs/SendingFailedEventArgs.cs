using Reminder.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.EventsArgs
{
    public class SendingFailedEventArgs : EventArgs
    {
        public SendReminderModel Reminder { get; set; }
        public Exception Exception { get; set; }

        public SendingFailedEventArgs(SendReminderModel reminder, Exception exception)
        {
            Reminder = reminder;
            Exception = exception;
        }
    }
}
