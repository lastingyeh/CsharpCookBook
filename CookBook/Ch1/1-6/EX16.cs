using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1.ConstInit
{
    class EX16
    {
        public static void Run()
        {
            Foo obj = new Foo(100);
            // readonly instance var
            Console.WriteLine(obj.bar);
            // const static var
            Console.WriteLine(Foo.y);
            
        }
    }
}
