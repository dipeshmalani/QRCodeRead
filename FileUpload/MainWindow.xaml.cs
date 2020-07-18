using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileUpload
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = openFileDlg.ShowDialog();
            if (result == true)
            {
                lblTextFilePath.Content = openFileDlg.FileName;
                await SendDataAsync(openFileDlg.FileName);
             }
        }

        public async Task SendDataAsync(string fullFilePath)
        {
            //fullFilePath = "D:\\Test\\response.png";
            if (!File.Exists(fullFilePath))
                throw new FileNotFoundException();
            var data = JsonConvert.SerializeObject(new UploadFile(fullFilePath));
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                await client.UploadStringTaskAsync(new Uri("http://localhost:44354/api/QRCode/"), "POST", fullFilePath);
            }
        }
    }
}
