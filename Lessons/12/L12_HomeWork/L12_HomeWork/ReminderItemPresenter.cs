using System;
using System.Collections.Generic;
using System.Text;

namespace L12_HomeWork
{
	public class ReminderItemPresenter
	{
		public static string TimeToAlarmLeft(TimeSpan time)
		{
			string days = string.Empty;
			string timeLeftFormat = string.Empty;

			if (time.Days != 0 && time.Days != 1)
			{
				days = $"{time.Days} days";
			}
			else if (time.Days == 1)
			{
				days = $"{time.Days} day";
			}

			timeLeftFormat = $"{days} {time:hh\\:mm\\:ss}";
			return timeLeftFormat.Trim();
		}
	}
}
