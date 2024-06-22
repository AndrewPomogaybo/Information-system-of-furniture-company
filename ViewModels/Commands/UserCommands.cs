using ShopMetta.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ShopMetta.ViewModels.Commands
{
    public class UserCommands
    {


        public UserCommands(Button btn, int id, string name, string surname, string login, string pwd, int role) 
        {
            switch (btn.Name)
            {
                case "Add_btn":
                    Add(id, name, surname, login, pwd, role);
                    break;
                case "Edit_btn":
                    Update(id, name, surname, login, pwd, role);
                    break;
            }  
        }

        private void Add(int id, string name, string surname, string login, string pwd, int role)
        {
            try
            {
                using (var dataBase = new DataBaseContext())
                {
                    var existingPwd = dataBase.Users.FirstOrDefault(c => c.User_password == pwd);
                    var existingLogin = dataBase.Users.FirstOrDefault(c => c.User_login == login);

                    if (existingPwd != null)
                    {
                        MessageBox.Show("Пароль уже сущетсвует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (existingLogin != null)
                    {
                        MessageBox.Show("Логин уже сущетсвует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    User newUser = new User
                        {
                            User_name = name,
                            User_surname = surname,
                            User_login = login,
                            User_password = pwd,
                            User_role = role
                        };
                        dataBase.Add(newUser);
                        dataBase.SaveChanges();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Update(int id, string name, string surname, string login, string pwd, int role)
        {
            try
            {
                using (var dataBase = new DataBaseContext())
                {

                    var existingPwd = dataBase.Users.FirstOrDefault(c => c.User_password == pwd);
                    var existingLogin = dataBase.Users.FirstOrDefault(c => c.User_login == login);

                    if (existingPwd != null)
                    {
                        MessageBox.Show("Пароль уже сущетсвует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (existingLogin != null)
                    {
                        MessageBox.Show("Логин уже сущетсвует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }


                    var user = dataBase.Users.FirstOrDefault(u => u.User_id == id);
                    if (user != null)
                    {
                        user.User_name = name;
                        user.User_surname = surname; 
                        user.User_login = login;
                        user.User_password = pwd;
                        user.User_role = role;


                        dataBase.Update(user);
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
