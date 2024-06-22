using Microsoft.EntityFrameworkCore;
using ShopMetta.Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using System;
using System.Linq;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Data;


namespace ShopMetta.ViewModels
{
    public  class MasterViewModel
    {
        private static ObservableCollection<Master> _masters = new ObservableCollection<Master>();
        private static DataBaseContext _context = new DataBaseContext();
        public MasterViewModel(DataGrid dgv) 
        {
            LoadBasket(dgv);
        }

        private void LoadBasket(DataGrid dgv)
        {
            using (var dataBase = new DataBaseContext())
            {
                try
                {
                    var master = dataBase.Masters.Include(m => m.Qualification).ToList();
                    _masters = new ObservableCollection<Master>(master);
                    dgv.ItemsSource = _masters;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void SearchMasters(DataGrid dgv, TextBox txtbox)
        {
            string searchText = txtbox.Text.ToLower();

            foreach (var item in dgv.Items)
            {
                var row = dgv.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    if (item is Master master)
                    {
                        if (master.Master_surname.ToLower().Contains(searchText))
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

        public static void ApplyFilterAndSort(ComboBox filter, ComboBox sort, DataGrid dgv)
        {
            if (_masters == null) return;

            var collectionView = CollectionViewSource.GetDefaultView(dgv.ItemsSource);
            collectionView.Filter = null;
            collectionView.SortDescriptions.Clear();

            
            if (filter.SelectedItem is ComboBoxItem selectedFilterItem)
            {
                var selectedLastName = selectedFilterItem.Content.ToString();
                if (selectedLastName != "Все")
                {
                    collectionView.Filter = item =>
                    {
                        if (item is Master master)
                        {
                            return master.Qualification.Qualification_name == selectedLastName;
                        }
                        return false;
                    };
                }
            }

            
            if (sort.SelectedItem is ComboBoxItem selectedSortItem)
            {
                switch (selectedSortItem.Content.ToString())
                {
                    case "По алфавиту":
                        collectionView.SortDescriptions.Add(new SortDescription("Master_surname", ListSortDirection.Ascending));
                        break;
                    case "В обратном порядке":
                        collectionView.SortDescriptions.Add(new SortDescription("Master_surname", ListSortDirection.Descending));
                        break;
                    case "Сбросить":
                        collectionView.SortDescriptions.Clear();
                        break;
                }
            }

            collectionView.Refresh();
        }
    }
}
