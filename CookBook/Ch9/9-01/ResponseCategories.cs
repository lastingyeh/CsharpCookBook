using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch9
{
    public enum ResponseCategories
    {
        Unknown, // <100 | >599
        Informational, // 100 <= 199
        Success, // 200 <= 299
        Redirected, // 300 <= 399
        ClientError, // 400 <= 499
        ServerError // 500 <= 599
    }
}
