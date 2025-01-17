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
        public MainWindow()
        {
            InitializeComponent();
        }

        readonly HttpClient client = new HttpClient();

        private void btnClose_Click(object sender, RoutedEventArgs e) => Close();

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtContent.Text = string.Empty;
        }

        private async void btnViewHTML_Click(object sender, RoutedEventArgs e)
        {
            string url = txtURL.Text;

            // Call asynchronous network methods in a try/catch block to handle exceptions
            try
            {
                string responseBody = await client.GetStringAsync(url);
                txtContent.Text = responseBody.Trim();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Message :{ex.Message}");
            }
        }
    }
}