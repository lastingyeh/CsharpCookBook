using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1
{
    public class DisposableList<T> : IList<T> where T : class, IDisposable
    {
        private List<T> _items = new List<T>();
        private void Delete(T item) => item.Dispose();
        public int IndexOf(T item) => _items.IndexOf(item);
        public void Insert(int index, T item) => _items.Insert(index, item);

        public T this[int index]
        {
            get { return (_items[index]); }
            set { _items[index] = value; }
        }

        public void RemoveAt(int index)
        {
            Delete(this[index]);
            _items.RemoveAt(index);
        }

        // ICollection<T> members
        public void Add(T item) => _items.Add(item);
        public bool Contains(T item) => _items.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);
        public int Count => _items.Count;
        public bool IsReadOnly => false;

        // IEnumberable<T> members
        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        // others
        public void Clear()
        {
            for (int index = 0; index < _items.Count; index++)
            {
                Delete(_items[index]);
            }

            _items.Clear();
        }

        public bool Remove(T item)
        {
            int index = _items.IndexOf(item);

            if (index > 0)
            {
                Delete(_items[index]);
                _items.RemoveAt(index);

                return true;
            }
            return false;
        }

    }
}
