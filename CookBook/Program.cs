using CookBook.Ch1;
using CookBook.Ch2;
using CookBook.Ch3;
using CookBook.Ch4;
using CookBook.Ch5;
using CookBook.Ch6;
using CookBook.Ch7;
using CookBook.Ch8;
using CookBook.Ch9;

namespace CookBook
{
    class Program
    {
        static void Main(string[] args)
        {
            EX904.Run();
        }

        static void Ch1()
        {
            EX102.TestSort();
            EX103.TestSearch();
            EX110.Run();
            EX111.Run();
            EX112.TestDisposableListCls();
            EX113.ShowSettingFieldsToDefaults();
            EX114.TestPartialMethods();
            EX115.InvokedWithTest();
            EX115.InvokeEveryOtherOperation();
            EX115.InvokeInReverse();
            EX115.TestIndividualInvokesExceptions();
            EX116.Run();
            EX117.Run();
            EX118.Run();
            EX119.Run();
        }

        static void Ch2()
        {
            EX201.GetSearchALL();
            EX201.GetSearchALLCount();
            EX202.Run();
            EX203.Run();
            EX205.Run();
            EX206.Run();
            EX207.Run();
            EX208.Run();
            EX209.CreateNestedObjects();
            EX210.Run().Wait();
        }

        static void Ch3()
        {
            EX302.Run();
            EX303.Run();
            EX304.Run();
            EX305.Run();
            EX306.Run();
            EX307.Run();
            EX308.Run();
            EX309.Run();
            EX310.Run();
            EX311.Run();
        }

        static void Ch4()
        {
            EX402.Run();
            EX404.Run();
            EX405.Run();
            EX407.Run();
            EX410.Run();
            EX411.Run();
            EX412.Run();
            EX413.Run();
        }

        static void Ch5()
        {
            EX502.Run();
            EX505.Run();
            EX506.Run();
            EX509.Run();
            EX513.Run();
            EX514.Run();
            EX515.Run();
            EX516.Run();
        }

        static void Ch6()
        {
            EX601.Run();
            EX602.Run();
            EX603.Run();
            EX604.Run();
            EX607.Run();
            EX609.Run();
            EX609.Run();
        }

        static void Ch7()
        {
            EX701.Run();
            EX703.Run();
            EX704.Run();
            EX705.Run();
            EX705.Run();
            EX706.Run();
        }

        static void Ch8()
        {
            EX802.Run();
        }

        static void Ch9()
        {
            EX902.Run();
            EX904.Run();
        }
    }
}
