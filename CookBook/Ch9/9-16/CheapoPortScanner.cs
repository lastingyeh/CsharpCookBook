using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Ch9
{
    public class CheapoPortScanner
    {
        #region Private consts and members
        private const int PORT_MIN_VALUE = 1;
        private const int PORT_MAX_VALUE = 65535;
        private List<int> _openPorts;
        private List<int> _closedPorts;
        #endregion

        #region Properties
        public ReadOnlyCollection<int> OpenPorts =>
            new ReadOnlyCollection<int>(_openPorts);
        public ReadOnlyCollection<int> ClosedPorts =>
            new ReadOnlyCollection<int>(_closedPorts);

        public int MinPort { get; } = PORT_MIN_VALUE;
        public int MaxPort { get; } = PORT_MAX_VALUE;
        public string Host { get; } = "127.0.0.1";
        #endregion

        #region Ctors & init
        public CheapoPortScanner()
        {
            SetupList();
        }

        public CheapoPortScanner(string host, int minPort, int maxPort)
        {
            if (minPort > maxPort)
                throw new ArgumentException("Min port cannot be greater than max port");

            if (minPort < PORT_MIN_VALUE || minPort > PORT_MAX_VALUE)
                throw new ArgumentOutOfRangeException(
                    $"Min port cannot be less than {PORT_MIN_VALUE} " +
                    $"or greater than {PORT_MAX_VALUE}");

            if (maxPort < PORT_MIN_VALUE || maxPort > PORT_MAX_VALUE)
                throw new ArgumentOutOfRangeException(
                    $"Max port cannot be less than {PORT_MIN_VALUE} " +
                    $"or greater than {PORT_MAX_VALUE}");

            Host = host;
            MinPort = minPort;
            MaxPort = maxPort;

            SetupList();
        }

        private void SetupList()
        {
            int rangeCount = (MaxPort - MinPort) + 1;
            if (rangeCount % 2 != 0)
                rangeCount += 1;

            _openPorts = new List<int>(rangeCount / 2);
            _closedPorts = new List<int>(rangeCount / 2);
        }
        #endregion

        #region Private Methods
        private async Task CheckPortAsync(int port, IProgress<PortScanResult> progress)
        {
            if (await IsPortOpenAsync(port))
            {
                _openPorts.Add(port);

                progress?.Report(
                    new PortScanResult() { PortNum = port, IsPortOpen = true });
            }
            else
            {
                _closedPorts.Add(port);

                progress?.Report(
                    new PortScanResult() { PortNum = port, IsPortOpen = false });
            }
        }

        private async Task<bool> IsPortOpenAsync(int port)
        {
            Socket sock = null;
            try
            {
                sock = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);

                await Task.Run(() => sock.Connect(Host, port));

                return true;
            }
            catch (SocketException se)
            {
                if (se.SocketErrorCode == SocketError.ConnectionRefused)
                    return false;

                Debug.WriteLine(se);
                Console.WriteLine(se);

            }
            finally
            {
                if (sock?.Connected ?? false)
                    sock?.Disconnect(false);
                sock?.Close();
            }
            return false;

        }
        #endregion

        #region Public Methods
        public async Task ScanAsync(IProgress<PortScanResult> progress)
        {
            for (int port = MinPort; port <= MaxPort; port++)
            {
                await CheckPortAsync(port, progress);
            }
        }

        public void LastPortScanSummary()
        {
            Console.WriteLine($"Port Scan for host at {Host}");
            Console.WriteLine($"\tStarting Port: {MinPort}");
            Console.WriteLine($"\tEnding Port: {MaxPort}");
            Console.WriteLine($"\tOpen ports: {string.Join(",", _openPorts)}");
            Console.WriteLine($"\tClosed ports: {string.Join(",", _closedPorts)}");
        }
        #endregion

        public class PortScanResult
        {
            public int PortNum { get; set; }
            public bool IsPortOpen { get; set; }
        }
    }

}
