using System;
using System.Collections.Generic;
using System.Reflection;

namespace CookBook.Ch6
{
    public static class EX606
    {
        public static void CreateDictionary()
        {
            // get the type to construct
            Type typeToConstruct = typeof(Dictionary<,>);
            // get the type arguments
            Type[] typeArguments = { typeof(int), typeof(string) };
            // bind type arguments
            Type newType = typeToConstruct.MakeGenericType(typeArguments);

            Dictionary<int, string> dict =
                (Dictionary<int, string>)Activator.CreateInstance(newType);

            // test
            Console.WriteLine($"Count == {dict.Count}");
            dict.Add(1, "test1");
            Console.WriteLine($"Count == {dict.Count}");
        }

        public static void TestCreateMultiMap()
        {
            Assembly asm = Assembly.LoadFrom("");
            // CreateDictionary(asm);
        }
    }
}
