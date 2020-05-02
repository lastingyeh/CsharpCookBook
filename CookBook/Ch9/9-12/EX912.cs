using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Ch9
{
    public static class EX912
    {
        public static void Run()
        {

        }

        public static async Task DownloadDataAsync(Uri uri)
        {
            using (WebClient client = new WebClient())
            {
                Console.WriteLine($"Downloading {uri.AbsoluteUri}");

                byte[] bytes;

                try
                {
                    bytes = await client.DownloadDataTaskAsync(uri);
                }
                catch (WebException we)
                {
                    Console.WriteLine(we);
                    return;
                }
                string page = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(page);
            }
        }

        public static async Task DownloadFileAsync(Uri uri)
        {
            using (WebClient client = new WebClient())
            {
                Console.WriteLine($"Retrieving file from {uri}...{Environment.NewLine}");

                string tempFile = Path.GetTempFileName();

                try
                {
                    await client.DownloadFileTaskAsync(uri, tempFile);
                }
                catch (WebException we)
                {
                    Console.WriteLine(we);
                    return;
                }
                Console.WriteLine($"Downloaded {uri} to {tempFile}");
            }
        }

        public static async Task UploadFileAsync(Uri uri)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    await client.UploadFileTaskAsync(uri, "SampleClassLibrary.dll");
                    Console.WriteLine($"Uploaded successfully to {uri.AbsoluteUri}");
                }
                catch (WebException we)
                {
                    Console.WriteLine(we);
                }
            }
        }
    }
}
