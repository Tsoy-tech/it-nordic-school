using System;

namespace Reminder.Parsing
{
    public static class MessageParser
    {
        public static ParsedMessage Parse(string input)
        {
            
            if (string.IsNullOrWhiteSpace(input))
                return null;
            
            DateTimeOffset date;
            int spaceIndex = input.IndexOf(' ');
            string sourceMessage = input.Trim();
            string potentialDate = sourceMessage.Substring(0, spaceIndex);

            try
            {
                date = DateTimeOffset.Parse(potentialDate);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
                //event AddingFailed
            }

            return new ParsedMessage()
            {
                Date = date,
                Message = sourceMessage.Substring(spaceIndex).TrimStart()
            };
        
        }
    }
}
