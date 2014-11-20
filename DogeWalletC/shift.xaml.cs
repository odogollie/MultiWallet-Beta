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

namespace DogeWalletC
{
    public partial class shift : PhoneApplicationPage
    {
        public shift()
        {
            InitializeComponent();
        }
        string sendCurrency = "DogecoinAPIKey";
        string receiveCurrency = "BitcoinAPIKey";

        private void ReceiveCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //PickedCurrency = "DogecoinAPIKey";

            if (ReceiveCurrency == null)
                Read_API(receiveCurrency);
            else if (ReceiveCurrency.SelectedIndex.Equals(1))
                receiveCurrency = "BitcoinAPIKey";
            else if (ReceiveCurrency.SelectedIndex.Equals(0))
                receiveCurrency = "DogecoinAPIKey";
            else if (ReceiveCurrency.SelectedIndex.Equals(2))
                receiveCurrency = "LitecoinAPIKey";

        }
        private void SendCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //PickedCurrency = "DogecoinAPIKey";

            if (SendCurrency == null)
                Read_API(sendCurrency);
            else if (SendCurrency.SelectedIndex.Equals(1))
                sendCurrency = "BitcoinAPIKey";
            else if (SendCurrency.SelectedIndex.Equals(0))
                sendCurrency = "DogecoinAPIKey";
            else if (SendCurrency.SelectedIndex.Equals(2))
                sendCurrency = "LitecoinAPIKey";

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
    }
}