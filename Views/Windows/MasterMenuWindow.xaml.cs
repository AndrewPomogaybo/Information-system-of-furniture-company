using ShopMetta.Views.Pages;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;


namespace ShopMetta.Views.Windows
{
    
    public partial class MasterMenuWindow : Window
    {
        private string _name;
        private string _surname;


        public MasterMenuWindow(string name,string surname)
        {
            InitializeComponent();
            _name = name;
            _surname = surname;
            Place.Content = new StartPage(_name, _surname);
        }



        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Place.Content = new MastersPage();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Place.Content = new CreateOrderPage();
        }

        private void menu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Place.Content = new StartPage(_name, _surname);
        }

        

        

        
    }
}
