using Microsoft.EntityFrameworkCore;
using ShopMetta.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace ShopMetta.ViewModels
{
    internal class CreateOrderViewModel
    {
        private static ObservableCollection<CreateOrder> _orders;


        public CreateOrderViewModel(DataGrid dgv)
        {
            Load(dgv);
        }

        private void Load(DataGrid dgv)
        {
            try
            {
                using (var db = new DataBaseContext())
                {
                    var create = db.Order_for_creation
                        .Include(c => c.Status)
                        .Include(c => c.Client)
                        .ToList();

                    _orders = new ObservableCollection<CreateOrder>(create);
                    dgv.ItemsSource = _orders;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }


        public static List<string> GetClients()
        {
            using (var context = new DataBaseContext())
            {
                List<string> clientFullName = context.Clients.Select(c => c.FullName).ToList();
                return clientFullName;
            }
        }

        public static List<string> GetMasters()
        {
            using (var context = new DataBaseContext())
            {
                List<string> masterFullName = context.Masters.Select(c => c.FullName).ToList();
                return masterFullName;
            }
        }

        public static DateTime SetDateLimits()
        {
            return DateTime.Today;
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
                        if (item is CreateOrder creation)
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
                        collectionView.SortDescriptions.Add(new SortDescription("Creation_sum", ListSortDirection.Ascending));
                        break;
                    case "По убыванию":
                        collectionView.SortDescriptions.Add(new SortDescription("Creation_sum", ListSortDirection.Descending));
                        break;
                    case "Сбросить":
                        collectionView.SortDescriptions.Clear();
                        break;
                }
            }

            collectionView.Refresh();
        }


        public static void SearchCreateOrder(DataGrid dgv, TextBox txtbox)
        {
            string searchText = txtbox.Text.ToLower();

            foreach (var item in dgv.Items)
            {
                var row = dgv.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    if (item is CreateOrder creation)
                    {
                        if (creation.Creation_name.ToLower().Contains(searchText))
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
