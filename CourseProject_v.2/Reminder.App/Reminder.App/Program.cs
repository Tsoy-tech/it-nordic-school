using System;
using Reminder.Domain;
using Reminder.Sender.Telegram;
using Reminder.Receiver.Telegram;
using Reminder.Storage.WebApi.Client;

namespace Reminder.App
{
    class Program
    {
        static void Main()
        {
            const string token = "1467408776:AAGSGszyTCYYCTWTKu4PL_it029uC8X8hbs";
            //botID = "1467408776"

            var storage = new ReminderStorageWebApiClient("https://localhost:44354/api/reminders");

            var sender = new TelegramReminderSender(token);
            var receiver = new TelegramReminderReceiver(token);

            using var domain = new ReminderDomain(storage, receiver, sender, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

            domain.SendingSucceeded += Domain_SendingSucceeded;
            domain.SendingFailed += Domain_SendingFailed;
            domain.ParsingFailed += Domain_ParsingFailed;
            domain.AddingSucceeded += Domain_AddingSucceeded;
            domain.AddingFailed += Domain_AddingFailed;

            domain.Run();

            Console.WriteLine("Domain logic running...");
            Console.ReadKey();
        }
        private static void Domain_AddingFailed(object sender, AddingFailedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Adding Failed ");
            Console.ResetColor();

            Console.WriteLine(
                $"Bot couldn't save new reminder from {e.Reminder.AccountId} " +
                $"message '{e.Reminder.Message}' " +
                $"at {e.Reminder.Date:r}.\n" +
                $"Exception: {e.Exception}");
        }

        private static void Domain_AddingSucceeded(object sender, AddingSucceededEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Adding OK ");
            Console.ResetColor();

            Console.WriteLine(
                $"New reminder from {e.Reminder.AccountId} received: " +
                $"message '{e.Reminder.Message}' " +
                $"at {e.Reminder.Date:r}");
        }

        private static void Domain_ParsingFailed(object sender, ParsingFailedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Parsing Failed ");
            Console.ResetColor();

            Console.WriteLine(
                $"Bot could not parse message from {e.ContactId} '{e.InputText}'");
        }

        private static void Domain_SendingFailed(object sender, Domain.EventsArgs.SendingFailedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Sending FAILED ");
            Console.ResetColor();
            Console.Write($"Contact {e.Reminder.AccountId} can't receive " +
                $"message {e.Reminder.Message} " +
                $"at { e.Reminder.Date:r}.\n" +
                $"Exception: {e.Exception}");
            Console.WriteLine();
        }

        private static void Domain_SendingSucceeded(object sender, Domain.EventsArgs.SendingSucceededEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Sending OK ");
            Console.ResetColor();
            Console.Write($"Contact {e.Reminder.AccountId} received message {e.Reminder.Message} at {e.Reminder.Date:r}\n");
        }
    }
}
