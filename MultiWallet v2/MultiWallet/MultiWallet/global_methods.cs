using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiWallet
{
    class global_methods
    {

        // Display Message with 2 args
        internal static void DisplayMessage(string message, string title)
        {
            MessageBoxResult messageBox = MessageBox.Show(message, title, MessageBoxButton.OK);
        }

        // Read API Keys
        internal static string ReadAPIKey(string network)
        {
            // Read isolated storage for api key for specific network
            return "";
        }

        // Save API Keys
        internal static void SaveAPIKey(string network, string apikey)
        {
            // Save keys in isolated storage

        }

        // Get Default Currency
        internal static string GetDefaultCurrency()
        {
            // Read isolated storage value for default currency
            return "";
        }

        // Set Default Currency
        internal static void SetDefaultCurrency()
        {
            // Set isolated storage value of default currency
        }


    }


}
