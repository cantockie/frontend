
using CursachFront.Core.Models;
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
using Newtonsoft.Json;
using System.IO;
using Microsoft.Xaml.Behaviors.Core;
using CursachFront.Core.Services.Path;
using System.Diagnostics;
namespace CursachFront
{
    /// <summary>
    /// Логика взаимодействия для searching.xaml
    /// </summary>
    public partial class searching : Page
    {
        PrisonerFilterViewModel _pfvm;
        private int PrisonInd; 
        public searching()
        {
            InitializeComponent();
            _pfvm = new PrisonerFilterViewModel();
            DataContext = new PrisonerFilterViewModel();
        }


 
        private void ToMoreInfo(object sender, RoutedEventArgs e)
        {
            if (dataListView.SelectedItem != null)
            {
                var selectedPrisoner = dataListView.SelectedItem as Prisoner;

                if (selectedPrisoner != null)
                {
                //    More_info moreInfoPage = new More_info();
                //    moreInfoPage.SetSelectedPrisoner(selectedPrisoner);

                    // Вызов метода для перехода на страницу More_info
                    MainWindow.ToMoreInformationEnotherframe((MainWindow)Window.GetWindow(this), selectedPrisoner);
                }
            }
        }
        private void OnListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataListView.SelectedItem != null)
            {

                var selectedPrisoner = dataListView.SelectedItem as Prisoner;


                if (selectedPrisoner != null)
                {
                    Name.Text = selectedPrisoner.Name;
                    SName.Text = selectedPrisoner.Surname;
                    klichka.Text = selectedPrisoner.Hospital;
                    Hender.Text = selectedPrisoner.Gender;
                    Dr.Text = selectedPrisoner.Birthday.ToString();
                    Country.Text = selectedPrisoner.Country;
                    Hair.Text = selectedPrisoner.ColorHair;
                    LastCountry.Text = selectedPrisoner.LastSee;
                    Status.Text = selectedPrisoner._Status.ToString();
                    Criminal.Text = selectedPrisoner.CriminalArticles.ToString();
                    PrisonInd = Convert.ToInt32(selectedPrisoner.Id);
                    string _face = PathFindService.GetPath(selectedPrisoner.PhotoName, true);
                    string _finger = PathFindService.GetPath(selectedPrisoner.FingerName, false);
                    FotocarSuspect.Source = new BitmapImage(new Uri(_face, UriKind.Absolute));
                    ImprintImage.Source = new BitmapImage(new Uri(_finger, UriKind.Absolute));
                    if (_face is not null)
                    {
                        FotocarSuspect.Source = new BitmapImage(new Uri(_face, UriKind.Absolute));

                    }
                    else
                    {
                        _face = PathFindService.GetPath("face1.jpg", true);
                        FotocarSuspect.Source = new BitmapImage(new Uri(_face, UriKind.Absolute));
                    }
                    if (_finger is not null)
                    {
                        ImprintImage.Source = new BitmapImage(new Uri(_finger, UriKind.Absolute));
                    }
                    else
                    {
                        _finger = PathFindService.GetPath("mark2.png", false);
                        ImprintImage.Source = new BitmapImage(new Uri(_face, UriKind.Absolute));
                    }
                }
            }

              



            }

        }
        
    }


