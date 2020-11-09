using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace L11_HomeWork
{
	class ReminderItem
	{
		private DateTimeOffset AlarmDate { get; set; }
		private string AlarmMessage { get; set; }
		private TimeSpan TimeToAlarm
		{
			get
			{
				return AlarmDate.Subtract(DateTimeOffset.Now);
			}
		}
		private bool IsOutdated 
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

		public void WriteProperties()
		{
			Console.WriteLine($"Alarm date: {AlarmDate}\n" +
				$"Alarm message: {AlarmMessage}\n" +
				$"Time to alarm: {TimeToAlarmLeft(TimeToAlarm)}\n" +
				$"Is outdated: {IsOutdated}\n");
		}

		private string TimeToAlarmLeft(TimeSpan time)
		{
			string days = string.Empty;
			string timeLeftFormat = string.Empty;

			if (time.Days != 0)
			{
				days = $"{time.Days.ToString()} d.";
			}
			
			timeLeftFormat = $"{days} {time:hh\\:mm\\:ss}";
			return timeLeftFormat.Trim();
		}
	}
}
