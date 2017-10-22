using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");


        }

        static bool CompletableFuture()
        {
            Random rnd = new Random();
            int a = rnd.Next(1000, 5000);
            Thread.Sleep(a);
            Console.WriteLine("Completed at {0}", a);
        }
    }
}
