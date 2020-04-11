using System;
using System.Threading;
using CookBook.Ch1;
using CookBook.Ch2;

namespace CookBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test current
            EX210.Run().Wait();
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
        }
    }
}
