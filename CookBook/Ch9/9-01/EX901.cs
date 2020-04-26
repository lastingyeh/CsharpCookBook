using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CookBook.Ch9
{
    public static class EX901
    {
        public static ResponseCategories CategorizeResponse(HttpWebResponse httpWebResponse)
        {
            int statusCode = (int)httpWebResponse.StatusCode;

            if (statusCode >= 100 && statusCode <= 199)
            {
                return ResponseCategories.Informational;
            }

            if (statusCode >=200 && statusCode <= 299)
            {
                return ResponseCategories.Success;
            }

            if (statusCode >= 300 && statusCode <= 399)
            {
                return ResponseCategories.Redirected;
            }

            if(statusCode >= 400 && statusCode <= 499)
            {
                return ResponseCategories.ClientError;
            }

            if (statusCode >= 500 && statusCode <= 599)
            {
                return ResponseCategories.ServerError;
            }

            return ResponseCategories.Unknown;
        }
    }
}
