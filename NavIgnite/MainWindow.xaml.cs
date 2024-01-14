using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Web.WebView2.Core;

namespace NavIgnite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeAsync();
            webView.NavigationStarting += EnsureHttps;
        }

        private void AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            //If Enter press --> Go to the URL
            if (e.Key == Key.Enter)
            {
                NavigateToAddress();
            }
        }

        private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
            //If ButtonGo press --> Go to the URL
            NavigateToAddress();
        }

        private void NavigateToAddress()
        {
            //Get the writen URL and go to it
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate(addressBar.Text);
            }
        }

        void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            //Check if the URL contain http, if yes show a toolbox to say the website isn't safe
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                webView.CoreWebView2.ExecuteScriptAsync($"alert('{uri} is not safe, try an https link')");
                args.Cancel = true;
            }
        }

        async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);

            //Get the default URL
            string defaultUrl = webView.Source?.ToString();

            //Update the URL
            Dispatcher.Invoke(() =>
            {
                addressBar.Text = defaultUrl;
            });

            webView.CoreWebView2.NavigationCompleted += (s, e) =>
            {
                Dispatcher.Invoke(() =>
                {
                    addressBar.Text = webView.Source.ToString();
                });
            };

            webView.CoreWebView2.WebMessageReceived += UpdateAddressBar;
        }

        void UpdateAddressBar(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            //Update the URL with the new get from server
            String uri = args.TryGetWebMessageAsString();
            Dispatcher.Invoke(() =>
            {
                addressBar.Text = uri;
            });
            webView.CoreWebView2.PostWebMessageAsString(uri);
        }
    }
}
