using CursachFront.Core.Models;
using CursachFront.Core.Services.Path;
using CursachFront.Core.Services.Prisoners;
using CursachFront.Core.Services.Users;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using Path = System.IO.Path;

namespace CursachFront
{
    /// <summary>
    /// Логика взаимодействия для NewUser.xaml
    /// </summary>
    public partial class NewUser : Page
    {
        private string _face;
        private string _finger;
        private readonly UserService _userService;
        public NewUser()
        {
            InitializeComponent();
            ButtonSelectFoto.Click += ButtonSelectFoto_Click;
            ButtonSelectImprint.Click += ButtonSelectImprint_Click;
            
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
            string[] dateFormats = { "yyyy.MM.dd", "yyyy/MM/dd", "yyyy-MM-dd" };
          
            
                if (DateTime.TryParseExact(DrOficer.Text, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime valueDr))
                {
                    AppUser user = new AppUser()
                    {
                        FirstName = NameOficer.Text,
                        LastName = SNameOficer.Text,
                        Username = LogginOficer.Text,
                        HashedPassword=PasswordOficer.Text,
                        Bio = BIOOficer.Text,
                        Gender = HenderOficer.Text,
                        Country =CountryOficer.Text,
                        Rank=Rank.Text,
                        Education=EducationOficer.Text,
                        Departments=DepartmentsOficer.Text,
                        Specifications = SpecializationOficer.Text,
                        Email= ContactInformationOficer.Text,
                        BirthDay = valueDr,
                        Role=Level.Text,
                        FingerName = _finger,                       
                    };
                    _userService.Add(user);
                }
                else throw new Exception("Incorrect form of data");
            

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string[] dateFormats = { "yyyy.MM.dd", "yyyy/MM/dd", "yyyy-MM-dd" };
            
                if (DateTime.TryParseExact(DrOficer.Text, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime valueDr))
                {
                    AppUser user = new AppUser()
                    {
                        FirstName = NameOficer.Text,
                        LastName = SNameOficer.Text,
                        Username = LogginOficer.Text,
                        HashedPassword = PasswordOficer.Text,
                        Bio = BIOOficer.Text,
                        Gender = HenderOficer.Text,
                        Country = CountryOficer.Text,
                        Rank = Rank.Text,
                        Education = EducationOficer.Text,
                        Departments = DepartmentsOficer.Text,
                        Specifications = SpecializationOficer.Text,
                        Email = ContactInformationOficer.Text,
                        BirthDay = valueDr,
                        Role = Level.Text,
                        FingerName = _finger,

                    };
                    _userService.Update(user);
                }
                else throw new Exception("Incorrect form of data");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int ID = Convert.ToInt32(id.Text);
           _userService.Remove(ID);
        }
        private void ButtonSelectFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                string destinationPath = PathFindService.GetPath("\\Sources\\Faces");

                try
                {
                    string fileName = System.IO.Path.GetFileName(selectedFilePath);
                    _face = fileName;
                    string destinationFilePath = System.IO.Path.Combine(destinationPath, fileName);
                    File.Copy(selectedFilePath, destinationFilePath, true);
                    BitmapImage bitmapImage = new BitmapImage(new Uri(destinationFilePath));
                    FotocarSuspect.Source = bitmapImage;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка загрузки/копирования изображения: {ex.Message}");
                }
                MessageBox.Show("Cool!");
            }
        }
        private void ButtonSelectImprint_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                string destinationPath = PathFindService.GetPath("\\Sources\\Fingermarks");

                try
                {
                    string fileName = System.IO.Path.GetFileName(selectedFilePath);
                    _finger = fileName;
                    string destinationFilePath = System.IO.Path.Combine(destinationPath, fileName);
                    File.Copy(selectedFilePath, destinationFilePath, true);
                    BitmapImage bitmapImage = new BitmapImage(new Uri(destinationFilePath));
                    ImprintImage.Source = bitmapImage;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка загрузки/копирования изображения: {ex.Message}");
                }
                MessageBox.Show("Well!");
            }
        }

    }
}
