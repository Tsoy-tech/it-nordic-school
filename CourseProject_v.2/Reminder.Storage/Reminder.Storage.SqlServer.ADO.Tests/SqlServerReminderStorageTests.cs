using System;
using System.Collections.Generic;
using System.Text;
using Reminder.Storage.SqlServer.ADO.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Linq;
using Reminder.Storage.Core;
using Microsoft.Extensions.Configuration;

namespace Reminder.Storage.SqlServer.ADO.Tests
{
    [TestClass]
    public class SqlServerReminderStorageTests
    {
        private static string _connectionString;
        
        [ClassInitialize]
        public static void Classinitialize(TestContext context)
        {
            _connectionString = new ConfigurationBuilder().AddJsonFile("appsetings.json").Build().GetConnectionString("DefaultConnection");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            RunSqlScript(Resources.Schema);
            RunSqlScript(Resources.SPs);
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
