﻿#pragma checksum "..\..\..\..\Views\Windows\AddOrderCreateWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0FED6A6D35632A84EBCE0E98171E9A4CC5F3928B53AE6F75DCB3C3A59E6C30AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ShopMetta.Views.Windows;
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


namespace ShopMetta.Views.Windows {
    
    
    /// <summary>
    /// AddOrderCreateWindow
    /// </summary>
    public partial class AddOrderCreateWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\Views\Windows\AddOrderCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image exit;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Views\Windows\AddOrderCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sum_txtbox;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\Views\Windows\AddOrderCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Client_cmb;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\Views\Windows\AddOrderCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name_txtbox;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\Views\Windows\AddOrderCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox description_txtbox;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\..\Views\Windows\AddOrderCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
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
            System.Uri resourceLocater = new System.Uri("/ShopMetta;component/views/windows/addordercreatewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Windows\AddOrderCreateWindow.xaml"
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
            this.exit = ((System.Windows.Controls.Image)(target));
            
            #line 32 "..\..\..\..\Views\Windows\AddOrderCreateWindow.xaml"
            this.exit.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.exit_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.sum_txtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 79 "..\..\..\..\Views\Windows\AddOrderCreateWindow.xaml"
            this.sum_txtbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.sum_txtbox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Client_cmb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.name_txtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 98 "..\..\..\..\Views\Windows\AddOrderCreateWindow.xaml"
            this.name_txtbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.name_txtbox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.description_txtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 108 "..\..\..\..\Views\Windows\AddOrderCreateWindow.xaml"
            this.description_txtbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.description_txtbox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 130 "..\..\..\..\Views\Windows\AddOrderCreateWindow.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

