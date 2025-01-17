using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ServerAppLab2
{
    internal class Program
    {
        static async Task Main()
        {
            const int port = 8080;
            TcpListener server = null;

            try
            {
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                Console.WriteLine("Server started. Waiting for connections...");

                while (true)
                {
                    TcpClient client = await server.AcceptTcpClientAsync();
                    Console.WriteLine("Client connected.");

                    _ = HandleClientAsync(client); // Handle each client in a separate task
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                server?.Stop();
            }
        }

        private static async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[256];
                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Client disconnected

                    string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received from client: {receivedData}");

                    string responseData = receivedData.ToUpper();
                    byte[] responseBuffer = Encoding.ASCII.GetBytes(responseData);
                    await stream.WriteAsync(responseBuffer, 0, responseBuffer.Length);
                    Console.WriteLine($"Sent to client: {responseData}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling client: {ex.Message}");
            }
            finally
            {
                client.Close();
                Console.WriteLine("Client disconnected.");
            }
        }
    }
}
