
using System.Windows;


namespace ShopMetta.Views.Windows
{

    public partial class InfoOrderWindow : Window
    {
        public InfoOrderWindow()
        {
            InitializeComponent();
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu seller = new AdminMenu("","");
            seller.Show();
            this.Close();
        }
    }
}
