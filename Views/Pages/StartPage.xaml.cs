using ShopMetta.ViewModels;
using ShopMetta.Views.Windows;
using System.Windows;
using System.Windows.Controls;


namespace ShopMetta.Views.Pages
{
    public partial class StartPage : Page
    {
        
        public StartPage(string name, string surname)
        {
            InitializeComponent();
            surname_txtblock.Text = surname;
            name_txtblock.Text = name.ToString();
        }

        private void LogOut_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if(this.WindowTitle == "SellerMenu")
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    DataContext = new BackupViewModel(LogOut_btn, "Dumps");
                    AdminMenu seller = (AdminMenu)Window.GetWindow(this);
                    seller.Close();
                }

                if (this.WindowTitle == "AdminMenuWindow")
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    DataContext = new BackupViewModel(LogOut_btn, "Dumps");
                    AdminMenuWindow admin = (AdminMenuWindow)Window.GetWindow(this);
                    admin.Close();

                }

                if (this.WindowTitle == "MasterMenuWindow")
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    DataContext = new BackupViewModel(LogOut_btn, "Dumps");
                    MasterMenuWindow master = (MasterMenuWindow)Window.GetWindow(this);
                    master.Close();
                }
                    
            }
        }
    }
}
