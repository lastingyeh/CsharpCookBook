using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1
{
    public static class EX110
    {
        public static void Run()
        {
            FixedSizeCollection A = new FixedSizeCollection(5);
            FixedSizeCollection B = new FixedSizeCollection(5);
            FixedSizeCollection C = new FixedSizeCollection(5);

            Console.WriteLine(A);
            Console.WriteLine(B);
            Console.WriteLine(C);

            Console.WriteLine(FixedSizeCollection.InstanceCount);

            FixedSizeCollection<bool> gA = new FixedSizeCollection<bool>(5);
            FixedSizeCollection<int> gB = new FixedSizeCollection<int>(5);
            FixedSizeCollection<string> gC = new FixedSizeCollection<string>(5);
            FixedSizeCollection<string> gD = new FixedSizeCollection<string>(5);

            Console.WriteLine(gA);
            Console.WriteLine(gB);
            Console.WriteLine(gC);
            Console.WriteLine(gD);

            Console.WriteLine(FixedSizeCollection<string>.InstanceCount);
        }
    }
}
