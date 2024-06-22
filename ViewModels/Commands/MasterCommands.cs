using ShopMetta.Models;
using System.Windows;
using System;
using System.Linq;
using System.Windows.Controls;

namespace ShopMetta.ViewModels.Commands
{
    public class MasterCommands
    {

        public MasterCommands(Button btn, int id, string name, string surname, int qualification) 
        {
            switch (btn.Name)
            {
                case "Add":
                    Add(id, name, surname, qualification);
                    break;
                case "Edit":
                    Update(id, name, surname, qualification);
                    break;
            }
        }



        private void Add(int id, string name, string surname, int qualification)
        {
            try
            {
                using (var dataBase = new DataBaseContext())
                {
                        Master newMaster = new Master
                        {
                            Master_name = name,
                            Master_surname = surname,
                            Master_qualification = qualification
                        };
                        dataBase.Add(newMaster);
                        dataBase.SaveChanges();
                    MessageBox.Show("Данные успешно добавлены!","Успех", MessageBoxButton.OK,MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update(int id, string name, string surname, int qualification)
        {
            try
            {
                using (var dataBase = new DataBaseContext())
                {
                    var master = dataBase.Masters.FirstOrDefault(m => m.Master_id == id);
                    if (master != null)
                    {
                        master.Master_name = name;
                        master.Master_surname = surname;
                        master.Master_qualification = qualification;

                        dataBase.Update(master);
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
                MessageBox.Show(ex.Message);
            }
        }

    }
}
