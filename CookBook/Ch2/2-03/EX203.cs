using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.Ch1._2_03
{
    public static class EX203
    {
        public static void Run()
        {
            Dictionary<string, string> hash = new Dictionary<string, string>()
            {
                ["2"]="two",
                ["1"] = "one",
                ["5"] = "five",
                ["4"] = "four",
                ["3"] = "three",
            };

            Console.WriteLine("Sorted by Keys ASC");

            var x = from k in hash.Keys orderby k ascending select k;
            foreach (var s in x)
            {
                Console.WriteLine($"Key: {s} Value: {hash[s]}");
            }

            Console.WriteLine("Sorted by Keys DESC");

            x = from k in hash.Keys orderby k descending select k;
            foreach (var s in x)
            {
                Console.WriteLine($"Key: {s} Value: {hash[s]}");
            }

            Console.WriteLine("Sorted by Values ASC");

            x = from v in hash.Values orderby v ascending select v;
            foreach (var s in x)
            {
                Console.WriteLine($"Value: {s}");
            }

            Console.WriteLine("Sorted by Values DESC");

            x = from v in hash.Values orderby v descending select v;
            foreach (var s in x)
            {
                Console.WriteLine($"Value: {s}");
            }

            Console.WriteLine("SortedDictionary");
            SortedDictionary<string, string> sortedHash = new SortedDictionary<string, string>()
            {
                ["2"] = "two",
                ["1"] = "one",
                ["5"] = "five",
                ["4"] = "four",
                ["3"] = "three",
            };

            Console.WriteLine("ASC");

            foreach (var key in sortedHash.Keys)
            {
                Console.WriteLine($"Key: {key} Value: {sortedHash[key]}");
            }

            Console.WriteLine("DESC");

            foreach (var key in sortedHash.OrderByDescending(item => item.Key).Select(item => item.Key)) 
            {
                Console.WriteLine($"Key: {key} Value: {sortedHash[key]}");
            }
        }
    }
}
