using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBook.Ch8
{
    public static class EX806
    {
        public static void WaitForZipCreation(string path, string fileName)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName));

            FileSystemWatcher fsw = null;

            try
            {
                fsw = new FileSystemWatcher();
                string[] data = new string[] { path, fileName };

                fsw.Path = path;
                fsw.Filter = fileName;

                fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                    | NotifyFilters.FileName | NotifyFilters.DirectoryName;

                Task work = Task.Run(() =>
                {
                    try
                    {
                        Thread.Sleep(1000);

                        if (data.Length == 2)
                        {
                            string dataPath = data[0];
                            string dataFile = path + data[1];
                            Console.WriteLine($"Creating {dataFile} in task...");

                            FileStream fileStream = File.Create(dataFile);
                            fileStream.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                });

                WaitForChangedResult result =
                    fsw.WaitForChanged(WatcherChangeTypes.Created, 3000);
                Console.WriteLine($"{result.Name} created at {path}.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                File.Delete(fileName);
                fsw?.Dispose();
            }
        }
    }
}
