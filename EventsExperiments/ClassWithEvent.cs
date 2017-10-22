using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsExperiments
{
    public class ClassWithEvent
    {
        public event Action<string> SomeCustomEvent;

        public virtual void OnSomeCustomEvent(string obj)
        {
            Action<string> handler = SomeCustomEvent;
            
            if (handler != null)
            {
                handler(obj);
            }
        }

        public virtual void OnSomeCustomEvent2(string obj)
        {
            Action<string> handler = SomeCustomEvent;

            if (handler != null)
            {
                Console.WriteLine("Some eventHandler2");

                handler(obj);
            }
        }
    }
}
