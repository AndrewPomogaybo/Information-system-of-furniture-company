using ShopMetta.ViewModels;
using ShopMetta.ViewModels.Commands;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace ShopMetta.Views.Windows
{

    public partial class AddOrderCreateWindow : Window
    {
        private int _id;


        public AddOrderCreateWindow()
        {
            InitializeComponent();
            Client_cmb.ItemsSource = CreateOrderViewModel.GetClients();
        }

        private void name_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void description_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CreateOrderCommands(Add, _id, Convert.ToInt32(Client_cmb.Text.Split(' ')[0]),name_txtbox.Text, description_txtbox.Text,2,"",Convert.ToDateTime("2000-05-02"),Convert.ToInt32(sum_txtbox.Text));
            this.DialogResult = true;
            this.Close();
        }

        private void exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                this.Close();
        }

        private void sum_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
        }
    }
}
