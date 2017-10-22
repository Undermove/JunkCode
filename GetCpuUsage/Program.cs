using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetCpuUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Process.GetProcesses()
                .Single(process => process.ProcessName.Contains(Process.GetCurrentProcess().ProcessName));

            CreateLoadOnCpu();

            while (true)
            {
                using (PerformanceCounter pcProcess = new PerformanceCounter("Process", "% Processor Time", a.ProcessName))
                {
                    pcProcess.NextValue();
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Process:{0} CPU% {1}", a.ProcessName, pcProcess.NextValue()/Environment.ProcessorCount);
                }
            }
        }

        private static void CreateLoadOnCpu()
        {
            for (int i = 0; i < 2; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    do
                    {
                        int j = 1;
                        j++;
                    } while (true);
                });
            }
        }
    }
}
