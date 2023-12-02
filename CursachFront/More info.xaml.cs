using Accessibility;
using CursachFront.Core;
using CursachFront.Core.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
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
    /// Логика взаимодействия для More_info.xaml
    /// </summary>
    //public partial class More_info : Page
    //{


    //    private Prisoner selectedPrisoner;
    //    public More_info()
    //    {
    //        InitializeComponent();
    //        Gets();

    //    }
    //    public void SetSelectedPrisoner(Prisoner prisoner)
    //    {
    //        selectedPrisoner = prisoner;

    //    }

    //    private void Back(object sender, RoutedEventArgs e)
    //    {
    //        MainWindow.ToSearchingEnotherframe((MainWindow)Window.GetWindow(this));
    //    }

    //    public async  void Gets()
    //    {
    //        Name.Text = selectedPrisoner.Name;
    //        SName.Text = selectedPrisoner.Surname;
    //        klichka.Text = selectedPrisoner.Hospital;
    //        Hender.Text = selectedPrisoner.Gender;
    //        Dr.Text = selectedPrisoner.Birthday.HasValue ? selectedPrisoner.Birthday.Value.ToString("yyyy-MM-dd") : string.Empty;
    //        Hair.Text = selectedPrisoner.ColorHair;
    //        Country.Text = selectedPrisoner.Country;
    //        LastCountry.Text = selectedPrisoner.LastSee;
    //        Status.Text = selectedPrisoner.Status.ToString();
    //        Criminal.Text = selectedPrisoner.CriminalArticles;
    //        Weight.Text = selectedPrisoner.Weight.ToString();
    //        EyeColor.Text = selectedPrisoner.EyeColor;
    //        InterestsHobbies.Text = selectedPrisoner.Hobbies;
    //        blood.Text = selectedPrisoner.BloodType;
    //        Profession.Text = selectedPrisoner.Profession;
    //        Married.Text = selectedPrisoner.Married ? "Yes" : "No";
    //        CivilSpecialization.Text = selectedPrisoner.CivilSpec;
    //        CrimeSpecialization.Text = selectedPrisoner.CrimeSpec;
    //        Gang.Text = selectedPrisoner.Gang;
    //        FirstCrimes.Text = selectedPrisoner.FirstCrimes;
    //        BIO.Text = selectedPrisoner.BIO;
    //    }
    //}
    public partial class More_info : Page
    {
        private Prisoner selectedPrisoner;
        private string photoFaceSource;
        ///Source/7.jpg <summary>
        /// Source/7.jpg
        /// </summary>

        public string PhotoSource
        {
            get { return photoFaceSource; }
            set { value = photoFaceSource; }// замените этот путь на актуальный путь к вашей фотографии
        }
        public More_info()
        {
            InitializeComponent();
            // Вызывать Gets() в момент, когда selectedPrisoner установлен
            
            //string selectedFilePath = openFileDialog.FileName;
            //FotocarSuspect.Source = new BitmapImage(new Uri(z));
        }

        public void SetSelectedPrisoner(Prisoner prisoner)
        {
            selectedPrisoner = prisoner;
            Gets();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.ToSearchingEnotherframe((MainWindow)Window.GetWindow(this));
        }

        public void Gets()
        {
            if (selectedPrisoner != null)
            {
                
                Name.Text = selectedPrisoner.Name;
                SName.Text = selectedPrisoner.Surname;
                klichka.Text = selectedPrisoner.Hospital;
                Hender.Text = selectedPrisoner.Gender;
                Dr.Text = selectedPrisoner.Birthday.HasValue ? selectedPrisoner.Birthday.Value.ToString("yyyy-MM-dd") : string.Empty;
                Hair.Text = selectedPrisoner.ColorHair;
                Country.Text = selectedPrisoner.Country;
                LastCountry.Text = selectedPrisoner.LastSee;
                Status.Text = selectedPrisoner.Status.ToString();
                Criminal.Text = selectedPrisoner.CriminalArticles;
                Weight.Text = selectedPrisoner.Weight.ToString();
                EyeColor.Text = selectedPrisoner.EyeColor;
                InterestsHobbies.Text = selectedPrisoner.Hobbies;
                blood.Text = selectedPrisoner.BloodType;
                Profession.Text = selectedPrisoner.Profession;
                Married.Text = selectedPrisoner.Married ? "Yes" : "No";
                CivilSpecialization.Text = selectedPrisoner.CivilSpec;
                CrimeSpecialization.Text = selectedPrisoner.CrimeSpec;
                Gang.Text = selectedPrisoner.Gang;
                FirstCrimes.Text = selectedPrisoner.FirstCrimes;
                BIO.Text = selectedPrisoner.BIO;
                FotocarSuspect.Source = new BitmapImage(new Uri(selectedPrisoner.PhotoName, UriKind.Absolute));
                ImprintImage.Source = new BitmapImage(new Uri(selectedPrisoner.FingerName, UriKind.Absolute));
            }

            }
        }
    }



