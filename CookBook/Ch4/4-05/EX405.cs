using System;

namespace CookBook.Ch4
{
    public static class EX405
    {
        public static void Run()
        {
            decimal?[] prices = new decimal?[10] { 13.5M, 17.8M, 92.3M, 0.1M, 15.7M,
                19.99M, 9.08M, 6.33M, 2.1M, 14.88M };

            Console.WriteLine(prices.WeightedMovingAverage());

            double?[] dprices = new double?[10] { 13.5, 17.8, 92.3, 0.1, 15.7, 19.99, 9.08, 6.33, 2.1, 14.88 };
            Console.WriteLine(dprices.WeightedMovingAverage());

            float?[] fprices = new float?[10] { 13.5F, 17.8F, 92.3F, 0.1F, 15.7F, 19.99F, 9.08F, 6.33F, 2.1F, 14.88F };
            Console.WriteLine(fprices.WeightedMovingAverage());

            int?[] iprices = new int?[10] { 13, 17, 92, 0, 15, 19, 9, 6, 2, 14 };
            Console.WriteLine(iprices.WeightedMovingAverage());

            long?[] lprices = new long?[10] { 13, 17, 92, 0, 15, 19, 9, 6, 2, 14 };
            Console.WriteLine(lprices.WeightedMovingAverage());

            Console.WriteLine("Average on short-based collections");
            short[] sprices = new short[10] { 13, 17, 92, 0, 15, 19, 9, 6, 2, 14 };
            Console.WriteLine(sprices.Average());
        }
    }
}
