using System;

namespace L12_HomeWork
{
	class ReminderItem
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
		public ReminderItem() { }

		public virtual void WriteProperties()
		{
			Console.WriteLine($"Type: {ToString()}\n" +
				$"Alarm date: {AlarmDate}\n" +
				$"Alarm message: {AlarmMessage}\n" +
				$"Time to alarm: {TimeToAlarmLeft(TimeToAlarm)}\n" +
				$"Is outdated: {IsOutdated}\n");
		}
		public string TimeToAlarmLeft(TimeSpan time)
		{
			string days = string.Empty;
			string timeLeftFormat = string.Empty;

			if (time.Days != 0 && time.Days != 1)
			{
				days = $"{time.Days.ToString()} days";
			}
			else if(time.Days == 1)
			{
				days = $"{time.Days.ToString()} day";
			}

			timeLeftFormat = $"{days} {time:hh\\:mm\\:ss}";
			return timeLeftFormat.Trim();
		}
		public  override string ToString()
		{ 
			Type objectType = typeof(L12_HomeWork.ReminderItem);
			string result = $"{base.ToString().Substring(objectType.Namespace.Length + 1)}";
			
			return result;
		}
	}
}
