using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CookBook.Ch8
{
    public static class EX805
    {
        public static async Task CreateLockedFileAsync(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName));

            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(fileName,
                FileMode.Create,
                FileAccess.ReadWrite,
                FileShare.ReadWrite, 4096, useAsync: true);

                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    await writer.WriteLineAsync("The First Line");
                    await writer.WriteLineAsync("The Second Line");
                    await writer.FlushAsync();

                    try
                    {
                        // Lock all of the file.
                        fileStream.Lock(0, fileStream.Length);
                        // Do some lengthy processing here…
                        Thread.Sleep(1000);
                    }
                    finally
                    {
                        // Make sure we unlock the file.
                        // If a process terminates with part of a file locked or closes
                        // a file that has outstanding locks, the behavior is undefined
                        // which is MS speak for bad things….
                        fileStream.Unlock(0, fileStream.Length);
                    }
                    await writer.WriteLineAsync("The Third Line");
                    fileStream = null;
                }
            }
            finally
            {
                fileStream?.Dispose();
            }
        }

        // If another thread is accessing this file, 
        // IOException thrown during the call to one of the WriteAsync, FlushAsync, or Close methods
        public static async Task CreateLockedFileWithExceptionAsync(string fileName)
        {
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite,
                    FileShare.ReadWrite, 4096, useAsync: true);

                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    await streamWriter.WriteLineAsync("The First Line");
                    await streamWriter.WriteLineAsync("The Second Line");
                    await streamWriter.FlushAsync();
                    // Lock all of the file.
                    fileStream.Lock(0, fileStream.Length);
                    FileStream writeFileStream = null;
                    try
                    {
                        writeFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Write,
                            FileShare.ReadWrite, 4096, useAsync: true);

                        using (StreamWriter streamWriter2 = new StreamWriter(writeFileStream))
                        {
                            await streamWriter2.WriteAsync("foo");
                            try
                            {
                                streamWriter2.Close(); // --> Exception occurs here!
                            }
                            catch
                            {
                                Console.WriteLine("The streamWriter2.Close call generated an exception.");
                            }
                            streamWriter.WriteLine("The Third Line");
                        }
                        writeFileStream = null;
                    }
                    finally
                    {
                        if (writeFileStream != null)
                            writeFileStream.Dispose();
                    }
                }
                fileStream = null;
            }
            finally
            {
                fileStream?.Dispose();
            }
        }

        public static async Task CreateLockedFileWithUnlockAsync(string fileName)
        {
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite,
                    FileShare.ReadWrite, 4096, useAsync: true);

                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    await streamWriter.WriteLineAsync("The First Line");
                    await streamWriter.WriteLineAsync("The Second Line");
                    await streamWriter.FlushAsync();
                    // Lock all of the file.
                    fileStream.Lock(0, fileStream.Length);
                    // Try to access the locked file…
                    FileStream writeFileStream = null;
                    try
                    {
                        writeFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Write,
                            FileShare.ReadWrite, 4096, useAsync: true);

                        using (StreamWriter streamWriter2 = new StreamWriter(writeFileStream))
                        {
                            await streamWriter2.WriteAsync("foo");
                            fileStream.Unlock(0, fileStream.Length);
                            await streamWriter2.FlushAsync();
                        }
                        writeFileStream = null;
                    }
                    finally
                    {
                        writeFileStream?.Dispose();
                    }
                }
                fileStream = null;
            }
            finally
            {
                fileStream?.Dispose();
            }
        }

    }
}
