using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using ShopMetta.ViewModels;
using ShopMetta.Views.Windows;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace ShopMetta.Views.Pages
{
    public partial class BackupPage : Page
    {
        private DataBaseContext _context = new DataBaseContext();
        public BackupPage()
        {
            InitializeComponent();
        }

        private void BackupBase_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "SQL files (*.sql)|*.sql",
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;
                    DataContext = new BackupViewModel(BackupBase_btn, filePath);
                    MessageBox.Show($"Данные успешно выгружены по пути {filePath}", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UploadData_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "SQL files (*.sql)|*.sql",
            };
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                ImportData(filePath);
            }
        }


        private void ImportData(string backupFilePath)
        {
            try
            {
                string sql = File.ReadAllText(backupFilePath);

                using (var dbContext = new DataBaseContext())
                {

                    dbContext.Database.ExecuteSqlRaw(sql);
                }

                MessageBox.Show("Данные успешно импортированы.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при импорте данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Choose_btn_Click(object sender, RoutedEventArgs e)
        {
            ExportTableWindow export = new ExportTableWindow();
            export.Show();
        }
    }
}
