using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using ShopMetta.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace ShopMetta.ViewModels
{
    public class ProductsViewModel
    {
        private DataBaseContext _context = new DataBaseContext();
        private static ObservableCollection<Product> _products { get; set; }
        private ICollectionView _productsView;

        private int _currentPage = 1;
        private int _itemsPerPage = 10;
        private int _totalPages;

        private DataGrid _dataGrid;

        public int CurrentPage => _currentPage;
        public int TotalPages => _totalPages;

        public ICollectionView ProductsView
        {
            get { return _productsView;}
            set
            {
                _productsView = value;
            }
        }

        public ProductsViewModel(DataGrid dataGrid)
        {
            _dataGrid = dataGrid;
            LoadProducts();
            ProductsView = CollectionViewSource.GetDefaultView(_products);
        }

        private void LoadProducts()
        {
            using (var DataBase = new DataBaseContext())
            {
                try
                {
                    var totalItems = DataBase.Products.Count();
                    _totalPages = (int)Math.Ceiling(totalItems / (double)_itemsPerPage);

                    var products = DataBase.Products
                                     .Skip((_currentPage - 1) * _itemsPerPage)
                                     .Take(_itemsPerPage)
                                     .Include(p => p.Category)
                                     .Include(p => p.Material)
                                     .ToList();

                    _products = new ObservableCollection<Product>(products);
                    GetImagesProducts(_products);
                    _dataGrid.ItemsSource = _products;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private static void GetImagesProducts(ObservableCollection<Product> _products)
        {
            foreach (var product in _products)
            {
                try
                {
                    product.Product_image = System.IO.Path.GetFullPath($"Images/" + product.Product_image);
                    product.Image = new BitmapImage(new Uri(product.Product_image));
                }
                catch
                {
                    product.Product_image = System.IO.Path.GetFullPath($"Images/picture.png");
                    product.Image = new BitmapImage(new Uri(product.Product_image));
                }
            }
        

        }

        public static void SearchProducts(DataGrid dgv,TextBox txtbox)
        {
            string searchText = txtbox.Text.ToLower();

            foreach (var item in dgv.Items)
            {
                var row = dgv.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)
                {
                    if (item is Product product)
                    {
                        if (product.Product_name.ToLower().Contains(searchText))
                        {
                            row.Background = Brushes.Yellow;
                            row.BringIntoView(); 
                        }
                        else
                        {
                            row.Background = Brushes.White;
                        }

                        if (string.IsNullOrEmpty(searchText))
                        {
                            row.Background = Brushes.White;
                        }
                    }
                }
            }
        }

        public static void ApplyFilterAndSort(ComboBox Filt, ComboBox Sort, DataGrid dataGrid)
        {
            if (_products == null) return;

            var collectionView = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
            collectionView.Filter = null;
            collectionView.SortDescriptions.Clear();

            
            if (Filt.SelectedItem is ComboBoxItem selectedFilterItem)
            {
                var selectedLastName = selectedFilterItem.Content.ToString();
                if (selectedLastName != "Все")
                {
                    collectionView.Filter = item =>
                    {
                        if (item is Product product)
                        {
                            return product.Category.Category_name == selectedLastName;
                        }
                        return false;
                    };
                }
            }

            
            if (Sort.SelectedItem is ComboBoxItem selectedSortItem)
            {
                switch (selectedSortItem.Content.ToString())
                {
                    case "По возрастанию":
                        collectionView.SortDescriptions.Add(new SortDescription("Product_price", ListSortDirection.Ascending));
                        break;
                    case "По убыванию":
                        collectionView.SortDescriptions.Add(new SortDescription("Product_price", ListSortDirection.Descending));
                        break;
                    case "Сбросить":
                        collectionView.SortDescriptions.Clear();
                        break;
                }
            }

            collectionView.Refresh();
        }

        public void NextPage()
        {
            if(_currentPage < _totalPages)
            {
                _currentPage++;
                LoadProducts();
            }
        }

        public void PreviousPage()
        {
            if(_currentPage > 1) 
            {
                _currentPage--;
                LoadProducts();
            }
        }

        public static void UploadPhoto(Image img, TextBox txtbox)
        {
            string destinationPath = "Images";

            OpenFileDialog getImage = new OpenFileDialog();
            getImage.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (getImage.ShowDialog() == true)
            {

                string fileName = getImage.FileName;
                string Name = System.IO.Path.GetFileName(fileName);
                destinationPath = destinationPath + "\\" + Name;

                File.Copy(fileName, destinationPath, true);

                img.Source = new BitmapImage(new Uri(fileName));

                txtbox.Text = Name;

            }
        }

        public void AddProductToCart(int productId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var product = _context.Products.FirstOrDefault(p => p.Product_id == productId);
                    if (product == null)
                        throw new Exception("Товар не найден!");

                    var cartItem = _context.Basket.FirstOrDefault(b => b.Basket_product == productId);
                    
                    if (cartItem == null)
                    {
                        cartItem = new Models.Basket
                        {
                            Basket_product = productId,
                            Basket_amount = 1,
                            Basket_totalPrice = product.Product_price,
                            Basket_image = product.Product_image
                        };
                        product.Product_amount--;
                        _context.Basket.Add(cartItem);
                        _context.SaveChanges();
                        transaction.Commit();
                    }
                    else
                    {
                        cartItem.Basket_amount++;
                        cartItem.Basket_totalPrice = cartItem.Basket_amount * product.Product_price;
                        _context.Basket.Update(cartItem);
                        _context.SaveChanges();
                        transaction.Commit();
                    }
                    
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Ошибка транзакции {ex.Message}");
                }
            }
        }
    }
}
