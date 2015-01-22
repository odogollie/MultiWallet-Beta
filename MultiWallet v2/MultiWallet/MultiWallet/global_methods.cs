using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO.IsolatedStorage;
using Newtonsoft.Json;

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
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            string apiKey = "";

            switch (network)
            {
                case "Bitcoin":
                    if (!settings.Contains("Bitcoin"))
                    {
                        DisplayMessage("No API Key set for Bitcoin!", "Error!");
                    }
                    else
                    {
                        apiKey = settings["Bitcoin"].ToString();
                    }
                    break;
                case "Litecoin":
                    if (!settings.Contains("Litecoin"))
                    {
                        DisplayMessage("No API Key set for Litecoin!", "Error!");
                    }
                    else
                    {
                        apiKey = settings["Litecoin"].ToString();
                    }
                    break;
                case "Dogecoin":
                    if (!settings.Contains("Dogecoin"))
                    {
                        DisplayMessage("No API Key set for Dogecoin!", "Error!");
                    }
                    else
                    {
                        apiKey = settings["Dogecoin"].ToString();
                    }
                    break;
            }

            return apiKey;
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
            IsolatedStorageSettings CurrencySettings = IsolatedStorageSettings.ApplicationSettings;
            if (!CurrencySettings.Contains("DefaultCurrency"))
            {
                return "Bitcoin";
            }
            else
            {
                return CurrencySettings["DefaultCurrency"].ToString();
            }

            
        }

        // Set Default Currency
        internal static void SetDefaultCurrency(string defaultCurrency)
        {
            // Set isolated storage value of default currency

            IsolatedStorageSettings CurrencySettings = IsolatedStorageSettings.ApplicationSettings;

            if (!CurrencySettings.Contains("DefaultCurrency"))
            {
                CurrencySettings.Add("DefaultCurrency", defaultCurrency);
                CurrencySettings.Save();
            }
            else
            {
                CurrencySettings.Remove("DefaultCurrency");
                CurrencySettings.Add("DefaultCurrency", defaultCurrency);
                CurrencySettings.Save();
            }

            


        }


    }


}
