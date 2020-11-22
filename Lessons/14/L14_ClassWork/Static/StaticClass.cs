using System;
using System.Collections.Generic;
using System.Text;

namespace L14_ClassWork.Static
{
    public class StaticClass
    {
        private static int _sum = 0;
        public static int SumWeght { get { return _sum; } }

        private int _weight;

        public int Weight
        {
            get { return _weight; }
            set 
            {
                _sum = _sum - _weight + value;
                _weight = value; 
            }
        }

    }
}
