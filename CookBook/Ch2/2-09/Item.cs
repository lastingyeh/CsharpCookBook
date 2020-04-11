using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch2
{
    class Item
    {
        public string Name { get; set; }
        public int Location { get; set; }
        public Item(string name, int location)
        {
            this.Name = name;
            this.Location = location;
        }
    }
}
