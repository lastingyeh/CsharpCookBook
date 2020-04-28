using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CookBook.Ch9
{
    public static class EX910
    {
        public static void Run()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(EX909.RunServer());
            tasks.Add(RunClinet());

            Task.WhenAll(tasks).Wait();
        }

        private static async Task RunClinet()
        {
            await TalkToServerAsync();
            Console.WriteLine(@"Press the ENTER key to continue...");
            Console.Read();
        }

        private static async Task TalkToServerAsync()
        {
            await MakeClientCallToServerAsync("Just wanted to say hi");
            await MakeClientCallToServerAsync("Just wanted to say hi again");
            await MakeClientCallToServerAsync("Are you ignoring me?");

            string msg;
            for (int i = 0; i < 100; i++)
            {
                msg = $"I'll not be ignored! (round {i})";
                RunClientCallAsTask(msg);
            }
        }

        private static async Task MakeClientCallToServerAsync(string msg)
        {
            MyTcpClient client = new MyTcpClient(IPAddress.Loopback, 55555);

            await client.ConnectToServerAsync(msg);
        }

        private static void RunClientCallAsTask(string msg)
        {
            Task work = Task.Run(async () =>
            {
                await MakeClientCallToServerAsync(msg);
            });
        }
    }
}
