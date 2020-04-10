using System;
using System.Collections.Generic;

namespace CookBook.Ch1
{
    public static class EX103
    {
        public static void TestSearch()
        {
            List<Square> listOfSquares = new List<Square>{
                new Square(1,3),
                new Square(4,3),
                new Square(2,1),
                new Square(6,1)
            };

            IComparer<Square> heightCompare = new CompareHeight();

            // Test List<Square>
            Console.WriteLine("List<Square>");
            Console.WriteLine("Original list");

            foreach (Square square in listOfSquares)
            {
                Console.WriteLine(square.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Sorted list using IComparer<Square>=heightCompare");
            listOfSquares.Sort(heightCompare);

            foreach (Square square in listOfSquares)
            {
                Console.WriteLine(square.ToString());
            }

            // Compare => 0
            Console.WriteLine();
            Console.WriteLine("Search using IComparer<Square>=heightCompare");
            int found = listOfSquares.BinarySearch(new Square(1, 5), heightCompare);
            Console.WriteLine($"Found (1,5): {found}");

            Console.WriteLine();
            Console.WriteLine("Sorted list using IComparable<Square>");
            listOfSquares.Sort();
            foreach (Square square in listOfSquares)
            {
                Console.WriteLine(square.ToString());
            }
            // CompareTo => 0
            Console.WriteLine();
            Console.WriteLine("Search using IComparable<Square>");
            found = listOfSquares.BinarySearch(new Square(1, 2)); // Use IComparable
            Console.WriteLine($"Found (1,2): {found}");

            // Test SortedList<Square>
            var sortedListOfSquares = new SortedList<int, Square>() {
                {0, new Square(1,3) },
                {2, new Square(4,3) },
                {1, new Square(2,1) },
                {4, new Square(6,1) }
            };

            Console.WriteLine();
            Console.WriteLine("SortedList<Square>");

            foreach (KeyValuePair<int, Square> kvp in sortedListOfSquares)
            {
                Console.WriteLine($"{kvp.Key} : {kvp.Value}");
            }

            Console.WriteLine();
            bool foundItem = sortedListOfSquares.ContainsKey(2);
            Console.WriteLine($"sortedListOfSquares.ContainsKey(2): {foundItem}");

            Console.WriteLine();
            Square value = new Square(6, 1);
            foundItem = sortedListOfSquares.ContainsValue(value);
            Console.WriteLine($"sortedListOfSquares.ContainsValue (new Square(6,1)): {foundItem}");

        }
    }
}
