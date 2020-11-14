using System;
using System.Collections.Generic;
using System.Text;

namespace L12_ClassWork
{
    class Employee : Person
    {
        public string EmployeeCode { get; set; }

        public DateTimeOffset HireDate { get; set; }

        public override string ShortDescription
        {
            get { return $"{Name}:{DateOfBirth: d\\.MM\\.yyyy}, {EmployeeCode} // {HireDate: d\\.MM\\.yyyy}"; }
        }

    }
}
