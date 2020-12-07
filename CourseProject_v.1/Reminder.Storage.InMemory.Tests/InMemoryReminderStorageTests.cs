using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory.Tests
{
	[TestClass]
	public class InMemoryReminderStorageTests
	{
		[TestMethod]
		public void Add_Entries_Successfully()
		{
			var reminder = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			InMemoryReminderStorage testStorage = new InMemoryReminderStorage();

			testStorage.Add(reminder);
			var itemFromStorage = testStorage.Get(reminder.Id);

			Assert.IsTrue(itemFromStorage.Equals(reminder));
		}

		[TestMethod]
		public void ArgumentException_Is_Excepted_On_Add_Items_With_The_Same_Id()
		{
			var reminder = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			var copyOfReminder = reminder;
			var testStorage = new InMemoryReminderStorage();

			testStorage.Add(reminder);

			_ = Assert.ThrowsException<ArgumentException>(() => testStorage.Add(copyOfReminder));
		}

		[TestMethod]
		public void Get_Unsaved_Object()
		{
			var reminder = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			var testStorage = new InMemoryReminderStorage();

			var itemFromStorage = testStorage.Get(reminder.Id);

			Assert.IsNull(itemFromStorage);
		}

		[TestMethod]
		public void Update_Entries_Successfully()
		{
			var id = Guid.NewGuid();
			var reminder = new ReminderItem(id, DateTimeOffset.Now, "Hello!", "New ID");
			var reminderWithNewData = new ReminderItem(id, DateTimeOffset.Now, "Bye! Bye!", "ID of new reminder");
			var testStorage = new InMemoryReminderStorage();

			testStorage.Add(reminder);
			testStorage.Update(reminderWithNewData);
			
			Assert.AreEqual(reminder.Id, reminderWithNewData.Id);
			Assert.AreEqual(reminder.Date, reminderWithNewData.Date);
			Assert.AreEqual(reminder.Message, reminderWithNewData.Message);
			Assert.AreEqual(reminder.AccountId, reminderWithNewData.AccountId);
			Assert.AreEqual(reminder.Status, reminderWithNewData.Status);
		}

		[TestMethod]
		public void KeyNotFoundException_Is_Excepted_On_Update_Non_Existent_Object()
		{
			var reminder = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			var reminderWithNewData = new ReminderItem(DateTimeOffset.Now, "Bye! Bye!", "ID of new reminder");
			var testStorage = new InMemoryReminderStorage();

			testStorage.Add(reminder);

			_ = Assert.ThrowsException<KeyNotFoundException>(() => testStorage.Update(reminderWithNewData));
		}

		[TestMethod]
		public void Get_List_Of_Objects_From_Storage()
		{
			var reminder = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			var reminder1 = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			var reminder2 = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			var testStorage = new InMemoryReminderStorage();
			var statuses = new List<ReminderItemStatus>();

			statuses.Add(ReminderItemStatus.Awaiting);
			testStorage.Add(reminder);
			testStorage.Add(reminder1);
			testStorage.Add(reminder2);
			var listOfItemsFromStorage = testStorage.GetList(statuses);

			Assert.IsNotNull(listOfItemsFromStorage);
			Assert.IsTrue(listOfItemsFromStorage.Contains(reminder));
			Assert.IsTrue(listOfItemsFromStorage.Contains(reminder1));
			Assert.IsTrue(listOfItemsFromStorage.Contains(reminder2));
		}

		[TestMethod]
		public void Get_List_Of_Objects_With_Statuses_ReadyToSend_And_Failed()
		{
			var reminder = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			var reminder1 = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			var reminder2 = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			var reminder3 = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			reminder3.Status = ReminderItemStatus.ReadyToSend;
			var reminder4 = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			reminder4.Status = ReminderItemStatus.ReadyToSend;
			var reminder5 = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			reminder5.Status = ReminderItemStatus.Failed;
			var testStorage = new InMemoryReminderStorage();
			var statuses = new List<ReminderItemStatus>();

			testStorage.Add(reminder);
			testStorage.Add(reminder1);
			testStorage.Add(reminder2);
			testStorage.Add(reminder3);
			testStorage.Add(reminder4);
			testStorage.Add(reminder5);
			statuses.Add(ReminderItemStatus.ReadyToSend);
			statuses.Add(ReminderItemStatus.Failed);
			var listOfItemsFromStorage = testStorage.GetList(statuses);

			Assert.IsNotNull(listOfItemsFromStorage);
			Assert.IsFalse(listOfItemsFromStorage.Contains(reminder));
			Assert.IsFalse(listOfItemsFromStorage.Contains(reminder1));
			Assert.IsFalse(listOfItemsFromStorage.Contains(reminder2));
			Assert.IsTrue(listOfItemsFromStorage.Contains(reminder3));
			Assert.IsTrue(listOfItemsFromStorage.Contains(reminder4));
			Assert.IsTrue(listOfItemsFromStorage.Contains(reminder5));
		}

		[TestMethod]
		public void Get_All_Objects_stating_from_3()
		{
			var reminder = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			var reminder1 = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			var reminder2 = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			var reminder3 = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			reminder3.Status = ReminderItemStatus.ReadyToSend;
			var reminder4 = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			reminder4.Status = ReminderItemStatus.ReadyToSend;
			var reminder5 = new ReminderItem(DateTimeOffset.Now, "Hello!", "New ID");
			reminder5.Status = ReminderItemStatus.Failed;
			var testStorage = new InMemoryReminderStorage();
			var statuses = new List<ReminderItemStatus>();

			testStorage.Add(reminder);
			testStorage.Add(reminder1);
			testStorage.Add(reminder2);
			testStorage.Add(reminder3);
			testStorage.Add(reminder4);
			testStorage.Add(reminder5);
			statuses.Add(ReminderItemStatus.Awaiting);
			statuses.Add(ReminderItemStatus.ReadyToSend);
			statuses.Add(ReminderItemStatus.Failed);

			var listOfItemsFromStorage = testStorage.GetList(statuses, -1, 4);

			Assert.IsNotNull(listOfItemsFromStorage);
			Assert.IsFalse(listOfItemsFromStorage.Contains(reminder));
			Assert.IsFalse(listOfItemsFromStorage.Contains(reminder1));
			Assert.IsFalse(listOfItemsFromStorage.Contains(reminder2));
			Assert.IsFalse(listOfItemsFromStorage.Contains(reminder3));
			Assert.IsTrue(listOfItemsFromStorage.Contains(reminder4));
			Assert.IsTrue(listOfItemsFromStorage.Contains(reminder5));
		}
	}
}
