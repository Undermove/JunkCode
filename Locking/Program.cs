using System;
using System.Threading;

namespace Locking
{
    class Program
    {
        private static bool done;
        public static readonly object Locker = new object();

        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                new Thread(Go).Start();
            }

            Go();
            Console.ReadLine();
        }

        static void Go()
        {
            lock (Locker)
            {
                if (!done)
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    done = true;
                }    
            }
        }
    }
}

