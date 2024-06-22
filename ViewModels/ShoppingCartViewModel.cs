using Microsoft.EntityFrameworkCore;
using ShopMetta.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ShopMetta.ViewModels
{
    public class ShoppingCartViewModel
    {
        private ObservableCollection<Basket> _carts { get; set; }
        private DataGrid _dataGrid;

        public ShoppingCartViewModel(DataGrid dataGrid)
        {
            _dataGrid = dataGrid;
            LoadBasket();
        }


        public void LoadBasket()
        {
            using (var dataBase = new DataBaseContext())
            {
                try
                {
                    var cart = dataBase.Basket.Include(c => c.Product).ToList();
                    _carts = new ObservableCollection<Basket>(cart);
                    LoadPhoto();
                    _dataGrid.ItemsSource = _carts;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void LoadPhoto()
        {
            foreach (var cart in _carts)
            {
                try
                {
                    cart.Basket_image = System.IO.Path.GetFullPath($"Images/" + cart.Basket_image);
                    cart.Image = new BitmapImage(new Uri(cart.Basket_image));
                }
                catch
                {
                    cart.Basket_image = System.IO.Path.GetFullPath($"Images/picture.png");
                    cart.Image = new BitmapImage(new Uri(cart.Basket_image));
                }
            }
        }

        public static void CreateOrderFromCart(int client, DateTime date, string products, int sum)
        {
            using (var context = new DataBaseContext())
            {
                var newOrder = new Order
                {
                    Order_date = date,
                    Order_client = client,
                    Order_status = 2,
                    Order_basket = products,
                    Order_sum = sum
                };

                context.Basket.RemoveRange(context.Basket);
                context.Orders.Add(newOrder);

                UpdateStatistics(context, products, sum);



                context.SaveChanges();
            }
        }

        private static void UpdateStatistics(DataBaseContext context, string products, int sum)
        {
            var productEntries = products.Split(',');

            foreach (var productName in productEntries)
            {
                var quantity = 1; // Поскольку каждый товар указан один раз, количество равно 1
                var productPrice = GetPrice(productName); // Получаем цену товара

                var productStats = context.ProductStatistics.FirstOrDefault(p => p.ProductName == productName);
                if (productStats == null)
                {
                    productStats = new ProductStatistic
                    {
                        ProductName = productName,
                        QuantitySold = quantity,
                        TotalRevenue = quantity * productPrice
                    };
                    context.ProductStatistics.Add(productStats);
                }
                else
                {
                    productStats.QuantitySold += quantity;
                    productStats.TotalRevenue += quantity * productPrice;
                }
            }

            var overallStats = context.OverallStatistics.FirstOrDefault();
            if (overallStats == null)
            {
                overallStats = new OverallStatistic
                {
                    TotalQuantitySold = productEntries.Length,
                    TotalRevenue = sum
                };
                context.OverallStatistics.Add(overallStats);
            }
            else
            {
                overallStats.TotalQuantitySold += productEntries.Length;
                overallStats.TotalRevenue += sum;
            }

            context.SaveChanges();
        }

        private static int GetPrice(string productName)
        {
            using(var context = new DataBaseContext())
            {
                var product = context.Products.FirstOrDefault(p => p.Product_name == productName);
                if (product == null)
                    MessageBox.Show("Err");

                return product.Product_price;
            }
        }


        public static int UpdateTotalSum(DataGrid dgv)
        {
            int total = 0;
            foreach (var item in dgv.Items)
            {
                if (item is Basket basket)
                    total += basket.Basket_totalPrice;
            }
            return total;
        }

        public static string GetProductNames(DataGrid dgv)
        {
            List<string> productNames = new List<string>();
            foreach (var item in dgv.Items)
            {
                if (item is Basket)
                {
                    productNames.Add((item as Basket).Product.Product_name);
                }
            }
            return String.Join(",", productNames);
        }

        public static int GetProductPrice(DataGrid dgv)
        {
            List<int> productPrices = new List<int>();
            foreach (var item in dgv.Items)
            {
                if (item is Basket)
                {
                    productPrices.Add((item as Basket).Product.Product_price);
                }
            }
            return productPrices.Sum();
        }

        public static List<int> GetProductAmount(DataGrid dgv)
        {
            List<int> productAmount = new List<int>();
            foreach (var item in dgv.Items)
            {
                if (item is Basket)
                {
                    productAmount.Add((item as Basket).Basket_amount);
                }
            }
            return productAmount;
        }

        public static List<int> GetProductSum(DataGrid dgv)
        {
            List<int> productSum = new List<int>();
            foreach (var item in dgv.Items)
            {
                if (item is Basket)
                {
                    productSum.Add((item as Basket).Basket_totalPrice);
                }
            }
            return productSum;
        }

    }
}
