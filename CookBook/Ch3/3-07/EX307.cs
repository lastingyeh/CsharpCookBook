using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch3
{
    public static class EX307
    {
        public static double RoundUp(double valueToRound) =>
            Math.Floor(valueToRound + 0.5);
        public static double RoundDown(double valueToRound)
        {
            double floorValue = Math.Floor(valueToRound);
            if ((valueToRound - floorValue) > .5)
            {
                return floorValue + 1;
            }
            return floorValue;
        }

        public static void Run()
        {
            double v1 = RoundDown(2.5);
            double v2 = RoundDown(2.1);
            double v3 = RoundDown(2.8);

            Console.WriteLine("RoundDown");
            Console.WriteLine($"2.5 = {v1}");
            Console.WriteLine($"2.1 = {v2}");
            Console.WriteLine($"2.8 = {v3}");

            Console.WriteLine();

            v1 = RoundUp(1.5);
            v2 = RoundUp(1.1);
            v3 = RoundUp(1.8);

            Console.WriteLine("RoundUp");
            Console.WriteLine($"1.5 = {v1}");
            Console.WriteLine($"1.1 = {v2}");
            Console.WriteLine($"1.8 = {v3}");
        }
    }
}
