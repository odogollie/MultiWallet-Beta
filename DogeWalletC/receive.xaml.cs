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
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Media.Imaging;

namespace DogeWalletC
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();

            BuildLocalizedApplicationBar();

            Update();
        }

        private async void Update()
        {
            string PickedCurrency = "DogecoinAPIKey";

            if (CurrencyPicker == null)
                Read_API(PickedCurrency);
            else if (CurrencyPicker.SelectedIndex.Equals(1))
                PickedCurrency = "BitcoinAPIKey";
            else if (CurrencyPicker.SelectedIndex.Equals(0))
                PickedCurrency = "DogecoinAPIKey";
            else if (CurrencyPicker.SelectedIndex.Equals(2))
                PickedCurrency = "LitecoinAPIKey";

            HttpClient client = new HttpClient();

            var ApiKey = Read_API(PickedCurrency);

            //https://block.io/api/v1/get_new_address/?api_key=62e5-8401-cdd9-f868

            string url = "https://block.io/api/v1/get_new_address/" +
                "?api_key={0}";

            string baseUrl = string.Format(url,
                ApiKey);

            try
            {
                string result = await client.GetStringAsync(baseUrl);

                APIReceive apiData = JsonConvert.DeserializeObject<APIReceive>(result);

                ReceiveAddressBox.Text = apiData.data.address;

                //https://chart.googleapis.com/chart?cht=qr&chs=200x200&chl=%22dogecoin:DE74RH9n92bPH5gGTJSATAiwwyngCSqPVF%22

                // CAN USE DOGECHAIN QR API
                // https://dogechain.info/api/v1/address/qrcode/DTXbfrYymxRakKPC56txP4w4bgD4CpcJdJ

                string dogechainQR = "https://dogechain.info/api/v1/address/qrcode/" +
                    "{0}";

                var address = apiData.data.address;
                string QrUrl = string.Format(dogechainQR,
                    apiData.data.address);

                //string qrCode = await client.GetStringAsync(QrUrl);

                QRImageHolder.Source = new BitmapImage(new Uri(QrUrl));
            }
            catch
            {
                ReceiveAddressBox.Text = "Error!";
            }

            

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private string Read_API(string currency)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(currency))
            {
                var apiKey = IsolatedStorageSettings.ApplicationSettings[currency].ToString();
                return apiKey;
            } else 
            return "NoAPI";

        }

        // Sample code for building a localized ApplicationBar
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

            ApplicationBarIconButton appBarButtonHome = new ApplicationBarIconButton(
                new Uri("/AppBarIcons/back.png", UriKind.Relative));
            appBarButtonHome.Text = "Back";
            appBarButtonHome.Click += HomeClick;
            ApplicationBar.Buttons.Add(appBarButtonHome);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItemSettings = new ApplicationBarMenuItem("Settings");
            appBarMenuItemSettings.Click += MenuSettings;
            ApplicationBar.MenuItems.Add(appBarMenuItemSettings);

            ApplicationBarMenuItem appBarMenuItemCredits = new ApplicationBarMenuItem("Credits");
            appBarMenuItemCredits.Click += MenuCredits;
            ApplicationBar.MenuItems.Add(appBarMenuItemCredits);
        }

        private void HomeClick(object sender, EventArgs e)
        {
            string navTo = "/MainPage.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }

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
        private void SendClick(object sender, EventArgs e)
        {
            string navTo = "/send.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }

        private void CurrencyPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Read_API("DogecoinAPIKey");
            Update();
        }


    }
    public class ReceiveData
    {
        public string network { get; set; }
        public int user_id { get; set; }
        public string address { get; set; }
        public string label { get; set; }
    }

    public class APIReceive
    {
        public string status { get; set; }
        public ReceiveData data { get; set; }
    }
}