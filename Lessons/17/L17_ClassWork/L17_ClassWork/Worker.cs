using System;
using System.Collections.Generic;
using System.Text;

namespace L17_ClassWork
{

    public partial class Worker
    {
        public string Name { get; set; } = "noname";

        public event EventHandler<WorkInfo> WorkPerfomed; // замена WorkPerfomedEvantHandler
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                if (workType == WorkType.Work)
                {
                    Console.WriteLine("$$$$$$$$$$$$$");
                }
                else if(workType == WorkType.DoNothing)
                {
                    Console.WriteLine("Zzzzz...");
                }

                //WorkPerfomed
                WorkPerfomed?.Invoke(this, 
                    new WorkInfo(workType, hours));
            }

            //WorkCompleted;
            WorkCompleted?.Invoke(this, EventArgs.Empty); //? - вызвать если не null
        }
    }
}
