using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace slot1_httpclientClass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "AIzaSyDL-n0E-C15LpVHiJa61R8tocit4bQUzKI"; // Thay bằng API key thực tế của bạn
        private const string Endpoint = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent";

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            var userMessage = UserInput.Text;

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            AppendToChatHistory($"You: {userMessage}");

            var response = await SendMessageToGemini(userMessage);

            if (!string.IsNullOrEmpty(response))
            {
                AppendToChatHistory($"Gemini: {response}");
            }

            UserInput.Clear();
        }

        private async Task<string> SendMessageToGemini(string userMessage)
        {
            try
            {
                // Tạo URL với API key
                var url = $"{Endpoint}?key={ApiKey}";

                // Dữ liệu JSON
                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new { text = userMessage }
                            }
                        }
                    }
                };

                var json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Gửi yêu cầu POST
                var response = await _httpClient.PostAsync(url, content);

                response.EnsureSuccessStatusCode();

                // Đọc nội dung phản hồi
                var responseBody = await response.Content.ReadAsStringAsync();

                // Phân tích phản hồi JSON
                var responseObject = JsonSerializer.Deserialize<JsonElement>(responseBody);

                // Trích xuất phần text từ phản hồi
                if (responseObject.TryGetProperty("contents", out var contents) &&
                    contents[0].TryGetProperty("parts", out var parts) &&
                    parts[0].TryGetProperty("text", out var text))
                {
                    return text.GetString();
                }

                return "Unable to parse response.";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private void AppendToChatHistory(string message)
        {
            ChatHistory.Text += message + "\n";
        }
    }
}