using System;
using System.Collections.Generic;

namespace L14_ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");

            using ErrorList errorList = new ErrorList("System");
             errorList.Add("Ошибка №1");
             errorList.Add("Ошибка №2");
            /*foreach (string error in errorList)
            {
                Console.WriteLine($"{errorList.Category}: {error}");
            }*/
            //ErrorList.OutputPrefixFormat = "";//Так можно переопределить формат!

            errorList.WriteToConsole();
        }
    }
}
