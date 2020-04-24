using System;
using System.Diagnostics;
using System.IO;

namespace CookBook.Ch8
{
    public static class EX804
    {
        public static void RunProcessToReadStandardInput()
        {
            Process application = new Process();
            // run the cmd shell
            application.StartInfo.FileName = @"cmd.exe";

            // turn on cmd extensions for cmd.exe
            application.StartInfo.Arguments = "/E:ON";

            application.StartInfo.RedirectStandardInput = true;

            application.StartInfo.UseShellExecute = false;

            application.Start();

            StreamWriter input = application.StandardInput;
            // run the cmd to display the time
            input.WriteLine("TIME /T");

            // stop the application that launched
            input.Write("exit");
        }
    }
}
