using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace FilterAttribute
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            Console.ReadLine();

            var test = new MainList() {
                ID=22,
                Name="ehsan",
                LastName="Manouchehri"
            };
            
            var dic = new Dictionary<string,object>();
           foreach (var p in test.GetType().GetProperties())
            {
                if (p.GetCustomAttributes(typeof(DuplicateKeyAttribute), false).Count() > 0)
                {

                    //just get the value of the property & cast it.
                    var propertyValue = p.GetValue(test, null);
                    dic.Add(p.Name, p.GetValue(test, null));
                    
                }
            }
            var dyn =DynamicObjHelper.BuildDynamicObj(dic);
            foreach (var d in dic)
            {
                Console.WriteLine(d.Key+d.Value);
                Console.WriteLine(d);
            }
            Console.WriteLine(dyn.ID);
            Console.WriteLine(test.ID);

        }
        public class MainList
        {
            [DuplicateKey]
            public int ID { get; set; }
            [DuplicateKey]
            public string Name { get; set; }
            
            public string LastName { get; set; }
            public string Address { get; set; }
            public int BankAcc { get; set; }

        }
    }
   
    internal class DuplicateKeyAttribute : Attribute
    {
    }
   
}
