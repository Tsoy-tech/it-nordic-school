using System;
using System.Collections.Generic;
using System.Text;

namespace L12_ClassWork
{
    class Person
    {
        public string Name { get; set; }

        public DateTimeOffset DateOfBirth{ get; set;}

        public virtual string ShortDescription
        {
            get { return $"{Name}:{DateOfBirth: d/MM/yyyy}";}
        }

        public void WriteShortDescription()
        {
            Console.WriteLine(ShortDescription);
        }
    }
}
