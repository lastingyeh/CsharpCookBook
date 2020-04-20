using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CookBook.Ch6
{
    public static class EX603
    {
        public static void Run()
        {
            Assembly asm = Assembly.GetAssembly(typeof(ReflectionUtils));
            var typeHierarchies = asm.GetTypeHierarchies();

            foreach (var th in typeHierarchies)
            {
                Console.WriteLine($"Derived Type: {th.DerivedType.FullName}");
                Console.WriteLine(th.InheritanceChain);
                Console.WriteLine();
            }

            //Type derivedType =
            //    asm.GetType("CookBook.Ch6.ReflectionUtils+DerivedOverrides",
            //    true, true);

            //var methodOverrides =
            //    derivedType.GetMethodOverrides();

            //foreach (MethodInfo mi in methodOverrides)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine($"Current Method: {mi}");
            //    Console.WriteLine($"Base Type FullName:  {mi.DeclaringType.FullName}");
            //    Console.WriteLine($"Base Method:  {mi}");

            //    foreach (ParameterInfo pi in mi.GetParameters())
            //    {
            //        Console.WriteLine($"\tParam {pi.Name} : {pi.ParameterType}");
            //    }
            //}

            // try the signature findmethodoverrides
            string methodName = "Foo";
            Type derivedType = typeof(DerivedOverrides);
            var baseTypeMethodInfo = derivedType.GetBaseMethodOverridden(
                methodName,
                new Type[3] { typeof(long), typeof(double), typeof(byte[]) });

            Console.WriteLine($"{Environment.NewLine}For [Type] Method: [{derivedType.Name}]" +
                $" {methodName}");

            Console.WriteLine($"Base Method: {baseTypeMethodInfo}");

            foreach (ParameterInfo pi in baseTypeMethodInfo.GetParameters())
            {
                Console.WriteLine($"\tParam {pi.Name} : {pi.ParameterType}");
            }


        }

        private static void DisplayInheritanceChain(IEnumerable<Type> chain)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var type in chain)
            {
                if (builder.Length == 0)
                    builder.Append(type.Name);
                else
                    builder.AppendFormat($"<-{type.Name}");
            }
            Console.WriteLine($"Base Type List: {builder.ToString()}");
        }
    }
}
