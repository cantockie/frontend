using CursachFront.Core;
using CursachFront.Core.Models;
using CursachFront.Core.Services.Path;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static PageOption Options = new PageOption();
        private static PageUserCabinet Cabinets = new PageUserCabinet();
        private static searching Searching = new searching();
        private static Veiw View = new Veiw();
        private static CHANDGESUSPECT Changer = new CHANDGESUSPECT();
        private static NewUser NUser = new NewUser();
        private static More_info Info = new More_info();
        private static FullUserCabinet FullUserCabinet = new FullUserCabinet();
        private ProfileData _current;
        private ProfileData GetProf()
            => new()
            {
                Country = _current.Country,
                Education = _current.Education,
                FirstName = _current.FirstName,
                LastName = _current.LastName,
                ProfileImage = _current.ProfileImage,
                Rank = _current.Rank,
                Role = _current.Role

              
            };
      
        public MainWindow()
        {
            _current = LocalIdentity.GetProfile();
            
            InitializeComponent();
            StatusBlock.Text = _current.Rank;
            NameOficer.Text = _current.FirstName;
            SNameOficer.Text = _current.LastName;
            string face = PathFindService.GetPath(_current.ProfileImage, true);
            FotocarOficer.Source = new BitmapImage(new Uri(face, UriKind.Absolute));
        }
        private void ToOption(object sender, RoutedEventArgs e) { OptionsPages.Content = Options; }
        public static void Cancell(MainWindow mainWindow) { mainWindow.CansellOptionMetod();}
        public  void CansellOptionMetod() { OptionsPages.Content = null; } 


        private void ToCabinet(object sender, RoutedEventArgs e) { 
            CadinetOficer.Content = Cabinets;
            PageUserCabinet.ToSUpdateInterfaceEnotherframe(Cabinets);


        }
        public static void CancellCabinet(MainWindow mainWindow) { mainWindow.CansellCabinetMetod(); }
        public void CansellCabinetMetod() { CadinetOficer.Content = null; }
       
        /// //////////////////кнопки поиска/
     
        private void ToSearching(object sender, RoutedEventArgs e) { FindesPages.Content = Searching; }
        public static void CancellSearching(MainWindow mainWindow) { mainWindow.CansellSearchingMetod(); }
        public static void ToSearchingEnotherframe(MainWindow mainWindow) { mainWindow.ToSearchingMetod(); }

       
        private void ToSearchingMetod() { FindesPages.Content = Searching; }
        public void CansellSearchingMetod() { FindesPages.Content = null; }

        /// //////////////////кнопки view/

        private void ToView(object sender, RoutedEventArgs e) { FindesPages.Content = View; }
        public static void CancellView(MainWindow mainWindow) { mainWindow.CansellViewMetod(); }
        public static void ToViewEnotherframe(MainWindow mainWindow) { mainWindow.ToViewMetod(); }


        private void ToViewMetod() { FindesPages.Content = View; }
        public void CansellViewMetod() { FindesPages.Content = null; }
        /// //////////////////кнопки changer/
        private void ToChangeSubject(object sender, RoutedEventArgs e) { FindesPages.Content = Changer; }
        public static void CancellChangeSubject(MainWindow mainWindow) { mainWindow.CansellChangeSubjectMetod(); }
        public static void ToChangeSubjectEnotherframe(MainWindow mainWindow) { mainWindow.ToChangeSubjectMetod(); }

        private void ToChangeSubjectMetod() { FindesPages.Content = Changer; }
        public void CansellChangeSubjectMetod() { FindesPages.Content = null; }
        /// //////////////////кнопки User/
        private void ToNewUser(object sender, RoutedEventArgs e) { FindesPages.Content = NUser; }
        public static void CancellNewUser(MainWindow mainWindow) { mainWindow.CansellNewUserMetod(); }
        public static void ToNewUserEnotherframe(MainWindow mainWindow) { mainWindow.ToNewUserMetod(); }

        private void ToNewUserMetod() { FindesPages.Content = NUser; }
        public void CansellNewUserMetod() { FindesPages.Content = null; }
        /// //////////////////кнопки User/
        private void ToMoreInformation(object sender, RoutedEventArgs e) { FindesPages.Content = Info; }
        public static void CancellMoreInformation(MainWindow mainWindow) { mainWindow.CansellMoreInformationMetod(); }
        public static void ToMoreInformationEnotherframe(MainWindow mainWindow, Prisoner pr) { mainWindow.ToMoreInformationMetod(pr); }

        private void ToMoreInformationMetod(Prisoner selectedPrisoner)
        {
            More_info Info = new More_info();

            Info.SetSelectedPrisoner(selectedPrisoner);

            FindesPages.Content = Info;
        }
        public void CansellMoreInformationMetod() { FindesPages.Content = null; }
        /// //////////////////кнопки FullCabinet/
        private void ToFullUserCabinet(object sender, RoutedEventArgs e) { FindesPages.Content = FullUserCabinet; }
        public static void CancellFullUserCabinet(MainWindow mainWindow) { mainWindow.CansellFullUserCabinetMetod(); }
        public static void ToFullUserCabinetEnotherframe(MainWindow mainWindow) { mainWindow.ToFullUserCabinetMetod(); FullUserCabinet.ToSUpdateInterfaceEnotherframe(FullUserCabinet); }
        public static void ToBackFullUserCabinetEnotherframe(MainWindow mainWindow) { mainWindow.GoBackFullUserCabinetMetod();  }

        private void ToFullUserCabinetMetod() { FindesPages.Content = FullUserCabinet;}
        public void  CansellFullUserCabinetMetod() { FindesPages.Content = null; }
        public void  GoBackFullUserCabinetMetod() { if (FindesPages.NavigationService.CanGoBack) { FindesPages.NavigationService.GoBack(); } else { FindesPages.Content = null;} }
        /// //////////////////
        private void CansellButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MinimizateButton(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
