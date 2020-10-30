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

            input = s4; 
            //вышеперечисленные операции не зависят от переменных факторов (+1)
            //Calculations

            foreach (char bracket in input) //N - количество символов в input
            {
                switch(bracket) //Выбор символа в input (+1)
				{
                    case '(':
                    case '[': // Выбор кейса (+1)
                        indexOfBracket = openBrackets.IndexOf(bracket); //определение индекса(+1) и присваивание(+1)
                        stackOfBrackets.Push(indexOfBracket); //вставка объекта как верхнего элемента стека (+1)
                        break;
                    case ')':
                    case ']': // Выбор кейса (+1)
                        indexOfBracket = closeBrackets.IndexOf(bracket); // определение индекса(+1) и присваивание(+1)
                        if (stackOfBrackets.Peek() != indexOfBracket) // возвращение объекта в начале стека (+1) и его сравнение (+1)
                                break;
                        stackOfBrackets.Pop(); // удаление объекта в начале стека(+1)
                        break;
                }
			}

            //Output
            // Нижеперечисленные операции не зависят от переменных факторов (+1)
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
//При условии, что input приравнен к пустой строке(N = 0):
//Ω = 2

//Если выполняется каждый блок, 
//то одна половина операций будет выполняться с открывающими скобками,
//другая - с закрывающими.
//Только в таком случае, в блоке с закрывающими скобками
//будет выполняться максимальное количество операций(7)!
//О(N) = (5 * N/2 + 7 * N/2) + 2
//О(N) = 2.5N + 3.5N + 2
//О(N) = 6N + 2
//N - количество символов в input(s1-8)

//Также рассмотрена ситуация, где все элементы - закрывающие скобки.
//В данном случае, количество операций составит 6.
//О(N) = 6N + 2
//Функция будет идентичной.