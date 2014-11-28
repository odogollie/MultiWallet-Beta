using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.System;
using System.Reflection;

namespace DogeWalletC
{
    public partial class credit : PhoneApplicationPage
    {
        public credit()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
            Version.Text = "Version: " + GetVersion();
        }

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

            ApplicationBarIconButton appBarButtonHome = new ApplicationBarIconButton(
                new Uri("/AppBarIcons/back.png", UriKind.Relative));
            appBarButtonHome.Text = "Home";
            appBarButtonHome.Click += HomeClick;
            ApplicationBar.Buttons.Add(appBarButtonHome);

            ApplicationBarMenuItem appBarMenuItemSettings = new ApplicationBarMenuItem("Settings");
            appBarMenuItemSettings.Click += MenuSettings;
            ApplicationBar.MenuItems.Add(appBarMenuItemSettings);
        }

        private void HomeClick(object sender, EventArgs e)
        {
            string navTo = "/MainPage.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }

        // Click event for Credits option in app Menu
        private void MenuSettings(object sender, EventArgs e)
        {
            string navTo = "/settings.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }
        // Click event for Receive
        private void ReceiveClick(object sender, EventArgs e)
        {
            string navTo = "/receive.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }

        // Click event for Send
        private void SendClick(object sender, EventArgs e)
        {
            string navTo = "/send.xaml";
            NavigationService.Navigate(new Uri(navTo, UriKind.RelativeOrAbsolute));
        }

        private async void FeedBack_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("mailto:oliver.shanklin@outlook.com"));
        }
        private async void Rate_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("zune:reviewapp?appid=appc8773a84-d2c7-49e9-92ce-4da848e70da8"));
            //?appid=appc8773a84-d2c7-49e9-92ce-4da848e70da8
        }
        public static string GetVersion()
        {
            var versionAttribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), true).FirstOrDefault() as AssemblyFileVersionAttribute;

            if (versionAttribute != null)
            {
                return versionAttribute.Version;
            }
            return "";
        }
    }


}