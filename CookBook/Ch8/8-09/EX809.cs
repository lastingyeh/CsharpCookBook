using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Ch8
{
    // Nuget 
    // System.IO.Compression
    public static class EX809
    {
        /// <summary>
        /// Compress the source file to the destination file.
        /// This is done in 1MB chunks to not overwhelm the memory usage.
        /// </summary>
        /// <param name="sourceFile">the uncompressed file</param>
        /// <param name="destinationFile">the compressed file</param>
        /// <param name="compressionType">the type of compression to use</param>
        public static async Task CompressFileAsync(string sourceFile,
            string destinationFile, CompressionType compressionType)
        {
            if (string.IsNullOrWhiteSpace(sourceFile))
                throw new ArgumentNullException(nameof(sourceFile));
            if (string.IsNullOrWhiteSpace(destinationFile))
                throw new ArgumentNullException(nameof(destinationFile));

            FileStream streamSource = null;
            FileStream streamDestination = null;
            Stream streamCompressed = null;

            int bufferSize = 4096;

            using (streamSource = new FileStream(sourceFile,
                FileMode.OpenOrCreate, FileAccess.Read, FileShare.None,
                bufferSize, useAsync: true))
            {
                using (streamDestination = new FileStream(destinationFile,
                    FileMode.OpenOrCreate, FileAccess.Write, FileShare.None,
                    bufferSize, useAsync: true))
                {
                    // read 1MB block as compression
                    long fileLength = streamSource.Length;

                    // write size of fileLength
                    byte[] size = BitConverter.GetBytes(fileLength);
                    await streamDestination.WriteAsync(size, 0, size.Length);
                    // 1MB
                    long chunkSize = 1024 * 1024;
                    while (fileLength > 0)
                    {
                        // read the chunk
                        byte[] data = new byte[chunkSize];
                        await streamSource.ReadAsync(data, 0, data.Length);
                        // compress the chunk
                        MemoryStream compressedDataStream = new MemoryStream();

                        if (compressionType == CompressionType.Deflate)
                        {
                            streamCompressed = new DeflateStream(compressedDataStream,
                                CompressionMode.Compress);
                        }
                        else
                        {
                            streamCompressed = new GZipStream(compressedDataStream,
                                CompressionMode.Compress);
                        }

                        using (streamCompressed)
                        {
                            // write the chunk in the compressed stream
                            await streamCompressed.WriteAsync(data, 0, data.Length);
                        }
                        // get the bytes for the compressed chunk
                        byte[] compressedData = compressedDataStream.GetBuffer();

                        // write out the chunk size
                        size = BitConverter.GetBytes(chunkSize);
                        await streamDestination.WriteAsync(size, 0, size.Length);

                        // write out the compressed size
                        size = BitConverter.GetBytes(compressedData.Length);
                        await streamDestination.WriteAsync(size, 0, size.Length);

                        // write out the compressed chunk
                        await streamDestination.WriteAsync(compressedData, 0, compressedData.Length);

                        // subtract the chunk size from the file size
                        fileLength -= chunkSize;

                        // if chunk is less than remaining file use
                        // remaining file
                        if (fileLength < chunkSize)
                            chunkSize = fileLength;
                    }
                }
            }
        }

        /// <summary>
        /// This function will decompress the chunked compressed file
        /// created by the CompressFile function.
        /// </summary>
        /// <param name="sourceFile">the compressed file</param>
        /// <param name="destinationFile">the destination file</param>
        /// <param name="compressionType">the type of compression to use</param>
        public static async Task DecompressFileAsync(string sourceFile,
            string destinationFile, CompressionType compressionType)
        {
            if (string.IsNullOrWhiteSpace(sourceFile))
                throw new ArgumentNullException(nameof(sourceFile));
            if (string.IsNullOrWhiteSpace(destinationFile))
                throw new ArgumentNullException(nameof(destinationFile));

            FileStream streamSource = null;
            FileStream streamDestination = null;
            Stream streamUncompressed = null;

            int bufferSize = 4096;

            using (streamSource = new FileStream(sourceFile, FileMode.OpenOrCreate,
                FileAccess.Read, FileShare.None, bufferSize, useAsync: true))
            {
                using (streamDestination = new FileStream(destinationFile, FileMode.OpenOrCreate,
                    FileAccess.Write, FileShare.None, bufferSize, useAsync: true))
                {
                    // read the fileLength size
                    // read the chunk size
                    byte[] size = new byte[sizeof(long)];
                    await streamSource.ReadAsync(size, 0, size.Length);
                    // convert the size back to a number
                    long fileLength = BitConverter.ToInt64(size, 0);
                    long chunkSize = 0;
                    int storedSize = 0;
                    long workingSet = Process.GetCurrentProcess().WorkingSet64;

                    while (fileLength > 0)
                    {
                        // read the chunk size
                        size = new byte[sizeof(long)];
                        await streamSource.ReadAsync(size, 0, size.Length);
                        // convert the size back to a number
                        chunkSize = BitConverter.ToInt64(size, 0);

                        if (chunkSize > fileLength || chunkSize > workingSet)
                            throw new InvalidDataException();

                        // read the compressed size
                        size = new byte[sizeof(int)];
                        await streamSource.ReadAsync(size, 0, size.Length);
                        // convert the size back to a number
                        storedSize = BitConverter.ToInt32(size, 0);

                        if (storedSize > fileLength || storedSize > workingSet)
                            throw new InvalidDataException();

                        if (storedSize > chunkSize)
                            throw new InvalidDataException();

                        byte[] uncompressedData = new byte[chunkSize];
                        byte[] compressedData = new byte[storedSize];
                        await streamSource.ReadAsync(compressedData, 0, compressedData.Length);

                        // uncompress the chunk
                        MemoryStream uncompressedDataStream = new MemoryStream(compressedData);

                        if (compressionType == CompressionType.Deflate)
                        {
                            streamUncompressed = new DeflateStream(uncompressedDataStream,
                                CompressionMode.Decompress);
                        }
                        else
                        {
                            streamUncompressed = new GZipStream(uncompressedDataStream,
                                CompressionMode.Decompress);
                        }

                        using (streamUncompressed)
                        {
                            // read the chunk in the compressed stream
                            await streamUncompressed.ReadAsync(uncompressedData, 0,
                                uncompressedData.Length);
                        }
                        // write out the uncompressed chunk
                        await streamDestination.WriteAsync(uncompressedData, 0,
                            uncompressedData.Length);
                        // subtract the chunk size from the file size
                        fileLength -= chunkSize;
                        // if chunk is less than remaining file use remaining file
                        if (fileLength < chunkSize)
                            chunkSize = fileLength;
                    }
                }
            }
        }
    }
}
