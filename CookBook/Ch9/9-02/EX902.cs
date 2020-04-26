using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CookBook.Ch9
{
    public static class EX902
    {
        public static void Run()
        {
            HttpWebRequest request = GenerateHttpWebRequest(new Uri("https://www.google.com"));

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (EX901.CategorizeResponse(response) == ResponseCategories.Success)
                {
                    Console.WriteLine("Request succeeded");
                }
            }
        }
        // GET
        public static HttpWebRequest GenerateHttpWebRequest(Uri uri)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);

            return webRequest;
        }

        // POST
        public static HttpWebRequest GenerateHttpWebRequest(Uri uri,
            string postData, string contentType)
        {
            HttpWebRequest webRequest = GenerateHttpWebRequest(uri);

            byte[] bytes = Encoding.UTF8.GetBytes(postData);

            // application/x-www-urlencoded
            // application/json
            // application/xml
            webRequest.ContentType = contentType;

            webRequest.ContentLength = postData.Length;

            using (Stream stream = webRequest.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            return webRequest;
        }

    }
}
