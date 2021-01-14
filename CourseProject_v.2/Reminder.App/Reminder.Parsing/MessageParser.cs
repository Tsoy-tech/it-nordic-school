using System;
using System.Linq;

namespace Reminder.Parsing
{
    public static class MessageParser
    {
        public static ParsedMessage Parse(string input)
        {
            
            if (string.IsNullOrWhiteSpace(input))
                return null;
            
            DateTimeOffset date;
            string sourceMessage = input.Trim();

            int spaceIndex = input.IndexOf(' ');

            if (spaceIndex < 0)
                return null;
                        
            string potentialDate = sourceMessage.Substring(0, spaceIndex);

            if (!DateTimeOffset.TryParse(potentialDate, out date) && !TryParseTimeOffSet(potentialDate, out date))
            {
                return null;
			}

            return new ParsedMessage()
            {
                Date = date,
                Message = sourceMessage.Substring(spaceIndex).TrimStart()
            };
        
        }

        private static bool TryParseTimeOffSet(string potentialDate, out DateTimeOffset date)
		{
            potentialDate = potentialDate.ToLower();

            date = DateTimeOffset.Now;
            string number = string.Empty;
            char numberDimension = (char)0;
            bool isLetterAllowed = true;
            for (int i = potentialDate.Length - 1; i >= 0; i--)
            {
                char ch = potentialDate[i];

                if (!char.IsLetterOrDigit(ch))
                    return false;

                if (char.IsLetter(ch) && isLetterAllowed)
                {
                    AddTimeToDate(ref date, numberDimension, number);

                    if (!isLetterAllowed || !new[] { 's', 'm', 'h', 'd' }.Contains(ch))
                        return false;

                    numberDimension = ch;
                    isLetterAllowed = false;
                    continue;
                }

                if (char.IsDigit(ch))
                {
                    number = ch + number;
                    isLetterAllowed = true;
                    continue;
                }
            }

            AddTimeToDate(ref date, numberDimension, number);

            return true;
        }
        private static void AddTimeToDate(ref DateTimeOffset date, char numberDimension, string number)
		{
            switch (numberDimension)
            {
                case 's':
                    date = date.AddSeconds(int.Parse(number));
                    break;
                case 'm':
                    date = date.AddMinutes(int.Parse(number));
                    break;
                case 'h':
                    date = date.AddHours(int.Parse(number));
                    break;
                case 'd':
                    date = date.AddDays(int.Parse(number));
                    break;
            }
        }
    }
}
