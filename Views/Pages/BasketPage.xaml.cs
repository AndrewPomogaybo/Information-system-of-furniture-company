using ShopMetta.Models;
using ShopMetta.ViewModels;
using ShopMetta.Views.Windows;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ShopMetta.Views.Pages
{
    public partial class BasketPage : Page
    {
        private int _id;
        
        public BasketPage()
        {
            InitializeComponent();
            Basket_dataGrid.Loaded += Basket_dataGrid_Loaded;
            DataContext = new ShoppingCartViewModel(Basket_dataGrid);
        }

        private void Basket_dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new ShoppingCartViewModel(Basket_dataGrid);
            totalSum.Text = ShoppingCartViewModel.UpdateTotalSum(Basket_dataGrid).ToString();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DeleteCommand.Delete<Basket>(_id);
                DataContext = new ShoppingCartViewModel(Basket_dataGrid);
                ShoppingCartViewModel.UpdateTotalSum(Basket_dataGrid).ToString();
            }
        }

        private void Basket_dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Basket_dataGrid.SelectedItem is Basket selected)
            {
                _id = selected.Basket_id;
            }
        }

        private void addOrder_Click(object sender, RoutedEventArgs e)
        {
            Checkout addOrder = new Checkout(ShoppingCartViewModel.GetProductNames(Basket_dataGrid), ShoppingCartViewModel.GetProductPrice(Basket_dataGrid), ShoppingCartViewModel.GetProductAmount(Basket_dataGrid), ShoppingCartViewModel.GetProductSum(Basket_dataGrid),Convert.ToInt32(totalSum.Text));
            if(addOrder.ShowDialog() == true)
                DataContext = new ShoppingCartViewModel(Basket_dataGrid);
        }

        private void refresh_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new ShoppingCartViewModel(Basket_dataGrid);
        }
    }
}
