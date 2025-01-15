using System.Net;
using System.Net.Sockets;
using System;
using System.IO;
using System.Text;
using System.Threading;
namespace ServerApp
{
    class Program
    {
        static void ProcessMessage(object parm)
        {
            string data;
            int count;
            try
            {
                TcpClient client = parm as TcpClient;
                Byte[] bytes = new Byte[256];
                NetworkStream stream = client.GetStream();
                while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, count);
                    Console.WriteLine($"Received: {data} at {DateTime.Now:t}");
                    data = $"{data.ToUpper()}";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine($"Sent: {data}");

                }
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}" + ex.Message );
                Console.WriteLine("Waiting message .....");
            }
        }

        static void ExcuteServer(string host, int port)
        {
            int Count = 0;
            TcpListener server = null;
            try
            {
                Console.Title = "Server Application";
                IPAddress localAddr = IPAddress.Parse(host);
                server = new TcpListener(localAddr, port);
                // Start listening for client requests.
                server.Start();
                Console.WriteLine(new string('*', 40));
                Console.WriteLine("Waiting for a connection... ");
                // Enter the listening loop.
                while (true)
                {
                    // Perform a blocking call to accept requests.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine($"Number of client connected: {++Count}");
                    Console.WriteLine(new string('*', 40));
                    // Create a thread to receive and send message
                    Thread thread = new Thread(new ParameterizedThreadStart(ProcessMessage));
                    thread.Start(client);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : {0}" + e.Message);
            }
            finally
            {
                server.Stop();
                Console.WriteLine("Server Stopped. Press any key to exit!");
            }

            Console.Read();
        }
        static void Main(string[] args)
        {
            string host = "127.0.0.1";
            int port = 13001;

            ExcuteServer(host, port);
        }
    }
}
