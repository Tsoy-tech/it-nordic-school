using System;
using System.Collections.Generic;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>
            {
                10, 20, 30, 40
            };

            intList.RemoveAt(1);
            intList.Insert(1, 21);

            int[] intArray = new[] { 50, 60 };

            intList.AddRange(intArray);

            string output = string.Join(", ", intList);


            intList.Clear();
            if(intList.Count == 0)
                Console.WriteLine("intList is empty!");


        }
    }
}
