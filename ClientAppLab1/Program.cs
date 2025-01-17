using System.Net.Sockets;
using System.Text;

namespace ClientAppLab1
{
    internal class Program
    {
        static async Task Main()
        {
            const string server = "127.0.0.1";
            const int port = 8080;

            try
            {
                TcpClient client = new TcpClient(server, port);
                Console.WriteLine("Connected to server.");

                NetworkStream stream = client.GetStream();

                while (true)
                {
                    Console.Write("Enter message: ");
                    string message = Console.ReadLine();
                    if (string.IsNullOrEmpty(message)) break;

                    byte[] data = Encoding.ASCII.GetBytes(message);
                    await stream.WriteAsync(data, 0, data.Length);
                    Console.WriteLine($"Sent: {message}");

                    byte[] buffer = new byte[256];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string responseData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received: {responseData}");
                }

                client.Close();
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"SocketException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
