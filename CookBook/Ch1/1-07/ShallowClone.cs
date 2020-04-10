using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1
{
    public class ShallowClone : IShallowCopy<ShallowClone>
    {
        public int Data = 1;
        public List<string> ListData = new List<string>();
        public object ObjData = new object();
        public ShallowClone ShallowCopy() => (ShallowClone)this.MemberwiseClone();
    }
}
