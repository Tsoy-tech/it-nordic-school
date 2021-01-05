using System;
using Reminder.Storage.InMemory;
using Reminder.Domain;
using Reminder.Domain.Model;
using Reminder.Sender.Telegram;
using Telegram.Bot;
using Reminder.Receiver.Telegram;
using Reminder.Receiver.Core;

namespace Reminder.App
{
    class Program
    {
        static void Main(string[] args)
        {
            const string token = "1467408776:AAGSGszyTCYYCTWTKu4PL_it029uC8X8hbs";
            //botID = "1467408776"

            var storage = new InMemoryReminderStorage();
            //var storage = new ReminderStorageWebApiClient("URL");
            var sender = new TelegramReminderSender(token);
            var receiver = new TelegramReminderReceiver(token);

            using var domain = new ReminderDomain(storage, receiver, sender, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));//Dependency injection

            var addReminderModel = new AddReminderModel(DateTimeOffset.Now.AddSeconds(2), "Hello World!", "1467408776");

            domain.SendingSucceeded += Domain_SendingSucceeded;
            domain.SendingFailed += Domain_SendingFailed;
            
            //receiver.MessageReceived += ;

            //domain.AddReminderModel(addReminderModel);
            domain.Run();

            Console.WriteLine("Domain logic running...");
            Console.ReadKey();
        }

        private static void Domain_SendingFailed(object sender, Domain.EventsArgs.SendingFailedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Sending FAILED ");
            Console.ResetColor();
            Console.Write($"Contact {e.Reminder.AccountId} can't receive message {e.Reminder.Message} at {e.Reminder.Date:f}\n");
            Console.WriteLine();
        }

        private static void Domain_SendingSucceeded(object sender, Domain.EventsArgs.SendingSucceededEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Sending OK ");
            Console.ResetColor();
            Console.Write($"Contact {e.Reminder.AccountId} received message {e.Reminder.Message} at {e.Reminder.Date:f}\n");
        }
    }
}
