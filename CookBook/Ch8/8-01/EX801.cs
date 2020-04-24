using System;
using System.IO;
using System.Linq;

namespace CookBook.Ch8
{
    // return disorder 
    // 
    // pattern
    // *.cs match '.cs'
    // *.html match '.htm, .html, .htma...so on
    public static class EX801
    {
        public static void DisplayFilesAndSubDirectories(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            string[] items = Directory.GetFileSystemEntries(path);

            Array.ForEach(items, item => { Console.WriteLine(item); });
        }

        public static void DisplaySubDirectories(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            string[] items = Directory.GetDirectories(path);
            Array.ForEach(items, item => { Console.WriteLine(item); });
        }

        public static void DisplayFiles(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            string[] items = Directory.GetFiles(path);
            Array.ForEach(items, item => { Console.WriteLine(item); });
        }

        public static void DisplayDirectoryContents(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            DirectoryInfo mainDir = new DirectoryInfo(path);

            var fileSystemDisplayInfos =
                (from fsi in mainDir.GetFileSystemInfos()
                 where fsi is FileSystemInfo || fsi is DirectoryInfo
                 select fsi.ToDisplayString()).ToArray();

            Array.ForEach(fileSystemDisplayInfos, s => { Console.WriteLine(s); });
        }

        public static void DisplayDirectoriesFromInfo(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            DirectoryInfo mainDir = new DirectoryInfo(path);
            DirectoryInfo[] items = mainDir.GetDirectories();

            Array.ForEach(items, item => { Console.WriteLine(item); });
        }

        public static void DisplayFilesFromInfo(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            DirectoryInfo mainDir = new DirectoryInfo(path);
            FileInfo[] items = mainDir.GetFiles();

            Array.ForEach(items, item => { Console.WriteLine($"FILE: {item.Name}"); });
        }

        public static void DisplayFilesWithPattern(string path, string pattern)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentNullException(nameof(pattern));

            string[] items = Directory.GetFileSystemEntries(path, pattern);

            Array.ForEach(items, item => { Console.WriteLine(item); });
        }

        public static void DisplayDirectoriesWithPattern(string path, string pattern)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentNullException(nameof(pattern));

            string[] items = Directory.GetDirectories(path, pattern);

            Array.ForEach(items, item => { Console.WriteLine(item); });
        }

        public static void DisplayFilesWithGetFiles(string path, string pattern)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentNullException(nameof(pattern));

            string[] items = Directory.GetFiles(path, pattern);

            Array.ForEach(items, item => { Console.WriteLine(item); });
        }

        public static void DisplayDirectoryContentsWithPattern(string path, string pattern)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentNullException(nameof(pattern));

            DirectoryInfo mainDir = new DirectoryInfo(path);

            var fileSystemDisplayInfos =
            (from fsi in mainDir.GetFileSystemInfos(pattern)
             where fsi is FileSystemInfo || fsi is DirectoryInfo
             select fsi.ToDisplayString()).ToArray();

            Array.ForEach(fileSystemDisplayInfos, s =>
            {
                Console.WriteLine(s);
            });
        }

        public static void DisplayDirectoriesWithPatternFromInfo(string path,
            string pattern)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentNullException(nameof(pattern));

            DirectoryInfo mainDir = new DirectoryInfo(path);
            DirectoryInfo[] items = mainDir.GetDirectories(pattern);

            Array.ForEach(items, item => { Console.WriteLine(item); });
        }

        public static void DisplayFilesWithInstanceGetFiles(string path,
            string pattern)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentNullException(nameof(pattern));

            DirectoryInfo mainDir = new DirectoryInfo(path);
            FileInfo[] items = mainDir.GetFiles(pattern);

            Array.ForEach(items, item =>
            {
                Console.WriteLine($"FILE: {item.Name}");
            });
        }
    }


}
