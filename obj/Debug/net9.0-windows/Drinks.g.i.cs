﻿#pragma checksum "..\..\..\Drinks.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3806BC6BFCB3AEA57F4F513DA16279BF1D68A5AF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TillApp;


namespace TillApp {
    
    
    /// <summary>
    /// Drinks
    /// </summary>
    public partial class Drinks : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Drinks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox transactionlistbox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Drinks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox totalpricetextbox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Drinks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ItemComboBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Drinks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SelectedItemTextBlock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TillApp;component/drinks.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Drinks.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\Drinks.xaml"
            ((TillApp.Drinks)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.transactionlistbox = ((System.Windows.Controls.ListBox)(target));
            
            #line 12 "..\..\..\Drinks.xaml"
            this.transactionlistbox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.removeitem);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 13 "..\..\..\Drinks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.beer);
            
            #line default
            #line hidden
            return;
            case 4:
            this.totalpricetextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 15 "..\..\..\Drinks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.coke);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ItemComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.SelectedItemTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            
            #line 19 "..\..\..\Drinks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.pay);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 20 "..\..\..\Drinks.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.home);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

