using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CookBook.Ch9
{
    public static class EX909
    {
        private static MyTcpServer _server;
        private static CancellationTokenSource _cts;

        public static async Task RunServer()
        {
            _cts = new CancellationTokenSource();

            try
            {
                await RunServer(_cts.Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            string msg = "Press Esc to stop the server...";
            Console.WriteLine(msg);
            ConsoleKeyInfo cki;

            while (true)
            {
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                {
                    _cts.Cancel();
                    _server.StopListening();
                    break;
                }
            }
            Console.WriteLine("");
            Console.WriteLine("All done listening");
        }

        private static async Task RunServer(CancellationToken cancellationToken)
        {
            try
            {
                await Task.Run(async () =>
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    _server = new MyTcpServer(IPAddress.Loopback, 55555);
                    await _server.ListenAsync(cancellationToken);
                }, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Cancelled.");
            }
        }
    }
}
