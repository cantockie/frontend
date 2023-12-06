using CursachFront.Core;
using CursachFront.Core.Models;
using CursachFront.Core.Services.Path;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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
    /// Логика взаимодействия для FullUserCabinet.xaml
    /// </summary>
    public partial class FullUserCabinet : Page
    {
        private ProfileData currentUser;
        private ProfileData _current;
        public ProfileData CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                UbdateFullCabinet();
            }
        }

        public FullUserCabinet()
        {
           _current = LocalIdentity.GetProfile();
            InitializeComponent();
            CurrentUser = LocalIdentity.GetProfile();
        }
        private void UbdateFullCabinet() 
        {
            if (CurrentUser is not null)
            {
                NameOficer.Text = _current.FirstName;
                SNameOficer.Text = _current.LastName;
                HenderOficer.Text = _current.Gender;
                Rank.Text = _current.Rank;
                DrOficer.Text = _current.BirthDay.ToString();
                EducationOficer.Text = _current.Education;
                CountryOficer.Text = _current.Country;
                DepartmentsOficer.Text = _current.Departments;
                SpecializationOficer.Text = _current.Specifications;
                ContactInformationOficer.Text = _current.Email;
                Level.Text = _current.Role;
                BIOOficer.Text = _current.Bio;
                idOficer.Text = _current.Id.ToString();
                string _face = PathFindService.GetPath(CurrentUser.ProfileImage, true);
                string _finger = PathFindService.GetPath(CurrentUser.ProfileImage, false);

                try 
                {
                    FotocarOficer.Source = new BitmapImage(new Uri(_face, UriKind.Absolute));

                }
                catch
                {
                    _face = PathFindService.GetPath("face1.jpg", true);
                    FotocarOficer.Source = new BitmapImage(new Uri(_face, UriKind.Absolute));
                }
                try {
                    ImprintImage.Source = new BitmapImage(new Uri(_finger, UriKind.Absolute));
                }
                catch
                {
                    _finger = PathFindService.GetPath("mark1.png", false);
                    ImprintImage.Source = new BitmapImage(new Uri(_finger, UriKind.Absolute));
                }
            }
        }

        
        public static void ToSUpdateInterfaceEnotherframe(FullUserCabinet fullUserCabinet) { fullUserCabinet.UbdateFullCabinet(); }
        private void b(object sender, RoutedEventArgs e)
        {        
            MainWindow.ToBackFullUserCabinetEnotherframe((MainWindow)Window.GetWindow(this));
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
