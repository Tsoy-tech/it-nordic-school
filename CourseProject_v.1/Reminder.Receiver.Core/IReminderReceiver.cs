using System;

namespace Reminder.Receiver.Core
{
    public interface IReminderReceiver
    {
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        void StartReceiving();
        
    }
}
