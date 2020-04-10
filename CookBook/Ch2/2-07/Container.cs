using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.Ch2
{
    //as foreach doing
    //1. Get the enumerator from the container using IEnumerator.GetEnumerator().
    //2. Access the IEnumerator.Current property for the current object (int) and place itinto i.
    //3. Call IEnumerator.MoveNext(). If MoveNext returns true, go back to step 2, or else end the loop.

    public class Container<T> : IEnumerable<T>
    {
        public Container(){}

        private List<T> _internalList = new List<T>();

        public IEnumerator<T> GetEnumerator() => _internalList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        // reverse iterates
        public IEnumerable<T> GetReverseOrderEnumerator()
        {
            foreach (T item in ((IEnumerable<T>)_internalList).Reverse())
                yield return item;
        }

        // first to last by stepping
        public IEnumerable<T> GetForwardStepEnumerator(int step)
        {
            foreach (T item in _internalList.EveryNthItem(step))
                yield return item;
        }

        // last to first by stepping
        public IEnumerable<T> GetReverseStepEnumerator(int step)
        {
            foreach (T item in ((IEnumerable<T>)_internalList).Reverse().EveryNthItem(step))
                yield return item;
        }

        public void Clear()
        {
            _internalList.Clear();
        }

        public void Add(T item)
        {
            _internalList.Add(item);
        }

        public void AddRange(ICollection<T> collection)
        {
            _internalList.AddRange(collection);
        }
    }

    // extensions
    public static class IEnumerableExtensions
    {        
        public static IEnumerable<T> EveryNthItem<T>(this IEnumerable<T> enumerable, int step)
        {
            int current = 0;
            foreach (var item in enumerable)
            {
                ++current;
                if (current % step == 0)
                    yield return item;
            }
        }

        public static void Display<T>(this IEnumerable<T> enumerable, string title)
        {
            Console.WriteLine(title);

            foreach (T item in enumerable)
            {
                Console.WriteLine(item);
            }
        }
    }
}
