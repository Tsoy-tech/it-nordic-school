using System;

namespace L12_ClassWork_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var doc1 = new BaseDocument()
            {
                DocName = "Договор",
                DocNumber = "1",
                IssueDate = DateTimeOffset.Now
            };

            doc1.WriteToConsole();

            var doc2 = new Passport()
            {
                DocName = "Passport",
                DocNumber = "25461325",
                Country = "Russia",
                IssueDate = DateTimeOffset.Parse("2013-06-30"),
                PersonName = "Ivanov Ivan Ivanovich"
            };

            doc2.WriteToConsole();*/

            var doc1 = new BaseDocument("Договор", "1", DateTimeOffset.Now);
            var doc2 = new Passport("25461325", 
                DateTimeOffset.Parse("2013-06-30"), 
                "Russia", "Ivanov Ivan Ivanovich");

            doc1.WriteToConsole();
            doc2.WriteToConsole();

            ////////////////////////

            BaseDocument doc3 = new Passport("46548364",
                DateTimeOffset.Parse("2016-09-25"),
                "Russia", "Ivanov Petr Konstantinovich");

            doc3.WriteToConsole();            
            
            if(doc3 is Passport)  //Если нет оверрайда! (т.е. new ...)
            {
                ((Passport)doc3).WriteToConsole();
            }
            else
            {
                ((BaseDocument)doc3).WriteToConsole();
            }
        }
    }
}
