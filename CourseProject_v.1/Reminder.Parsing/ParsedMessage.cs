using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Parsing
{
    public class ParsedMessage
    {
        public DateTimeOffset Date { get; set; }
        public string Message { get; set; }
    }
}
