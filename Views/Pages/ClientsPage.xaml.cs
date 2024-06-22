using ShopMetta.Models;
using ShopMetta.ViewModels;
using ShopMetta.Views.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ShopMetta.Views.Pages
{
    public partial class ClientsPage : Page
    {

        private int _id;
        private string _name;
        private string _surname;
        private string _patronymic;
        private int _age;
        private string _phone;
        private DataBaseContext _context = new DataBaseContext();
        private ObservableCollection<Client> _clients = new ObservableCollection<Client>();
        

        public ClientsPage()
        {
            InitializeComponent();
            DataContext = new ClientsViewModel(Clients_dataGrid);
            LoadLastNamesToComboBox();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClient = new AddClientWindow(_id);
            if(addClient.ShowDialog() == true)
                DataContext = new ClientsViewModel(Clients_dataGrid);

        }

        private void edit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EditClientWindow editClient = new EditClientWindow(_id,_name,_surname,_patronymic,_phone,_age);
            if (editClient.ShowDialog() == true)
                DataContext = new ClientsViewModel(Clients_dataGrid);

        }

        private void delete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DeleteCommand.Delete<Client>(_id);
                DataContext = new ClientsViewModel(Clients_dataGrid);
            }
        }

        private void LoadLastNamesToComboBox()
        {
            var lastNames = _context.Clients.Select(c => c.Client_surname).Distinct().ToList();
            Filter_combobox.Items.Add(new ComboBoxItem { Content = "Все" });
            foreach (var lastName in lastNames)
            {
                Filter_combobox.Items.Add(new ComboBoxItem { Content = lastName });
            }
        }

        private void Clients_dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Clients_dataGrid.SelectedItem is Client selected)
            {
                _id = selected.Client_id;
                _name = selected.Client_name;
                _surname = selected.Client_surname;
                _patronymic = selected.Client_patronymic;
                _age = selected.Client_age;
                _phone = selected.Client_phone;
            }
        }

        private void currentPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Search_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClientsViewModel.SearchClients(Clients_dataGrid, Search_txtbox);
        }

        private void refreshData_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new ClientsViewModel(Clients_dataGrid);
        }

        private void Sort_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClientsViewModel.ApplyFilterAndSort(Filter_combobox, Sort_combobox, Clients_dataGrid);
        }

        private void Filter_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClientsViewModel.ApplyFilterAndSort(Filter_combobox,Sort_combobox, Clients_dataGrid);
        }

    }
}
