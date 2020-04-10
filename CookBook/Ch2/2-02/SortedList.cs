using System;
using System.Collections.Generic;

namespace CookBook.Ch2
{
    public class SortedList<T>:List<T>
    {
        public new void Add(T item)
        {
            int position = this.BinarySearch(item);

            if (position < 0)
                position = ~position;

            this.Insert(position, item);
        }

        public void ModifySorted(T item, int index)
        {
            this.RemoveAt(index);

            int position = this.BinarySearch(item);

            if(position < 0)
                position = ~position;


            this.Insert(position, item);
        }
    }
}
