using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Ch9
{
    public static class EX916
    {
        public static void Run()
        {
            TestPortScanner().Wait();
        }
        public static async Task TestPortScanner()
        {
            Console.WriteLine("Checking ports 75-85 on localhost...");
            CheapoPortScanner cps = new CheapoPortScanner("127.0.0.1", 75, 85);

            var progress = new Progress<CheapoPortScanner.PortScanResult>();
            progress.ProgressChanged += (sender, args) => {
                Console.WriteLine($"Port {args.PortNum} is " +
                    $"{(args.IsPortOpen ? "open":"closed")}");
            };
            await cps.ScanAsync(progress);
            cps.LastPortScanSummary();

        }

        private static void Progress_ProgressChanged(object sender, CheapoPortScanner.PortScanResult e)
        {
            throw new NotImplementedException();
        }
    }
}
