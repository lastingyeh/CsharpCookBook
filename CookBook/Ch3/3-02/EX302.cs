using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CookBook.Ch3
{
    public static class EX302
    {
        public static void Run()
        {
            string bmpAsString = EX301.EncodeBitmapToString(@"bmp.png");

            // C:\Users\[username]\AppData\Local\Temp\[tempfilename].bmp
            string bmpFile = Path.GetTempFileName() + ".bmp";

            byte[] imageBytes = bmpAsString.Base64DecodeString();

            FileStream fs = new FileStream(bmpFile, FileMode.CreateNew, FileAccess.Write);

            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(imageBytes);
            }
        }
    }
}
