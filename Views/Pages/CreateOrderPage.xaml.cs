using ShopMetta.Models;
using ShopMetta.ViewModels;
using ShopMetta.Views.Windows;
using System;
using System.Windows;
using System.Windows.Controls;



namespace ShopMetta.Views.Pages
{
    public partial class CreateOrderPage : Page
    {
        private int _id;
        private string _name;
        private int _price;
        private int _client;
        private string _description;
        private int _status;
        private DateTime _date;
        private string _master;

        public CreateOrderPage()
        {
            InitializeComponent();
            DataContext = new CreateOrderViewModel(Order_dataGrid);
            

        }

        private void Delete_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DeleteCommand.Delete<CreateOrder>(_id);
                DataContext = new CreateOrderViewModel(Order_dataGrid);
            }
        }

        private void Edit_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EditOrderCreationWindow editCreation = new EditOrderCreationWindow(_id,_name,_description, _price, _status,_master,_date,_client);
            if (editCreation.ShowDialog() == true)
                DataContext = new CreateOrderViewModel(Order_dataGrid);
            
        }

        private void Order_dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Order_dataGrid.SelectedItem is CreateOrder selected)
            {
                _id = selected.Creation_id;
                _name = selected.Creation_name;
                _description = selected.Creation_description;
                _client = selected.Creation_client;
                _status = selected.Creation_status;

                if(selected.Creation_master != null)
                    _master = selected.Creation_master;

                if(selected.Creation_date.HasValue)
                    _date = (DateTime)selected.Creation_date;

                _price = selected.Creation_sum;
            }
        }

        private void Search_SelectionChanged(object sender, RoutedEventArgs e)
        {
            CreateOrderViewModel.SearchCreateOrder(Order_dataGrid, Search);
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateOrderViewModel.ApplyFilterAndSort(Filter, Sort, Order_dataGrid);
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateOrderViewModel.ApplyFilterAndSort(Filter, Sort, Order_dataGrid);
        }
    }
}
