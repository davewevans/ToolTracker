﻿#pragma checksum "..\..\..\Views\NotifyExceptionWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CB2E32B2630DE1E577423AAB2987B6D6"
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
using ToolTracker.Views;


namespace ToolTracker.Views {
    
    
    /// <summary>
    /// NotifyExceptionWindow
    /// </summary>
    public partial class NotifyExceptionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\Views\NotifyExceptionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ToolTracker.Views.NotifyExceptionWindow windowNotifyException;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\NotifyExceptionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockCaption;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Views\NotifyExceptionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockErrMsg;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Views\NotifyExceptionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image1;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\NotifyExceptionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonClose;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\NotifyExceptionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander expanderDetails;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Views\NotifyExceptionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scrollViewerDetails;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Views\NotifyExceptionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxTechDetails;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Views\NotifyExceptionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCopyToClipboard;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ToolTracker;component/views/notifyexceptionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\NotifyExceptionWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.windowNotifyException = ((ToolTracker.Views.NotifyExceptionWindow)(target));
            
            #line 8 "..\..\..\Views\NotifyExceptionWindow.xaml"
            this.windowNotifyException.Loaded += new System.Windows.RoutedEventHandler(this.NotifyExceptionWindow_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBlockCaption = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.textBlockErrMsg = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.image1 = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.buttonClose = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Views\NotifyExceptionWindow.xaml"
            this.buttonClose.Click += new System.Windows.RoutedEventHandler(this.ButtonClose_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.expanderDetails = ((System.Windows.Controls.Expander)(target));
            
            #line 42 "..\..\..\Views\NotifyExceptionWindow.xaml"
            this.expanderDetails.Expanded += new System.Windows.RoutedEventHandler(this.ExpanderDetails_OnExpanded);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\Views\NotifyExceptionWindow.xaml"
            this.expanderDetails.Collapsed += new System.Windows.RoutedEventHandler(this.ExpanderDetails_OnCollapsed);
            
            #line default
            #line hidden
            return;
            case 7:
            this.scrollViewerDetails = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 8:
            this.textBoxTechDetails = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.buttonCopyToClipboard = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\Views\NotifyExceptionWindow.xaml"
            this.buttonCopyToClipboard.Click += new System.Windows.RoutedEventHandler(this.ButtonCopyToClipboard_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

