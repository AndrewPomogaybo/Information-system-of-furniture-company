﻿#pragma checksum "..\..\..\..\Views\Pages\ClientsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BCDA415EBFB3088B7DAFD94403FA5622DB1A46AC4C360CBD9A5852E44EF66B60"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ShopMetta.Views.Pages;
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


namespace ShopMetta.Views.Pages {
    
    
    /// <summary>
    /// ClientsPage
    /// </summary>
    public partial class ClientsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 36 "..\..\..\..\Views\Pages\ClientsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Views\Pages\ClientsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Clients_dataGrid;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\..\..\Views\Pages\ClientsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image refreshData;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\..\Views\Pages\ClientsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Sort_combobox;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\..\Views\Pages\ClientsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search_txtbox;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\..\..\Views\Pages\ClientsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Filter_combobox;
        
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
            System.Uri resourceLocater = new System.Uri("/ShopMetta;component/views/pages/clientspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Pages\ClientsPage.xaml"
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
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Views\Pages\ClientsPage.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Clients_dataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 55 "..\..\..\..\Views\Pages\ClientsPage.xaml"
            this.Clients_dataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Clients_dataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.refreshData = ((System.Windows.Controls.Image)(target));
            
            #line 143 "..\..\..\..\Views\Pages\ClientsPage.xaml"
            this.refreshData.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.refreshData_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Sort_combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 159 "..\..\..\..\Views\Pages\ClientsPage.xaml"
            this.Sort_combobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Sort_combobox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Search_txtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 167 "..\..\..\..\Views\Pages\ClientsPage.xaml"
            this.Search_txtbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_txtbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Filter_combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 177 "..\..\..\..\Views\Pages\ClientsPage.xaml"
            this.Filter_combobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Filter_combobox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 109 "..\..\..\..\Views\Pages\ClientsPage.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.delete_MouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 117 "..\..\..\..\Views\Pages\ClientsPage.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.edit_MouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

