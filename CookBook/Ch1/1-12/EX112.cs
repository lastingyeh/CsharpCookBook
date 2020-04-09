using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CookBook.Ch1._1_12
{
    public static class EX112
    {
        public static void TestDisposableListCls()
        {
            DisposableList<StreamReader> dl = new DisposableList<StreamReader>();

            StreamReader tr1 = new StreamReader("C:\\LEARNING\\C#\\CookBook\\data\\test1.txt");
            StreamReader tr2 = new StreamReader("C:\\LEARNING\\C#\\CookBook\\data\\test2.txt");
            StreamReader tr3 = new StreamReader("C:\\LEARNING\\C#\\CookBook\\data\\test3.txt");

            dl.Add(tr1);
            dl.Insert(0, tr2);
            dl.Add(tr3);

            foreach (StreamReader sr in dl)
            {
                Console.WriteLine($"sr.ReadLine() == {sr.ReadLine()}");
            }

            dl.RemoveAt(0);
            dl.Remove(tr1);
            dl.Clear();

        }
    }
}
