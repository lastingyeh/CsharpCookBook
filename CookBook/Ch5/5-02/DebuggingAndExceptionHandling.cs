using System;
using System.Reflection;

namespace CookBook.Ch5
{
    public static class DebuggingAndExceptionHandling
    {
        public static void ReflectionException()
        {
            Type reflectedClass = typeof(DebuggingAndExceptionHandling);

            try
            {
                MethodInfo methodToInvoke = reflectedClass.GetMethod("TestInvoke");
                methodToInvoke?.Invoke(null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToShortDisplayString());
            }
        }

        public static void TestInvoke()
        {
            throw new Exception("Throw from invoked method.");
        }
    }
}
