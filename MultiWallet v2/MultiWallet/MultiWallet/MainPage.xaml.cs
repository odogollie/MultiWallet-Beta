using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MultiWallet.Resources;
using System.IO.IsolatedStorage;
using BlockIo;
using System.Net.Http;
using Newtonsoft.Json;


namespace MultiWallet
{
    public partial class MainPage : PhoneApplicationPage
    {
        const string settingsAppLaunched = "appLaunched";
        private string localBalance = "";

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Check to see if First Run

            if (IsFirstLaunch())
            {
                global_methods.DisplayMessage("Please Set API Keys", "First Launch");
                Launched();

                // Change View to set API keys
                global_methods.SetDefaultCurrency("Bitcoin");
                
                HomeLoaded.Visibility = Visibility.Collapsed;
                SettingsLoaded.Visibility = Visibility.Visible;


            }
            else
            {
                // Get and Set Balances before changing to Home Screen

                // get Deflaut Currency balance
                // get balance for default currency (Passing APIKey for Default Currency


                var blockioClient = new BlockIoClient(global_methods.ReadAPIKey(global_methods.GetDefaultCurrency()));

                setBalance(global_methods.GetDefaultCurrency());
                
                // Change View to Home

                SettingsLoaded.Visibility = Visibility.Collapsed;
                HomeLoaded.Visibility = Visibility.Visible;

                
            }
            

        }

        private async void setBalance(string currencyOverride)
        {
            
            string currency = global_methods.GetDefaultCurrency();

            // Check to see if currency override is different then default currency
            if (!currencyOverride.Equals(currency))
            {
                currency = currencyOverride;
            }
            var blockioClient = new BlockIoClient(global_methods.ReadAPIKey(currency));

            var balance = await blockioClient.GetBalance();
            // Get default currency from global methods
            switch (currency){
                case "Bitcoin":
                    BalanceBlock.Text = balance + " ฿";
                    break;
                case "Litecoin":
                    BalanceBlock.Text = balance + " Ł";
                    break;
                case "Dogecoin":
                    BalanceBlock.Text = balance + " Ð";
                    break;
            }
            
            
        }

        private async void getBalance(string apiKey)
        {
            HttpClient client = new HttpClient();
            string url = block_io.baseUrl + "get_balance/?api_key=" + apiKey;

            try
            {
                string result = await client.GetStringAsync(url);


                block_io_root apiData = JsonConvert.DeserializeObject<block_io_root>(result);


                localBalance = apiData.data.available_balance;

            }
            catch
            {
                localBalance = "error";
            }
        } 

        private static bool IsFirstLaunch()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            
            return !(settings.Contains(settingsAppLaunched));
        }

        private static void Launched()
        {
            if (IsFirstLaunch())
            {
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                settings.Add(settingsAppLaunched, true);
                settings.Save();
            }
        }

        // Page Navigation service 
        private void NavTo(string uri)
        {
            NavigationService.Navigate(new Uri(uri, UriKind.RelativeOrAbsolute));
            
        }


        // Changed Currency on home page
        private void CurrencyPickerHome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BitcoinAPIBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void LitecoinAPIBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void DogecoinAPIBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }
            

        
    }
}