using System.Linq;
using System.Windows;
using System;

namespace ShopMetta.ViewModels.Commands
{
    public class OrderCommands
    {

        public OrderCommands(int id, string name, int status) 
        {
            Update(id, name, status);
        }


        private void Update(int id, string name, int status)
        {
            try
            {
                using (var dataBase = new DataBaseContext())
                {
                    var order = dataBase.Orders.FirstOrDefault(o => o.Order_id == id);
                    if (order != null)
                    {
                        order.Order_basket = name;
                        order.Order_status = status;
                        dataBase.Update(order);
                        dataBase.SaveChanges();
                        MessageBox.Show("Заказ успешно отредактирован!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Заказ не найден!","Ошибка", MessageBoxButton.OK,MessageBoxImage.Error);
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
