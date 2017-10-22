using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeUsageTest
{
    [Test(SomeString = "Some derived string!!!!!")]
    class SomeClassDerived : SomeClassBase
    {
    }
}
