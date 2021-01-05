using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain
{
	public class ParsingFailedEventArgs
	{
		public string ContactId { get; set; }
		public string InputText { get; set; }

		public ParsingFailedEventArgs(string contactId, string inputText)
		{
			ContactId = contactId;
			InputText = inputText;
		}
	}
}
