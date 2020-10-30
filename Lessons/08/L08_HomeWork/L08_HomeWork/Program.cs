using System;
using System.Collections.Generic;
using System.Linq;

namespace L08_HomeWork
{
	class Program
	{
		static void Main(string[] args)
		{
            var s1 = "()";            // True
            var s2 = "[]()";          // True
            var s3 = "[[]()]";        // True
            var s4 = "([([])])()[]";  // True

            var s5 = "(";             // False
            var s6 = "[][)";          // False
            var s7 = "[(])";          // False
            var s8 = "(()[]]";        // False

            int indexOfBracket = 0;
            string input = string.Empty;
            string status = string.Empty;
			ConsoleColor color;
            const string openBrackets =  "([";
            const string closeBrackets = ")]";
            Stack<int> stackOfBrackets = new Stack<int>();

            //Input

            input = s7;
            
            //Calculations

            foreach (char bracket in input)
			{
                switch(bracket)
				{
                    case '(':
                    case '[':
                        indexOfBracket = openBrackets.IndexOf(bracket);
                        stackOfBrackets.Push(indexOfBracket);
                        break;
                    case ')':
                    case ']':
                        indexOfBracket = closeBrackets.IndexOf(bracket);
                        if (stackOfBrackets.Peek() != indexOfBracket)
                                break;
                        stackOfBrackets.Pop();
                        break;
                }
			}

            //Output

            if (stackOfBrackets.Count == 0)
            {
                status = "корректна!";
                color = ConsoleColor.Green;
            }
            else
			{
                status = "некорректна!";
                color = ConsoleColor.Red;
			}

            Console.Write($"Строка \"{input}\" ");
            WriteLineWithColor(status, color);
        }
        static void WriteLineWithColor(string text, ConsoleColor color)
		{
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
		}
    }
}
