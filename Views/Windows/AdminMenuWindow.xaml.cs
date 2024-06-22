using ShopMetta.Views.Pages;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ShopMetta.Views.Windows
{
    public partial class AdminMenuWindow : Window
    {
        private readonly DataBaseContext _context;
        private string _name;
        private string _surname;


        public AdminMenuWindow(string name, string surname)
        {
            InitializeComponent();
            _name = name;
            _surname = surname;
            Place.Content = new StartPage(_name, _surname);
        }

        

        

        

        
        private void Catalog_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Place.Content = new ProductsPage(_context);
        }

        private void Backup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Place.Content = new BackupPage();
        }

        private void User_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Place.Content = new UserPage();
        }

        private void Menu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Place.Content = new StartPage(_name, _surname);
        }
    }
}
