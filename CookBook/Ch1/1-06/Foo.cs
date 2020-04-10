using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1
{
    public class Foo
    {
        // Runtime initial
        public readonly int bar;
        // Compile initial 
        public const int y = 1;
        public Foo() { }
        public Foo(int constInitValue) {
            bar = constInitValue;
        }
    }
}
