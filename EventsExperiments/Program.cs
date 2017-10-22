using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsExperiments
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassWithEvent withEvent = new ClassWithEvent();

            withEvent.SomeCustomEvent += WithEventOnSomeCustomEvent;

            object obj = new ClassWithEvent();
            Console.WriteLine($"{obj.GetType()}");
            Console.WriteLine(new StackTrace());
            Console.ReadKey();
        }

        private static void WithEventOnSomeCustomEvent(string s)
        {
            object obj = new ClassWithEvent();
            Console.WriteLine("Event happens!, {0}", s);
            Console.WriteLine($"{obj.GetType()}");
            Console.ReadKey();
        }
    }
}
