using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DogeWalletC.Resources;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO.IsolatedStorage;


namespace DogeWalletC
{
    public partial class MainPage : PhoneApplicationPage
    {
        IsolatedStorageSettings previousBal = IsolatedStorageSettings.ApplicationSettings;
        private string dogeresult;
        private string bitresult;
        private string literesult;
        private string previousDoge = "Set API Key";
        private string previousBit = "Set API Key";
        private string previousLite = "Set API Key";
        const string settingsAppLaunched = "appLaunched";


        // Constructor
        public MainPage()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
            Refresh();

            getPreviousBal("PreviousDoge");
            getPreviousBal("PreviousBit");
            getPreviousBal("PreviousLite");

            if (IsFirstLaunch()){
            
                DisplayMessage("Coming Soon, if you want to see a specific change use the feedback button in the credits!", "Major Changes!");
                Launched();
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

        private async void Refresh()
        {
            ProgressBar.Visibility = Visibility.Visible;
            HttpClient client = new HttpClient();

            //https://block.io/api/v2/get_balance/?api_key=

            // set apikeys to local vars
            var dogeapiKey = Read_API("doge");
            var bitapiKey = Read_API("btc");
            var liteapiKey = Read_API("ltc");

            // setting urls
            string dogeurl = "https://block.io/api/v2/get_balance/" +
                "?api_key=" + dogeapiKey;
            string biturl = "https://block.io/api/v2/get_balance/" +
                "?api_key=" + bitapiKey;
            string liteurl = "https://block.io/api/v2/get_balance/" +
                "?api_key=" + liteapiKey;

            // try catch for each url

            //doge
            try
            {
                dogeresult = await client.GetStringAsync(dogeurl);
                setBalance("doge");

                
            }
            catch
            {
                DogecoinBalance.Text = "Set API Key";
            }
            try
            {
                bitresult = await client.GetStringAsync(biturl);
                setBalance("bit");
                

            }
            catch
            {
                BitcoinBalance.Text = "Set API Key";
            }
            try
            {
                literesult = await client.GetStringAsync(liteurl);
                setBalance("lite");
                

            }
            catch
            {
                LitecoinBalance.Text = "Set API Key";
            }


            ProgressBar.Visibility = Visibility.Collapsed;
            
            
        }

        private void setBalance(string net)
        {
            // SET AVAILABLE and UNCONFIRMED

            if (net == "doge")
            {
                BlockDataResult DogeapiData = JsonConvert.DeserializeObject<BlockDataResult>(dogeresult);

                double doubleBal = Double.Parse(DogeapiData.data.available_balance);
                string bal = String.Concat(doubleBal);
                double unconBal = Double.Parse(DogeapiData.data.pending_received_balance);
                if (bal.Length>9)
                    DogecoinBalance.Text = bal.Substring(0, bal.Length - 9) + " Ð";
                else
                    DogecoinBalance.Text = bal + " Ð";

                DogeUnconfirmedBalance.Text = unconBal + " Ð";

                // Set LocalAppSettings for Dogecoin Bal
                // setPreviousBal("PreviousDoge", bal.Substring(0, bal.Length - 9) + " Ð");
                
            } 
            else if (net == "bit")
            {
                BlockDataResult BitapiData = JsonConvert.DeserializeObject<BlockDataResult>(bitresult);

                double doubleBal = Double.Parse(BitapiData.data.available_balance);
                string bal = String.Concat(doubleBal);
                double unconBal = Double.Parse(BitapiData.data.pending_received_balance);

                BitcoinBalance.Text = bal + " ฿";
                BitUnconfirmedBalance.Text = unconBal + " ฿";

                // Set LocalAppSettings for Dogecoin Bal

                //setPreviousBal("PreviousBit", bal + " ฿");
            }
            else if (net == "lite")
            {
                BlockDataResult LiteapiData = JsonConvert.DeserializeObject<BlockDataResult>(literesult);

                double doubleBal = Double.Parse(LiteapiData.data.available_balance);
                string bal = String.Concat(doubleBal);
                double unconBal = Double.Parse(LiteapiData.data.pending_received_balance);
                if (bal.Length > 5)
                    LitecoinBalance.Text = bal.Substring(0, bal.Length - 9) + " Ł";
                else
                    LitecoinBalance.Text = bal + " Ł";
                
                LiteUnconfirmedBalance.Text = unconBal + " Ł";

                // Set LocalAppSettings for Dogecoin Bal
                // setPreviousBal("PreviousLite", bal.Substring(0, bal.Length - 5) + " Ł");
            }
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

            ApplicationBarIconButton appBarButtonReceive = new ApplicationBarIconButton(
                new Uri("/AppBarIcons/download.png", UriKind.Relative));
            appBarButtonReceive.Text = "Receive";
            appBarButtonReceive.Click += ReceiveClick;
            ApplicationBar.Buttons.Add(appBarButtonReceive);

            ApplicationBarIconButton appBarButtonRefresh = new ApplicationBarIconButton(
                new Uri("/AppBarIcons/refresh.png", UriKind.Relative));
            appBarButtonRefresh.Text = "Refresh";
            appBarButtonRefresh.Click += RefreshClick;
            ApplicationBar.Buttons.Add(appBarButtonRefresh);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItemSettings = new ApplicationBarMenuItem("Settings");
            appBarMenuItemSettings.Click += MenuSettings;
            ApplicationBar.MenuItems.Add(appBarMenuItemSettings);

            ApplicationBarMenuItem appBarMenuItemCredits = new ApplicationBarMenuItem("Credits");
            appBarMenuItemCredits.Click += MenuCredits;
            ApplicationBar.MenuItems.Add(appBarMenuItemCredits);

            //Shapeshift.io page
            ApplicationBarMenuItem appBarMenuItemShape = new ApplicationBarMenuItem("Shift Coins");
            appBarMenuItemShape.Click += MenuShape;
            ApplicationBar.MenuItems.Add(appBarMenuItemShape);
        }

        private void MenuShape(object sender, EventArgs e)
        {
            string navTo = "/shift.xaml";
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
        // Click event for Receive
        private void ReceiveClick(object sender, EventArgs e)
        {
            string navTo = "/receive.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }
        // Click event for Refresh
        private void RefreshClick(object sender, EventArgs e)
        {
            if (Read_API("doge") == "NoAPI" && Read_API("btc") == "NoAPI" && Read_API("ltc") == "NoAPI")
            {
                DisplayMessage("Please Set All 3 API Keys In Settings","Error!");
            }else{
                Refresh();
            }
            
            
        }

        private void DisplayMessage(string message, string error)
        {
            MessageBoxResult messageBox = MessageBox.Show(message, error, MessageBoxButton.OK);
        }
        // Click event for Send
        private void SendClick(object sender, EventArgs e)
        {
            string navTo = "/send.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }
        private string Read_API(string net)
        {
            if (net == "doge")
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains("DogecoinAPIKey"))
                {
                    var apiKey = IsolatedStorageSettings.ApplicationSettings["DogecoinAPIKey"].ToString();
                    return apiKey;
                }
            }
            else if (net == "btc")
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains("BitcoinAPIKey"))
                {
                    var apiKey = IsolatedStorageSettings.ApplicationSettings["BitcoinAPIKey"].ToString();
                    return apiKey;
                }
            }
            else if (net == "ltc")
            {
                if (IsolatedStorageSettings.ApplicationSettings.Contains("LitecoinAPIKey"))
                {
                    var apiKey = IsolatedStorageSettings.ApplicationSettings["LitecoinAPIKey"].ToString();
                    return apiKey;
                }
            }
            return "NoAPI";

        }

