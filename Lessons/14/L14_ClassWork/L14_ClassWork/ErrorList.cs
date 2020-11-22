using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace L14_ClassWork
{
    public class ErrorList: IDisposable, IEnumerable<string>
    {
        private List<string> _errors;

        public static string OutputPrefixFormat { get; set; }
        public string Category { get; }

        static ErrorList()
        {
            OutputPrefixFormat = "MMMM d, yyyy (h:mm tt)";
        }

        public ErrorList(string category)
        {
            _errors = new List<string>();
            Category = category;
        }

        public void WriteToConsole()
        {
            foreach (string errors in _errors)
            {
                Console.WriteLine($"{DateTimeOffset.Now.ToString(OutputPrefixFormat)}   {Category}: {errors}");
            }
        }

        public void Dispose()
        {
            _errors.Clear();
            _errors = null;
        }
        public void Add(string errorMessage)
        {
            _errors.Add(errorMessage);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _errors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _errors.GetEnumerator();
        }
    }
}
