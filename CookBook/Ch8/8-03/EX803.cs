using System;
using System.IO;
using System.Text;

namespace CookBook.Ch8
{
    public static class EX803
    {
        public static void DisplayPathParts(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException(nameof(path));

            string root = Path.GetPathRoot(path);
            string dirName = Path.GetDirectoryName(path);
            string fullFileName = Path.GetFileName(path);
            string fileExt = Path.GetExtension(path);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(path);

            StringBuilder format = new StringBuilder();

            format.Append($"ParsePath of {path} breaks up into the following pieces:" +
                $"{Environment.NewLine}");
            format.Append($"\tRoot: {root}{Environment.NewLine}");
            format.Append($"\tDirectory Name: {dirName}{Environment.NewLine}");
            format.Append($"\tFull File Name: {fullFileName}{Environment.NewLine}");
            format.Append($"\tFile Extension: {fileExt}{Environment.NewLine}");
            format.Append($"\tFile Name Without Extension: {fileNameWithoutExt}" +
                $"{Environment.NewLine}");

            Console.WriteLine(format);
        }
    }
}
