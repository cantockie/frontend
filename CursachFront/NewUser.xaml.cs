using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CursachFront
{
    /// <summary>
    /// Логика взаимодействия для NewUser.xaml
    /// </summary>
    public partial class NewUser : Page
    {
        public NewUser()
        {
            InitializeComponent();
            ButtonSelectFoto.Click += ButtonSelectFoto_Click;
            ButtonSelectImprint.Click += ButtonSelectImprint_Click;
            
        }
        private void ButtonSelectFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;

                FotocarSuspect.Source = new BitmapImage(new Uri(selectedFilePath));
            }
        }
        private void Vibor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddButton.Visibility = Visibility.Collapsed;
            ChangeButton.Visibility = Visibility.Collapsed;
            DeleteButton.Visibility = Visibility.Collapsed;

            if (Vibor.SelectedItem == Update)
            {
                ChangeButton.Visibility = Visibility.Visible;
            }
            else if (Vibor.SelectedItem == Add)
            {
                AddButton.Visibility = Visibility.Visible;
            }
            else if (Vibor.SelectedItem == Delete)
            {
                DeleteButton.Visibility = Visibility.Visible;
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Обработка события для кнопки Add
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Обработка события для кнопки Update
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Обработка события для кнопки Delete
        }
        private void ButtonSelectImprint_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                ImprintImage.Source = new BitmapImage(new Uri(selectedFilePath));
            }
        }
    }
}
