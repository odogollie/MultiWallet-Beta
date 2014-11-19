using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Net.Http;
using System.IO.IsolatedStorage;
using Newtonsoft.Json;

namespace DogeWalletC
{
    public partial class send : PhoneApplicationPage
    {
        string PickedCurrency = "DogecoinAPIKey";
        public send()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
        }

        private void PinBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PinBox.Text = string.Empty;
        }

        private void AddressBox_GotFocus(object sender, RoutedEventArgs e)
        {
           //AddressBox.Text = string.Empty;
        }

        private void AmountBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //AmountBox.Text = string.Empty;
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // Constuct Url using Box Data
            HttpClient client = new HttpClient();

            var address = AddressBox.Text;
            var amount = AmountBox.Text;
            var pin = PinBox.Text;

            var apiKey = Read_API(PickedCurrency);

            //https://block.io/api/v2/withdraw/?api_key=62e5-8401-cdd9-f868&amounts=10&to_addresses=nXuk6KcvtjKH8e6pR5hTj1p6sEebrKiEme&pin=63645639


            string url = "https://block.io/api/v2/withdraw/" +
                "?api_key={0}" + 
                "&amounts={1}" + 
                "&to_addresses={2}" + 
                "&pin={3}";

            string baseUrl = string.Format(url,
                apiKey,
                amount,
                address,
                pin);

            try
            {
                string result = await client.GetStringAsync(baseUrl);
                APIResult apiData = JsonConvert.DeserializeObject<APIResult>(result);
                DisplayMessage(amount, address, apiData.data.network);

                string navTo = "/MainPage.xaml";
                NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
            }
            catch
            {
                ErrorMessage();
            }
               
            
        }

        private void DisplayMessage(string amount, string address, string network)
        {
            MessageBoxResult messageBox = MessageBox.Show("To " + address, amount + network + " sent", MessageBoxButton.OK);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            AddressBox.Text = string.Empty;
            PinBox.Text = string.Empty;
            AmountBox.Text = string.Empty;
        }

        private string Read_API(string PickedCurrency)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(PickedCurrency))
            {
                var apiKey = IsolatedStorageSettings.ApplicationSettings[PickedCurrency].ToString();
                return apiKey;
            }
            return "NoAPI";

        }

        private void CurrencyPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //PickedCurrency = "DogecoinAPIKey";

            if (CurrencyPicker == null)
                Read_API(PickedCurrency);
            else if (CurrencyPicker.SelectedIndex.Equals(1))
                PickedCurrency = "BitcoinAPIKey";
            else if (CurrencyPicker.SelectedIndex.Equals(0))
                PickedCurrency = "DogecoinAPIKey";
            else if (CurrencyPicker.SelectedIndex.Equals(2))
                PickedCurrency = "LitecoinAPIKey";
            
        }


        private void ErrorMessage()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Something went wrong!", "Error!", MessageBoxButton.OK);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                /*string navTo = "/MainPage.xaml";
                NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));*/
            }
        }

        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButtonReceive = new ApplicationBarIconButton(
                new Uri("/AppBarIcons/download.png", UriKind.Relative));
            appBarButtonReceive.Text = "Receive";
            appBarButtonReceive.Click += ReceiveClick;
            ApplicationBar.Buttons.Add(appBarButtonReceive);

            /*ApplicationBarIconButton appBarButtonScan = new ApplicationBarIconButton(
                new Uri("/AppBarIcons/feature.camera.png", UriKind.Relative));
            appBarButtonScan.Text = "Scan";
            appBarButtonScan.Click += ScanClick;
            ApplicationBar.Buttons.Add(appBarButtonScan);*/

            /*ApplicationBarIconButton appBarButtonHome = new ApplicationBarIconButton(
                new Uri("/AppBarIcons/back.png", UriKind.Relative));
            appBarButtonHome.Text = "Back";
            appBarButtonHome.Click += HomeClick;
            ApplicationBar.Buttons.Add(appBarButtonHome);*/

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItemSettings = new ApplicationBarMenuItem("Settings");
            appBarMenuItemSettings.Click += MenuSettings;
            ApplicationBar.MenuItems.Add(appBarMenuItemSettings);

            ApplicationBarMenuItem appBarMenuItemCredits = new ApplicationBarMenuItem("Credits");
            appBarMenuItemCredits.Click += MenuCredits;
            ApplicationBar.MenuItems.Add(appBarMenuItemCredits);
        }

        private void ScanClick(object sender, EventArgs e)
        {
            ScanCode();
        }

        private void ScanCode()
        {
            throw new NotImplementedException();
        }

        /*private void HomeClick(object sender, EventArgs e)
        {
            string navTo = "/MainPage.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }*/

        // Click event for Settings option in app Menu
        private void MenuSettings(object sender, EventArgs e)
        {
            string navTo = "/settings.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }

        // Click event for Credits option in app Menu
        private void MenuCredits(object sender, EventArgs e)
        {
            string navTo = "/credits.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }


        // Click event for Send
        private void ReceiveClick(object sender, EventArgs e)
        {
            string navTo = "/receive.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }

        

    }

    public class SendData
    {
        public string network { get; set; }
        public string txid { get; set; }
        public string amount_withdrawn { get; set; }
        public string amount_sent { get; set; }
        public string network_fee { get; set; }
        public string blockio_fee { get; set; }
    }

    public class APIResult
    {
        public string status { get; set; }
        public SendData data { get; set; }
    } 
}