using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch3
{
    public static class EX308
    {
        public static void Run()
        {
            long lhs = 34000;
            long rhs = long.MaxValue;

            try
            {
                int result = lhs.AddNarrowingChecked(rhs);
                Console.WriteLine(result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }
        }

        public static void CheckAsConvertToShort()
        {
            int sourceValue = 34000;
            short destinationValue = 0;

            if (sourceValue <= short.MaxValue && sourceValue >= short.MinValue)
            {
                destinationValue = (short)sourceValue;
                Console.WriteLine(destinationValue);
            }
            else
            {
                Console.WriteLine("convert loss");
            }
        }
    }
}
