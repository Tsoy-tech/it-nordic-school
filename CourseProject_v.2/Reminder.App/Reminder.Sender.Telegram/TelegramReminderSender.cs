using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Reminder.Sender.Core;

namespace Reminder.Sender.Telegram
{
    public class TelegramReminderSender : IReminderSender
    {
        private readonly TelegramBotClient _botClient;

        public TelegramReminderSender(string token)
        {
            _botClient = new TelegramBotClient(token);
        }

        public void Send(string accountId, string message)
        {
            _botClient.SendTextMessageAsync(
                new ChatId(long.Parse(accountId))
                , message);
        }
    }
}
