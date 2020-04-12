using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch3
{
    static class DataTypeByteArrayExtMethods
    {
        public static string Base64EncodeBytes(this byte[] inputBytes) =>
            (Convert.ToBase64String(inputBytes));

    }
}
