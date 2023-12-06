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
using System.Net.NetworkInformation;
using System.Reflection.Emit;
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
            _prisonerService = new PrisonerService();
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
            string[] dateFormats = { "yyyy.MM.dd", "yyyy/MM/dd", "yyyy-MM-dd", "yyyy-MM-dd HH:mm:ss", "dd.MM.yyyy H:mm:ss" };
            if (_face is null)
                _face = "face1.jpg";
            if (_finger is null)
                _finger = "mark1.jpg";
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
                        ColorHair = Hair.Text,
                        FirstCrimes = FirstCrimes.Text,
                        LastSee = LastCountry.Text,
                        PhotoName = _face,
                        _Status = statusValue,
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
            string[] dateFormats = { "yyyy.MM.dd", "yyyy/MM/dd", "yyyy-MM-dd", "yyyy-MM-dd HH:mm:ss", "dd.MM.yyyy H:mm:ss" };
            if (_face is null)
                _face = "face1.jpg";
            if (_finger is null)
                _finger = "mark1.jpg";
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
                        Weight = Convert.ToDouble(Weight.Text),
                        Gang = Gang.Text,
                        CivilSpec = CivilSpecialization.Text,
                        CrimeSpec = CrimeSpecialization.Text,
                        CriminalArticles = Criminal.Text,
                        Hobbies = InterestsHobbies.Text,
                        BloodType = blood.Text,
                        Married = (Married.Text == "Yes") ? true : false,
                        Profession = Profession.Text,
                        _Status = statusValue,
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

        private Prisoner CheckId(Prisoner psr, long ids)
        {
            var list = _prisonerService.GetList();
            int itemCount = list.Count();
            if (ids > itemCount)
            {
                psr.Id = ids;
                psr.Name = "";
                psr.Surname = "";
                psr.Hobbies = "";
                psr.Hospital = "";
                psr.Gender = "";
                psr.PhotoName = "face1.jpg";
                psr.FingerName = "mark1.png";
                psr._Status = Core.Models.Status.None;
                psr.Country = "";
                psr.Gender = "";
                psr.Birthday = new DateTime();
                psr.CrimeSpec = "";
                psr.CriminalArticles = "";
                psr.Hobbies = "";
                psr.FirstCrimes = "";
                psr.BIO = "";
                psr.ColorHair = "";
                psr.EyeColor = "";
                psr.Married = false;
                psr.Profession = "";
                psr.CivilSpec = "";
                psr.BloodType = "";
                psr.Weight = 0.0;
                psr.Gang = "";
                psr.LastSee = "";
           
        
            }
            else
            {
                psr = list.FirstOrDefault(x => x.Id == ids);
            }
            return psr;
        }

        private void id_TextChanged(object sender, TextChangedEventArgs e)
        {
            
                if (Vibor.Text == "Change" || Vibor.Text is "Delete")
                {
                    long ids;

                if (long.TryParse(id.Text, out ids) && ids > 0)
                {
                    Prisoner usr = new Prisoner();
                    if (usr != null)
                    {
                        usr = CheckId(usr, ids);
                        Name.Text = usr.Name;
                        SName.Text = usr.Surname;
                        klichka.Text = usr.Hospital;
                        Hender.Text = usr.Gender;
                        BIO.Text = usr.BIO;
                        Hair.Text = usr.ColorHair;
                        EyeColor.Text = usr.EyeColor;
                        blood.Text = usr.BloodType;
                        Country.Text = usr.Country;
                        LastCountry.Text = usr.LastSee;
                        Dr.Text = usr.Birthday.ToString();
                        Status.Text= usr._Status.ToString();
                        Weight.Text= usr._Status.ToString();
                        Criminal.Text= usr.CriminalArticles;
                        CrimeSpecialization.Text = usr.CrimeSpec;
                        CivilSpecialization.Text = usr.CivilSpec;
                        FirstCrimes.Text = usr.FirstCrimes;
                        Married.Text = (usr.Married) ? "YES" : "NO";
                        Profession.Text = usr.Profession;
                        Gang.Text = usr.Gang;
                        FotocarSuspect.Source = new BitmapImage(new Uri(PathFindService.GetPath(usr.PhotoName, true), UriKind.Absolute));
                        ImprintImage.Source = new BitmapImage(new Uri(PathFindService.GetPath(usr.FingerName, false), UriKind.Absolute));
                    }
                    
                }
                else
                {
                    Name.Text = "";
                    SName.Text = "";
                    klichka.Text = "";
                    Hender.Text = "";
                    BIO.Text = "";
                    Hair.Text = "";
                    EyeColor.Text = "";
                    blood.Text = "";
                    Dr.Text = "";
                    CrimeSpecialization.Text = "";
                    CivilSpecialization.Text = "";
                    FirstCrimes.Text = "";
                    Married.Text = "";
                    Status.Text = "";
                    Profession.Text = "";
                    _finger = "";
                    _face = "";
                    Gang.Text = "";
                    Weight.Text = "";

                }


            }
            else
            {
                Name.Text = "";
                SName.Text = "";
                klichka.Text = "";
                Hender.Text = "";
                BIO.Text = "";
                Hair.Text = "";
                EyeColor.Text = "";
                blood.Text = "";
                Dr.Text = "";
                CrimeSpecialization.Text = "";
                CivilSpecialization.Text = "";
                FirstCrimes.Text = "";
                Married.Text = "";
                Status.Text = "";
                Profession.Text = "";
                _finger = "";
                _face = "";
                Gang.Text = "";
                Weight.Text = "";

            }



        }
    }
}
