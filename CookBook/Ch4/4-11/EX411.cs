using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CookBook.Ch4
{
    public static class EX411
    {
        public static void Run()
        {
            Type[] interfaces =
            {
                typeof(System.ICloneable),
                typeof(System.Collections.ICollection),
                typeof(System.IDisposable)
            };

            Type searchType = typeof(System.Collections.ArrayList);

            var matches = from t in searchType.GetInterfaces()
                          join s in interfaces on t equals s
                          select s;

            Console.WriteLine("matches");

            foreach (Type type in matches)
                Console.WriteLine(type.ToString());

            Console.WriteLine("\r\ncollectionsInterfaces");
            var collectionsInterfaces = from type in searchType.GetInterfaces()
                                        where type.Namespace == "System.Collections"
                                        select type;
            foreach (Type type in collectionsInterfaces)
                Console.WriteLine(type.ToString());

            Console.WriteLine("\r\naddInterfaces");
            var addInterfaces = from type in searchType.GetInterfaces()
                                from method in type.GetMethods()
                                where (method.Name == "Add") &&
                                    (method.ReturnType == typeof(int))
                                select type;
            foreach (Type type in addInterfaces)
                Console.WriteLine(type.ToString());

            Console.WriteLine("\r\ngacInterfaces");
            var gacInterfaces = from type in searchType.GetInterfaces()
                                where type.Assembly.GlobalAssemblyCache
                                select type;
            foreach (Type type in gacInterfaces)
                Console.WriteLine(type.ToString());

            Console.WriteLine("\r\nversionInterfaces");
            var versionInterfaces = from type in searchType.GetInterfaces()
                                    where type.Assembly.GlobalAssemblyCache &&
                                        type.Assembly.GetName().Version.Major == 4 &&
                                        type.Assembly.GetName().Version.Minor == 0 &&
                                        type.Assembly.GetName().Version.Build == 0 &&
                                        type.Assembly.GetName().Version.Revision == 0
                                    select type;
            foreach (Type type in versionInterfaces)
                Console.WriteLine(type.ToString());
        }
    }
}
