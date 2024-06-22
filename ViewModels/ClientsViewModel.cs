
using ShopMetta.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Media;


namespace ShopMetta.ViewModels
{
    public class ClientsViewModel
    {
        private static ObservableCollection<Client> _clients { get; set; }
        private ICollectionView _clientsView;
        private DataGrid _dataGrid;

        public ICollectionView ClientsView
        {
            get { return _clientsView; }
            set
            {
                _clientsView = value;
            }
        }

        public ClientsViewModel(DataGrid dataGrid) 
        {
            _dataGrid = dataGrid;
            LoadClients();
            ClientsView = CollectionViewSource.GetDefaultView(_clients);
        }

        private void LoadClients()
        {
            using (var DataBase = new DataBaseContext())
            {
                try
                {
                    var clients = DataBase.Clients.ToList();
                    _clients = new ObservableCollection<Client>(clients);
                    _dataGrid.ItemsSource = _clients;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void SearchClients(DataGrid dgv, TextBox txtbox)
        {
            string searchText = txtbox.Text.ToLower();

            foreach (var item in dgv.Items)
            {
                var row = dgv.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    if (item is Client client)
                    {
                        if (client.Client_surname.ToLower().Contains(searchText))
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


        public static void ApplyFilterAndSort(ComboBox Filt, ComboBox Sort, DataGrid dataGrid)
        {
            if (_clients == null) return;

            var collectionView = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
            collectionView.Filter = null;
            collectionView.SortDescriptions.Clear();

            // Фильтр
            if (Filt.SelectedItem is ComboBoxItem selectedFilterItem)
            {
                var selectedLastName = selectedFilterItem.Content.ToString();
                if (selectedLastName != "Все")
                {
                    collectionView.Filter = item =>
                    {
                        if (item is Client client)
                        {
                            return client.Client_surname == selectedLastName;
                        }
                        return false;
                    };
                }
            }

            // Сортировка
            if (Sort.SelectedItem is ComboBoxItem selectedSortItem)
            {
                switch (selectedSortItem.Content.ToString())
                {
                    case "По алфавиту":
                        collectionView.SortDescriptions.Add(new SortDescription("Client_surname", ListSortDirection.Ascending));
                        break;
                    case "В обратном порядке":
                        collectionView.SortDescriptions.Add(new SortDescription("Client_surname", ListSortDirection.Descending));
                        break;
                    case "Сбросить":
                        collectionView.SortDescriptions.Clear();
                        break;
                }
            }

            collectionView.Refresh();
        }

        public static void MaskPhone(TextBox text)
        {
            if (!text.Text.StartsWith("+7"))
                text.Text = "+7";

            if (text.Text.Length > 12)
                text.Text = text.Text.Substring(0, 12);

            text.SelectionStart = text.Text.Length;
        }


        public void AgePlus(Button btn, int age, TextBox txt)
        {
            age++;
            txt.Text = age.ToString();
            if (age >= 100)
                btn.IsEnabled = false;
        }

        public void AgeMinus(Button btn, int age, TextBox txt)
        {
            if (age == 0)
                return;

            if(age < 100)
                btn.IsEnabled = true;
                
            age--;
            txt.Text = age.ToString();
        }
    }
}
