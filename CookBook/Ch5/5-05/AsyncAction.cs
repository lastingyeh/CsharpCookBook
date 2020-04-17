using System;
namespace CookBook.Ch5
{


    public class AsyncAction
    {
        public delegate int AsyncInvoke();

        public void PollAsyncDelegate()
        {
            AsyncInvoke MI = new AsyncInvoke(TestAsyncInvoke.Method1);
            IAsyncResult AR = MI.BeginInvoke(null, null);

            while (!AR.IsCompleted)
            {
                System.Threading.Thread.Sleep(100);
                Console.WriteLine('.');
            }
            Console.WriteLine("Finished Polling");

            try
            {
                int retVal = MI.EndInvoke(AR);
                Console.WriteLine("RetVal (Polling): " + retVal);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

    public class TestAsyncInvoke
    {
        public static int Method1()
        {
            throw new Exception("Method1");
        }
    }
}
