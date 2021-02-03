using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Reminder.Storage.Core;

namespace Reminder.Storage.SqlServer.ADO
{
    public class SqlServerReminderStorage : IReminderStorage
    {
        private readonly string _connectionString;

        public SqlServerReminderStorage(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public Guid Add(ReminderItemRestricted reminderItemRestricted)
        {
            using var connection = GetOpennedSqlConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "[dbo].[AddReminderItem]";

            command.Parameters.AddWithValue("@contactId", reminderItemRestricted.AccountId);
            command.Parameters.AddWithValue("@targetDate", reminderItemRestricted.Date);
            command.Parameters.AddWithValue("@message", reminderItemRestricted.Message);
            command.Parameters.AddWithValue("@statusId", (byte)reminderItemRestricted.Status);

            Guid id = (Guid)command.ExecuteScalar();
            return id;
        }

        public ReminderItem Get(Guid id)
        {
            using var connection = GetOpennedSqlConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "[dbo].[GetReminderItemById]";

            command.Parameters.AddWithValue("@reminderId", id);
            using var reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            int ordinalId = reader.GetOrdinal("Id");
            int ordinalAccountId = reader.GetOrdinal("AccountId");
            int ordinalTargetDate = reader.GetOrdinal("TargetDate");
            int ordinalMessage = reader.GetOrdinal("Message");
            int ordinalStatusId = reader.GetOrdinal("StatusId");

            var result = new ReminderItem(
                reader.GetGuid(ordinalId),
                reader.GetDateTimeOffset(ordinalTargetDate),
                reader.GetString(ordinalMessage),
                reader.GetString(ordinalAccountId),
                (ReminderItemStatus)reader.GetByte(ordinalStatusId));

            return result;
        }
        public List<ReminderItem> GetList(IEnumerable<ReminderItemStatus> statuses, int count = -1, int startPosition = 0)
        {
            throw new NotImplementedException();
        }

        public void Update(ReminderItem reminderItem)
        {
            throw new NotImplementedException();
        }

        private SqlConnection GetOpennedSqlConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
