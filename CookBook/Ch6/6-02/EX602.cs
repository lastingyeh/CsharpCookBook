using System;
using System.Linq;
using System.Reflection;

namespace CookBook.Ch6
{
    public static class EX602
    {
        public static void Run()
        {
            Type objectType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                               from t in assembly.GetTypes()
                               where t.IsClass && t.Name == "AssemblyExtension"
                               select t).Single();

            Assembly asm = Assembly.GetAssembly(objectType);

            Console.WriteLine($"{Environment.NewLine}GetMembersInAssembly");

            var members = asm.GetMembersInAssembly("GetMembersInAssembly");

            foreach (var member in members)
            {
                Console.WriteLine(member);
            }

            Console.WriteLine($"{Environment.NewLine}GetExportedTypes");
            var types = asm.GetExportedTypes();

            foreach (var t in types)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine($"{Environment.NewLine}GetSerializableTypes");
            var serializeableTypes = asm.GetSerializableTypes();

            foreach (var t in serializeableTypes)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine($"{Environment.NewLine}GetSubclassesForType");
            Type type = Type.GetType("CookBook.Ch6.AssemblyExtension");
            var subClasses = asm.GetSubclassesForType(type);

            foreach (var sc in subClasses)
            {
                Console.WriteLine(sc);
            }

            Console.WriteLine($"{Environment.NewLine}GetNestedTypes");
            var nestedTypes = asm.GetNestedTypes();

            foreach (var nt in nestedTypes)
            {
                Console.WriteLine(nt);
            }

        }
    }
}
