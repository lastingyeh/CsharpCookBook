using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Ch9
{
    class NamedPipeServerConsole
    {
        public static async Task RunServer()
        {
            Console.WriteLine("Initiating server, waiting for client...");
            // Start up our named pipe in message mode and close the pipe
            // when done.

            using (NamedPipeServerStream serverStream =
                new NamedPipeServerStream("mypipe", PipeDirection.InOut, 1,
                PipeTransmissionMode.Message, PipeOptions.None))
            {
                // wait for a client…
                await serverStream.WaitForConnectionAsync();

                while (serverStream.IsConnected)
                {
                    int bytesRead = 0;
                    byte[] messageBytes = new byte[256];

                    // read until we have the message then respond
                    do
                    {
                        // build up the client message
                        StringBuilder message = new StringBuilder();
                        // check canRead
                        if (serverStream.CanRead)
                        {
                            do
                            {
                                // loop until the entire message is read
                                bytesRead = await serverStream.ReadAsync(messageBytes, 0,
                                    messageBytes.Length);
                                // get bytes from stream and add to message
                                if (bytesRead > 0)
                                {
                                    message.Append(Encoding.Unicode.GetString(messageBytes,
                                        0, bytesRead));
                                    Array.Clear(messageBytes, 0, messageBytes.Length);
                                }
                            } while (!serverStream.IsMessageComplete);
                        }
                        // write it out till it got message
                        if (message.Length > 0)
                        {
                            bytesRead = 0;
                            Console.WriteLine($"Received message: {message}");
                            // return message in reverse
                            char[] messageChars = message.ToString().Trim().ToCharArray();
                            Array.Reverse(messageChars);
                            string reversedMessageText = new string(messageChars);

                            Console.WriteLine($"   Returning Message: " +
                                $"{reversedMessageText}");

                            messageBytes = Encoding.Unicode.GetBytes(messageChars);
                            if (serverStream.CanWrite)
                            {
                                // write the message
                                await serverStream.WriteAsync(messageBytes, 0,
                                    messageBytes.Length);
                                // flush buffer
                                await serverStream.FlushAsync();
                                // wait till read by client 
                                serverStream.WaitForPipeDrain();
                            }
                        }
                    } while (bytesRead != 0);
                }
            }
        }
    }
}
