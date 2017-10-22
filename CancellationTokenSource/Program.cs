using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace CancellationTokenSourceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> list = new List<object>();
            CancellationTokenSource cts = new CancellationTokenSource();

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    list.Add(new object());
                    if (cts.IsCancellationRequested)
                    {
                        return;
                    }
                    Thread.Sleep(3);
                }
            }, cts.Token);

            Thread.Sleep(200);

            cts.Cancel();

            Thread.Sleep(3000);

            Console.WriteLine(list.Count);
            Console.ReadLine();
        }
    }
}
