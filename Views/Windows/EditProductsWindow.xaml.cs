using ShopMetta.ViewModels;
using ShopMetta.ViewModels.Commands;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace ShopMetta.Views.Windows
{
    public partial class EditProductsWindow : Window
    {
        private int _id;
        public EditProductsWindow(int id, string name, string description, string category, string material, int price, int amount, string colour, string image)
        {
            InitializeComponent();
            name_txtbox.Text = name;
            description_txtbox.Text = description;
            category_combobox.Text = category;
            material_combobox.Text = material;
            amount_txtbox.Text = amount.ToString();
            colour_txtbox.Text = colour;
            image_txtbox.Text = image;
            price_txtbox.Text = price.ToString();
            img_view.Source = new BitmapImage(new Uri(image));
            _id = id;
        }

        private void exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {

            
            
                string name = name_txtbox.Text;
                string category = category_combobox.Text;

                switch (category)
                {
                    case "Диван":
                        category = 1.ToString();
                        break;
                    case "Кресла":
                        category = 2.ToString();
                        break;
                    case "Пуфики":
                        category = 3.ToString();
                        break;
                    default:
                        MessageBox.Show("Категория не найдена","Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                }

                string description = description_txtbox.Text;
                string colour = colour_txtbox.Text;
                int price = Convert.ToInt32(price_txtbox.Text);
                string material = material_combobox.Text;
                int amount = Convert.ToInt32(amount_txtbox.Text);
                string img = System.IO.Path.GetFileName(image_txtbox.Text);

                switch (material)
                {
                    case "Кожа":
                        material = 1.ToString();
                        break;
                    case "Замша":
                        material = 2.ToString();
                        break;
                    default:
                        MessageBox.Show("Материал не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
            }

                ProductCommands.Update(_id, name, Convert.ToInt32(category), description, Convert.ToInt32(material), amount, colour, price, img);
                this.DialogResult = true;
                this.Close();
            
            

            
        }

        private void Upload_btn_Click(object sender, RoutedEventArgs e)
        {
            ProductsViewModel.UploadPhoto(img_view, image_txtbox);
        }

        private void name_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void description_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void colour_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void price_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
        }

        private void amount_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
        }

        private void category_combobox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }

        private void material_combobox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-я]+$");
        }
    }
}
