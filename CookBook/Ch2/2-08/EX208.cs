using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch2
{
    public static class EX208
    {
        public static void Run()
        {
            StringSet vs = new StringSet()
            {
                "item1",
                "item2",
                "item3",
                "item4",
                "item5",
            };

            foreach (string s in vs)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\r\nTryCatchRun\r\n");
            TryCatchRun(vs);
        }

        static void TryCatchRun(StringSet vs)
        {
            try
            {
                foreach (string s in vs)
                {
                    try
                    {
                        Console.WriteLine(s);
                        throw new Exception();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("In foreach catch block");
                    }
                    finally
                    {
                        Console.WriteLine("In foreach finally block");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("In outer catch block");
            }
            finally
            {
                Console.WriteLine("In outer finally block");
            }
        }
    }
}
