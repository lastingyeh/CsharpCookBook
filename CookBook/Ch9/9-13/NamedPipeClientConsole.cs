using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Ch9
{
    class NamedPipeClientConsole
    {
        public static async Task RunClient()
        {
            Console.WriteLine("Initiating client, looking for server...");
            // set up a message to send
            string messageText = "Sample text message!";
            int bytesRead;

            // set up the named pipe client and close it when complete
            using (NamedPipeClientStream clientStream =
                new NamedPipeClientStream(".", "mypipe", PipeDirection.InOut, PipeOptions.None))
            {
                // connect to the server stream
                await clientStream.ConnectAsync();
                // set the read mode to message
                clientStream.ReadMode = PipeTransmissionMode.Message;

                // write the message 10 times
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Sending message: {messageText}");
                    byte[] messageBytes = Encoding.Unicode.GetBytes(messageText);

                    // check and write the message
                    if (clientStream.CanWrite)
                    {
                        await clientStream.WriteAsync(messageBytes, 0, messageBytes.Length);
                        await clientStream.FlushAsync();
                        // wait till it is read
                        clientStream.WaitForPipeDrain();
                    }

                    // set up a buffer for the message bytes
                    messageBytes = new byte[256];

                    do
                    {
                        // collect the message bits
                        StringBuilder message = new StringBuilder();

                        // read all of the bits until we have the
                        // complete response message
                        do
                        {
                            // read from the pipe
                            bytesRead = await clientStream.ReadAsync(
                                messageBytes, 0, messageBytes.Length);

                            // if we got something, add it to the message
                            if (bytesRead > 0)
                            {
                                message.Append(
                                    Encoding.Unicode.GetString(messageBytes, 0, bytesRead));
                                Array.Clear(messageBytes, 0, messageBytes.Length);
                            }
                        } while (!clientStream.IsMessageComplete);
                        // set to zero as we have read the whole message
                        bytesRead = 0;
                        Console.WriteLine($"    Received message: {message}");

                    } while (bytesRead != 0);
                }
            }
        }
    }
}
