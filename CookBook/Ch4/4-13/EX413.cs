using System;
namespace CookBook.Ch4
{
    public static class EX413
    {
        

        public static void Run()
        {
            DoWork doWork = new DoWork();
            doWork.RunWork();
            doWork.TestParams("Hello","World","123");
        }
    }
}
