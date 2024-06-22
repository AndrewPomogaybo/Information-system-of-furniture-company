
using ShopMetta.Models;
using ShopMetta.ViewModels;
using ShopMetta.Views.Windows;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ShopMetta.Views.Pages
{
    public partial class OrderPage : Page
    {
        
        private int _id;
        private string _name;
        private int _price;
        private int _client;
        private string _description;
        private int _status;
        private DateTime _date;
        private string _master;


        private DataBaseContext _context = new DataBaseContext();
        public OrderPage()
        {
            InitializeComponent();
            DataContext = new OrderViewModel(Order_dataGrid);
            DataContext = new CreateOrderViewModel(CreateOrder_dataGrid);
        }

        private void delete_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DeleteCommand.Delete<Order>(_id);
                DataContext = new OrderViewModel(Order_dataGrid);
            }
        }

        private void edit_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EditOrderWindow editOrder = new EditOrderWindow(_status,_id,_name);
            if(editOrder.ShowDialog() == true)
                DataContext = new OrderViewModel(Order_dataGrid);
        }

        private void Order_dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Order_dataGrid.SelectedItem is Order selected)
            {
                _id = selected.Order_id;
                _status = selected.Order_status;
                _name = selected.Order_basket;
            }
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderViewModel.ApplyFilterAndSort(Filter, Sort, Order_dataGrid);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddOrderCreateWindow addCreate = new AddOrderCreateWindow();
            if(addCreate.ShowDialog() == true)
                DataContext = new CreateOrderViewModel(CreateOrder_dataGrid);
        }

        private void SearchCreate_SelectionChanged(object sender, RoutedEventArgs e)
        {
            CreateOrderViewModel.SearchCreateOrder(CreateOrder_dataGrid,SearchCreate);
        }

        private void Del_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DeleteCommand.Delete<CreateOrder>(_id);
                DataContext = new CreateOrderViewModel(CreateOrder_dataGrid);
            }
        }

        private void CreateOrder_dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CreateOrder_dataGrid.SelectedItem is CreateOrder selected)
            {
                _id = selected.Creation_id;
                _name = selected.Creation_name;
                _description = selected.Creation_description;
                _client = selected.Creation_client;
                _status = selected.Creation_status;

                if (selected.Creation_master != null)
                    _master = selected.Creation_master;

                if (selected.Creation_date.HasValue)
                    _date = (DateTime)selected.Creation_date;

                _price = selected.Creation_sum;
            }
        }

        private void FilterCreate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateOrderViewModel.ApplyFilterAndSort(FilterCreate, SortCreate, CreateOrder_dataGrid);
        }

        private void SortCreate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateOrderViewModel.ApplyFilterAndSort(FilterCreate, SortCreate, CreateOrder_dataGrid);
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderViewModel.ApplyFilterAndSort(Filter, Sort, Order_dataGrid);
        }

        private void Search_SelectionChanged(object sender, RoutedEventArgs e)
        {
            OrderViewModel.SearchOrder(Order_dataGrid, Search);
        }

        
        private void Edit_seller_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EditCreationForSellerWindow editForSeller = new EditCreationForSellerWindow(_id, _status);
            if (editForSeller.ShowDialog() == true)
                DataContext = new CreateOrderViewModel(CreateOrder_dataGrid);
        }

        private void info_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            InfoOrderWindow order = new InfoOrderWindow();
            order.Show();
            AdminMenu seller = (AdminMenu)Window.GetWindow(this);
            seller.Close();
        }
    }
}
