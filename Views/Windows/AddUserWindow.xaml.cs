using ShopMetta.ViewModels.Commands;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ShopMetta.Views.Windows
{
    public partial class AddUserWindow : Window
    {
        private int _id;
        private int _role;
        public AddUserWindow(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch
            {

            }
        }
        
        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            switch (role_combobox.Text)
            {
                case "Продавец":
                    _role = 2;
                    break;
                case "Админ":
                    _role = 1;
                    break;
                case "Начальник цеха":
                    _role = 3;
                    break;
            }
            DataContext = new UserCommands(Add_btn, Convert.ToInt32(_id),name_txtbox.Text,surname_txtbox.Text,login_txtbox.Text,pwd_txtbox.Text,_role);
            this.DialogResult = true;
            this.Close(); ;
        }

        private void name_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void surname_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void login_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[a-zA-Z]+$");
        }

        private void pwd_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[a-zA-Z]+$");
        }
    }
}
