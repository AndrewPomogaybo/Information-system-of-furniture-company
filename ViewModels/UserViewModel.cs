using ShopMetta.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Media;

namespace ShopMetta.ViewModels
{
    public class UserViewModel
    {
        private static ObservableCollection<User> _users { get; set; }
        private DataGrid _dataGrid;

        private int _currentPage = 1;
        private int _itemsPerPage = 10;
        private int _totalPages;

        public int CurrentPage => _currentPage;
        public int TotalPages => _totalPages;

        public UserViewModel(DataGrid dataGrid) 
        {
            _dataGrid = dataGrid;
            LoadUsers();
        }


        public void LoadUsers()
        {
            using (var DataBase = new DataBaseContext())
            {
                try
                {
                    var totalItems = DataBase.Users.Count();
                    _totalPages = (int)Math.Ceiling(totalItems / (double)_itemsPerPage);

                    var user = DataBase.Users
                                     .Skip((_currentPage - 1) * _itemsPerPage)
                                     .Take(_itemsPerPage)
                                     .Include(u => u.Role)
                                     .ToList();
                    _users = new ObservableCollection<User>(user);
                    
                    _dataGrid.ItemsSource = _users;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void ApplyFilterAndSort(ComboBox filter, ComboBox sort, DataGrid dgv)
        {
            if (_users == null) return;

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
                        if (item is User user)
                        {
                            return user.Role.Role_name == selectedLastName;
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
                    case "По алфавиту":
                        collectionView.SortDescriptions.Add(new SortDescription("User_surname", ListSortDirection.Ascending));
                        break;
                    case "В обратном порядке":
                        collectionView.SortDescriptions.Add(new SortDescription("User_surname", ListSortDirection.Descending));
                        break;
                    case "Сбросить":
                        collectionView.SortDescriptions.Clear();
                        break;
                }
            }

            collectionView.Refresh();
        }


        public static void SearchUsers(DataGrid dgv, TextBox txtbox)
        {
            string searchText = txtbox.Text.ToLower();

            foreach (var item in dgv.Items)
            {
                var row = dgv.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    if (item is User user)
                    {
                        if (user.User_surname.ToLower().Contains(searchText))
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


        public void NextPage()
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadUsers();
            }
        }

        public void PreviousPage()
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadUsers();
            }
        }


    }
}
