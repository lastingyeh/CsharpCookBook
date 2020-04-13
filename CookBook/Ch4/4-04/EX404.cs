using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace CookBook.Ch4
{
    public static class EX404
    {
        public static void Run()
        {
            string[] names =
            {
                "Jello", "Apple", "Bar", "Æble",
                "Forsooth", "Orange", "Zanzibar"
            };

            CultureInfo da = new CultureInfo("da-DK");
            CultureInfo us = new CultureInfo("en-US");

            CultureStringComparer comparer =
                new CultureStringComparer(da, CompareOptions.None);
            var query = names.OrderBy(n => n, comparer);

            Console.WriteLine($"Ordered by specific culture : " +
                $"{comparer.CurrentCultureInfo.Name}");

            foreach (var name in query)
                Console.WriteLine(name);

            // change CurrentCultureInfo = us
            comparer.CurrentCultureInfo = us;
            Console.WriteLine($"Ordered by specific culture : " +
               $"{comparer.CurrentCultureInfo.Name}");

            foreach (var name in query)
                Console.WriteLine(name);

            // CurrentThread
            query = from n in names
                    orderby n
                    select n;
            Console.WriteLine("Ordered by Thread.CurrentThread.CurrentCulture : " +
                $"{Thread.CurrentThread.CurrentCulture.Name}");
            foreach (string name in query)
                Console.WriteLine(name);
        }
    }
}
