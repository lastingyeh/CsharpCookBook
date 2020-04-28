using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Ch9
{
    public class MyTcpClient : IDisposable
    {
        private TcpClient _client;
        private IPEndPoint _endPoint;
        private bool _disposed;

        public IPAddress Address { get; }
        public int Port { get; }
        public string SSLServerName { get; }

        public MyTcpClient(IPAddress address, int port, string sslServerName = null)
        {
            Address = address;
            Port = port;
            _endPoint = new IPEndPoint(Address, Port);
            SSLServerName = sslServerName;
        }

        public async Task ConnectToServerAsync(string msg)
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(_endPoint.Address, _endPoint.Port);

                Stream stream = null;

                if (!string.IsNullOrWhiteSpace(SSLServerName))
                {
                    SslStream sslStream = new SslStream(_client.GetStream(), false,
                        new RemoteCertificateValidationCallback(CertificateValidationCallback));
                    sslStream.AuthenticateAsClient(SSLServerName);
                    DisplaySSLInformation(SSLServerName, sslStream, true);
                    stream = sslStream;
                }
                else
                {
                    stream = _client.GetStream();
                }

                using (stream)
                {
                    // get the bytes to send for the message
                    byte[] bytes = Encoding.ASCII.GetBytes(msg);

                    // send message
                    Console.WriteLine($"Sending message to server: {msg}");
                    await stream?.WriteAsync(bytes, 0, bytes.Length);

                    // get the response
                    // buffer to store the response bytes
                    bytes = new byte[1024];

                    int bytesRead = await stream?.ReadAsync(bytes, 0, bytes.Length);
                    string serverResponse = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    Console.WriteLine($"Server said: {serverResponse}");
                }
            }
            catch (SocketException se)
            {
                Console.WriteLine($"There was an error talking to the server: {se}");
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _client?.Close();
                }
                _disposed = true;
            }
        }

        private bool CertificateValidationCallback(object sender, X509Certificate certificate,
            X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors)
            {
                Console.WriteLine($"The X509Chain.ChainStatus returned an array of " +
                    $"X509ChainStatus objects containing error information.");
            }
            else if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateNameMismatch)
            {
                Console.WriteLine("There was a mismatch of the name on a certificate.");
            }
            else if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateNotAvailable)
            {
                Console.WriteLine("No certificate was available.");
            }
            else
            {
                Console.WriteLine("SSL Certificate Validation Error!");
            }

            Console.WriteLine("");
            Console.WriteLine("SSL Certificate Validation Error!");
            Console.WriteLine(sslPolicyErrors.ToString());

            return false;
        }

        private static void DisplaySSLInformation(string serverName, SslStream sslStream,
            bool verbose)
        {
            DisplayCertInformation(sslStream.RemoteCertificate, verbose);
            Console.WriteLine("");
            Console.WriteLine($"SSL Connect Report for : {serverName}");
            Console.WriteLine("");
            Console.WriteLine($"Is Authenticated: {sslStream.IsAuthenticated}");
            Console.WriteLine($"Is Encrypted: {sslStream.IsEncrypted}");
            Console.WriteLine($"Is Signed: {sslStream.IsSigned}");
            Console.WriteLine($"Is Mutually Authenticated: {sslStream.IsMutuallyAuthenticated}");
            Console.WriteLine("");
            Console.WriteLine($"Hash Algorithm: {sslStream.HashAlgorithm}");
            Console.WriteLine($"Hash Strength: {sslStream.HashStrength}");
            Console.WriteLine($"Cipher Algorithm: {sslStream.CipherAlgorithm}");
            Console.WriteLine($"Cipher Strength: {sslStream.CipherStrength}");
            Console.WriteLine("");
            Console.WriteLine($"Key Exchange Algorithm: {sslStream.KeyExchangeAlgorithm}");
            Console.WriteLine($"Key Exchange Strength: {sslStream.KeyExchangeStrength}");
            Console.WriteLine("");
            Console.WriteLine($"SSL Protocol: {sslStream.SslProtocol}");
        }

        private static void DisplayCertInformation(X509Certificate remoteCertificate,
            bool verbose)
        {
            Console.WriteLine("");
            Console.WriteLine("Certficate Information for:");
            Console.WriteLine($"{remoteCertificate.Subject}");
            Console.WriteLine("");
            Console.WriteLine("Valid From:");
            Console.WriteLine($"{remoteCertificate.GetEffectiveDateString()}");
            Console.WriteLine("Valid To:");
            Console.WriteLine($"{remoteCertificate.GetExpirationDateString()}");
            Console.WriteLine("Certificate Format:");
            Console.WriteLine($"{remoteCertificate.GetFormat()}");
            Console.WriteLine("");
            Console.WriteLine("Issuer Name:");
            Console.WriteLine($"{remoteCertificate.Issuer}");

            if (verbose)
            {
                Console.WriteLine("Serial Number:");
                Console.WriteLine($"{remoteCertificate.GetSerialNumberString()}");
                Console.WriteLine("Hash:");
                Console.WriteLine($"{remoteCertificate.GetCertHashString()}");
                Console.WriteLine("Key Algorithm:");
                Console.WriteLine($"{remoteCertificate.GetKeyAlgorithm()}");
                Console.WriteLine("Key Algorithm Parameters:");
                Console.WriteLine($"{remoteCertificate.GetKeyAlgorithmParametersString()}");
                Console.WriteLine("Public Key:");
                Console.WriteLine($"{remoteCertificate.GetPublicKeyString()}");
            }
        }
    }
}
