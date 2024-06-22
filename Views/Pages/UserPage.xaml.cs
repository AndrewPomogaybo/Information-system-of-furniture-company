using ShopMetta.Models;
using ShopMetta.ViewModels;
using ShopMetta.Views.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ShopMetta.Views.Pages
{

    public partial class UserPage : Page
    {

        private int _id;
        private string _name;
        private string _surname;
        private string _login;
        private string _password;
        private string _role;

        private DataBaseContext _context = new DataBaseContext();

        public UserPage()
        {
            InitializeComponent();
            DataContext = new UserViewModel(User_dataGrid);
            LoadRolesToComboBox();
            UpdatepageInfo();
        }

        private void LoadRolesToComboBox()
        {
            List<string> roles = _context.Users.Select(u => u.Role.Role_name).Distinct().ToList();
            Filter.Items.Add(new ComboBoxItem { Content = "Все" });
            foreach (var role in roles)
            {
                Filter.Items.Add(new ComboBoxItem { Content = role });
            }
        }

        private void Edit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EditUserWindow editUser = new EditUserWindow(_id,_name,_surname,_login,_password,_role);
            if(editUser.ShowDialog() == true)
            {
                DataContext = new UserViewModel(User_dataGrid);
                UpdatepageInfo();
            }
                
        }

        private void User_dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (User_dataGrid.SelectedItem is User selected)
            {
                _id = selected.User_id;
                _name = selected.User_name;
                _surname = selected.User_surname;
                _login = selected.User_login;
                _password = selected.User_password;
                _role = selected.Role.Role_name;
            }
        }

        private void Delete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DeleteCommand.Delete<User>(_id);
                DataContext = new UserViewModel(User_dataGrid);
            }
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserViewModel.ApplyFilterAndSort(Filter, Sort, User_dataGrid);
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserViewModel.ApplyFilterAndSort(Filter, Sort, User_dataGrid);
        }

        private void Search_SelectionChanged(object sender, RoutedEventArgs e)
        {
            UserViewModel.SearchUsers(User_dataGrid, Search);
        }

        private void Add_Click_1(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUser = new AddUserWindow(_id);
            if(addUser.ShowDialog() == true)
            {
                DataContext = new UserViewModel(User_dataGrid);
                UpdatepageInfo();
            }
        }

        private void UpdatepageInfo()
        {
            var viewModel = DataContext as UserViewModel;
            currentPage.Text = viewModel.CurrentPage.ToString();
            totalPages.Text = viewModel.TotalPages.ToString();
        }

        private void right_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var viewModel = DataContext as UserViewModel;
            viewModel.NextPage();
            UpdatepageInfo();
        }

        private void left_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var viewModel = DataContext as UserViewModel;
            viewModel.PreviousPage();
            UpdatepageInfo();
        }
    }
}
