using System;

namespace Reminder.Sender.Core
{
    public interface IReminderSender
    {
        void Send(string accountId, string message);
    }
}
