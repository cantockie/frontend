using CursachFront.Core;
using CursachFront.Core.Models;
using CursachFront.Core.Services.Path;
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
    /// Логика взаимодействия для PageUserCabinet.xaml
    /// </summary>
    public partial class PageUserCabinet : Page
    {
        private ProfileData currentUser;

        public ProfileData CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                // Обновите ваш интерфейс на основе текущего пользователя
                UpdateInterface();
            }
        }

        public PageUserCabinet()
        {
            InitializeComponent();
            // При создании страницы вы можете установить текущего пользователя
            CurrentUser = LocalIdentity.GetProfile();
        }

        public static void ToSUpdateInterfaceEnotherframe(PageUserCabinet pageUserCabinet) { pageUserCabinet.UpdateInterface(); }


        private void UpdateInterface()
        {
            // Обновите ваш интерфейс на основе свойств текущего пользователя
            // Например, вы можете обновить текстовые блоки, изображения и так далее.
            if (CurrentUser != null)
            {
                Name.Text = CurrentUser.FirstName;
                Sname.Text = CurrentUser.LastName;
                Status.Text = CurrentUser.Role;
                Experience.Text = CurrentUser.Education;
                ContryOficer.Text = CurrentUser.Country;
                Level.Text = CurrentUser.Rank;
                string face = PathFindService.GetPath(CurrentUser.ProfileImage, true);
                FotocarOficer.Source = new BitmapImage(new Uri(face, UriKind.Absolute));
            }
        }

        private void CancellCabinet(object sender, RoutedEventArgs e)
        {
            MainWindow.CancellCabinet((MainWindow)Window.GetWindow(this));
        }

        private void FullCabinet(object sender, RoutedEventArgs e)
        {
            MainWindow.ToFullUserCabinetEnotherframe((MainWindow)Window.GetWindow(this));
            MainWindow.CancellCabinet((MainWindow)Window.GetWindow(this));
        }
    }
}
