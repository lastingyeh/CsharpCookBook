using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Ch9
{
    public static class EX913
    {
        public static void Run()
        {
            Task client = NamedPipeClientConsole.RunClient();
            Task server = NamedPipeServerConsole.RunServer();

            Task.WhenAll(new Task[] { client, server }).Wait();

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
