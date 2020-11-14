using System;
using System.Collections.Generic;
using System.Text;

namespace L12_ClassWork_1
{
    class Passport : BaseDocument
    {
        public string Country { get; set; }
        public string PersonName { get; set; }

        public Passport(string docNumber, DateTimeOffset issueDate, string country, string personName) : base("Passport", docNumber, issueDate)
        {
            Country = country;
            PersonName = personName;
        }

        public Passport() { }

        public override string PropertiesString 
        {
            get
            {
                return $"{DocName} № {DocNumber}\n" +
                    $"Issue date {IssueDate: d\\.MM\\.yyyy} " +
                    $"in {Country}\n" +
                    $"{PersonName}\n";
            }
        }
    }
}
