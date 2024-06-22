using ShopMetta.Models;
using ShopMetta.ViewModels;
using ShopMetta.Views.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ShopMetta.Views.Pages
{
    public partial class ProductsPage : Page
    {
        static DataGrid grid;
        private int _id;
        private string _name;
        private string _description;
        private int _price;
        private int _category;
        private int _material;
        private string _colour;
        private string _image;
        private int _amount;
        private string _joinCategory;
        private string _joinMaterial;

        private readonly DataBaseContext _context = new DataBaseContext();
        

        public ProductsPage(DataBaseContext context)
        {
            InitializeComponent();
            DataContext = new ProductsViewModel(dataGrid);
            UpdatepageInfo();
            LoadRolesToComboBox();
        }

        private void LoadRolesToComboBox()
        {
            var categories = _context.Products.Select(p => p.Category.Category_name).Distinct().ToList();
            Filter_combobox.Items.Add(new ComboBoxItem { Content = "Все" });
            foreach (var role in categories)
            {
                Filter_combobox.Items.Add(new ComboBoxItem { Content = role });
            }
        }

        private void Sort_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductsViewModel.ApplyFilterAndSort(Filter_combobox, Sort_combobox, dataGrid);
        }

        private void Search_txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductsViewModel.SearchProducts(dataGrid, Search_txtbox);
        }

        private void Filter_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductsViewModel.ApplyFilterAndSort(Filter_combobox, Sort_combobox, dataGrid);
        }

        private void Refresh_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new ProductsViewModel(dataGrid);
        }

        private void Back_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var viewModel = DataContext as ProductsViewModel;
            viewModel.PreviousPage();
            UpdatepageInfo();
        }

        private void Next_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var viewModel = DataContext as ProductsViewModel;
            viewModel.NextPage();
            UpdatepageInfo();
        }

        private void UpdatepageInfo()
        {
            var viewModel = DataContext as ProductsViewModel;
            currentPage.Text = viewModel.CurrentPage.ToString();
            totalPages.Text = viewModel.TotalPages.ToString();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите удалить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DeleteCommand.Delete<Product>(_id);
                DataContext = new ProductsViewModel(dataGrid);
            }   
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Product selected)
            {
                _id = selected.Product_id;
                _name = selected.Product_name;
                _description = selected.Product_description;
                _price = selected.Product_price;
                _image = selected.Product_image;
                _material = selected.Product_material;
                _category = selected.Product_category;
                _amount = selected.Product_amount;
                _colour = selected.Product_colour;
                _joinCategory = selected.Category.Category_name;
                _joinMaterial = selected.Material.Material_name;
            }
        }

        private void edit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EditProductsWindow edit = new EditProductsWindow(_id,_name,_description, _joinCategory, _joinMaterial, _price,_amount,_colour,_image);
            if(edit.ShowDialog() == true)
                DataContext = new ProductsViewModel(dataGrid);
        }

        private void buy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var viewModel = DataContext as ProductsViewModel;
                viewModel.AddProductToCart(_id);
                MessageBox.Show("Товар успешно добавлен в корзину");
            }
            catch
            {
                MessageBox.Show("Не удалось добавить в корзину");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddProductsWindow add = new AddProductsWindow();
            if(add.ShowDialog() == true)
                DataContext = new ProductsViewModel(dataGrid);
        }

        private void inf_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MoreInfoWindow info = new MoreInfoWindow(_name,_description,_joinCategory,_joinMaterial,_price.ToString(),_image,_colour,_amount.ToString());
            info.Show();
            AdminMenu seller = (AdminMenu)Window.GetWindow(this);
            seller.Close();
        }

        private void inf_btn_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.WindowTitle == "AdminMenuWindow") 
            {
                infoColumn.Visibility = Visibility.Collapsed;
                buyColumn.Visibility = Visibility.Collapsed;
            } 
        }
    }
}
