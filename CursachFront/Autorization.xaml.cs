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
        private bool anonymius = false;

        public Autorization()
        {
            InitializeComponent();
            _identityService = new IdentityService();
            _memoryService = new MemoryService();

            _memory = _memoryService.Deserialize();

            if (_memory is not null)
            {
                Login.Text = _memory.Login;
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
                string username = "", password = "";
                {
                    if (!anonymius)
                    {
                        username = Login.Text;
                        password = passwordBox.Password;
                    }
                    if (anonymius)
                    {
                        username = "eva.green@gmail.com";
                        password = "dasdasdas12";
                    }
                }
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
                _memory = new Memory { Login = username};
            }
            else
            {
                if(_memory.Login != "guest@gmail.com")
                username = _memory.Login;
            }

            if (RememberMe.IsChecked == true)
            {
                _memoryService.Serialized(_memory);
            }
            else
            {
                _memoryService.ClearMemoryFile();
            }
            if (_memory.Login is "guest@gmail.com")
                _memoryService.ClearMemoryFile();
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
            anonymius = true;
            toMainwindow(sender, e);
        }
    }
}