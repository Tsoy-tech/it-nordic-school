using System;
using System.ComponentModel;
using System.Dynamic;
using System.Text;

namespace L03_ClassWork
{
	class Program
	{
		static void Main(string[] args)
		{
			/*const int myConstant = 255;
			const int mySecondConstant = myConstant + 1;
			Console.WriteLine(myConstant);
			Console.WriteLine(mySecondConstant);
			Console.WriteLine(mySecondConstant - myConstant);*/

			/*string inpute = Console.ReadLine();
			object i = int.Parse(inpute);
			object j = (int)i + 10;
			Console.WriteLine(Math.Sqrt((int)j)); //приведение типа object r int*/

			/*object s1 = Console.ReadLine();
			Console.WriteLine(((string)s1).Length);

			dynamic s2 = Console.ReadLine();
			Console.WriteLine(s2.Length);

			var a = 3.14f; //float
			var b = 1m; //decimal
			var c = 49l; //long
			var d = (byte)255; //byte*/

			/*int? a1 = null;
			a1 = 5;
			Console.WriteLine(a1.Value); // nulable (null для значимых типов)
			Console.WriteLine(a1.HasValue);*/

			//Массивы

			/*const int index = 3;
			string[] trees = new string[index];
			string[] ages = new string[index];

			for (int i = 0; i < trees.Length; i++)
			{
				Console.WriteLine("Введите наименование " + (i + 1) + "-го дерева");
				trees[i] = Console.ReadLine();
				Console.WriteLine("Введите возраст" + (i + 1) + "-го дерева");
				ages[i] = Console.ReadLine();
			}

			for (int i = 0; i < trees.Length; i++)
			{
				Console.WriteLine(trees[i] + " - возраст в годах:" + ages[i]);
			}*/

			Console.WriteLine("Нажмите любую клавишу");
			ConsoleKeyInfo keyInfo = Console.ReadKey();

			Console.WriteLine($"Key char{ keyInfo.Key}");
			ConsoleModifiers modifiers = keyInfo.Modifiers;

			ConsoleColor fgColor = Console.ForegroundColor; //Сохранение изначального цвета
			ConsoleColor bgColor = Console.BackgroundColor;

			Console.ForegroundColor = ConsoleColor.Green; //цвет шрифта
			Console.BackgroundColor = ConsoleColor.White; //цвет выделения текста

			Console.SetCursorPosition(left: 10, top: 10); //Установка места отображения

			Console.InputEncoding = Encoding.UTF8; //Ввод на кириллице
			Console.OutputEncoding = Encoding.UTF8; 

			if ((modifiers & ConsoleModifiers.Alt) != 0)
				Console.WriteLine("Alt pressed");

			Console.ForegroundColor = fgColor; //Возвращение изначального цвета
			Console.BackgroundColor = bgColor;

			if ((modifiers & ConsoleModifiers.Shift) != 0)
				Console.WriteLine("Shift pressed");

			if ((modifiers & ConsoleModifiers.Control) != 0)
				Console.WriteLine("Control pressed");

			string s = "10";
			s.PadRight(4);
		}
	}
}
