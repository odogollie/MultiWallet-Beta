﻿#pragma checksum "C:\Users\Oliver\SkyDrive\Documents\Visual Studio Solutions\DogeWalletC\DogeWalletC\send.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EDD20D0CA4EBBA579FD6850BE5A3EC28"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace DogeWalletC {
    
    
    public partial class Page1 : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox AmountBox;
        
        internal System.Windows.Controls.TextBox AddressBox;
        
        internal System.Windows.Controls.TextBox PinBox;
        
        internal System.Windows.Controls.Button SendButton;
        
        internal System.Windows.Controls.Button ClearButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/DogeWalletC;component/send.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.AmountBox = ((System.Windows.Controls.TextBox)(this.FindName("AmountBox")));
            this.AddressBox = ((System.Windows.Controls.TextBox)(this.FindName("AddressBox")));
            this.PinBox = ((System.Windows.Controls.TextBox)(this.FindName("PinBox")));
            this.SendButton = ((System.Windows.Controls.Button)(this.FindName("SendButton")));
            this.ClearButton = ((System.Windows.Controls.Button)(this.FindName("ClearButton")));
        }
    }
}

