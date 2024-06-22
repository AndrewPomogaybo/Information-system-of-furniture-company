using ShopMetta.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ShopMetta.Views.Windows
{
    public partial class StatisticWindow : Window
    {
        private Button btn = new Button();
        public StatisticWindow()
        {
            InitializeComponent();
            DataContext = new StatisticViewModel(ProductTextBlock,TotalQuantityTextBlock, TotalRevenueTextBlock,salesCanvas,btn);
        }
        
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu seller = new AdminMenu("","");
            seller.Show();
            this.Close();
        }

        private void ExportReport_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new StatisticViewModel(ProductTextBlock, TotalQuantityTextBlock, TotalRevenueTextBlock, salesCanvas, ExportReport);
        }
    }
}
