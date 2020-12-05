using System;
using Reminder.Storage.InMemory;
using Reminder.Storage.Core;

namespace Reminder.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new InMemoryReminderStorage();
            var item = new ReminderItem(DateTimeOffset.Now, "Hello World!", "TestContact");

            storage.Add(item);
            var itemFromStorage = storage.Get(item.Id);

            Console.WriteLine(itemFromStorage.Message);
        }
    }
}
