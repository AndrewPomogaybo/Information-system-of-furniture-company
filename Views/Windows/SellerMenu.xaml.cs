using ShopMetta.ViewModels;
using ShopMetta.Views.Pages;
using ShopMetta.Views.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;


namespace ShopMetta.Views
{

    public partial class AdminMenu : Window
    {
        private readonly DataBaseContext _context;
        private string _name;
        private string _surname;


        public AdminMenu(string name, string surname)
        {
            InitializeComponent();
            _name = name;
            _surname = surname;
        }


        
        

        private void ShowLoginWindow()
        {
            
            Application.Current.Dispatcher.Invoke(() =>
            {

                foreach (Window window in Application.Current.Windows.Cast<Window>().ToList())
                {
                    window.Hide(); 
                }
                MainWindow main = new MainWindow();
                main.Show();
            });
        }


        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        

        

        private void catalog_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Place.Content = new ProductsPage(_context);

        }

        private void clients_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Place.Content = new ClientsPage();
        }

        private void menu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Place.Content = new StartPage(_name,_surname);
        }

        private void basket_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Place.Content = new BasketPage();
        }

        private void order_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Place.Content = new OrderPage();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Place.Content = new StartPage(_name, _surname);
        }

        private void stat_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StatisticWindow stat = new StatisticWindow();
            stat.Show();
            AdminMenu seller = (AdminMenu)Window.GetWindow(this);
            seller.Close();
        }

        
        
        
    }


}
