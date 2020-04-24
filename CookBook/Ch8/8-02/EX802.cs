using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CookBook.Ch8
{
    public static class EX802
    {
        public static void Run()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            // list all of the files without recursion
            Stopwatch watch1 = Stopwatch.StartNew();
            DisplayAllFilesAndDirectoriesWithoutRecursion(dir);
            watch1.Stop();
            Console.WriteLine("*************************");

            // list all of the files with recursion
            Stopwatch watch2 = Stopwatch.StartNew();
            DisplayAllFilesAndDirectoriesWithRecursion(dir);
            watch2.Stop();
            Console.WriteLine("*************************");

            Console.WriteLine($"Non-Recursive method time elapsed {watch1.Elapsed}");
            Console.WriteLine($"Recursive method time elapsed {watch2.Elapsed}");
        }

        public static IEnumerable<FileSystemInfo> GetAllFilesAndDirectories(string dir)
        {
            if (string.IsNullOrWhiteSpace(dir))
                throw new ArgumentNullException(nameof(dir));

            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            Stack<FileSystemInfo> stack = new Stack<FileSystemInfo>();

            stack.Push(dirInfo);

            while (dirInfo != null || stack.Count > 0)
            {
                FileSystemInfo fileSystemInfo = stack.Pop();
                DirectoryInfo subDirInfo = fileSystemInfo as DirectoryInfo;

                if (subDirInfo != null)
                {
                    yield return subDirInfo;

                    foreach (var fsi in subDirInfo.GetFileSystemInfos())
                    {
                        stack.Push(fsi);
                        dirInfo = subDirInfo;
                    }
                }
                else
                {
                    yield return fileSystemInfo;
                    dirInfo = null;
                }
            }
        }

        public static void DisplayAllFilesAndDirectories(string dir)
        {
            if (string.IsNullOrWhiteSpace(dir))
                throw new ArgumentNullException(nameof(dir));

            var strings = (from fileSystemInfo in GetAllFilesAndDirectories(dir)
                           select fileSystemInfo.ToDisplayString()).ToArray();

            Array.ForEach(strings, s => { Console.WriteLine(s); });
        }

        public static void DisplayAllFilesWithExtension(string dir, string ext)
        {
            if (string.IsNullOrWhiteSpace(dir))
                throw new ArgumentNullException(nameof(dir));
            if (string.IsNullOrWhiteSpace(ext))
                throw new ArgumentNullException(nameof(ext));

            var strings = (from fileSystemInfo in GetAllFilesAndDirectories(dir)
                           where fileSystemInfo is FileInfo &&
                                 fileSystemInfo.FullName.Contains("Chapter 1") &&
                                 (string.Compare(fileSystemInfo.Extension, ext,
                                    StringComparison.OrdinalIgnoreCase) == 0)
                           select fileSystemInfo.ToDisplayString()).ToArray();

            Array.ForEach(strings, s => { Console.WriteLine(s); });
        }

        // tree representation of a directory and the files
        public static IEnumerable<FileSystemInfo> GetAllFilesAndDirectoriesWithRecursion(string dir)
        {
            if (string.IsNullOrWhiteSpace(dir))
                throw new ArgumentNullException(nameof(dir));

            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            FileSystemInfo[] fileSystemInfos = dirInfo.GetFileSystemInfos();

            foreach (FileSystemInfo fileSystemInfo in fileSystemInfos)
            {
                yield return fileSystemInfo;

                if (fileSystemInfo is DirectoryInfo)
                {
                    foreach (var fsi in
                        GetAllFilesAndDirectoriesWithRecursion(fileSystemInfo.FullName))
                    {
                        yield return fsi;
                    }
                }
            }
        }
        // WithRecursion
        public static void DisplayAllFilesAndDirectoriesWithRecursion(string dir)
        {
            if (string.IsNullOrWhiteSpace(dir))
                throw new ArgumentNullException(nameof(dir));

            var strings = (from fileSystemInfo in
                               GetAllFilesAndDirectoriesWithRecursion(dir)
                           select fileSystemInfo.ToDisplayString()).ToArray();

            Array.ForEach(strings, s => { Console.WriteLine(s); });
        }

        // WithoutRecursion
        public static void DisplayAllFilesAndDirectoriesWithoutRecursion(string dir)
        {
            var strings = from fileSystemInfo in
                              GetAllFilesAndDirectoriesWithoutRecursion(dir)
                          select fileSystemInfo.ToDisplayString();

            foreach (var s in strings)
                Console.WriteLine(s);
        }

        public static void DisplayAllFilesWithExtensionWithoutRecursion(string dir, string ext)
        {
            var strings = from fileSystemInfo in
                              GetAllFilesAndDirectoriesWithoutRecursion(dir)
                          where fileSystemInfo is FileInfo &&
                                fileSystemInfo.FullName.Contains("Chapter 1") &&
                                (string.Compare(fileSystemInfo.Extension, ext,
                                    StringComparison.OrdinalIgnoreCase) == 0)
                          select fileSystemInfo.ToDisplayString();

            foreach (string s in strings)
                Console.WriteLine(s);
        }

        public static IEnumerable<FileSystemInfo> GetAllFilesAndDirectoriesWithoutRecursion(string dir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            Stack<FileSystemInfo> stack = new Stack<FileSystemInfo>();

            stack.Push(dirInfo);

            while (dirInfo != null || stack.Count > 0)
            {
                FileSystemInfo fileSystemInfo = stack.Pop();
                DirectoryInfo subDirInfo = fileSystemInfo as DirectoryInfo;

                if (subDirInfo != null)
                {
                    yield return subDirInfo;

                    foreach (var fsi in subDirInfo.GetFileSystemInfos())
                    {
                        stack.Push(fsi);
                    }
                    dirInfo = subDirInfo;
                }
                else
                {
                    yield return fileSystemInfo;
                    dirInfo = null;
                }
            }
        }
    }
}
