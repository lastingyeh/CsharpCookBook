using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1
{
    public class TestInvokeBoolReturn
    {
        public static bool Method1()
        {
            Console.WriteLine("Invoked Method1");
            return true;
        }

        public static bool Method2()
        {
            Console.WriteLine("Invoked Method2");
            return false;
        }

        public static bool Method3()
        {
            Console.WriteLine("Invoked Method3");
            return true;
        }
    }
}
