using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContinueWithTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task testTask = new Task(() => Console.WriteLine("Task completed in {0}", Thread.CurrentThread.ManagedThreadId));
            for (int i = 0; i < 10; i++)
            {
                testTask.ContinueWith(task => Console.WriteLine(Thread.CurrentThread.ManagedThreadId));
            }
            testTask.Start();
            Console.ReadLine();
        }
    }
}
