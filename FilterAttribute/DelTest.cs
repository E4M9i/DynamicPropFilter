using System;
using System.Collections.Generic;
using System.Text;

namespace FilterAttribute
{
    class DelTest
    {
        public delegate void Method(string p1);
        public void GenericMethod(Method method, string message)
        {
            method.DynamicInvoke(message);
        }
        public void Print(string message) { Console.WriteLine(message); }
    }
}
