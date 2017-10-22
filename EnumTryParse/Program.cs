using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace EnumTryParse
{
    class SecondOne
    {
        public string Msg { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            object message = new SecondOne() { Msg = "MyClassMessage" };

            Console.WriteLine("Returned Type is: {0} value is: {1}", GetMessageType(message).GetType().Name, GetMessageType(message), "PONY", "HONY", "BONY");
            Console.ReadKey();
        }

        public static MyEnumFirst GetMessageType(object message)
        {
            MyEnumFirst msg;
            Enum.TryParse(message.GetType().Name, out msg);
            return msg;
        }
    }
}
