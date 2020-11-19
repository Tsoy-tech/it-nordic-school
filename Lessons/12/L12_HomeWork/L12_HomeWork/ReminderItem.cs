using System;

namespace L12_HomeWork
{
	public class ReminderItem : ReminderItemPresenter
	{
		public DateTimeOffset AlarmDate { get; set; }
		public string AlarmMessage { get; set; }
		public TimeSpan TimeToAlarm
		{
			get
			{
				return AlarmDate.Subtract(DateTimeOffset.Now);
			}
		}
		public bool IsOutdated
		{
			get
			{
				return TimeToAlarm.TotalSeconds < 0;
			}
		}

		public ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
		{
			AlarmDate = alarmDate;
			AlarmMessage = alarmMessage;
		}

		public virtual void WriteProperties()
		{
			Console.WriteLine($"Type: {ToString()}\n" +
				$"Alarm date: {AlarmDate}\n" +
				$"Alarm message: {AlarmMessage}\n" +
				$"Time to alarm: {TimeToAlarmLeft(TimeToAlarm)}\n" +
				$"Is outdated: {IsOutdated}\n");
		}

		public  override string ToString()
		{ 
			Type objectType = typeof(L12_HomeWork.ReminderItem);
			string result = $"{base.ToString().Substring(objectType.Namespace.Length + 1)}";
			
			return result;
		}
	}
}
