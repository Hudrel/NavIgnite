using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Web.WebView2.Core;

namespace NavIgnite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> favorites = new List<string>();
        private bool isFavorite = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeAsync();
            webView.NavigationStarting += EnsureHttps;
        }

        private void AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            // If Enter press --> Go to the URL
            if (e.Key == Key.Enter)
            {
                NavigateToAddress();
            }
        }

        private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
            // If ButtonGo press --> Go to the URL
            NavigateToAddress();
        }

        private void NavigateToAddress()
        {
            // Get the written URL and go to it
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate(addressBar.Text);
            }
        }

        void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            // Check if the URL contains http, if yes, show a toolbox to say the website isn't safe
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

            // Get the default URL
            string defaultUrl = webView.Source?.ToString();

            // Update the URL
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
            // Update the URL with the new get from the server
            String uri = args.TryGetWebMessageAsString();
            Dispatcher.Invoke(() =>
            {
                addressBar.Text = uri;
            });
            webView.CoreWebView2.PostWebMessageAsString(uri);
        }

        private void ButtonBackPage_Click(object sender, RoutedEventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null && webView.CoreWebView2.CanGoBack)
            {
                webView.CoreWebView2.GoBack();
            }
        }

        private void ButtonNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null && webView.CoreWebView2.CanGoForward)
            {
                webView.CoreWebView2.GoForward();
            }
        }

        private void ButtonRefreshPage_Click(object sender, RoutedEventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Reload();
            }
        }

        private void ButtonAddToFav_Click(object sender, RoutedEventArgs e)
        {
            isFavorite = !isFavorite;

            /*if (isFavorite)
            {
                FavIcon.Source = new BitmapImage(new Uri("/Assets/Img/FavImg.png", UriKind.Relative));
            }
            else
            {
                FavIcon.Source = new BitmapImage(new Uri("/Assets/Img/NotFavImg.png", UriKind.Relative));
            }*/

            string currentUrl = webView.Source?.AbsoluteUri;
            if (currentUrl != null)
            {
                if (favorites.Contains(currentUrl))
                {
                    // Remove the favorite
                    favorites.Remove(currentUrl);
                    UpdateFavoritesPanel();
                }
                else
                {
                    // Add the favorite
                    favorites.Add(currentUrl);
                    UpdateFavoritesPanel();
                }
            }
        }

        private void UpdateFavoritesPanel()
        {
            favoritesWrapPanel.Children.Clear();

            foreach (string favorite in favorites)
            {
                Button favButton = new Button
                {
                    Content = favorite,
                    Margin = new Thickness(5),
                };
                favoritesWrapPanel.Children.Add(favButton);
            }

            // Update the icon of the AddToFavButton accordingly
            string currentUrl = webView.Source?.AbsoluteUri;
            Image favImage = new Image
            {
                Height = 24,
                Stretch = System.Windows.Media.Stretch.Fill,
                Width = 23,
            };

            if (currentUrl != null && favorites.Contains(currentUrl))
            {
                favImage.Source = new BitmapImage(new Uri("/Assets/Img/FavImg.png", UriKind.Relative));
            }
            else
            {
                favImage.Source = new BitmapImage(new Uri("/Assets/Img/NotFavImg.png", UriKind.Relative));
            }

            // Use a StackPanel to combine text and image
            StackPanel stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
            };

            stackPanel.Children.Add(new TextBlock
            {
                Text = "\u0081", // Utilisez le code unicode ici
                Margin = new Thickness(5),
                FontFamily = new System.Windows.Media.FontFamily("/NavIgnite;Assets/Fonts/Byom-Icons-Trial.ttf#Byom Icons Trial"),
            });

            AddToFavButton.Content = stackPanel;
        }
    }
}
