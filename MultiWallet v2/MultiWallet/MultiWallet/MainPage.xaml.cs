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

namespace MultiWallet
{
    public partial class MainPage : PhoneApplicationPage
    {
        const string settingsAppLaunched = "appLaunched";

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Check to see if First Run

            /*if (IsFirstLaunch())
            {
                global_methods.DisplayMessage("Please Set API Keys", "First Launch");
                Launched();

                // Send to first_run.xaml
                NavigationService.Navigate(new Uri("/first_run.xaml", UriKind.Absolute));
            }
            else
            {
                //string navTo = "home.xaml";
                //NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
                //GoHome();
            } */

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

        private void DisplayMessage(string message, string title)
        {
            MessageBoxResult messageBox = MessageBox.Show(message, title, MessageBoxButton.OK);
        }

        private void NavTo(string uri)
        {
            NavigationService.Navigate(new Uri(uri, UriKind.RelativeOrAbsolute));
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadingBar.Visibility = Visibility.Collapsed;

            /*if (IsFirstLaunch())
            {
                //global_methods.DisplayMessage("Please Set API Keys", "First Launch");
                Launched();

                // Send to first_run.xaml
                //NavigationService.Navigate(new Uri("/first_run.xaml", UriKind.Absolute));
                NavTo("/first_run.xaml");
            }
            else
            {
                //string navTo = "home.xaml";
                //NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
                NavTo("/home.xaml");
            }*/
        }
            

        
    }
}