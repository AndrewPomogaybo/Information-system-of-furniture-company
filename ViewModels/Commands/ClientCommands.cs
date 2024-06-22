using ShopMetta.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ShopMetta.ViewModels.Commands
{
    public class ClientCommands
    {

        public ClientCommands(Button btn, int id, string name, string surname, string patronymic, int age, string phone) 
        {
            switch (btn.Name)
            {
                case "Add":
                    Add(name, surname, patronymic, age, phone);
                    break;
                case "Edit":
                    Update(id, name, surname, patronymic, age, phone);
                    break;
            }
        }

        private void Add(string name, string surname, string patronymic, int age, string phone)
        {
            try
            {
                using (var dataBase = new DataBaseContext())
                {
                    var existingPhone = dataBase.Clients.FirstOrDefault(c => c.Client_phone == phone);

                    if(existingPhone != null) 
                    { 
                        MessageBox.Show("Номер уже сущетсвует","Ошибка", MessageBoxButton.OK,MessageBoxImage.Error);
                        return;
                    }


                    if(phone.Length != 12)
                    {
                        MessageBox.Show("Номер телефона введен неккоректно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        Client newClient = new Client
                        {
                            Client_name = name,
                            Client_surname = surname,
                            Client_patronymic = patronymic,
                            Client_age = age,
                            Client_phone = phone
                        };
                        dataBase.Add(newClient);
                        dataBase.SaveChanges();
                    } 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update(int id, string name, string surname, string patronymic, int age, string phone)
        {
            try
            {
                using (var dataBase = new DataBaseContext())
                {
                    var existingPhone = dataBase.Clients.FirstOrDefault(c => c.Client_phone == phone);

                    if (existingPhone != null)
                    {
                        MessageBox.Show("Номер уже сущетсвует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var client = dataBase.Clients.FirstOrDefault(c => c.Client_id == id);
                    if (client != null)
                    {
                        client.Client_name = name;
                        client.Client_surname = surname;
                        client.Client_patronymic = patronymic;
                        client.Client_age = age;
                        
                        if (phone.Length == 12)
                            client.Client_phone = phone;
                        else
                        {
                            MessageBox.Show("Номер телефона введен неккоректно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        
                        dataBase.Update(client);
                        dataBase.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Товар не найден!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
