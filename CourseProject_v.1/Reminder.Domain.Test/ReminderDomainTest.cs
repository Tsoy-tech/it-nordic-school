using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Domain.Model;
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
            using var domain = new ReminderDomain(storage, TimeSpan.FromMilliseconds(50), TimeSpan.FromMilliseconds(50));

            var item = new ReminderItem(DateTimeOffset.Now, "Hello World!", "TestContact"); //addReminderModel
            domain.AddReminder(item); //Model was here

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
