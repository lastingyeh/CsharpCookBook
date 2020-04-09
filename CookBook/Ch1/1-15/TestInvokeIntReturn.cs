using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1._1_15
{
    public class TestInvokeIntReturn
    {
        public static int Method1()
        {
            Console.WriteLine("Invoked Method1");
            return 1;
        }

        public static int Method2()
        {
            Console.WriteLine("Invoked Method2");
            return 2;
        }

        public static int Method3()
        {
            Console.WriteLine("Invoked Method3");
            return 3;
        }
    }
}
