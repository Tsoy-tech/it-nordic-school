using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Reminder.Storage.Core.Tests
{
    [TestClass]
    public class ReminderItemTests
    {
        private ReminderItem _testItem;

        [TestInitialize]
        public void TestInitialize()
        { }

        [TestMethod]
        public void Constructor_Initializes_Id_With_Not_Empty_Guid()
        {
            //Preparing
            //Test run
            _testItem = new ReminderItem(DateTimeOffset.MinValue, null, null, ReminderItemStatus.Awaiting);

            //Checking the results
            Assert.AreNotEqual(Guid.Empty, _testItem.Id);
        }

        [TestMethod]
        public void Constructor_Initializes_Status_With_Awaiting()
        {
            //Preparing
            Guid id = Guid.NewGuid();
            DateTimeOffset date = DateTimeOffset.Parse("2019-12-01 12:00");
            const string message = "msg";
            const string accountId = "id";

            //Test run
            _testItem = new ReminderItem(id, date, message, accountId, ReminderItemStatus.Awaiting);

            //Checking the results
            Assert.AreEqual(ReminderItemStatus.Awaiting, _testItem.Status);
            Assert.AreEqual(date, _testItem.Date);
            Assert.AreEqual(message, _testItem.Message);
            Assert.AreEqual(accountId, _testItem.AccountId);
        }

        [DataTestMethod]
        [DataRow("1000-01-01 00:00")]
        [DataRow("3000-01-01 00:00")]
        public void TimeToAlarm_Positive_For_Future_Event_And_Vise_Versa(string stringDate)
        {
            //Preparing
            DateTimeOffset date = DateTimeOffset.Parse(stringDate);
            int expected = Math.Sign(date.Subtract(DateTimeOffset.Now).TotalDays);

            //Test run
            _testItem = new ReminderItem(date, null, null, ReminderItemStatus.Awaiting);

            //cheking the result
            int actual = Math.Sign(_testItem.TimeToAlarm.TotalDays);
            Assert.AreEqual(expected, actual);
        }
    }
}
