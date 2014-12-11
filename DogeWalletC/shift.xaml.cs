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
using System.Net.Http.Headers;
using Newtonsoft.Json;

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
        string pair = "btc_ltc";
        
        private string returnAddress;
        private string receiveAddress;

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
            else if (SendCurrency.SelectedIndex.Equals(0))
                sendCurrency = "BitcoinAPIKey";
            else if (SendCurrency.SelectedIndex.Equals(1))
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
                //words here
                //More Words
                var sendAPI = Read_API(sendCurrency);
                var receiveAPI = Read_API(receiveCurrency);
                var amount = AmountBox.Text;
                double amountD = 0;
                try
                {
                    amountD = Double.Parse(amount);
                }
                catch
                {
                    DisplayMessage("Please set an amount to receive!");
                }
                //double amountD = Double.Parse(AmountBox.Text);
                var pin = PinBox.Text;

                if (AmountBox.Text == string.Empty)
                {
                    DisplayMessage("Please set an amount to receive!");
                }
                else if (pin.Equals(string.Empty))
                {
                    DisplayMessage("Please Type in Pin!");
                }

                setPair();

                getReceiveAddress(receiveCurrency);
                getReturnAddress(sendCurrency);

                try
                {
                                        
                    HttpClient post = new HttpClient();

                    post.BaseAddress = new Uri("http://shapeshift.io/sendamount");
                    post.DefaultRequestHeaders.Accept.Clear();
                    post.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var transaction = new PostTransaction() { amount = amountD, pair = pair, returnAddress = returnAddress, withdrawal = receiveAddress };

                    HttpResponseMessage response = PostAsync(transaction);

                }
                catch
                {
                    DisplayMessage("Failed!");
                }
            }

        }

        

        private void setPair()
        {
            if (sendCurrency == "BitcoinAPIKey")
            {
                pair = "btc_";
                if (receiveCurrency == "LitecoinAPIKey")
                {
                    pair += "ltc";
                }
                else if (receiveCurrency == "DogecoinAPIKey")
                {
                    pair += "doge";
                }
            }
            else if (sendCurrency == "LitecoinAPIKey")
            {
                pair = "ltc_";
                if (receiveCurrency == "BitcoinAPIKey")
                {
                    pair += "btc";
                }
                else if (receiveCurrency == "DogecoinAPIKey")
                {
                    pair += "doge";
                }
            }
            else if (sendCurrency == "DogecoinAPIKey")
            {
                pair = "doge_";
                if (receiveCurrency == "LitecoinAPIKey")
                {
                    pair += "ltc";
                }
                else if (receiveCurrency == "BitcoinAPIKey")
                {
                    pair += "btc";
                }
            }
        }
        private void DisplayMessage(string error)
        {
            MessageBoxResult messageBox = MessageBox.Show(error, "Error!", MessageBoxButton.OK);
        }

        private async void getReturnAddress(string network)
        {
            var apiKey = Read_API(network);

            string url = "https://block.io/api/v2/get_new_address/" +
                "?api_key={0}";

            string baseUrl = string.Format(url,
                apiKey);

            try
            {
                HttpClient client = new HttpClient();

                string result = await client.GetStringAsync(baseUrl);

                APIReceive apiData = JsonConvert.DeserializeObject<APIReceive>(result);

                returnAddress = apiData.data.address;
                
            }
            catch
            {
                DisplayMessage("Error Getting Return Address!");
            }

        }
        private async void getReceiveAddress(string receiveCurrency)
        {

            var apiKey = Read_API(receiveCurrency);

            string url = "https://block.io/api/v2/get_new_address/" +
                "?api_key={0}";

            string baseUrl = string.Format(url,
                apiKey);

            try
            {
                HttpClient client = new HttpClient();

                string result = await client.GetStringAsync(baseUrl);

                APIReceive apiData = JsonConvert.DeserializeObject<APIReceive>(result);

                receiveAddress = apiData.data.address;
            }
            catch
            {

            }
        }
        
    }

    public class Transaction
    {
        public string status { get; set; }
        public string address { get; set; }
        public string withdraw { get; set; }
        public double incomingCoin { get; set; }
        public string incomingType { get; set; }
        public string outgoingCoin { get; set; }
        public string outgoingType { get; set; }
        public string transaction { get; set; }
        public string error { get; set; }

    }

    public class DepositLimit
    {
        public string pair { get; set; }
        public string limit { get; set; }
    }

    public class PostTransaction
    {
        public double amount { get; set; }
        public string withdrawal { get; set; }
        public string pair { get; set; }
        public string returnAddress { get; set; }
    }


}