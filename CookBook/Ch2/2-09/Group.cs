using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch2
{
    public class Group<T> : IEnumerable<T>
    {
        public string Name { get; set; }
        public int Count => _groupList.Count;

        public void Add(T group)
        {
            _groupList.Add(group);
        }
        private List<T> _groupList = new List<T>();
        public Group(string name)
        {
            this.Name = name;
        }
        public IEnumerator<T> GetEnumerator() => _groupList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
