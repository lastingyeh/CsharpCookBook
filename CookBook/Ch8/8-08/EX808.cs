using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CookBook.Ch8
{
    public static class EX808
    {
        public static void DisplayAllDriveInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            Array.ForEach(drives, drive =>
            {
                if (drive.IsReady)
                {
                    Console.WriteLine($"Drive {drive.Name} is ready.");
                    Console.WriteLine($"AvailableFreeSpace: {drive.AvailableFreeSpace}");
                    Console.WriteLine($"DriveFormat: {drive.DriveFormat}");
                    Console.WriteLine($"DriveType: {drive.DriveType}");
                    Console.WriteLine($"Name: {drive.Name}");
                    Console.WriteLine($"RootDirectory.FullName: " +
                        $"{drive.RootDirectory.FullName}");
                    Console.WriteLine($"TotalFreeSpace: {drive.TotalFreeSpace}");
                    Console.WriteLine($"TotalSize: {drive.TotalSize}");
                    Console.WriteLine($"VolumeLabel: {drive.VolumeLabel}");
                }
                else
                {
                    Console.WriteLine($"Drive {drive.Name} is not ready.");
                }
                Console.WriteLine();
            });
        }
    }
}
