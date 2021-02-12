using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Reminder.Storage.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.SqlServer.ADO.Tests.Properties;

namespace Reminder.Storage.SqlServer.ADO.Tests
{
    [TestClass]
    public class SqlServerReminderStorageTests
    {
        private static string _connectionString;
        
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _connectionString = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("DefaultConnection");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            RunSqlScript(Resources.Schema);
            RunSqlScript(Resources.SPs);
            RunSqlScript(Resources.Data);
        }

        [TestMethod]
        public void Add_Creates_New_ReminderItem_And_Gets_Them()
        {
            var storage = new SqlServerReminderStorage(_connectionString);

            DateTimeOffset expectedDate = DateTimeOffset.Now;
            string expectedAccountId = "TEST_ACCOUNT_ID";
            string expectedMessage = "TEST_MESSAGE";
            ReminderItemStatus expectedStatus = ReminderItemStatus.Failed;

            Guid id = storage.Add(new ReminderItemRestricted(expectedDate, expectedMessage, expectedAccountId, expectedStatus));

            Assert.AreNotEqual(Guid.Empty, id);

            ReminderItem actualReminderItem = storage.Get(id);
            Assert.IsNotNull(actualReminderItem);
            Assert.AreEqual(expectedAccountId, actualReminderItem.AccountId);
            Assert.AreEqual(expectedDate, actualReminderItem.Date);
            Assert.AreEqual(expectedMessage, actualReminderItem.Message);
            Assert.AreEqual(expectedStatus, actualReminderItem.Status);

        }

        [TestMethod]
        public void Update_Updates_ReminderItem()
        {
            var storage = new SqlServerReminderStorage(_connectionString);

            Guid reminderItemId = new Guid("00000000-0000-0000-0000-111111111111");
            DateTimeOffset expectedDate = DateTimeOffset.Now;
            string expectedAccountId = "TEST_ACCOUNT_ID";
            string expectedMessage = "TEST_MESSAGE";
            ReminderItemStatus expectedStatus = ReminderItemStatus.Failed;
            var expectedCreatedDate = DateTimeOffset.Parse("2000-01-01 00:00:00 +00:00");
            var expectedUpdateDate = DateTimeOffset.Now;

            storage.Update(new ReminderItem(reminderItemId, expectedDate, expectedMessage, expectedAccountId, expectedStatus));

            using var connection = GetOpennedSqlConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = @"
                SELECT * 
                FROM [dbo].[ReminderItem] 
                WHERE [Id] = @reminderId";

            command.Parameters.AddWithValue("@reminderId", reminderItemId);
            
            using var reader = command.ExecuteReader();
            Assert.IsTrue(reader.Read());

            int ordinalId = reader.GetOrdinal("Id");
            int ordinalAccountId = reader.GetOrdinal("AccountId");
            int ordinalTargetDate = reader.GetOrdinal("TargetDate");
            int ordinalMessage = reader.GetOrdinal("Message");
            int ordinalStatusId = reader.GetOrdinal("StatusId");
            int ordinalExpectedCreatedDate = reader.GetOrdinal("CreatedDate");

            Assert.AreEqual(reminderItemId, reader.GetGuid(ordinalId));
            Assert.AreEqual(expectedDate, reader.GetDateTimeOffset(ordinalTargetDate));
            Assert.AreEqual(expectedMessage, reader.GetString(ordinalMessage));
            Assert.AreEqual(expectedStatus, (ReminderItemStatus)reader.GetByte(ordinalStatusId));
            //Assert.AreEqual(expectedUpdateDate, reader.GetDateTimeOffset(ordinalTargetDate));
        }

        [TestMethod]
        public void GetReminderItemsByStatus_Returns_Corresponding_Records()
        {
            var storage = new SqlServerReminderStorage(_connectionString);
            int expectedCount = 3;
            var statuses = new List<ReminderItemStatus>
            {
                ReminderItemStatus.ReadyToSend,
                ReminderItemStatus.SuccessfullySent
            };

            List<ReminderItem> actualReminderItemList = storage.GetList(statuses);
            Assert.IsNotNull(actualReminderItemList);
            Assert.AreEqual(expectedCount, actualReminderItemList.Count);
        }
        private void RunSqlScript(string sqlCommandText)
        {
            using var connection = GetOpennedSqlConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            string[] sqlInstractions = Regex.Split(sqlCommandText, @"\bGO\b");
            
            foreach(string sqlInstraction in sqlInstractions.Where(s => !string.IsNullOrWhiteSpace(s)))
            {
                command.CommandText = sqlInstraction;
                command.ExecuteNonQuery();
            }
        }
        private SqlConnection GetOpennedSqlConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
