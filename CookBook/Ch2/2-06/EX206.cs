using System;
using System.Collections.Generic;

namespace CookBook.Ch2
{
    public static class EX206
    {
        public static void Run()
        {
            List<string> strings = new List<string>() { "one", null, "three", "four" };

            string str = strings.TrueForAll((string val) =>
            {
                if (val == null)
                    return false;

                return true;

            }).ToString();

            Console.WriteLine(str);
        }
    }
}
