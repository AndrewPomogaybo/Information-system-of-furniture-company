using ShopMetta.ViewModels.Commands;
using ShopMetta.Views.Pages;
using System.Windows;

namespace ShopMetta.Views.Windows
{
    public partial class EditOrderWindow : Window
    {
        private int _id;
        private int _status;

        public EditOrderWindow(int status, int id, string name)
        {
            InitializeComponent();
            _id = id;
            _status = status;
            nameOrder_txtbox.Text = name;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            switch (statusOrder_txtbox.Text)
            {
                case "Получен":
                    _status = 1;
                    break;
                case "Не получен":
                    _status = 2;
                    break;
            }

            DataContext = new OrderCommands(_id, nameOrder_txtbox.Text, _status);
            this.DialogResult = true;
            this.Close(); ;
        }

        private void exit_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }
    }
}
