using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TasksExaples
{
    public class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Console.WriteLine("Shity tasks example start");
            Console.ReadKey();
            Task task = new Task(() =>
            {
                Thread.Sleep(5000);
                i = 10;
                Console.WriteLine("Shity long task complete");
            });

            Task taskAfterTask = new Task(() =>
            {
                if (i > 0)
                {
                    Console.WriteLine("Oh stupid but works!");
                }
            });

            task.ContinueWith(task1 => taskAfterTask.Start());
            task.Start();

            Console.WriteLine("Continue when all shit");
            Console.ReadKey();

            List<Task> listOfTasks = new List<Task>();

            for (int j = 0; j < 100; j++)
            {
                var jLocal = j;
                listOfTasks.Add(new Task(() =>
                {
                    Thread.Sleep(10);
                    Console.Write("Stupid j {0}", jLocal);
                }));
            }

            Stopwatch sw = Stopwatch.StartNew();
            Task.Factory.ContinueWhenAll(listOfTasks.ToArray(), tasks => { Console.WriteLine("Complete!");});

            Parallel.ForEach(listOfTasks, task1 => task1.Start());
            sw.Stop();
            Console.WriteLine("Elapsed:", sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
