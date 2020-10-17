using System;

namespace L06_ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //Постусловие
            /* string str = String.Empty;
             do
             {
                 Console.Write("Введите любое слово или exit для выхода:");
                 str = Console.ReadLine();

                 if (str == "exit")
                     break;

                 if (str.Length > 15)
                 {
                     Console.WriteLine("Too long string. Try another!");
                     continue;
                 }

                 Console.WriteLine($"Entered string length is {str.Length}");
             }
             while (true);*/

            //Предусловие

            /*int i = 0;
            int sum = 0;
            int sumPlus = 0;
            int sumMinus = 0;
            int[] numbers = { -10, 100, 50, 7, 9, -64 };

            while(i < numbers.Length)
            {
                sum += numbers[i];
                Console.WriteLine($"Current sum (step-{i+1}): " + sum);
                i++;
            }

            Console.WriteLine("Total sum: " + sum);

            for(int j = 0; j < numbers.Length; j++)
            {
                if (numbers[j] >= 0)
                {
                    sumPlus += numbers[j];
                    Console.WriteLine($"Current sum (PLUS)(step-{j + 1}): " + sumPlus);
                }
                else
                {
                    sumMinus += numbers[j];
                    Console.WriteLine($"Current sum (MINUS)(step-{j + 1}): " + sumMinus);
                }
            }
            Console.WriteLine("Total PLUS: " + sumPlus);
            Console.WriteLine("Total MINUS: " + sumMinus);
            Console.WriteLine($"Total sum: { sumMinus + sumPlus}");*/

            float sumAverage = 0;
            float sumWeek = 0;
            float sumDay = 0;
            float totalMarks = 0;
            float totalSum = 0;

            var marks = new []
            {
                new []{ 2, 3, 3, 2, 3},
                new []{ 2, 4, 5, 3},
                null,
                new []{ 5, 5, 5, 5},
                new []{ 4 }
            };

            for(int i = 0; i < marks.Length; i++)
            {
                if (marks[i] == null)
                    continue;

                for (int j = 0; j < marks[i].Length; j++)
                {
                    sumDay += (float)marks[i][j]/marks[i].Length;
                    sumWeek += (float)marks[i][j];
                }

                totalMarks = marks.Length * marks[i].Length;
                totalSum += sumDay;
                Console.WriteLine($"Средний балл за {i+1}-день: {sumDay}");
                sumDay = 0;
            }

            sumAverage = totalSum / totalMarks;
            Console.WriteLine($"Средний балл за неделю: {sumAverage}");

        }
    }
}
