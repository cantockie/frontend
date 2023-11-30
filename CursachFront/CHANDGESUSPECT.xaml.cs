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
    /// Логика взаимодействия для CHANDGESUSPECT.xaml
    /// </summary>
    public partial class CHANDGESUSPECT : Page
    {
        public CHANDGESUSPECT()
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
                // openFileDialog.FileName содержит путь к выбранному файлу
                string selectedFilePath = openFileDialog.FileName;

                // Загрузка выбранного изображения в элемент Image
                FotocarSuspect.Source = new BitmapImage(new Uri(selectedFilePath));
            }
        }
        private void ButtonSelectImprint_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // openFileDialog.FileName содержит путь к выбранному файлу
                string selectedFilePath = openFileDialog.FileName;

                // Загрузка выбранного изображения в элемент Image
                ImprintImage.Source = new BitmapImage(new Uri(selectedFilePath));
            }
        }
        private void Vibor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Cast SelectedItem to ComboBoxItem
            ComboBoxItem selectedItem = (ComboBoxItem)Vibor.SelectedItem;

            // If selectedItem is null, return
            if (selectedItem == null)
                return;

            // Hide all buttons
            AddButton.Visibility = Visibility.Collapsed;
            SaveChangeButton.Visibility = Visibility.Collapsed;
            DeleteButton.Visibility = Visibility.Collapsed;

            // Show the corresponding button based on the selected ComboBoxItem
            if (selectedItem == Change)
            {
                SaveChangeButton.Visibility = Visibility.Visible;
            }
            else if (selectedItem == Add)
            {
                AddButton.Visibility = Visibility.Visible;
            }
            else if (selectedItem == Delete)
            {
                DeleteButton.Visibility = Visibility.Visible;
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
