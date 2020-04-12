using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch3
{
    public static class EX306
    {
        public static void Run()
        {
            int i = (int)Math.Round(2.5555);
            Console.WriteLine($"i = {i}");

            double dbl = Math.Round(2.5555, 2);
            Console.WriteLine($"dbl = {dbl}");

            //round always to even number
            double dbl1 = Math.Round(1.5);
            double dbl2 = Math.Round(2.5);

            //rounded up to the nearest even whole number(2) and 2.5 is rounded down to the nearest even whole number(also 2).
            Console.WriteLine($"Math.Round(1.5) = {dbl1}"); // 2
            Console.WriteLine($"Round(2.5) = {dbl2}"); // 2
        }
    }
}
