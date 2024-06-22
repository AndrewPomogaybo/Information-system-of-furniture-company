using ShopMetta.ViewModels;
using ShopMetta.ViewModels.Commands;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace ShopMetta.Views.Windows
{
    public partial class AddProductsWindow : Window
    {
        public AddProductsWindow()
        {
            InitializeComponent();
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
            try
            {
                string name = name_txtbox.Text;
                string category = category_combobox.Text;

                switch (category)
                {
                    case "Кресла":
                        category = 2.ToString();
                        break;
                    case "Диван":
                        category = 1.ToString();
                        break;
                    case "Пуфики":
                        category = 3.ToString();
                        break;
                }

                string description = description_txtbox.Text;
                string colour = colour_txtbox.Text;
                int price = Convert.ToInt32(price_txtbox.Text);
                string material = material_combobox.Text;
                int amount = Convert.ToInt32(amount_txtbox.Text);
                string img = image_txtbox.Text;

                switch (material)
                {
                    case "Кожа":
                        material = 1.ToString();
                        break;
                    case "Замша":
                        material = 2.ToString();
                        break;
                }

                ProductCommands.Add(name, Convert.ToInt32(category), description, Convert.ToInt32(material), amount, colour, price, img);


                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Upload_btn_Click(object sender, RoutedEventArgs e)
        {
            ProductsViewModel.UploadPhoto(Image, image_txtbox);
        }

        private void price_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
        }

        private void image_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void colour_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void description_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void name_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void amount_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
        }
    }
}
