using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1
{
    public static class EX119
    {
        public delegate bool Approval();
        public static void Run()
        {
            string val = null;

            val?.Trim().ToUpper();

            //person?.address?.state?.trim();

            string[] strs = null;
            //strs null?
            strs?[0].ToUpper();
            //strs[0] null?
            strs[0]?.ToUpper();

            // delegate null?
            Approval approval = () => { return true; };
            approval?.Invoke();

            // length
            int? len = val?.Length;
            // get int? default value
            byte[] data = new byte[(val?.Length).GetValueOrDefault()];

            //switch
            switch (val?.Length)
            {
                case 0:
                    Console.WriteLine("val.Length = 0");
                    break;
                case 1:
                    Console.WriteLine("val.Length = 1");
                    break;
                default:
                    Console.WriteLine("val.Length > 1 or val.Length = null");
                    break;
            }
        }
    }
}
