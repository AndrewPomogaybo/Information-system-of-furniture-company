using Microsoft.EntityFrameworkCore;
using ShopMetta.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace ShopMetta.ViewModels
{
    public class OrderViewModel
    {
        private static ObservableCollection<Order> _orders { get; set; }
        private DataGrid _dataGrid;
        private int _currentPage = 1;
        private int _itemsPerPage = 10;
        private int _totalPages;

        private ICollectionView _productsView;

        public int CurrentPage => _currentPage;
        public int TotalPages => _totalPages;

        public ICollectionView ProductsView
        {
            get { return _productsView; }
            set
            {
                _productsView = value;
            }
        }

        public OrderViewModel(DataGrid dgv)
        {
            _dataGrid = dgv;
            LoadOrder();
        }

        private void LoadOrder()
        {
            using (var db = new DataBaseContext())
            {
                try
                {
                    var orders = db.Orders
                        .Include(o => o.Client)
                        .Include(o => o.Status)
                        .ToList();

                    _orders = new ObservableCollection<Order>(orders);
                    _dataGrid.ItemsSource = _orders;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        public static void ApplyFilterAndSort(ComboBox filter, ComboBox sort, DataGrid dgv)
        {
            if (_orders == null) return;

            var collectionView = CollectionViewSource.GetDefaultView(dgv.ItemsSource);
            collectionView.Filter = null;
            collectionView.SortDescriptions.Clear();

            // Apply filter
            if (filter.SelectedItem is ComboBoxItem selectedFilterItem)
            {
                var selectedLastName = selectedFilterItem.Content.ToString();
                if (selectedLastName != "Все")
                {
                    collectionView.Filter = item =>
                    {
                        if (item is Order creation)
                        {
                            return creation.Status.Status_name == selectedLastName;
                        }
                        return false;
                    };
                }
            }

            // Apply sort
            if (sort.SelectedItem is ComboBoxItem selectedSortItem)
            {
                switch (selectedSortItem.Content.ToString())
                {
                    case "По возрастанию":
                        collectionView.SortDescriptions.Add(new SortDescription("Order_sum", ListSortDirection.Ascending));
                        break;
                    case "По убыванию":
                        collectionView.SortDescriptions.Add(new SortDescription("Order_sum", ListSortDirection.Descending));
                        break;
                    case "Сбросить":
                        collectionView.SortDescriptions.Clear();
                        break;
                }
            }

            collectionView.Refresh();
        }


        public static void SearchOrder(DataGrid dgv, TextBox txtbox)
        {
            string searchText = txtbox.Text.ToLower();

            foreach (var item in dgv.Items)
            {
                var row = dgv.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    if (item is Order order)
                    {
                        if (order.Order_basket.ToLower().Contains(searchText))
                        {
                            row.Background = Brushes.Yellow;
                            row.BringIntoView();
                        }
                        else
                        {
                            row.Background = Brushes.White;
                        }

                        if (string.IsNullOrEmpty(searchText))
                        {
                            row.Background = Brushes.White;
                        }
                    }
                }
            }
        }


    }
}
