using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch2
{
    public class StringSet : IEnumerable<string>
    {
        private List<string> _items = new List<string>();

        public void Add(string value)
        {
            _items.Add(value);
        }


        public IEnumerator<string> GetEnumerator()
        {
            try
            {
                for (int index = 0; index < _items.Count; index++)
                {
                    yield return (_items[index]);
                }
            }
            finally
            {
                Console.WriteLine("In iterator finally block");
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
