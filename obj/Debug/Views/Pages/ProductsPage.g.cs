﻿#pragma checksum "..\..\..\..\Views\Pages\ProductsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F0D9A34642E397C2699941409E76C050FB08FACDC320E1C2E1355F08DCE4B366"
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
    /// ProductsPage
    /// </summary>
    public partial class ProductsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 74 "..\..\..\..\Views\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Sort_combobox;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Views\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Search_txtbox;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Views\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Filter_combobox;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\Views\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\..\Views\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn infoColumn;
        
        #line default
        #line hidden
        
        
        #line 236 "..\..\..\..\Views\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn buyColumn;
        
        #line default
        #line hidden
        
        
        #line 283 "..\..\..\..\Views\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add;
        
        #line default
        #line hidden
        
        
        #line 298 "..\..\..\..\Views\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Back_btn;
        
        #line default
        #line hidden
        
        
        #line 302 "..\..\..\..\Views\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Next_btn;
        
        #line default
        #line hidden
        
        
        #line 306 "..\..\..\..\Views\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock currentPage;
        
        #line default
        #line hidden
        
        
        #line 314 "..\..\..\..\Views\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock totalPages;
        
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
            System.Uri resourceLocater = new System.Uri("/ShopMetta;component/views/pages/productspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Pages\ProductsPage.xaml"
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
            this.Sort_combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 74 "..\..\..\..\Views\Pages\ProductsPage.xaml"
            this.Sort_combobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Sort_combobox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Search_txtbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 82 "..\..\..\..\Views\Pages\ProductsPage.xaml"
            this.Search_txtbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_txtbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Filter_combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 92 "..\..\..\..\Views\Pages\ProductsPage.xaml"
            this.Filter_combobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Filter_combobox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 118 "..\..\..\..\Views\Pages\ProductsPage.xaml"
            this.dataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.infoColumn = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 9:
            this.buyColumn = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 11:
            this.Add = ((System.Windows.Controls.Button)(target));
            
            #line 283 "..\..\..\..\Views\Pages\ProductsPage.xaml"
            this.Add.Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Back_btn = ((System.Windows.Controls.Image)(target));
            
            #line 298 "..\..\..\..\Views\Pages\ProductsPage.xaml"
            this.Back_btn.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Back_btn_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Next_btn = ((System.Windows.Controls.Image)(target));
            
            #line 302 "..\..\..\..\Views\Pages\ProductsPage.xaml"
            this.Next_btn.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Next_btn_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 14:
            this.currentPage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 15:
            this.totalPages = ((System.Windows.Controls.TextBlock)(target));
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
            case 6:
            
            #line 212 "..\..\..\..\Views\Pages\ProductsPage.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.inf_btn_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 212 "..\..\..\..\Views\Pages\ProductsPage.xaml"
            ((System.Windows.Controls.Image)(target)).Loaded += new System.Windows.RoutedEventHandler(this.inf_btn_Loaded);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 221 "..\..\..\..\Views\Pages\ProductsPage.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 231 "..\..\..\..\Views\Pages\ProductsPage.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.edit_MouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 239 "..\..\..\..\Views\Pages\ProductsPage.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.buy_MouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
