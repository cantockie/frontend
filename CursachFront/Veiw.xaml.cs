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
    /// Логика взаимодействия для Veiw.xaml
    /// </summary>
    public partial class Veiw : Page
    {
        private PrisonerViewModel _prisonerViewModel;

        public Veiw()
        {
            InitializeComponent();
            _prisonerViewModel = new PrisonerViewModel();
            LoadAllAlive();
        }
        public void LoadAllAlive()
        {
            Status.Text = "Alive";
            Status.Text = "";
        }
    }
}
