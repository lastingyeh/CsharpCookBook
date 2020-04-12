using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CookBook.Ch3
{
    public static class EX301
    {
        // convert image to byte[] as Base64 of string
        public static string EncodeBitmapToString(string bitmapFilePath)
        {
            byte[] image = null;
            FileStream fs =
                new FileStream(bitmapFilePath, FileMode.Open, FileAccess.Read);

            using (BinaryReader reader = new BinaryReader(fs))
            {
                image = new byte[reader.BaseStream.Length];
                for (int i = 0; i < reader.BaseStream.Length; i++)
                {
                    image[i] = reader.ReadByte();
                }
            }
            return image.Base64EncodeBytes();
        }

        // convert base64 to MIME-ready string
        public static string MakeBase64EncodedStringForMime(string base64Encoded)
        {
            StringBuilder originalStr = new StringBuilder(base64Encoded);
            StringBuilder newStr = new StringBuilder();

            const int mimeBoundary = 76;
            int cntr = 1;

            while ((cntr * mimeBoundary) < (originalStr.Length - 1))
            {
                newStr.AppendLine(originalStr.ToString(((cntr - 1) * mimeBoundary), mimeBoundary));
                cntr++;
            }

            if (((cntr - 1) * mimeBoundary) < (originalStr.Length - 1))
            {
                newStr.AppendLine(originalStr.ToString(((cntr - 1) * mimeBoundary), ((originalStr.Length) - ((cntr - 1) * mimeBoundary))));
            }
            return newStr.ToString();
        }
    }
}
