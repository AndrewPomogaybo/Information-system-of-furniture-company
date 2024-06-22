using ShopMetta.ViewModels;
using ShopMetta.ViewModels.Commands;
using System;
using System.Windows;
using System.Windows.Input;


namespace ShopMetta.Views.Windows
{

    public partial class EditOrderCreationWindow : Window
    {
        private int _id;
        private int _client;
        private string _name;
        private string _description;
        private int _sum;
        private int _status;
        public EditOrderCreationWindow(int id, string name, string description, int sum, int status,string master, DateTime date, int client)
        {
            InitializeComponent();
            _id = id;
            _name = name;
            _description = description;
            _sum = sum;
            _status = status;
            _client = client;
            Master_cmb.ItemsSource = CreateOrderViewModel.GetMasters();
            Master_cmb.Text = master;
            datePicker.DisplayDateStart = CreateOrderViewModel.SetDateLimits();
            datePicker.DisplayDateStart = CreateOrderViewModel.SetDateLimits().AddDays(10);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Master_cmb.SelectedItem.ToString());
            DataContext = new CreateOrderCommands(Edit, _id, _client, _name, _description, _status, Master_cmb.SelectedItem.ToString(), Convert.ToDateTime(datePicker.SelectedDate), _sum);
            DialogResult = true;
            this.Close();
        }

        private void exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                this.Close();
        }
    }
}
