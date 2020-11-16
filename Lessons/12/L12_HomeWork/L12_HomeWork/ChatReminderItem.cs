using System;

namespace L12_HomeWork
{
	class ChatReminderItem : ReminderItem
	{
		public string ChatName { get; set; }
		public string AccountName { get; set; }

		public ChatReminderItem(string chatName, string accountName, DateTimeOffset alarmDate, string alarmMessage) : base(alarmDate, alarmMessage)
		{
			ChatName = chatName;
			AccountName = accountName;
		}

		public override void WriteProperties()
		{
			Console.WriteLine($"Type of object: {ToString()}\n" +
				$"Chat: {ChatName}\n" +
				$"Account: {AccountName}\n" +
				$"Alarm date: {AlarmDate}\n" +
				$"Alarm message: {AlarmMessage}\n" +
				$"Time to alarm: {TimeToAlarmLeft(TimeToAlarm)}\n" +
				$"Is outdated: {IsOutdated}\n");
		}
	}
}
