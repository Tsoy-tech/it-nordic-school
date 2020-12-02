using System;
using System.Threading;
using static L17_ClassWork.Worker;

namespace L17_ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {   
            var worker = new Worker();

            worker.WorkCompleted += (object sender, EventArgs e) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Work completed");
                Console.ResetColor();
            };

            worker.WorkPerfomed += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{((Worker)sender).Name} {e.TypeOfWork} in progress ({e.Hours} hours)...");
                Console.ResetColor();
            };

            Thread t1 = new Thread(() => worker.DoWork(8, WorkType.Work));
            Thread t2 = new Thread(() => worker.DoWork(2, WorkType.DoNothing));
            
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }
    }
}
