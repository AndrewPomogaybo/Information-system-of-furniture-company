using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ShopMetta.ViewModels
{
    public  class BackupViewModel
    {
        private  DataBaseContext _context = new DataBaseContext();

        public BackupViewModel(Button btn, string folderPath)
        {
            switch (btn.Name)
            {
                case "BackupBase_btn":
                    var tables = _context.Model.GetEntityTypes().Select(t => t.GetTableName()).Distinct().ToList();
                    foreach (var tableName in tables)
                    {
                        ExportDatabase(folderPath);
                    }
                    break;
                case "LogOut_btn":
                    tables = _context.Model.GetEntityTypes().Select(t => t.GetTableName()).Distinct().ToList();
                    foreach (var tableName in tables)
                    {
                        ExportDatabase(folderPath);
                    }
                    break;
                
            } 
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

        private void ExportDatabase(string filePath)
        {
            try
            {
                var tables = new[] { "Roles", "Statuses", "Qualifications", "Category", "Materials", "Clients", "Products", "Users", "Masters", "Orders", "Order_for_creation", "Basket" }; // Замените на свои таблицы
                StringBuilder fileContent = new StringBuilder();

                foreach (var table in tables)
                {
                    fileContent.Append(ExportTable(table));
                    fileContent.AppendLine();
                }

                File.WriteAllText(filePath, fileContent.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
