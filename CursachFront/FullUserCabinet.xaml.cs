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
    /// Логика взаимодействия для FullUserCabinet.xaml
    /// </summary>
    public partial class FullUserCabinet : Page
    {
        public FullUserCabinet()
        {
            InitializeComponent();
        }
        private void b(object sender, RoutedEventArgs e)
        {        
            MainWindow.ToBackFullUserCabinetEnotherframe((MainWindow)Window.GetWindow(this));
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
