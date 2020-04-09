using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch2._2_01
{
    public static class EX201
    {
        public static void GetSearchALL()
        {
            List<int> listRetrieval =
                new List<int>() { -1, -1, 1, 2, 2, 2, 2, 3, 100, 4, 5 };

            Console.WriteLine("--GET ALL--");
            IEnumerable<int> items = listRetrieval.GetAll(2);
            foreach (var item in items)
            {
                Console.WriteLine($"item(2): {item}");
            }

            Console.WriteLine();

            items = listRetrieval.GetAll(-2);
            foreach (var item in items)
            {
                Console.WriteLine($"item(-2): {item}");
            }

            Console.WriteLine();

            items = listRetrieval.GetAll(5);
            foreach (var item in items)
            {
                Console.WriteLine($"item(5): {item}");
            }

            Console.WriteLine("\r\n--BINARY SEARCH GET ALL--");
            listRetrieval.Sort();
            int[] listItems = listRetrieval.BinarySearchGetAll(-2);
            foreach (var item in listItems)
            {
                Console.WriteLine($"item(-2): {item}");
            }

            Console.WriteLine();

            listItems = listRetrieval.BinarySearchGetAll(2);
            foreach (var item in listItems)
            {
                Console.WriteLine($"item(2): {item}");
            }

            Console.WriteLine();

            listItems = listRetrieval.BinarySearchGetAll(5);
            foreach (var item in listItems)
            {
                Console.WriteLine($"item(5): {item}");
            }
        }

        public static void GetSearchALLCount()
        {
            List<int> list = new List<int>() { -2, -2, -1, -1, 1, 2, 2, 2, 2, 3, 100, 4, 5 };

            Console.WriteLine("--CONTAINS TOTAL--");
            int count = list.CountAll(2);
            Console.WriteLine($"Count2: {count}");

            count = list.CountAll(3);
            Console.WriteLine($"Count3: {count}");

            count = list.CountAll(1);
            Console.WriteLine($"Count1: {count}");

            Console.WriteLine("\r\n--BINARY SEARCH COUNT ALL--");
            list.Sort();

            count = list.BinarySearchCountAll(2);
            Console.WriteLine($"Count2: {count}");

            count = list.BinarySearchCountAll(3);
            Console.WriteLine($"Count3: {count}");

            count = list.BinarySearchCountAll(1);
            Console.WriteLine($"Count1: {count}");
        }
    }
}
