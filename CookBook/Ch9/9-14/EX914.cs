using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Ch9
{
    public static class EX914
    {
        public static void Run()
        {
            TestPing().Wait();
        }

        private static async Task TestPing()
        {
            Ping pinger = new Ping();
            PingReply reply = await pinger.SendPingAsync("www.oreilly.com");
            DisplayPingReplyInfo(reply);

            pinger.PingCompleted += pinger_PingCompleted;
            pinger.SendAsync("www.oreilly.com", "oreilly ping");
        }

        private static void pinger_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            PingReply reply = e.Reply;
            DisplayPingReplyInfo(reply);

            if (e.Cancelled)
                Console.WriteLine($"Ping for {e.UserState} was cancelled");
            else
                Console.WriteLine($"Exception thrown during ping: {e.Error?.ToString()}");
        }

        private static void DisplayPingReplyInfo(PingReply reply)
        {
            Console.WriteLine("Results from pinging " + reply.Address);
            Console.WriteLine($"\tFragmentation allowed?: " +
                $"{!reply.Options.DontFragment}");
            Console.WriteLine($"\tTime to live: {reply.Options.Ttl}");
            Console.WriteLine($"\tRoundtrip took: {reply.RoundtripTime}");
            Console.WriteLine($"\tStatus: {reply.Status}");
        }
    }
}
