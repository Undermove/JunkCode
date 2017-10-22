using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingTimerTest
{
    class Program
    {
        static readonly Timer timer = new Timer(Callback, null, Timeout.Infinite, Timeout.Infinite);
        private static int i = 100;

        static void Main(string[] args)
        {
            timer.Change(1000, 1000);
            Console.ReadKey();
        }

        private static void Callback(object state)
        {
            Console.WriteLine("Timer callback {0}", i);
            timer.Change(i+=1000, 0);
        }
    }
}
