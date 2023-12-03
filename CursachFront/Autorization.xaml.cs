using CursachFront.Core.Models;
using CursachFront.Core.Services.Auth;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CursachFront
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        private static string memory = "memory.json";
        private readonly IdentityService _identityService;
        private readonly MemoryService _memoryService;
        private Memory _memory;
        private int i = 0;

        public Autorization()
        {
            InitializeComponent();
            _identityService = new IdentityService();
            _memoryService = new MemoryService();

            _memory = _memoryService.Deserialize();

            if (_memory is not null)
            {
                Login.Text = _memory.Login;
                passwordBox.Password = _memory.Password;
                RememberMe.IsChecked = true;
            }
           
        }

        private void CansellButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizateButton(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private async void toMainwindow(object sender, RoutedEventArgs e)
        {

            passwordBox.Visibility = Visibility.Visible;

            try
            {
                string username = Login.Text;
                string password = passwordBox.Password;

                MemoryCheck(username, password);

                _identityService.SignIn(username, password);

                MainWindow newWindow = new MainWindow();
                this.Close();
                newWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                i++;
                MessageBox.Show(ex.Message);
                

            }
            if(i == 3)
                WantToSecurity();
        }
        private async void WantToSecurity()
        {
            {
                logIN.IsEnabled = false;
                viEW.IsEnabled = false;
                MessageBox.Show(" We tell to the security!");

                this.Dispatcher.Invoke(() =>
                {
                    this.Background = Brushes.Black;
                });
                await Task.Run(async () =>
                {
                    await Task.Delay(500);
                    Close();

                });
            }
        }
            private void MemoryCheck(string username, string password)
        {
            if (_memory is null)
            {
                _memory = new Memory { Login = username, Password = password };
            }
            else
            {
                username = _memory.Login;
                password = _memory.Password;
            }

            if (RememberMe.IsChecked == true)
            {
                _memoryService.Serialized(_memory);
            }
            else
            {
                _memoryService.ClearMemoryFile();
            }
        }

        private void ViewPassword_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Visibility == Visibility.Collapsed)
            {
                passwordBox.Password = PasswordTextBox.Text;
                passwordBox.Visibility = Visibility.Visible;
                PasswordTextBox.Visibility = Visibility.Collapsed;

                passwordBox.Focus();
                passwordBox.SelectAll();
            }
            else
            {
                PasswordTextBox.Text = passwordBox.Password;
                PasswordTextBox.Visibility = Visibility.Visible;
                passwordBox.Visibility = Visibility.Collapsed;

                PasswordTextBox.Focus();
                PasswordTextBox.CaretIndex = PasswordTextBox.Text.Length;
            }
        }

        private void toView_Button(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            _identityService.SignIn("guest@gmail.com", "dasdasdas12");
            mainWindow.Show();
        }
    }
}