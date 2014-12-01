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
        String[] currencys = {"Dogecoin", 
                                "Bitcoin", 
                                "Litecoin"};
        public shift()
        {
            InitializeComponent();
            this.SendCurrency.ItemsSource = currencys;
            this.ReceiveCurrency.ItemsSource = currencys;
        }
        string sendCurrency = "DogecoinAPIKey";
        string receiveCurrency = "BitcoinAPIKey";

        private void ReceiveCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //PickedCurrency = "DogecoinAPIKey";

            if (ReceiveCurrency == null)
                Read_API(receiveCurrency);
            else if (ReceiveCurrency.SelectedIndex.Equals(0))
                receiveCurrency = "BitcoinAPIKey";
            else if (ReceiveCurrency.SelectedIndex.Equals(1))
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
                return IsolatedStorageSettings.ApplicationSettings[PickedCurrency].ToString();
            }
            return "NoAPI";

        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            PinBox.Text = string.Empty;
            AmountBox.Text = string.Empty;
        }
        private void Shift_Click(object sender, RoutedEventArgs e)
        {

            if (sendCurrency == receiveCurrency)
            {
                DisplayMessage("Please make sure the currencies are not the same!");
            }
            else
            {
                var sendAPI = Read_API(sendCurrency);
                var receiveAPI = Read_API(receiveCurrency);
                var amount = AmountBox.Text;
                double amountD = Double.Parse(AmountBox.Text);
                var pin = PinBox.Text;

                if (amount == string.Empty || amountD == 0)
                {
                    DisplayMessage("Please set an amount to receive!");
                }
                else if (pin.Equals(string.Empty))
                {
                    DisplayMessage("Please Type in Pin!");
                }
            }

        }
        private void DisplayMessage(string error)
        {
            MessageBoxResult messageBox = MessageBox.Show(error, "Error!", MessageBoxButton.OK);
        }
    }

    class Transaction
    {
        public string amount { get; set; }
        public double withdrawl { get; set; }
        public string pair { get; set; }
        public string reutnr { get; set; }

    }
}