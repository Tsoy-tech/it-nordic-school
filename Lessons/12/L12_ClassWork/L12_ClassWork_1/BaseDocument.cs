using System;
using System.Collections.Generic;
using System.Text;

namespace L12_ClassWork_1
{
    class BaseDocument
    {
        public string DocName { get; set; }
        public string DocNumber { get; set; }
        public DateTimeOffset IssueDate { get; set; }

        public virtual string PropertiesString //
        {
            get 
            {
                return $"{DocName} № {DocNumber}\n" +
                    $"Issue date {IssueDate: d\\.MM\\.yyyy}\n";
            }
        }

        public BaseDocument(string docName, string docNumber, DateTimeOffset issueDate)
        {
            DocName = docName;
            DocNumber = docNumber;
            IssueDate = issueDate;
        }

        public BaseDocument() { }

        public void WriteToConsole()
        {
            Console.WriteLine(PropertiesString);
        }
    }
}
