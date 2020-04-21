using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;

namespace CookBook.Ch6
{
    public static class EX605
    {
        public static void TestGetLocalVars()
        {
            string file = GetProcessPath();

            ReadOnlyCollection<LocalVariableInfo> vars =
                GetLocalVars(file, "SampleClassLibrary.SampleClass", "TestMethod2");
        }

        private static string GetProcessPath()
        {
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

        public static ReadOnlyCollection<LocalVariableInfo>
            GetLocalVars(string asmPath, string typeName, string methodName)
        {
            Assembly asm = Assembly.LoadFrom(asmPath);
            Type asmType = asm.GetType(typeName);
            MethodInfo mi = asmType.GetMethod(methodName);
            MethodBody mb = mi.GetMethodBody();

            ReadOnlyCollection<LocalVariableInfo> vars =
                mb.LocalVariables as ReadOnlyCollection<LocalVariableInfo>;

            foreach (LocalVariableInfo lvi in vars)
            {
                Console.WriteLine($"IsPinned: {lvi.IsPinned}");
                Console.WriteLine($"LocalIndex: {lvi.LocalIndex}");
                Console.WriteLine($"LocalType.Module: {lvi.LocalType.Module}");
                Console.WriteLine($"LocalType.FullName: {lvi.LocalType.FullName}");
                Console.WriteLine($"ToString(): {lvi}");
            }

            return vars;
        }
    }
}
