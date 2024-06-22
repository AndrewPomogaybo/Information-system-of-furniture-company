using ShopMetta.ViewModels;
using ShopMetta.ViewModels.Commands;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ShopMetta.Views.Windows
{
    public partial class AddClientWindow : Window
    {
        private int _id;
        private int age = 0;
        private static DataGrid dgv = new DataGrid();

        private DispatcherTimer _inactivityTimer;
        private readonly TimeSpan _inactivityTimeLimit = TimeSpan.FromSeconds(20);

        public AddClientWindow(int id)
        {
            InitializeComponent();
            _id = id;
            //InitializeInactivityTimer();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ClientCommands(Add, _id, name_txtbox.Text, surname_txtbox.Text, pat_txtbox.Text, Convert.ToInt32(age_txtbox.Text), phone_txtbox.Text);
            this.DialogResult = true;
            this.Close();
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (age == 0)
                return;

            if(age < 100)
                plus.IsEnabled = true;
                
            age--;
            age_txtbox.Text = age.ToString();

        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            age++;
            age_txtbox.Text = age.ToString();
            if (age >= 100)
                plus.IsEnabled = false;
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
            if (!phone_txtbox.Text.StartsWith("+7"))
                phone_txtbox.Text = "+7";

            if (phone_txtbox.Text.Length > 12)
                phone_txtbox.Text = phone_txtbox.Text.Substring(0, 12);

            phone_txtbox.SelectionStart = phone_txtbox.Text.Length;
            
        }

    }
}
