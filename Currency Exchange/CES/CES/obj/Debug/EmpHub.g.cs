﻿#pragma checksum "..\..\EmpHub.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A0604554E924A1444979D9BC5CDFD178E3179239D2169CF836BB727072B40B1A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CES;
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


namespace CES {
    
    
    /// <summary>
    /// EmpHub
    /// </summary>
    public partial class EmpHub : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\EmpHub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCE;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\EmpHub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnClients;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\EmpHub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEmployee;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\EmpHub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCurrency;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\EmpHub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame EmpFrame;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\EmpHub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Shutdown;
        
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
            System.Uri resourceLocater = new System.Uri("/CES;component/emphub.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EmpHub.xaml"
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
            this.BtnCE = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\EmpHub.xaml"
            this.BtnCE.Click += new System.Windows.RoutedEventHandler(this.BtnCE_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnClients = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\EmpHub.xaml"
            this.BtnClients.Click += new System.Windows.RoutedEventHandler(this.BtnClients_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnEmployee = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\EmpHub.xaml"
            this.BtnEmployee.Click += new System.Windows.RoutedEventHandler(this.BtnEmployee_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnCurrency = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\EmpHub.xaml"
            this.BtnCurrency.Click += new System.Windows.RoutedEventHandler(this.BtnCurrency_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EmpFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 6:
            this.Shutdown = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\EmpHub.xaml"
            this.Shutdown.Click += new System.Windows.RoutedEventHandler(this.Shutdown_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

