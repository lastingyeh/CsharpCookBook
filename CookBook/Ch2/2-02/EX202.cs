using System;

namespace CookBook.Ch2._2_02
{
    public static class EX202
    {
        public static void Run()
        {
            SortedList<int> sortedList = new SortedList<int>();
            sortedList.Add(200);
            sortedList.Add(20);
            sortedList.Add(2);
            sortedList.Add(7);
            sortedList.Add(10);
            sortedList.Add(0);
            sortedList.Add(100);
            sortedList.Add(-20);
            sortedList.Add(56);
            sortedList.Add(55);
            sortedList.Add(57);
            sortedList.Add(200);
            sortedList.Add(-2);
            sortedList.Add(-20);
            sortedList.Add(55);
            sortedList.Add(55);

            //Display it
            foreach (var i in sortedList)
            {
                Console.WriteLine(i);
            }

            //Now modify a value at a particular index
            sortedList.ModifySorted(0, 5);
            sortedList.ModifySorted(1, 10);
            sortedList.ModifySorted(2, 11);
            sortedList.ModifySorted(3, 7);
            sortedList.ModifySorted(4, 2);
            sortedList.ModifySorted(2, 4);
            sortedList.ModifySorted(15, 0);
            sortedList.ModifySorted(0, 15);
            sortedList.ModifySorted(223, 15);

            //Display it
            Console.WriteLine();
            foreach (var i in sortedList)
            {
                Console.WriteLine(i);
            }

        }

    }
}
