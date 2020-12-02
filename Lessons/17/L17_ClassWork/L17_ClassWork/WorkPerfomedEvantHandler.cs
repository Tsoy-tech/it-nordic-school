using System;
using System.Collections.Generic;
using System.Text;

namespace L17_ClassWork
{
    public partial class Worker
    {
        public delegate void WorkPerfomedEvantHandler(int hours, WorkType workType);
    }
}
