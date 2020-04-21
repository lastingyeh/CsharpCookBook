using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace CookBook.Ch6
{
    public static class EX604
    {
        public static void Run()
        {
            TestReflectionInvocation();
        }

        public static void TestReflectionInvocation()
        {
            string file = Path.GetFullPath("../../../Ch6/6-04/SampleClassLibraryTests.xml");

            XDocument xdoc =
                XDocument.Load(file);

            ReflectionInvoke(xdoc, @"SampleClassLibrary.dll");
        }

        public static void ReflectionInvoke(XDocument xdoc, string asmPath)
        {
            var test = from t in xdoc.Root.Elements("Test")
                       select new
                       {
                           typeName = t.Attribute("className").Value,
                           methodName = t.Attribute("methodName").Value,
                           parameter = from p in t.Elements("Parameter")
                                       select new { arg = p.Value }
                       };

            Assembly asm = Assembly.LoadFrom(asmPath);

            foreach (var elem in test)
            {
                // create the actual type
                Type reflClassType = asm.GetType(elem.typeName, true, false);

                // create an instance of this type and verify that it exists
                object reflObj = Activator.CreateInstance(reflClassType);
                if (reflObj != null)
                {
                    // verify that the method exists and get its MethodInfo obj
                    MethodInfo invokedMethod = reflClassType.GetMethod(elem.methodName);
                    if (invokedMethod != null)
                    {
                        // create the argument list for the dynamically invoked methods
                        object[] arguments = new object[elem.parameter.Count()];
                        int index = 0;

                        // for each parameter, add it to the list
                        foreach (var arg in elem.parameter)
                        {
                            // get the type of the parameter
                            Type paramType =
                                invokedMethod.GetParameters()[index].ParameterType;

                            // change the value to that type and assign it
                            arguments[index] =
                                Convert.ChangeType(arg.arg, paramType);
                            index++;
                        }

                        // Invoke the method with the parameters
                        object retObj = invokedMethod.Invoke(reflObj, arguments);

                        Console.WriteLine($"\tReturned object: {retObj}");
                        Console.WriteLine($"\tReturned object: {retObj.GetType().FullName}");
                    }
                }
            }
        }
    }
}
