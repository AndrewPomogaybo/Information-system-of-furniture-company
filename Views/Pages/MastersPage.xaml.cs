
using ShopMetta.Models;
using ShopMetta.ViewModels;
using ShopMetta.Views.Windows;
using System.Windows;
using System.Windows.Controls;

namespace ShopMetta.Views.Pages
{
    public partial class MastersPage : Page
    {
        private int _id;
        private string _name;
        private string _surname;
        private int _qualification;
        private int _filter;
        private static DataBaseContext _context = new DataBaseContext();

        public MastersPage()
        {
            InitializeComponent();
            DataContext = new MasterViewModel(Masters_dataGrid);
        }

        private void AddMaster_btn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddMasterWindow addMaster = new AddMasterWindow();
            if (addMaster.ShowDialog() == true)
                DataContext = new MasterViewModel(Masters_dataGrid);
        }

        private void Masters_dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Masters_dataGrid.SelectedItem is Master selected)
            {
                _id = selected.Master_id;
                _name = selected.Master_name;
                _surname = selected.Master_surname;
                _qualification = selected.Master_qualification;
            }
        }

        private void Edit_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
                EditMasterWindow editMaster = new EditMasterWindow(_id, _name, _surname, _qualification);
                if(editMaster.ShowDialog() == true)
                    DataContext = new MasterViewModel(Masters_dataGrid);
        }

        private void Delete_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DeleteCommand.Delete<Master>(_id);
                DataContext = new MasterViewModel(Masters_dataGrid);
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            MasterViewModel.SearchMasters(Masters_dataGrid, Search);
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MasterViewModel.ApplyFilterAndSort(Filter, Sort, Masters_dataGrid);
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MasterViewModel.ApplyFilterAndSort(Filter, Sort, Masters_dataGrid);
        }
    }
}
