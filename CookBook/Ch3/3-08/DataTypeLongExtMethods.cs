using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch3
{
    public static class DataTypeLongExtMethods
    {
        public static int AddNarrowingChecked(this long lhs, long rhs) => 
            checked((int)(lhs + rhs));
    }
}
