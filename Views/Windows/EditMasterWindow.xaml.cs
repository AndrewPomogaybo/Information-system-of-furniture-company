using ShopMetta.ViewModels.Commands;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace ShopMetta.Views.Windows
{
    public partial class EditMasterWindow : Window
    {
        private int _id;
        private string _name;
        private string _surname;
        private int _qualification;


        public EditMasterWindow(int id, string name, string surname, int qualification)
        {
            InitializeComponent();
            _id = id;
            _name = name;
            _surname = surname;
            _qualification = qualification;

            name_txtbox.Text = _name;
            surname_txtbox.Text = _surname;

        }

        private void surname_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void name_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if(qualif_combobox.Text == null || name_txtbox.Text == null || surname_txtbox.Text == null)
                MessageBox.Show("Не все поля заполнены!","Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);

            switch (qualif_combobox.Text)
            {
                case "Мастер-конструктор":
                    _qualification = 1;
                    break;
                case "Мастер деревообработки":
                    _qualification = 2;
                    break;
                case "Мастер-технолог":
                    _qualification = 3;
                    break;
            }

            DataContext = new MasterCommands(Edit,_id,_name,_surname,_qualification);
            this.DialogResult = true;
            this.Close();
        }
    }
}
