using System;
namespace CookBook.Ch4
{
    public class DoWork
    {
        delegate int DoOutWork(out string work);
        delegate int DoRefWork(ref string work);
        delegate int DoParamsWork(params object[] workItems);

        DoOutWork dow = (out string s) =>
        {
            s = "WorkFinished";
            Console.WriteLine(s);
            return s.GetHashCode();
        };

        DoRefWork drw = (ref string s) =>
        {
            Console.WriteLine(s);
            s = "WorkFinished";
            return s.GetHashCode();
        };

        ////Done as an lambda expression you also get
        ////CS1670 "params is not valid in this context"
        //DoParamsWork dpwl = (params object[] workItems) =>
        //{
        //    foreach (var obj in workItems)
        //    {
        //        Console.WriteLine(obj.ToString());
        //    }
        //    return workItems.GetHashCode();
        //};

        //Done as an anonymous method you get CS1670
        //"params is not valid in this context"
        //DoParamsWork dpwa = delegate (params object[] workItems)
        //{
        // foreach (object o in workItems)
        // {
        // Console.WriteLine(o.ToString());
        // }
        // return workItems.GetHashCode();
        //};
        DoParamsWork dpw = (workItems) => {
            foreach (var obj in workItems)
                Console.WriteLine(obj.ToString());
            return workItems.GetHashCode();
        };

        public void RunWork()
        {
            string work;
            int i = dow(out work);
            Console.WriteLine(work);

            work = "WorkStarted";
            i = drw(ref work);
            Console.WriteLine(work);

            i = dpw("Hello", "42", "bar");

        }

        //public void TestOut(out string outStr)
        //{
        //    // declare instance
        //    DoWork dw = s =>
        //    {
        //        Console.WriteLine(s);
        //        // Causes error CS1628:
        //        // "Cannot use ref or out parameter 'outStr' inside an
        //        // anonymous method, lambda expression, or query expression"
        //        outStr = s;
        //        return s.GetHashCode();
        //    };
        //    // invoke delegate
        //    int i = dw("DoWorkMethodImpl1");
        //}

        //public void TestRef(ref string refStr)
        //{
        //    // declare instance
        //    DoWork dw = s =>
        //    {
        //        Console.WriteLine(s);
        //        // Causes error CS1628:
        //        // "Cannot use ref or out parameter 'refStr' inside an
        //        // anonymous method, lambda expression, or query expression"
        //        refStr = s;
        //        return s.GetHashCode();
        //    };
        //    // invoke delegate
        //    int i = dw("DoWorkMethodImpl1");
        //}
        delegate int DoWorks(string work);

        public void TestParams(params string[] items)
        {
            DoWorks dw = s =>
            {
                Console.WriteLine(s);
                foreach (string item in items)
                    Console.WriteLine(item);
                return s.GetHashCode();
            };
            int i = dw("DoWorkMethodImp1");
        }

    }
}
