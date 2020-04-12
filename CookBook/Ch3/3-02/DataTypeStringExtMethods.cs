using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch3
{
    static class DataTypeStringExtMethods
    {
        public static byte[] Base64DecodeString(this string inputStr)
        {
            byte[] decodedByteArray = Convert.FromBase64String(inputStr);

            return decodedByteArray;
        }
    }
}
