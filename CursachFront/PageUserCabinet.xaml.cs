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
        public PageUserCabinet()
        {
            InitializeComponent();
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
