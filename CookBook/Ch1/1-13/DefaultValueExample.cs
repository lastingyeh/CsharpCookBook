using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1._1_13
{
    public class DefaultValueExample<T>
    {
        T data = default(T);

        public bool IsDefaultData()
        {
            T temp = default(T);

            if (temp.Equals(data))
            {
                return true;
            }
            return false;
        }

        public void SetData(T val) => data = val;
    }
}
