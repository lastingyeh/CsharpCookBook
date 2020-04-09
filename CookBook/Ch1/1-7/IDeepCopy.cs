using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1._1_7
{
    public interface IDeepCopy<T>
    {
        T DeepCopy();
    }
}
