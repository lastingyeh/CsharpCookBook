using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBook.Ch2._2_1
{
    static class CollectionExtMethods
    {
        //Looking for Duplicate Items in a List<T>
        public static IEnumerable<T> GetAll<T>(this List<T> myList, T searchValue) =>
            myList.Where(t => t.Equals(searchValue));

        //Search for Duplicate Items at sorted List 
        public static T[] BinarySearchGetAll<T>(this List<T> myList, T searchValue)
        {
            List<T> retObjs = new List<T>();
            // find first item
            int center = myList.BinarySearch(searchValue);

            if (center > 0)
            {
                retObjs.Add(myList[center]);

                int left = center;
                while (left > 0 && myList[left - 1].Equals(searchValue))
                {
                    left -= 1;
                    retObjs.Add(myList[left]);
                }

                int right = center;
                while (right < (myList.Count - 1) && myList[right + 1].Equals(searchValue))
                {
                    right += 1;
                    retObjs.Add(myList[right]);
                }
            }
            return retObjs.ToArray();
        }

        //GetALL Count
        public static int CountAll<T>(this List<T> myList, T searchValue) =>
            myList.GetAll(searchValue).Count();

        //GetALL Count at sorted List
        public static int BinarySearchCountAll<T>(this List<T> myList, T searchValue) =>
            BinarySearchGetAll(myList, searchValue).Count();
    }
}
