using Microsoft.Win32;
using ShopMetta.Models;
using ShopMetta.ViewModels;
using ShopMetta.Views.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Xceed.Document.NET;
using Xceed.Words.NET;


namespace ShopMetta.Views.Windows
{
    public partial class Checkout : Window
    {
        private string _products;
        private string[] _arrProducts;
        private string _formattedDate;
        private int _prices;
        private List<int> _productAmount;
        private List<int> _productSum;
        private int _totalSum;

        

        public Checkout(string productNames, int productPrice, List<int>productAmount, List<int>productSum, int totalSum)
        {
            InitializeComponent();
            Client_combobox.ItemsSource = CheckuotViewModel.GetClients();
            _products = productNames;
            _prices = productPrice;
            _productAmount = productAmount;
            _productSum = productSum;
            _arrProducts = productNames.Split(',');
            _totalSum = totalSum;
            datePicker.DisplayDateStart = CheckuotViewModel.SetDateLimits();
            datePicker.DisplayDateEnd = CheckuotViewModel.SetDateLimits().AddDays(10);
        }

        private void exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void datePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (datePicker.SelectedDate.HasValue)
            {
                _formattedDate = datePicker.SelectedDate.Value.ToString("yyyy-MM-dd");
            }
        }

        private void CreateAndOpenWordDocument()
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "DOCX files (*.docx)|*.docx",
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                var doc = DocX.Create(filePath);

                Table t = doc.AddTable(_arrProducts.Length + 1, 3);

                doc.InsertParagraph("Кассовый чек").FontSize(30).Alignment = Alignment.center;
                doc.InsertParagraph();

                t.Alignment = Alignment.center;

                t.Rows[0].Cells[0].Paragraphs.First().Append("Наименование товара").FontSize(20).Alignment = Alignment.center;
                t.Rows[0].Cells[1].Paragraphs.First().Append("Количество").FontSize(20).Alignment = Alignment.center;
                t.Rows[0].Cells[2].Paragraphs.First().Append("Цена").FontSize(20).Alignment = Alignment.center;

                for (int i = 0; i < _arrProducts.Length; i++)
                {
                    t.Rows[i + 1].Cells[0].Paragraphs.First().Append(_arrProducts[i]).FontSize(20).Alignment = Alignment.center;
                    t.Rows[i + 1].Cells[1].Paragraphs.First().Append(_productAmount[i].ToString()).FontSize(20).Alignment = Alignment.center;
                    t.Rows[i + 1].Cells[2].Paragraphs.First().Append(_productSum[i].ToString()).FontSize(20).Alignment = Alignment.center;
                }
                doc.InsertTable(t);
                doc.InsertParagraph("-------------------------------------------------------------------------------------------------------------------------------------");

                Table inf = doc.AddTable(3, 2);
                inf.Alignment = Alignment.center;

                inf.Rows[0].Cells[0].Paragraphs.First().Append("Общая сумма").FontSize(20).Alignment = Alignment.center;
                inf.Rows[1].Cells[0].Paragraphs.First().Append("Покупатель").FontSize(20).Alignment = Alignment.center;
                inf.Rows[2].Cells[0].Paragraphs.First().Append("Дата выдачи ").FontSize(20).Alignment = Alignment.center;
                inf.Rows[0].Cells[1].Paragraphs.First().Append(_totalSum.ToString()).FontSize(20).Alignment = Alignment.center;
                inf.Rows[1].Cells[1].Paragraphs.First().Append($"{Client_combobox.Text.Split(' ')[1]} {Client_combobox.Text.Split(' ')[2]} {Client_combobox.Text.Split(' ')[3]}").FontSize(20).Alignment = Alignment.center;
                inf.Rows[2].Cells[1].Paragraphs.First().Append(_formattedDate).FontSize(20).Alignment = Alignment.center;
                doc.InsertTable(inf);

                doc.InsertParagraph();
                doc.InsertParagraph("Подпись ___________").FontSize(15);
                doc.Save();
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true});
            }

            
        }

        private void addOrder_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Сформировать чек?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                CreateAndOpenWordDocument();
                ShoppingCartViewModel.CreateOrderFromCart(Convert.ToInt32(Client_combobox.Text.Split(' ')[0]), Convert.ToDateTime(_formattedDate), _products, _prices);
                DialogResult = true;
                this.Close();
            }
            else
            {
                ShoppingCartViewModel.CreateOrderFromCart(Convert.ToInt32(Client_combobox.Text.Split(' ')[0]), Convert.ToDateTime(_formattedDate), _products, _prices);
                DialogResult = true;
                this.Close();
            }
        }
    }
}