        public void setPreviousBal(string network, string balance)
        {
            if (!previousBal.Contains(network))
            {
                previousBal.Add(network, balance);
            }
            else
            {
                previousBal[network] = balance;
            }
        }

        public void getPreviousBal(string network)
        {
            if (network == "PreviousDoge")
            {
                if (previousBal.Contains(network))
                {
                    DogecoinBalance.Text = previousBal[network].ToString();
                }
                else
                    DogecoinBalance.Text = "No Balance";
            }
            else if (network == "PreviousBit")
            {
                if (previousBal.Contains(network))
                {
                    BitcoinBalance.Text = previousBal[network].ToString();
                }
                else
                    BitcoinBalance.Text = "No Balance";
            }
            else if (network == "PreviousLite")
            {
                if (previousBal.Contains(network))
                {
                    LitecoinBalance.Text = previousBal[network].ToString();
                }
                else
                    LitecoinBalance.Text = "No Balance";
            }
            
        }

        /*private void Dogecoin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }
        private void Bitcoin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }
        private void Litecoin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }*/

    }


    public class Data
    {
        public string network { get; set; }
        public string available_balance { get; set; }
        public string pending_received_balance { get; set; }
        public string error_message { get; set; }
    }

    public class BlockDataResult
    {
        public string status { get; set; }
        public Data data { get; set; }
    }
}
