using System;
namespace CookBook.Ch5
{
    public static class EX503
    {
        public static void Run()
        {
            TestSpecializedException();
        }

        public static void TestSpecializedException()
        {
            Exception inner = new Exception("The inner Exception");
            RemoteComponentException se1 =
                new RemoteComponentException();
            RemoteComponentException se2 =
                new RemoteComponentException("A Test Message for se2");
            RemoteComponentException se3 =
                new RemoteComponentException("A Test Message for se3", inner);
            RemoteComponentException se4 =
                new RemoteComponentException("A Test Message for se4", "MyServer");
            RemoteComponentException se5 =
                new RemoteComponentException("A Test Message for se5", inner, "MyServer");

            // Test overridden Message property
            Console.WriteLine(Environment.NewLine + "TEST -OVERRIDDEN- MESSAGE PROPERTY");
            Console.WriteLine("se1.Message == " + se1.Message);
            Console.WriteLine("se2.Message == " + se2.Message);
            Console.WriteLine("se3.Message == " + se3.Message);
            Console.WriteLine("se4.Message == " + se4.Message);
            Console.WriteLine("se5.Message == " + se5.Message);

            // Test -overridden- ToString method.
            Console.WriteLine(Environment.NewLine +"TEST -OVERRIDDEN- TOSTRING METHOD");
            Console.WriteLine("se1.ToString() == " + se1.ToString());
            Console.WriteLine("se2.ToString() == " + se2.ToString());
            Console.WriteLine("se3.ToString() == " + se3.ToString());
            Console.WriteLine("se4.ToString() == " + se4.ToString());
            Console.WriteLine("se5.ToString() == " + se5.ToString());
            Console.WriteLine(Environment.NewLine + "END TEST" + Environment.NewLine);
        }
    }
}
