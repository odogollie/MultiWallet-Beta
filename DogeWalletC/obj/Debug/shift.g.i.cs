﻿#pragma checksum "D:\Program Files\Onedrive\Documents\Git\MultiWallet-Beta\DogeWalletC\shift.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C51040A3FD7559CF9FF66AD006E93FAF"
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
    
    
    public partial class shift : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.ListPicker SendCurrency;
        
        internal Microsoft.Phone.Controls.ListPickerItem Doge;
        
        internal Microsoft.Phone.Controls.ListPickerItem Bit;
        
        internal Microsoft.Phone.Controls.ListPickerItem Lite;
        
        internal System.Windows.Controls.TextBlock WhichToSend;
        
        internal Microsoft.Phone.Controls.ListPicker ReceiveCurrency;
        
        internal Microsoft.Phone.Controls.ListPickerItem Bit2;
        
        internal Microsoft.Phone.Controls.ListPickerItem Doge2;
        
        internal Microsoft.Phone.Controls.ListPickerItem Lite2;
        
        internal System.Windows.Controls.TextBlock WhichToReceive;
        
        internal System.Windows.Controls.TextBox AmountBox;
        
        internal System.Windows.Controls.TextBlock Amount;
        
        internal System.Windows.Controls.TextBox PinBox;
        
        internal System.Windows.Controls.TextBlock Pin;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/DogeWalletC;component/shift.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.SendCurrency = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("SendCurrency")));
            this.Doge = ((Microsoft.Phone.Controls.ListPickerItem)(this.FindName("Doge")));
            this.Bit = ((Microsoft.Phone.Controls.ListPickerItem)(this.FindName("Bit")));
            this.Lite = ((Microsoft.Phone.Controls.ListPickerItem)(this.FindName("Lite")));
            this.WhichToSend = ((System.Windows.Controls.TextBlock)(this.FindName("WhichToSend")));
            this.ReceiveCurrency = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("ReceiveCurrency")));
            this.Bit2 = ((Microsoft.Phone.Controls.ListPickerItem)(this.FindName("Bit2")));
            this.Doge2 = ((Microsoft.Phone.Controls.ListPickerItem)(this.FindName("Doge2")));
            this.Lite2 = ((Microsoft.Phone.Controls.ListPickerItem)(this.FindName("Lite2")));
            this.WhichToReceive = ((System.Windows.Controls.TextBlock)(this.FindName("WhichToReceive")));
            this.AmountBox = ((System.Windows.Controls.TextBox)(this.FindName("AmountBox")));
            this.Amount = ((System.Windows.Controls.TextBlock)(this.FindName("Amount")));
            this.PinBox = ((System.Windows.Controls.TextBox)(this.FindName("PinBox")));
            this.Pin = ((System.Windows.Controls.TextBlock)(this.FindName("Pin")));
        }
    }
}

