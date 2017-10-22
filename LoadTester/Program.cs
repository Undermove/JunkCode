using System;
using System.Threading;
using System.Threading.Tasks;

namespace LoadTester
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("FIRST STEP. Enter threads number and press enter");

                int numOfThreads = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Starting {numOfThreads} of infinite parallel loops. Press ENTER to stop. Or it automatically stops after 5 minutes.");

                CancellationTokenSource cts = new CancellationTokenSource(300000);

                for (int i = 0; i < numOfThreads; i++)
                {
                    Task.Factory.StartNew(() =>
                    {
                        do
                        {
                            int j = 1;
                            j++;
                            if (cts.IsCancellationRequested)
                            {
                                Console.WriteLine("Task completed.");
                            }
                        } while (!cts.IsCancellationRequested);

                    }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Current);
                }
                Console.ReadLine();
                cts.Cancel();
            }
        }
    }
}
