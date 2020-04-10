using System;

using CookBook.Ch1.TestSearch;
using CookBook.Ch1.TestSort;
using CookBook.Ch1._1_10;
using CookBook.Ch1._1_11;
using CookBook.Ch1._1_12;
using CookBook.Ch1._1_13;
using CookBook.Ch1._1_14;
using CookBook.Ch1._1_15;
using CookBook.Ch1._1_16;
using CookBook.Ch1._1_17;
using CookBook.Ch1._1_18;
using CookBook.Ch1._1_19;
using CookBook.Ch2._2_01;
using CookBook.Ch2._2_02;
using CookBook.Ch2._2_03;


namespace CookBook
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static void Ch1()
        {
            EX12.TestSort();
            EX13.TestSearch();
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
        }
    }
}
