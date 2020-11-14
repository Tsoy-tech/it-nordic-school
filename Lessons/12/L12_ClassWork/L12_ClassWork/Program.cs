using System;
using L12_ClassWork.Properties;
using System.Threading;
using System.Globalization;

namespace L12_ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            Console.WriteLine(Resources.AnySting);*/

            var p1 = new Person
            {
                Name = "Andrei",
                DateOfBirth = DateTimeOffset.Parse("2020-05-26")
            };

            p1.WriteShortDescription();

            var e1 = new Employee
            {
                Name = "Masha",
                DateOfBirth = DateTimeOffset.Parse("2000-01-01"),
                EmployeeCode = "E00001",
                HireDate = DateTimeOffset.Now
            };

            e1.WriteShortDescription();
        }
    }
}