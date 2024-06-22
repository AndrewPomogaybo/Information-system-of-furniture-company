using ShopMetta.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace ShopMetta.ViewModels.Commands
{
    public static class ProductCommands
    {


        public static void Add(string name, int category, string description, int material, int amount, string colour, int price,string img)
        {
            try
            {
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", img);
                FileInfo info = new FileInfo(imagePath);
                long fileSize = info.Length / 1024;

                if (fileSize > 4000)
                {
                    MessageBox.Show("Размер изображения превышает допустимый лимит", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                using (var dataBase = new DataBaseContext())
                {

                    Product newProduct = new Product
                    {
                        Product_name = name,
                        Product_category = category,
                        Product_description = description,
                        Product_material = material,
                        Product_amount = amount,
                        Product_colour = colour,
                        Product_price = price,
                        Product_image = img
                    };

                    dataBase.Products.Add(newProduct);
                    dataBase.SaveChanges();
                    MessageBox.Show("Успешно!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void Update(int id,string name,int category, string description, int material, int amount, string colour, int price, string img)
        {
            using (var dataBase = new DataBaseContext())
            {
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", img);
                FileInfo info = new FileInfo(imagePath);
                long fileSize = info.Length / 1024;

                if (fileSize > 4000)
                {
                    MessageBox.Show("Размер изображения превышает допустимый лимит", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var product = dataBase.Products.FirstOrDefault(p => p.Product_id == id);

                if(product != null) 
                {
                    product.Product_name = name;
                    product.Product_category = category;
                    product.Product_description = description;
                    product.Product_material = material;
                    product.Product_amount = amount;
                    product.Product_colour = colour;
                    product.Product_price = price;
                    product.Product_image = System.IO.Path.GetFileName(img);
                    dataBase.Products.Update(product);
                    dataBase.SaveChanges();
                    MessageBox.Show("Успешно!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Товар не найден!");
                }
            }
        }


    }
}
