using System;
using Reminder.Storage.InMemory;
using Reminder.Domain;
using Reminder.Domain.Model;

namespace Reminder.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new InMemoryReminderStorage();
            using var domain = new ReminderDomain(storage, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));//Dependency injection

            var addReminderModel = new AddReminderModel(DateTimeOffset.Now.AddSeconds(2), "Hello World!", "@TestContact");
            domain.SendingSucceeded += Domain_SendingSucceeded;
            domain.SendingFailed += Domain_SendingFailed;
            domain.AddReminderModel(addReminderModel);
            domain.Run();

            Console.WriteLine("Domain logic running...");
            Console.ReadKey();
        }

        private static void Domain_SendingFailed(object sender, Domain.EventsArgs.SendingFailedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Sending FAILED ");
            Console.ResetColor();
            Console.Write($"Contact {e.Reminder.AccountId} can't receive message {e.Reminder.Message} at {e.Reminder.Date:f}");
            Console.WriteLine();
        }

        private static void Domain_SendingSucceeded(object sender, Domain.EventsArgs.SendingSucceededEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Sending OK ");
            Console.ResetColor();
            Console.Write($"Contact {e.Reminder.AccountId} received message {e.Reminder.Message} at {e.Reminder.Date:f}");
        }
    }
}
