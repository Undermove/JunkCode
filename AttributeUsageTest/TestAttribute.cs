using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeUsageTest
{

    [AttributeUsage(AttributeTargets.Class , Inherited = true, AllowMultiple = false)]
    public class TestAttribute : Attribute
    {
        public string SomeString { get; set; }
    }
}
