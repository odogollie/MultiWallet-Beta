﻿#pragma checksum "C:\Users\Oliver\SkyDrive\Documents\Visual Studio Solutions\DogeWalletC\DogeWalletC\settings.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5518F496156AE529B5496979FDE7465B"
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
    
    
    public partial class settings : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox BitapiKeyInput;
        
        internal System.Windows.Controls.TextBox DogeapiKeyInput;
        
        internal System.Windows.Controls.TextBox LiteapiKeyInput;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/DogeWalletC;component/settings.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.BitapiKeyInput = ((System.Windows.Controls.TextBox)(this.FindName("BitapiKeyInput")));
            this.DogeapiKeyInput = ((System.Windows.Controls.TextBox)(this.FindName("DogeapiKeyInput")));
            this.LiteapiKeyInput = ((System.Windows.Controls.TextBox)(this.FindName("LiteapiKeyInput")));
        }
    }
}

