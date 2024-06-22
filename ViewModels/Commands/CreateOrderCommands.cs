using ShopMetta.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace ShopMetta.ViewModels.Commands
{
    public class CreateOrderCommands
    {

        public CreateOrderCommands(Button btn, int id, int client, string name, string description, int status, string master, DateTime date, int sum) 
        {
            switch (btn.Name)
            {
                case "Add":
                    Add(client, name, description, sum);
                    break;
                case "Edit":
                    Update(id, client, name, description, status, master, date);
                    break;
                case "Edit_seller":
                    UpdateStatus(id, status);
                    break;
            }
        }



        private void Add(int client, string name, string description, int sum)
        {
            
                using (var dataBase = new DataBaseContext())
                {
                    CreateOrder newOrder = new CreateOrder
                    {
                        Creation_name = name,
                        Creation_client = client,
                        Creation_description = description,
                        Creation_status = 2,
                        Creation_sum = sum,
                        Creation_date = null
                    };
                    dataBase.Add(newOrder);
                    dataBase.SaveChanges();
                    MessageBox.Show("Данные успешно добавлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            
        }

        private void Update(int id, int client, string name, string description, int status, string master, DateTime date )
        {
            try
            {
                using (var dataBase = new DataBaseContext())
                {
                    var order = dataBase.Order_for_creation.FirstOrDefault(m => m.Creation_id == id);
                    if (order != null)
                    {
                        order.Creation_name = name;
                        order.Creation_description = description;
                        order.Creation_client = client;
                        order.Creation_master = master;
                        order.Creation_status = status;
                        order.Creation_date = date;

                        dataBase.Update(order);
                        dataBase.SaveChanges();
                        MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не найдено");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateStatus(int id, int status)
        {
            try
            {
                using (var dataBase = new DataBaseContext())
                {
                    var order = dataBase.Order_for_creation.FirstOrDefault(m => m.Creation_id == id);
                    if (order != null)
                    {
                        order.Creation_status = status;
                        dataBase.Update(order);
                        dataBase.SaveChanges();
                        MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не найдено");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
