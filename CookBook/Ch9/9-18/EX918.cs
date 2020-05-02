using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Ch9
{
    public static class EX918
    {
        public static void Run()
        {
            // Download ex
            Uri downloadFtpSite =
                new Uri("ftp://ftp.oreilly.com/pub/examples/CSharpCookbook.zip");
            string targetPath = "CSharpCookbook.zip";
            FtpDownloadAsync(downloadFtpSite, targetPath).Wait();

            // Upload ex
            string uploadFile = "SampleClassLibrary.dll";
            Uri uploadFtpSite = new Uri($"ftp://localhost/{uploadFile}");
            FtpUploadAsync(uploadFtpSite, uploadFile).Wait();
        }

        public static async Task FtpDownloadAsync(Uri ftpSite, string targetPath)
        {
            try
            {
                FtpWebRequest request = WebRequest.Create(ftpSite) as FtpWebRequest;

                request.Credentials = new NetworkCredential("anonymous",
                    "authors@oreilly.com");

                using (FtpWebResponse response =
                    await request.GetResponseAsync() as FtpWebResponse)
                {
                    Stream data = response.GetResponseStream();
                    File.Delete(targetPath);
                    Console.WriteLine($"Downloading {ftpSite.AbsoluteUri} to {targetPath}...");

                    byte[] byteBuffer = new byte[4096];

                    using (FileStream output = new FileStream(targetPath, FileMode.CreateNew,
                        FileAccess.ReadWrite, FileShare.ReadWrite, 4096, useAsync: true))
                    {
                        int bytesRead = 0;
                        do
                        {
                            bytesRead = await data.ReadAsync(byteBuffer, 0, byteBuffer.Length);
                            if (bytesRead > 0)
                                await output.WriteAsync(byteBuffer, 0, bytesRead);
                        } while (bytesRead > 0);
                    }
                    Console.WriteLine($"Downloaded {ftpSite.AbsoluteUri} to {targetPath}");
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(
                    $"Failed to download {ftpSite.AbsoluteUri} to {targetPath}");
                Console.WriteLine(e);
            }
        }

        public static async Task FtpUploadAsync(Uri ftpSite, string uploadFile)
        {
            Console.WriteLine($"Uploading {uploadFile} to {ftpSite.AbsoluteUri}...");

            try
            {
                FileInfo fileInfo = new FileInfo(uploadFile);
                FtpWebRequest request = WebRequest.Create(ftpSite) as FtpWebRequest;
                request.Method = WebRequestMethods.Ftp.UploadFile;

                request.UseBinary = true;
                request.ContentLength = fileInfo.Length;
                request.Credentials = new NetworkCredential("anonymous", "authors@oreilly.com");

                byte[] byteBuffer = new byte[4096];

                using (Stream requestStream = await request.GetRequestStreamAsync())
                {
                    using (FileStream fileStream =
                        new FileStream(uploadFile, FileMode.Open, FileAccess.Read,
                        FileShare.Read, 4096, useAsync: true))
                    {
                        int bytesRead = 0;
                        do
                        {
                            bytesRead = await fileStream.ReadAsync(byteBuffer, 0, byteBuffer.Length);

                            if (bytesRead > 0)
                                await requestStream.WriteAsync(byteBuffer, 0, bytesRead);
                        } while (bytesRead > 0);
                    }
                }

                using (FtpWebResponse response =
                    await request.GetResponseAsync() as FtpWebResponse)
                {
                    Console.WriteLine(response.StatusDescription);
                }
                Console.WriteLine($"Uploaded {uploadFile} to {ftpSite.AbsoluteUri}...");
            }
            catch (WebException e)
            {
                Console.WriteLine($"Failed to upload {uploadFile} to {ftpSite.AbsoluteUri}");
                Console.WriteLine((e.Response as FtpWebResponse)?.StatusDescription);
                Console.WriteLine(e);
            }
        }
    }
}
