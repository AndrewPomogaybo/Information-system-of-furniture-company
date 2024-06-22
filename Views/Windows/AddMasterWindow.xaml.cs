using ShopMetta.ViewModels.Commands;
using ShopMetta.Views.Pages;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace ShopMetta.Views.Windows
{
    public partial class AddMasterWindow : Window
    {
        private int _id;
        private int _qualification;
        public AddMasterWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            switch (qualif_combobox.Text)
            {
                case "Мастер-конструктор":
                    _qualification = 1;
                    break;
                case "Мастер-деревообработки":
                    _qualification = 2;
                    break;
                case "Мастер-технолог":
                    _qualification = 3;
                    break;
            }

            DataContext = new MasterCommands(Add,_id, name_txtbox.Text, surname_txtbox.Text, _qualification);
            this.DialogResult = true;
            this.Close();
        }

       
        private void name_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void surname_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }
    }
}
