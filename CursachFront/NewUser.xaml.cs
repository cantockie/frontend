using CursachFront.Core.Models;
using CursachFront.Core.Services.Path;
using CursachFront.Core.Services.Prisoners;
using CursachFront.Core.Services.Users;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
        private readonly IUserService _userService;
        public NewUser()
        {
            InitializeComponent();
            ButtonSelectFoto.Click += ButtonSelectFoto_Click;
            ButtonSelectImprint.Click += ButtonSelectImprint_Click;
            _userService = new UserService();
            
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
            if (_face is null)
                _face = "face1.jpg";
            if (_finger is null)
                _finger = "mark1.jpg";

           
                    if (DateTime.TryParse(DrOficer.Text, out DateTime hjh))
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
                    BirthDay = hjh,
                    Role = Level.Text,
                    FingerName = _finger,
                    PhotoName = _face
                    };
                _userService.Add(user);
                    
                }
                else throw new Exception("Incorrect form of data");
            

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string[] dateFormats = { "yyyy.MM.dd", "yyyy/MM/dd", "yyyy-MM-dd" };
            if (_face is null)
                _face = "face1.jpg";
            if (_finger is null)
                _finger = "mark1.png";
            if (DateTime.TryParse(DrOficer.Text, out DateTime hjh))
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
                    BirthDay = hjh,
                    Role = Level.Text,
                    FingerName = _finger,
                    PhotoName = _face
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
                ImagesSet(selectedFilePath, destinationPath);


            }
        }
        private void ImagesSet(string selectedFilePath, string destinationPath)
        {
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

        private void id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Vibor.Text == "Change" || Vibor.Text is "Delete")
            {
                long ids;
                
            if (long.TryParse(id.Text, out ids)&&ids>0)
            {
                    AppUser usr = new AppUser();
                    if (usr != null)
                    {
                        usr = CheckId(usr, ids);
                        NameOficer.Text = usr.FirstName;
                        SNameOficer.Text = usr.LastName;
                        LogginOficer.Text = usr.Username;
                        PasswordOficer.Text = "";
                        BIOOficer.Text = usr.Bio;
                        HenderOficer.Text = usr.Gender;
                        CountryOficer.Text = usr.Country;
                        Rank.Text = usr.Rank;
                        DrOficer.Text = usr.BirthDay.ToString();
                        EducationOficer.Text = usr.Education;
                        DepartmentsOficer.Text = usr.Departments;                        
                        SpecializationOficer.Text = usr.Specifications;
                        ContactInformationOficer.Text = usr.Email;
                        Level.Text = usr.Role;
                        FotocarSuspect.Source = new BitmapImage(new Uri(PathFindService.GetPath(usr.PhotoName, true), UriKind.Absolute));
                        ImprintImage.Source = new BitmapImage(new Uri(PathFindService.GetPath(usr.FingerName, false), UriKind.Absolute));
                    }
                    else
                    {
                       
                    }
                }
           
            }
            else 
             FillEmpty();
        }
        private void FillEmpty()
        {
            NameOficer.Text = "";
            SNameOficer.Text = "";
            LogginOficer.Text = "";
            PasswordOficer.Text = "";
            BIOOficer.Text = "";
            HenderOficer.Text = "";
            CountryOficer.Text = "";
            Rank.Text = "";
            DrOficer.Text = "";
            EducationOficer.Text = "";
            DepartmentsOficer.Text = "";
            SpecializationOficer.Text = "";
            ContactInformationOficer.Text = "";
            Level.Text = "";
            _finger = "";
            _face = "";
        }
        private AppUser CheckId(AppUser usr, long ids) 
        {
            var list = _userService.GetList();
            int itemCount = list.Count();
            if (ids > itemCount)
            {
                usr.Id = ids;
                usr.FirstName = "";
                usr.Email = "";
                usr.Bio = "";
                usr.Departments = "";
                usr.LastName = "";
                usr.PhotoName = "face1.jpg";
                usr.FingerName = "mark1.png";
                usr.Username = "";
                usr.Country = "";
                usr.Gender = "";
                usr.BirthDay = new DateTime();
                usr.Education = "";
                usr.Protection = 0;
                usr.Rank = "";
                usr.Specifications = "";
                usr.HashedPassword = "";
                usr.Role = "";
            }
            else
            {
                usr = list.FirstOrDefault(x => x.Id == ids);
            }
            return usr;
        }
    }
}
