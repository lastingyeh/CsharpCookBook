using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CookBook.Ch1
{
    public static class EX115
    {
        public static void InvokeInReverse()
        {
            Func<int> myDelegateInstance1 = TestInvokeIntReturn.Method1;
            Func<int> myDelegateInstance2 = TestInvokeIntReturn.Method2;
            Func<int> myDelegateInstance3 = TestInvokeIntReturn.Method3;

            Func<int> allInstances = myDelegateInstance1 + myDelegateInstance2 + myDelegateInstance3;

            Console.WriteLine("Fire delegates in reverse");
            Delegate[] delegateList = allInstances.GetInvocationList();

            foreach (Func<int> instance in delegateList)
            {
                instance();
            }
        }

        public static void InvokeEveryOtherOperation()
        {
            Func<int> myDelegateInstance1 = TestInvokeIntReturn.Method1;
            Func<int> myDelegateInstance2 = TestInvokeIntReturn.Method2;
            Func<int> myDelegateInstance3 = TestInvokeIntReturn.Method3;

            Func<int> allInstances = myDelegateInstance1 + myDelegateInstance2 + myDelegateInstance3;

            Delegate[] delegateList = allInstances.GetInvocationList();
            Console.WriteLine("Invoke every other delegate");

            foreach (Func<int> instance in delegateList)
            {
                int retVal = instance();
                Console.WriteLine($"Delegate returned {retVal}");
            }
        }

        static IEnumerable<T> EveryOther<T>(this IEnumerable<T> enumerable)
        {
            bool retNext = true;
            foreach (T t in enumerable)
            {
                if (retNext) yield return t;
                retNext = !retNext;
            }
        }

        public static void InvokedWithTest()
        {
            Func<bool> myDelegateInstanceBool1 = TestInvokeBoolReturn.Method1;
            Func<bool> myDelegateInstanceBool2 = TestInvokeBoolReturn.Method2;
            Func<bool> myDelegateInstanceBool3 = TestInvokeBoolReturn.Method3;

            Func<bool> allInstanceBool = myDelegateInstanceBool1 + myDelegateInstanceBool2 + myDelegateInstanceBool3;

            Console.WriteLine("Invoke individuall (Call based on previous return value):");

            foreach (Func<bool> instance in allInstanceBool.GetInvocationList())
            {
                if (!instance())
                    break;
            }

        }

        public static void TestIndividualInvokesExceptions()
        {
            Func<int> myDelegateInstance1 = TestInvokeIntReturn.Method1;
            Func<int> myDelegateInstance2 = TestInvokeIntReturn.Method2;
            Func<int> myDelegateInstance3 = TestInvokeIntReturn.Method3;

            Func<int> allInstances = myDelegateInstance1 + myDelegateInstance2 + myDelegateInstance3;

            Console.WriteLine("Invoke individually (handle exceptions):");

            List<Exception> invocationExceptions = new List<Exception>();

            foreach (Func<int> instance in allInstances.GetInvocationList())
            {
                try
                {
                    int retVal = instance();
                    Console.WriteLine($"\tOutput:  {retVal}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    // nuget deps
                    EventLog myLog = new EventLog();
                    myLog.Source = "MyApplicationSource";
                    myLog.WriteEntry(
                        $"Failure invoking {instance.Method.Name} with error" +
                        $"{ex.ToString()}",
                        EventLogEntryType.Error);

                    invocationExceptions.Add(ex);
                }
            }

            if (invocationExceptions.Count > 0)
            {
                throw new MulticastInvocationException(invocationExceptions);
            }
        }
    }
}
