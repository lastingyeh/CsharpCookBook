using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Ch9
{
    public static class EX904
    {
        public static void Run()
        {
            Task<string> htmlTask = GetHtmlFromUrlAsync(new Uri("https://www.google.com"));

            htmlTask.Wait();

            Console.WriteLine(htmlTask.Result);
        }
        public static async Task<string> GetHtmlFromUrlAsync(Uri url)
        {
            string html = string.Empty;
            HttpWebRequest request = EX902.GenerateHttpWebRequest(url);

            using(HttpWebResponse response = 
                    (HttpWebResponse)await request.GetResponseAsync())
            {
                if(EX901.CategorizeResponse(response) == ResponseCategories.Success)
                {
                    Stream stream = response.GetResponseStream();
                    using(StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        html = reader.ReadToEnd();
                    }
                }
            }
            return html;
        }
    }
}
