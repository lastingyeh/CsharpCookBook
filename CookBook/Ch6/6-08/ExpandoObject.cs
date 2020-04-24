using System;
using System.Collections.Generic;

namespace CookBook.Ch6
{
    public class ExpandoObject : Dictionary<string, object>
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
