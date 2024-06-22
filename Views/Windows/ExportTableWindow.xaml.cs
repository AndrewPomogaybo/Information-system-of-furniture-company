using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using ShopMetta.ViewModels;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;


namespace ShopMetta.Views.Windows
{
    public partial class ExportTableWindow : Window
    {
        private DataBaseContext _context = new DataBaseContext();

        public ExportTableWindow()
        {
            InitializeComponent();
        }

        private void Export_btn_Click(object sender, RoutedEventArgs e)
        {
            string table = ""; 
            switch (TableCombobox.Text)
            {
                case "Пользователи":
                    table = "users";
                    break;
                case "Товары":
                    table = "products";
                    break;
                case "Клиенты":
                    table = "clients";
                    break;
                case "Мастеры":
                    table = "masters";
                    break;
                case "Роли":
                    table = "roles";
                    break;
                case "Категории":
                    table = "categories";
                    break;
                case "Материалы":
                    table = "materials";
                    break;
                case "Статусы":
                    table = "statuses";
                    break;
                case "Заказы":
                    table = "orders";
                    break;
            }
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "SQL files (*.sql)|*.sql",
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;
                    ExportDatabase(filePath,table);
                    MessageBox.Show($"Данные успешно выгружены по пути {filePath}", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Exit_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }




        private string ExportTable(string tableName)
        {
            var connection = _context.Database.GetDbConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {tableName}";
            var reader = command.ExecuteReader();

            StringBuilder fileContent = new StringBuilder();

            fileContent.AppendLine($"-- Dump of table {tableName}");
            fileContent.AppendLine($"-- Date: {DateTime.Now}");
            fileContent.AppendLine();

            while (reader.Read())
            {
                fileContent.Append($"INSERT INTO {tableName} (");

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    fileContent.Append(reader.GetName(i));
                    if (i < reader.FieldCount - 1)
                        fileContent.Append(", ");
                }
                fileContent.Append(") VALUES (");

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var value = reader[i];
                    if (value is DBNull)
                    {
                        fileContent.Append("NULL");
                    }
                    else if (value is DateTime dateTime)
                    {
                        fileContent.Append($"'{dateTime.ToString("yyyy-MM-dd")}'"); // Удаление времени из даты
                    }
                    else if (value is string)
                    {
                        fileContent.Append($"'{value.ToString().Replace("'", "''")}'");
                    }
                    else
                    {
                        fileContent.Append(value.ToString());
                    }

                    if (i < reader.FieldCount - 1)
                        fileContent.Append(", ");
                }
                fileContent.Append(") ON DUPLICATE KEY UPDATE ");

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var columnName = reader.GetName(i);
                    fileContent.Append($"{columnName}=VALUES({columnName})");

                    if (i < reader.FieldCount - 1)
                        fileContent.Append(", ");
                }
                fileContent.AppendLine(";");
            }

            reader.Close();
            connection.Close();
            return fileContent.ToString();
        }

        private void ExportDatabase(string filePath, string table)
        {
            try
            {
                StringBuilder fileContent = new StringBuilder();

                    fileContent.Append(ExportTable(table));
                    fileContent.AppendLine();
                File.WriteAllText(filePath, fileContent.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
