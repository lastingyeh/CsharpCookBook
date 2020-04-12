using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch3
{
    public static class EX305
    {
        public static void Run()
        {
            string str = "12.5";
            double result = 0;

            if (double.TryParse(str,
                System.Globalization.NumberStyles.Float,
                System.Globalization.NumberFormatInfo.CurrentInfo,
                out result))
            {
                Console.WriteLine($"{result} is double");
            }
        }
    }
}
