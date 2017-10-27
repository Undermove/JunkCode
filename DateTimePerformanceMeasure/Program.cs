using System;
using System.Diagnostics;

namespace DateTimePerformanceMeasure
{
    class Program
    {
        static void Main(string[] args)
        {
            const int iterationsCount = 1000000;

            long temp = 0;
            DateTime tempDate;

            Stopwatch sw = new Stopwatch();

            for (int j = 0; j < 4; j++)
            {
                decimal dateTimeCallTicks = 0;
                for (int i = 0; i < iterationsCount; i++)
                {
                    sw.Restart();
                    tempDate = DateTime.UtcNow;
                    sw.Stop();
                    dateTimeCallTicks += sw.ElapsedTicks;
                }
                decimal median = dateTimeCallTicks / iterationsCount;
                Console.WriteLine($"DateTime {median}");

                decimal tickCountCallTicks = 0;
                for (int i = 0; i < iterationsCount; i++)
                {
                    sw.Restart();
                    temp = Environment.TickCount;
                    sw.Stop();
                    tickCountCallTicks += sw.ElapsedTicks;
                }
                median = tickCountCallTicks / iterationsCount;
                Console.WriteLine($"TickCount {median}");
                Console.WriteLine();
            }


            Console.ReadLine();
        }
    }
}
