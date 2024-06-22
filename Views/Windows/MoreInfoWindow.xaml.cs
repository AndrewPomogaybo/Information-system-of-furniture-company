using System;
using System.Windows;
using System.Windows.Media.Imaging;


namespace ShopMetta.Views.Windows
{
    public partial class MoreInfoWindow : Window
    {
        public MoreInfoWindow(string name, string desc, string category, string material, string price, string image, string colour, string amount)
        {
            InitializeComponent();
            name_txtBlock.Text = name;
            desc_txtBlock.Text = desc;  
            categoryTxtblock.Text = category;
            materialtxtblock.Text = material;
            pricetxtblock.Text = price;
            amountTxtblock.Text = amount;
            colourtxtblock.Text = colour;
            ProductImage.Source = new BitmapImage(new Uri(image));
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu seller = new AdminMenu("","");
            seller.Show();
            this.Close();
        }
    }
}
