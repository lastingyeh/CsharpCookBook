using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1
{
    public interface IShallowCopy<T>
    {
        T ShallowCopy();
    }
}
