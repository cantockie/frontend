using CursachFront.Core;
using CursachFront.Core.Models;
using CursachFront.Core.Services.Path;
using CursachFront.Core.Services.Prisoners;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
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
        private string _face;
        private string _finger;
        private readonly PrisonerService _prisonerService;
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
        private void Vibor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)Vibor.SelectedItem;

            if (selectedItem == null)
                return;

            AddButton.Visibility = Visibility.Collapsed;
            SaveChangeButton.Visibility = Visibility.Collapsed;
            DeleteButton.Visibility = Visibility.Collapsed;

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
            string[] dateFormats = { "yyyy.MM.dd", "yyyy/MM/dd", "yyyy-MM-dd" };
            if (Enum.TryParse(Status.Text, out Status statusValue))
            {
                if (DateTime.TryParseExact(Dr.Text, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime valueDr))
                {
                    Prisoner prisoner = new Prisoner()
                    {
                        Name = Name.Text,
                        BIO = BIO.Text,
                        EyeColor = EyeColor.Text,
                        Hospital = klichka.Text,
                        Gender = Hender.Text,
                        Country = Country.Text,
                        Weight = Convert.ToDouble(Weight),
                        Gang = Gang.Text,
                        CivilSpec = CivilSpecialization.Text,
                        CrimeSpec = CrimeSpecialization.Text,
                        CriminalArticles = Criminal.Text,
                        Hobbies = InterestsHobbies.Text,
                        BloodType = blood.Text,
                        Married = (Married.Text == "Yes") ? true : false,
                        Profession = Profession.Text,
                        Status = statusValue,
                        ColorHair = Hair.Text,
                        FirstCrimes = FirstCrimes.Text,
                        LastSee = LastCountry.Text,
                        PhotoName = _face,
                        FingerName = _finger,
                        Birthday = valueDr

                    };
                    _prisonerService.Add(prisoner);
                }
                else throw new Exception("Incorrect form of data");
            };
      
         }
        

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string[] dateFormats = { "yyyy.MM.dd", "yyyy/MM/dd", "yyyy-MM-dd" };
            if (Enum.TryParse(Status.Text, out Status statusValue))
            {
                if (DateTime.TryParseExact(Dr.Text, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime valueDr))
                {
                    Prisoner prisoner = new Prisoner()
                    {
                        Name = Name.Text,
                        BIO = BIO.Text,
                        EyeColor = EyeColor.Text,
                        Hospital = klichka.Text,
                        Gender = Hender.Text,
                        Country = Country.Text,
                        Weight = Convert.ToDouble(Weight),
                        Gang = Gang.Text,
                        CivilSpec = CivilSpecialization.Text,
                        CrimeSpec = CrimeSpecialization.Text,
                        CriminalArticles = Criminal.Text,
                        Hobbies = InterestsHobbies.Text,
                        BloodType = blood.Text,
                        Married = (Married.Text == "Yes") ? true : false,
                        Profession = Profession.Text,
                        Status = statusValue,
                        ColorHair = Hair.Text,
                        FirstCrimes = FirstCrimes.Text,
                        LastSee = LastCountry.Text,
                        PhotoName = _face,
                        FingerName = _finger,
                        Birthday = valueDr
                    };
                    _prisonerService.Update(prisoner);
                }
                else throw new Exception("Incorrect form of data");
            };
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int ID = Convert.ToInt32(id.Text);
            _prisonerService.Remove(ID);
        }
    }
}
