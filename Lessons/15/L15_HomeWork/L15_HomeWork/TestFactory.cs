using System;
using System.Collections.Generic;
using System.Text;

namespace L15_HomeWork
{
    public static class TestFactory
    {
        /*ILogWriter _factory;

        public TestFactory(ILogWriter logWriter) 
        {
            _factory = logWriter;
        }*/

        public static ILogWriter GetLogWriter<T>(T anyClass, object parameters = null) where T:ILogWriter
       {
            if(anyClass is FileLogWriter)
            {
                string fileName = (string)parameters;
                var obj = new FileLogWriter(fileName);
                return obj;
            }

            if(anyClass is ConsoleLogWriter)
            {
                var obj = new ConsoleLogWriter();
                return obj;
            }

            if(anyClass is MultipleLogWriter)
            {
                List<ILogWriter> listOfLogs = (List<ILogWriter>)parameters;
                var obj = new MultipleLogWriter(listOfLogs);
                return obj;
            }

            return null;
       }
    }
}
