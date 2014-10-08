using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using Windows.Web.Http;

namespace DogeWalletC
{
    public partial class settings : PhoneApplicationPage
    {
        public settings()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings APIKeySetting = IsolatedStorageSettings.ApplicationSettings;

            var BitcoinAPIKey = "BitcoinAPIKey";
            var DogecoinAPIKey = "DogecoinAPIKey";
            var LitecoinAPIKey = "LitecoinAPIKey";

            // Bitcoin Save API
            if (!APIKeySetting.Contains(BitcoinAPIKey))
            {
                APIKeySetting.Add(BitcoinAPIKey, BitapiKeyInput.Text);
            }
            else
            {
                APIKeySetting[BitcoinAPIKey] = BitapiKeyInput.Text;
            }
            // Dogecoin Save API
            if (!APIKeySetting.Contains(DogecoinAPIKey))
            {
                APIKeySetting.Add(DogecoinAPIKey, DogeapiKeyInput.Text);
            }
            else
            {
                APIKeySetting[DogecoinAPIKey] = DogeapiKeyInput.Text;
            }
            // Litecoin Save API
            if (!APIKeySetting.Contains(LitecoinAPIKey))
            {
                APIKeySetting.Add(LitecoinAPIKey, LiteapiKeyInput.Text);
            }
            else
            {
                APIKeySetting[LitecoinAPIKey] = LiteapiKeyInput.Text;
            }

            // Save IsolatedStorageSettings
            APIKeySetting.Save();

            //Return to MainPage
            string navTo = "/MainPage.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }

        // Litecoin

        private void LiteapiKeyInput_LostFocus(object sender, RoutedEventArgs e)
        {
            TestAPIKey(LiteapiKeyInput.Text, "LTC");

        }
        // Dogecoin
        private void DogeapiKeyInput_LostFocus(object sender, RoutedEventArgs e)
        {
            TestAPIKey(DogeapiKeyInput.Text, "DOGE");
        }
        // Bitcoin
        private void BitapiKeyInput_LostFocus(object sender, RoutedEventArgs e)
        {
            TestAPIKey(BitapiKeyInput.Text, "BTC");
        }

        public async void TestAPIKey(string apiKey, string network)
        {
            HttpClient client = new HttpClient();

            //https://block.io/api/v1/get_balance/?api_key=

            var url = "https://block.io/api/v1/get_balance/?api_key=" +
                apiKey;
            try
            {
                string result = await client.GetStringAsync(new Uri(url, UriKind.RelativeOrAbsolute));
            }
            catch
            {
                DisplayMessage(network);

                if (network == "LTC")
                {
                    LiteapiKeyInput.Text = "";
                } if (network == "DOGE")
                {
                    DogeapiKeyInput.Text = "";
                }
                if (network == "BTC")
                {
                    BitapiKeyInput.Text = "";
                }
            }
            



        }

        private void DisplayMessage(string network)
        {
            MessageBoxResult messageBox = MessageBox.Show("Error!", "Invalid key for " + network, MessageBoxButton.OK);
        }


        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButtonSend = new ApplicationBarIconButton(
                new Uri("/AppBarIcons/upload.png", UriKind.Relative));
            appBarButtonSend.Text = "Send";
            appBarButtonSend.Click += SendClick;
            ApplicationBar.Buttons.Add(appBarButtonSend);

            ApplicationBarIconButton appBarButtonReceive = new ApplicationBarIconButton(
                new Uri("/AppBarIcons/download.png", UriKind.Relative));
            appBarButtonReceive.Text = "Receive";
            appBarButtonReceive.Click += ReceiveClick;
            ApplicationBar.Buttons.Add(appBarButtonReceive);

            ApplicationBarIconButton appBarButtonHome = new ApplicationBarIconButton(
                new Uri("/AppBarIcons/back.png", UriKind.Relative));
            appBarButtonHome.Text = "Home";
            appBarButtonHome.Click += HomeClick;
            ApplicationBar.Buttons.Add(appBarButtonHome);

            ApplicationBarMenuItem appBarMenuItemCredits = new ApplicationBarMenuItem("Credits");
            appBarMenuItemCredits.Click += MenuCredits;
            ApplicationBar.MenuItems.Add(appBarMenuItemCredits);
        }

        private void HomeClick(object sender, EventArgs e)
        {
            string navTo = "/MainPage.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }

        // Click event for Credits option in app Menu
        private void MenuCredits(object sender, EventArgs e)
        {
            string navTo = "/credits.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }
        // Click event for Receive
        private void ReceiveClick(object sender, EventArgs e)
        {
            string navTo = "/receive.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }
        
        // Click event for Send
        private void SendClick(object sender, EventArgs e)
        {
            string navTo = "/send.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }



    }
}