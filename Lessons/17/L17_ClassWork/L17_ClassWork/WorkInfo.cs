using System;
using System.Collections.Generic;
using System.Text;

namespace L17_ClassWork
{
    public class WorkInfo : EventArgs
    {
        public Worker.WorkType TypeOfWork { get; set; }
        public int Hours { get; set; }

        public WorkInfo(Worker.WorkType type, int hours) 
        {
            TypeOfWork = type;
            Hours = hours;
        }

    }
}
