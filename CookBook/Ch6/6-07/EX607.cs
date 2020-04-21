using System;
using System.Reflection;

namespace CookBook.Ch6
{
    public static class EX607
    {
        public static void Run()
        {
            // Load the assembly
            Assembly asm = Assembly.LoadFrom(@"SampleClassLibrary.dll");
            // Get the SampleClass type
            Type reflClassType = asm?.GetType("SampleClassLibrary.SampleClass", true, false);

            if (reflClassType != null)
            {
                // Create class instance
                dynamic sampleClass = Activator.CreateInstance(reflClassType);

                Console.WriteLine($"LastMessage: {sampleClass.LastMessage}");
                Console.WriteLine("Calling TestMethod1");
                sampleClass.TestMethod1("Running TestMethod1");
                Console.WriteLine($"LastMessage: {sampleClass.Lastmessage}");

                Console.WriteLine("Calling TestMethod2");
                sampleClass.TestMethod2("Running TestMethod2", 27);
                Console.WriteLine($"LastMessage: {sampleClass.Lastmessage}");

                // use object instead of dynamic
                //object objSampleClass = Activator.CreateInstance(reflClassType);
                //Console.WriteLine($"LastMessage: {objSampleClass.LastMessage}");
                //Console.WriteLine("Calling TestMethod1");
                //objSampleClass.TestMethod1("Running TestMethod1");
                //Console.WriteLine($"LastMessage: {objSampleClass.LastMessage}");
                //Console.WriteLine("Calling TestMethod2");
                //objSampleClass.TestMethod2("Running TestMethod2", 27);
                //Console.WriteLine($"LastMessage: {objSampleClass.LastMessage}");
            }
        }
    }
}
