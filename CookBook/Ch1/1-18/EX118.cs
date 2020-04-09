using System;
using System.Linq;

namespace CookBook.Ch1._1_18
{
    public static class EX118
    {
        public static void Run()
        {
            Data2[] dataList = new Data2[4];

            dataList = dataList.Select((data, idx) => new Data2(idx)).ToArray();

            foreach (var data in dataList)
            {
                Console.WriteLine(data);
            }
        }

        public static Data2 NewData2(Data2 data)
        {
            data = new Data2();
            return data;
        }
    }
}
