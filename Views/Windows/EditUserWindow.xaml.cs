using ShopMetta.ViewModels.Commands;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace ShopMetta.Views.Windows
{
    public partial class EditUserWindow : Window
    {
        private int _id;
        private string _name;
        private string _surname;
        private string _login;
        private string _password;
        private int _role;
        public EditUserWindow(int id, string name, string surname, string login, string pwd, string role)
        {
            InitializeComponent();
            _id = id;
            name_txtbox.Text = name;
            surname_txtbox.Text = surname;
            login_txtbox.Text = login;
            role_combobox.Text = role.ToString();
            pwd_txtbox.Text = pwd;
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

        private void exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (role_combobox.Text)
                {
                    case "seller":
                        _role = 2;
                        break;
                    case "admin":
                        _role = 1;
                        break;
                    case "master":
                        _role = 3;
                        break;
                    default:
                        MessageBox.Show("Роль не найдена!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                }
                DataContext = new UserCommands(Edit_btn, _id, name_txtbox.Text, surname_txtbox.Text, login_txtbox.Text, pwd_txtbox.Text, _role);
                this.DialogResult = true;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void login_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[a-zA-Z]+$");
        }

        private void surname_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void name_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
        }

        private void role_combobox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void pwd_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[a-zA-Z]+$");
        }
    }
}
