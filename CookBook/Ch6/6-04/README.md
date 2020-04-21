#### Build SampleClassLibrary

1. Create new class library 'SampleClassLibrary' at visual studio

2. Create new class 'SampleClass'

```csharp
using System;

namespace SampleClassLibrary
{
    public class SampleClass
    {
        public bool TestMethod1(string text)
        {
            Console.WriteLine(text);
            return true;
        }

        public bool TestMethod2(string text, int n)
        {
            Console.WriteLine(text + " invoked with {0}", n);
            return true;
        }
    }
}
```
3. Open CookBook project

4. Go to Dependencies/Assemblies

5. add 'SampleClassLibrary.dll'
