using System;
using Telegram.Bot;
using Reminder.Receiver.Core;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Reminder.Receiver.Telegram
{
    //ref
    public class TelegramReminderReceiver : IReminderReceiver
    {
        private readonly TelegramBotClient _botClient;

        public TelegramReminderReceiver(string token) 
        {
            _botClient = new TelegramBotClient(token);
        }

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public void StartReceiving()
        {
            _botClient.OnMessage += (sender, sourceArgs) =>
            {
                if (sourceArgs.Message.Type != MessageType.Text)
                    return;
                var ourArgs = new MessageReceivedEventArgs(
                    sourceArgs.Message.Chat.Id.ToString(), 
                    sourceArgs.Message.Text);

                MessageReceived?.Invoke(this, ourArgs);
            };

            _botClient.StartReceiving();
        }

        protected virtual void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            MessageReceived?.Invoke(sender, e);
        }
    }
}
