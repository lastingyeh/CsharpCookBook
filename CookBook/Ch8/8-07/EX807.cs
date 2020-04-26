using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CookBook.Ch8
{
    public static class EX807
    {
        private static FileComparison ComparePart(int p1, int p2) =>
            p1 > p2 ? FileComparison.Newer : (p1 < p2 ? FileComparison.Older : FileComparison.Same);

        public static FileComparison CompareFileVersions(string file1, string file2)
        {
            if (string.IsNullOrWhiteSpace(file1))
                throw new ArgumentNullException(nameof(file1));
            if (string.IsNullOrWhiteSpace(file2))
                throw new ArgumentNullException(nameof(file2));

            FileComparison retValue = FileComparison.Error;
            FileVersionInfo file1VersionInfo = FileVersionInfo.GetVersionInfo(file1);
            FileVersionInfo file2VersionInfo = FileVersionInfo.GetVersionInfo(file2);

            retValue = ComparePart(file1VersionInfo.FileMajorPart,
                file2VersionInfo.FileMajorPart);

            if (retValue != FileComparison.Same)
            {
                retValue = ComparePart(file1VersionInfo.FileMinorPart,
                    file2VersionInfo.FileMinorPart);
                if (retValue != FileComparison.Same)
                {
                    retValue = ComparePart(file1VersionInfo.FileBuildPart,
                        file2VersionInfo.FileBuildPart);
                    if (retValue != FileComparison.Same)
                    {
                        retValue = ComparePart(file1VersionInfo.FilePrivatePart,
                            file2VersionInfo.FilePrivatePart);
                    }
                }
            }
            return retValue;
        }
    }
}
