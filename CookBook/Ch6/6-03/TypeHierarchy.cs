using System;
using System.Collections.Generic;

namespace CookBook.Ch6
{
    public class TypeHierarchy
    {
        public Type DerivedType { get; set; }
        public IEnumerable<Type> InheritanceChain { get; set; }
    }
}
