using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace CookBook.Ch6
{
    public static class EX601
    {
        public static void Run()
        {
            string file = GetProcessPath();
            StringCollection assemblies = new StringCollection();

            BuildDependentAssemblyList(file, assemblies);

            Console.WriteLine($"Assembly {file} has a dependency tree of these " +
                $"assemblies:{Environment.NewLine}");

            foreach (var name in assemblies)
            {
                Console.WriteLine($"\t{name}{Environment.NewLine}");
            }
        }

        public static void BuildDependentAssemblyList(string path,
            StringCollection assemblies)
        {
            if (assemblies == null)
                assemblies = new StringCollection();

            if (assemblies.Contains(path))
                return;

            try
            {
                Assembly asm = null;

                if ((path.IndexOf(@"\", 0, path.Length, StringComparison.Ordinal) != -1) ||
                    (path.IndexOf(@"/", 0, path.Length, StringComparison.Ordinal) != -1))
                {
                    // load the assembly from a path
                    asm = Assembly.LoadFrom(path);
                }
                else
                {
                    // try as assembly name
                    asm = Assembly.Load(path);
                }

                if (asm != null)
                    assemblies.Add(path);

                AssemblyName[] imports = asm.GetReferencedAssemblies();

                // iterate
                foreach (AssemblyName asmName in imports)
                {
                    // now recursively call this assembly to get the new modules
                    BuildDependentAssemblyList(asmName.FullName, assemblies);
                }
            }
            catch (FileLoadException fle)
            {
                // just let this one go.
                Console.WriteLine(fle);
            }
        }

        public static string GetProcessPath()
        {
            // fix the path so that if running under the debugger we get the original
            // file
            string processName = Process.GetCurrentProcess().MainModule.FileName;
            int index = processName.IndexOf("vshost", StringComparison.Ordinal);

            if (index != -1)
            {
                string first = processName.Substring(0, index);
                int numChars = processName.Length - (index + 7);
                string second = processName.Substring(index + 7, numChars);

                processName = first + second;
            }
            return processName;
        }
    }
}
