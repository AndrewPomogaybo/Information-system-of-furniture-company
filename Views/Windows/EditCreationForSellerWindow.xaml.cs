using ShopMetta.ViewModels.Commands;
using System;
using System.Windows;
using System.Windows.Input;


namespace ShopMetta.Views.Windows
{

    public partial class EditCreationForSellerWindow : Window
    {
        private int _id;
        private int _status;

        public EditCreationForSellerWindow(int id, int status)
        {
            InitializeComponent();
            _id = id;
            _status = status;
        }

        private void exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void Edit_seller_Click(object sender, RoutedEventArgs e)
        {
            switch (Status_cmb.Text)
            {
                case "Получен":
                    _status = 1;
                    break;
                case "Не получен":
                    _status = 2;
                    break;
            }
            DataContext = new CreateOrderCommands(Edit_seller,_id,1,"","",_status,"",Convert.ToDateTime("2004-05-05"),1);
            DialogResult = true;
            this.Close();
        }
    }
}
