using System;
using System.IO;

namespace CookBook.Ch8
{
    public static class FileSystemInfoExt
    {
       public static string ToDisplayString(this FileSystemInfo info)
        {
            string type = info.GetType().ToString();
            if (info is DirectoryInfo)
                type = "DIRECTORY";
            else if (info is FileInfo)
                type = "FILE";

            return $"{type}: {info.Name}";
        }
    }
}
