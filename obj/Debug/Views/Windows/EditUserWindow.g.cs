﻿#pragma checksum "..\..\..\..\Views\Windows\EditUserWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1D90E886F742A6349BBAD20E2CB0B2BDF54318E2DDD8B79877ADCFBBE9ACEBE9"
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
    /// EditUserWindow
    /// </summary>
    public partial class EditUserWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image exit;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Edit_btn;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name_txtbox;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox surname_txtbox;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pwd_txtbox;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox login_txtbox;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox role_combobox;
        
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
            System.Uri resourceLocater = new System.Uri("/ShopMetta;component/views/windows/edituserwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
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
            
            #line 8 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
            ((ShopMetta.Views.Windows.EditUserWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.exit = ((System.Windows.Controls.Image)(target));
            
            #line 27 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
            this.exit.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.exit_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Edit_btn = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
            this.Edit_btn.Click += new System.Windows.RoutedEventHandler(this.Edit_btn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.name_txtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 144 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
            this.name_txtbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.name_txtbox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.surname_txtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 154 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
            this.surname_txtbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.surname_txtbox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.pwd_txtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 164 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
            this.pwd_txtbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.pwd_txtbox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.login_txtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 174 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
            this.login_txtbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.login_txtbox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.role_combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 184 "..\..\..\..\Views\Windows\EditUserWindow.xaml"
            this.role_combobox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.role_combobox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

