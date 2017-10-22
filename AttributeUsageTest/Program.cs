using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeUsageTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof (SomeClassDerived);

            Assembly assy = type.Assembly;

            Attribute attribute = type.GetCustomAttribute(typeof(TestAttribute));

            TestAttribute test = (TestAttribute)attribute;

            Console.WriteLine(test.SomeString);
            Console.ReadKey();
        }
    }
}
