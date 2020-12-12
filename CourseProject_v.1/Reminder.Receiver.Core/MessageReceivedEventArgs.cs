using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Receiver.Core
{
    public class MessageReceivedEventArgs
    {
        public string AccountID { get; set; }
        public string Message { get; set; }

        public MessageReceivedEventArgs(string accountId, string message)
        {
            AccountID = accountId;
            Message = message;
        }
    }
}
