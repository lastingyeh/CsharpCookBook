using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CookBook.Ch1
{
    public static class EX111
    {
        public static void Run()
        {
            SortedList<int, string> data = new SortedList<int, string>()
            {
                [2] = "two",
                [5] = "five",
                [3] = "three",
                [1] = "one"
            };

            foreach (KeyValuePair<int, string> kvp in data)
            {
                Console.WriteLine($"\t {kvp.Key}\t{kvp.Value}");
            }

            Console.WriteLine();

            var query = from d in data
                        orderby d.Key descending
                        select d;

            foreach (KeyValuePair<int, string> kvp in query)
            {
                Console.WriteLine($"\t {kvp.Key}\t{kvp.Value}");
            }

            Console.WriteLine();

            // add data
            data.Add(4, "four");

            query = from d in data
                    orderby d.Key descending
                    select d;

            foreach (KeyValuePair<int, string> kvp in query)
            {
                Console.WriteLine($"\t {kvp.Key}\t{kvp.Value}");
            }

            Console.WriteLine("");

            foreach (KeyValuePair<int, string> kvp in data)
            {
                Console.WriteLine($"\t {kvp.Key}\t{kvp.Value}");
            }

        }

    }
}
