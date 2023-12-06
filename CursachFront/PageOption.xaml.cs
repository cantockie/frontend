using CursachFront.Core;
using CursachFront.Core.Models;
using CursachFront.Core.Models.Enums;
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
    /// Логика взаимодействия для PageOption.xaml
    /// </summary>
    public partial class PageOption : Page
    {
  
        public PageOption()
        {
           
            InitializeComponent();

            if (!LocalIdentity.IsInRole(Roles.ADMIN))
                Admin.IsEnabled = false;
            if (!(LocalIdentity.IsInRole(Roles.ADMIN) || LocalIdentity.IsInRole(Roles.MANAGER)))
                Manager.IsEnabled = false;
            if (!(LocalIdentity.IsInRole(Roles.ADMIN) || LocalIdentity.IsInRole(Roles.MANAGER) || LocalIdentity.IsInRole(Roles.USER)))
                Search.IsEnabled = false;
        }
        private void CancellOp(object sender, RoutedEventArgs e)
        {
            MainWindow.Cancell((MainWindow)Window.GetWindow(this));
       
        }
        private void ToSearchgFrameOption(object sender, RoutedEventArgs e)
        {
            MainWindow.ToSearchingEnotherframe((MainWindow)Window.GetWindow(this));
            MainWindow.Cancell((MainWindow)Window.GetWindow(this));
        }
       
        private void ToVievFrameOption(object sender, RoutedEventArgs e)
        {
            MainWindow.ToViewEnotherframe((MainWindow)Window.GetWindow(this));
            MainWindow.Cancell((MainWindow)Window.GetWindow(this));
        }
        private void ToOptionSuspectsFrameOption(object sender, RoutedEventArgs e)
        {
            MainWindow.ToChangeSubjectEnotherframe((MainWindow)Window.GetWindow(this));
            MainWindow.Cancell((MainWindow)Window.GetWindow(this));
        }
        private void ToUserEnotherFrameOption(object sender, RoutedEventArgs e)
        {
            MainWindow.ToNewUserEnotherframe((MainWindow)Window.GetWindow(this));
            MainWindow.Cancell((MainWindow)Window.GetWindow(this));
        }
    }

}
