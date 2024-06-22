using ShopMetta.ViewModels;
using ShopMetta.ViewModels.Commands;
using ShopMetta.Views.Pages;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ShopMetta.Views.Windows
{
    
    public partial class EditClientWindow : Window
    {
        private int _age = 0;
        private int _id = 0;
        
        public EditClientWindow(int id, string name, string surname, string patronymic, string phone, int age)
        {
            InitializeComponent();
            name_txtbox.Text = name;
            surname_txtbox.Text = surname;
            pat_txtbox.Text = patronymic;
            phone_txtbox.Text = phone;
            phone_txtbox.Text += phone;
            age_txtbox.Text = age.ToString();
            _age = age;
            _id = id;
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

        private void name_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void surname_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void pat_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void phone_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
        }

        private void name_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Handler.LowCharToUpper(name_txtbox);
        }

        private void surname_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Handler.LowCharToUpper(surname_txtbox);
        }

        private void pat_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Handler.LowCharToUpper(pat_txtbox);
        }

        private void phone_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClientsViewModel.MaskPhone(phone_txtbox);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ClientCommands(Edit, _id, name_txtbox.Text, surname_txtbox.Text, pat_txtbox.Text, Convert.ToInt32(age_txtbox.Text), phone_txtbox.Text);
            this.DialogResult = true;
            this.Close();
        }

        private void exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (_age == 0)
                return;

            if (_age < 100)
                plus.IsEnabled = true;

            _age--;
            age_txtbox.Text = _age.ToString();
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            _age++;
            age_txtbox.Text = _age.ToString();
            if (_age >= 100)
                plus.IsEnabled = false;
        }
    }
}
