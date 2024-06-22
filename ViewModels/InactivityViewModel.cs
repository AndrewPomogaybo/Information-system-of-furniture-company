using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ShopMetta.ViewModels
{
    public class InactivityViewModel : Window
    {
        private DispatcherTimer _inactivityTimer;
        private readonly TimeSpan _inactivityTimeLimit = TimeSpan.FromSeconds(10); // Установите нужное время неактивности

        public InactivityViewModel()
        {
            Loaded += OnWindowLoaded;
            KeyDown += OnUserActivity;
            MouseMove += OnUserActivity;
            MouseDown += OnUserActivity;
            TextInput += OnUserActivity;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            InitializeInactivityTimer();
        }

        private void InitializeInactivityTimer()
        {
            _inactivityTimer = new DispatcherTimer();
            _inactivityTimer.Interval = _inactivityTimeLimit;
            _inactivityTimer.Tick += OnInactivityTimeout;
            ResetInactivityTimer();
        }

        private void OnInactivityTimeout(object sender, EventArgs e)
        {
            _inactivityTimer.Stop();
            ShowLoginWindow();
        }

        protected virtual void ShowLoginWindow()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                MainWindow loginWindow = new MainWindow();
                loginWindow.Show();
                Close();
            });
        }

        private void ResetInactivityTimer()
        {
            _inactivityTimer.Stop();
            _inactivityTimer.Start();
        }

        private void OnUserActivity(object sender, InputEventArgs e)
        {
            ResetInactivityTimer();
        }
    }
}
