﻿#pragma checksum "C:\Users\Oliver\SkyDrive\Documents\Visual Studio Solutions\DogeWalletC\DogeWalletC\scan.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8BF3698C89C08FD81CCDBF4593DAAC6E"
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
    
    
    public partial class scan : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid grdCamera;
        
        internal System.Windows.Shapes.Rectangle _previewRect;
        
        internal System.Windows.Media.VideoBrush _previewVideo;
        
        internal System.Windows.Media.CompositeTransform _previewTransform;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/DogeWalletC;component/scan.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.grdCamera = ((System.Windows.Controls.Grid)(this.FindName("grdCamera")));
            this._previewRect = ((System.Windows.Shapes.Rectangle)(this.FindName("_previewRect")));
            this._previewVideo = ((System.Windows.Media.VideoBrush)(this.FindName("_previewVideo")));
            this._previewTransform = ((System.Windows.Media.CompositeTransform)(this.FindName("_previewTransform")));
        }
    }
}

