using ShopMetta.ViewModels;
using ShopMetta.Views;
using ShopMetta.Views.Windows;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace ShopMetta
{
    public partial class MainWindow : Window
    {
        private UserService _userService;
        private MigrationService _migrationService;
        AuthorizationViewModel viewModel = new AuthorizationViewModel();
        private int _errorCounter;
        private DispatcherTimer _timer;
        private string captchaText;
        private int _timeLeft;

        private string _name;
        private string _surname;

        public MainWindow()
        {
            InitializeComponent();
            var _context = new DataBaseContext();
            _userService = new UserService(_context);
            _migrationService = new MigrationService(_context);
            MigrateUsers();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
        }

        private void MigrateUsers()
        {
            _migrationService.MigrateUsers();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch
            {

            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void SignIn_btn_Click(object sender, RoutedEventArgs e)
        {

            if (login_txtbox.Text == "admin" && password_txtbox.Password == "admin")
            {
                AdminMenuWindow admin = new AdminMenuWindow("", "");
                admin.Show();
                this.Close();
            }

            
            if (viewModel == null)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _errorCounter++;
                return;
            }

            if (_errorCounter > 2)
                StartTimer();

            if (_errorCounter >= 1)
            {

                if (Captcha_txtbox.Visibility == Visibility.Hidden)
                {
                    ShowCaptcha();
                }
                else if (captchaText != Captcha_txtbox.Text || !_userService.LoginUser(login_txtbox.Text,password_txtbox.Password))
                {
                    MessageBox.Show("Каптча введена неверна", "Ошибка каптчи");
                    _errorCounter++;
                    ShowCaptcha();
                }
                else if (captchaText == Captcha_txtbox.Text && _userService.LoginUser(login_txtbox.Text, password_txtbox.Password))
                {
                    switch (viewModel.GetRole(login_txtbox.Text, password_txtbox.Password))
                    {
                        case 1:
                            _name = viewModel.GetName(login_txtbox.Text, password_txtbox.Password);
                            _surname = viewModel.GetSurname(login_txtbox.Text, password_txtbox.Password);
                            AdminMenuWindow admin = new AdminMenuWindow(_name,_surname);
                            admin.Show();
                            this.Close();
                            break;
                        case 2:
                            _name = viewModel.GetName(login_txtbox.Text, password_txtbox.Password);
                            _surname = viewModel.GetSurname(login_txtbox.Text, password_txtbox.Password);
                            AdminMenu seller = new AdminMenu(_name, _surname);
                            seller.Show();
                            this.Close();
                            break;
                        case 3:
                            _name = viewModel.GetName(login_txtbox.Text, password_txtbox.Password);
                            _surname = viewModel.GetSurname(login_txtbox.Text, password_txtbox.Password);
                            MasterMenuWindow master = new MasterMenuWindow(_name,_surname);
                            master.Show();
                            this.Close();
                            break;
                    }
                }

            }
            else
            {
                if (_userService.LoginUser(login_txtbox.Text, password_txtbox.Password))
                {
                    switch (viewModel.GetRole(login_txtbox.Text, password_txtbox.Password))
                    {
                        case 1:
                            _name = viewModel.GetName(login_txtbox.Text, password_txtbox.Password);
                            _surname = viewModel.GetSurname(login_txtbox.Text, password_txtbox.Password);
                            AdminMenuWindow admin = new AdminMenuWindow(_name, _surname);
                            admin.Show();
                            this.Close();
                            break;
                        case 2:
                            _name = viewModel.GetName(login_txtbox.Text, password_txtbox.Password);
                            _surname = viewModel.GetSurname(login_txtbox.Text, password_txtbox.Password);
                            AdminMenu seller = new AdminMenu(_name,_surname);
                            seller.Show();
                            this.Close();
                            break;
                        case 3:
                            _name = viewModel.GetName(login_txtbox.Text, password_txtbox.Password);
                            _surname = viewModel.GetSurname(login_txtbox.Text, password_txtbox.Password);
                            MasterMenuWindow master = new MasterMenuWindow(_name, _surname);
                            master.Show();
                            this.Close();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    _errorCounter++;
                }
            }
        }

        private void refresh_img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ShowCaptcha();
        }

        private void ShowCaptcha()
        {
            Captcha_txtbox.Visibility = Visibility.Visible;
            captchaImg.Visibility = Visibility.Visible;
            GenerateCaptcha();
        }

        private void GenerateCaptcha()
        {
            Random rand = new Random();
            const string chars = "АБВГДЕЖЗИКЛМНОПР0123456789";
            captchaText = new string(Enumerable.Repeat(chars, 4).Select(s => s[rand.Next(s.Length)]).ToArray());

            DrawingVisual visual = new DrawingVisual();
            using (DrawingContext dc = visual.RenderOpen())
            {
                dc.DrawRectangle(Brushes.White, null, new Rect(0, 0, 200, 50));

                // Разместим символы капчи на разных уровнях по вертикали
                for (int i = 0; i < captchaText.Length; i++)
                {
                    double x = 20 + i * 40;
                    double y = rand.Next(10, 30);
                    dc.DrawText(
                        new System.Windows.Media.FormattedText(
                            captchaText[i].ToString(),
                            System.Globalization.CultureInfo.InvariantCulture,
                            FlowDirection.LeftToRight,
                            new Typeface("Arial"),
                            24,
                            Brushes.Black,
                            VisualTreeHelper.GetDpi(this).PixelsPerDip),
                        new Point(x, y));
                }

                // Добавим графический шум
                for (int i = 0; i < 10; i++)
                {
                    dc.DrawLine(new Pen(Brushes.Gray, 1),
                        new Point(rand.Next(0, 200), rand.Next(0, 50)),
                        new Point(rand.Next(0, 200), rand.Next(0, 50)));
                }
            }

            RenderTargetBitmap rtb = new RenderTargetBitmap(200, 50, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(visual);

            captchaImg.Source = rtb;
        }

        private void StartTimer()
        {
            _timeLeft = 10;
            SignIn_btn.IsEnabled = false;
            password_txtbox.IsEnabled = false;
            login_txtbox.IsEnabled = false;
            Captcha_txtbox.IsEnabled = false;
            _timer.Start();
            UpdateButtonContent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timeLeft--;
            if (_timeLeft <= 0)
            {
                _timer.Stop();
                SignIn_btn.IsEnabled = true;
                password_txtbox.IsEnabled = true;
                login_txtbox.IsEnabled = true;
                Captcha_txtbox.IsEnabled = true;
                SignIn_btn.Content = "Войти";
            }
            else
            {
                UpdateButtonContent();
            }
        }

        private void UpdateButtonContent()
        {
            SignIn_btn.Content = $"Войти ({_timeLeft})";
        }

        private void login_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void password_txtbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            // Регулярное выражение для проверки, что введенный текст состоит только из английских букв, цифр и спецсимволов
            Regex regex = new Regex("^[a-zA-Z0-9!@#$%^&*()_+=\\-\\[\\]{};:'\"\\|,.<>/?`~]*$");
            return regex.IsMatch(text);
        }
    }
}
