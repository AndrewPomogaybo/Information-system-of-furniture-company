﻿#pragma checksum "..\..\..\..\Views\Windows\EditClientWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "14ED305316FCCC4BAF6CDA5D23A1AFD6B5B57513BF6512A23A04E9714F979137"
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
    /// EditClientWindow
    /// </summary>
    public partial class EditClientWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image exit;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name_txtbox;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox surname_txtbox;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pat_txtbox;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox age_txtbox;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button plus;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minus;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phone_txtbox;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Edit;
        
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
            System.Uri resourceLocater = new System.Uri("/ShopMetta;component/views/windows/editclientwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
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
            
            #line 9 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
            ((ShopMetta.Views.Windows.EditClientWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.exit = ((System.Windows.Controls.Image)(target));
            
            #line 32 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
            this.exit.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.exit_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.name_txtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 69 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
            this.name_txtbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.name_txtbox_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 69 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
            this.name_txtbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.name_txtbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.surname_txtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 83 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
            this.surname_txtbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.surname_txtbox_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 83 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
            this.surname_txtbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.surname_txtbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.pat_txtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 97 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
            this.pat_txtbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.pat_txtbox_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 97 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
            this.pat_txtbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.pat_txtbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.age_txtbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.plus = ((System.Windows.Controls.Button)(target));
            
            #line 132 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
            this.plus.Click += new System.Windows.RoutedEventHandler(this.plus_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.minus = ((System.Windows.Controls.Button)(target));
            
            #line 142 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
            this.minus.Click += new System.Windows.RoutedEventHandler(this.minus_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.phone_txtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 158 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
            this.phone_txtbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.phone_txtbox_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 158 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
            this.phone_txtbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.phone_txtbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Edit = ((System.Windows.Controls.Button)(target));
            
            #line 169 "..\..\..\..\Views\Windows\EditClientWindow.xaml"
            this.Edit.Click += new System.Windows.RoutedEventHandler(this.Edit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
