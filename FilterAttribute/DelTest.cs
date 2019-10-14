using System;
using System.Collections.Generic;
using System.Text;

namespace FilterAttribute
{
    class DelTest
    {
        public delegate void Method(string p1, out string p2);
        public void GenericMethod(Method method, string message, out string r,Method method2 , string message2, out string r2)
        {
           // r = "";
            //method.DynamicInvoke(message, out r);
            method.Invoke(message, out r);
            method2.Invoke(message2, out r2);
        }
        public void Print(string message,out string res)
        { 
            Console.WriteLine(message);
            res = "Tadaaa";
            
        }
    }
}
