using System;

namespace L12_HomeWork
{
	public class PhoneReminderItem : ReminderItem
	{
		public string PhoneNumber { get; set; }

		public PhoneReminderItem(string phoneNumber, DateTimeOffset alarmDate, string alarmMessage) : base(alarmDate, alarmMessage)
		{
			PhoneNumber = phoneNumber;
		}

		public override void WriteProperties()
		{
			Console.WriteLine($"Type of object: {ToString()}\n" +
				$"Pnone: {PhoneNumber}\n" +
				$"Alarm date: {AlarmDate}\n" +
				$"Alarm message: {AlarmMessage}\n" +
				$"Time to alarm: {TimeToAlarmLeft(TimeToAlarm)}\n" +
				$"Is outdated: {IsOutdated}\n");
		}
	}
}
