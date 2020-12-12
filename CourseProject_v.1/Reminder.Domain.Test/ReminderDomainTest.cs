using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Domain.Model;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using System;

namespace Reminder.Domain.Test
{
    [TestClass]
    public class ReminderDomainTest
    {
        [TestMethod]
        public void Awaiting_Item_Changes_Status_To_ReadyToSend_After_Checking_Period()
        {
            //preparing

            var storage = new InMemoryReminderStorage();

            var sender = new TelegramReminderSender("1467408776:AAGSGszyTCYYCTWTKu4PL_it029uC8X8hbs");
            var receiver = new TelegramReminderReceiver("1467408776:AAGSGszyTCYYCTWTKu4PL_it029uC8X8hbs");

            using var domain = new ReminderDomain(storage, receiver, sender, TimeSpan.FromMilliseconds(50), TimeSpan.FromMilliseconds(50));

            var item = new ReminderItem(DateTimeOffset.Now, "Hello World!", "TestContact"); //addReminderModel
            //domain.AddReminder(item); //Model was here

            // run

            domain.Run();

            //Check the result

            System.Threading.Thread.Sleep(50);

            var actualItem = storage.Get(item.Id);
            Assert.IsNotNull(actualItem);
            Assert.AreEqual(ReminderItemStatus.ReadyToSend, actualItem.Status);

        }
    }
}
