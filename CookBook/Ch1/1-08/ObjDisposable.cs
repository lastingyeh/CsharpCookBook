using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CookBook.Ch1
{
    class ObjDisposable
    {
        public static void Run()
        {
            using (FileStream FS = new FileStream("Test.txt", FileMode.Create))
            {
                FS.WriteByte((byte)1);
                FS.WriteByte((byte)2);
                FS.WriteByte((byte)3);

                using (StreamWriter SW = new StreamWriter(FS))
                {
                    SW.WriteLine("some text.");
                    // Dispose SW
                }
                // Dispose FS
            }
        }
    }
}
