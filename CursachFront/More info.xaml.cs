using Accessibility;
using CursachFront.Core;
using CursachFront.Core.Models;
using CursachFront.Core.Services.Path;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Path = System.IO.Path;

namespace CursachFront
{
    public partial class More_info : Page
    {
        private Prisoner selectedPrisoner;
        private string photoFaceSource;
        private string _face;
        private string _finger;
        public More_info()
        {
            InitializeComponent();
        }

        public void SetSelectedPrisoner(Prisoner prisoner)
        {
            selectedPrisoner = prisoner;
            _face = PathFindService.GetPath(selectedPrisoner.PhotoName, true);
            _finger = PathFindService.GetPath(selectedPrisoner.FingerName, false);
            Gets();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.ToSearchingEnotherframe((MainWindow)Window.GetWindow(this));
        }

        public void Gets()
        {
            if (selectedPrisoner is not null)
            {
                
                Name.Text = selectedPrisoner.Name;
                SName.Text = selectedPrisoner.Surname;
                klichka.Text = selectedPrisoner.Hospital;
                Hender.Text = selectedPrisoner.Gender;
                Dr.Text = selectedPrisoner.Birthday.HasValue ? selectedPrisoner.Birthday.Value.ToString("yyyy-MM-dd") : string.Empty;
                Hair.Text = selectedPrisoner.ColorHair;
                Country.Text = selectedPrisoner.Country;
                LastCountry.Text = selectedPrisoner.LastSee;
                Status.Text = selectedPrisoner._Status.ToString();
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
                    _finger = PathFindService.GetPath("mark1.png", false);
                    ImprintImage.Source = new BitmapImage(new Uri(_finger, UriKind.Absolute));
                }
            }

            }

        private void ToHTML_Click(object sender, RoutedEventArgs e)
            => SaveHtmlToFile(GenerateHtmlContent());
        
        string GenerateHtmlContent()
        {
     
             _face = PathFindService.GetPath(selectedPrisoner.PhotoName, true);
             _finger = PathFindService.GetPath(selectedPrisoner.FingerName, false);

            string html = $@"
            <!DOCTYPE html>
            <html>
            <head>
            <title>Информация о заключенном</title>
            <style>
            body {{
            font-family: Arial, sans-serif;
            margin: 20px;
            }}
            h1 {{
            color: #333;
            }}
            p {{
            margin-bottom: 10px;
            }}
            img {{
            margin-top: 20px;
            border: 1px solid #333;
            }}
            </style>
            </head>
            <body>
            <h1>Информация о заключенном</h1>
            <p><strong>Имя:</strong> {Name.Text}</p>
            <p><strong>Фамилия:</strong> {SName.Text}</p>
            <p><strong>Кличка:</strong> {klichka.Text}</p>
            <p><strong>Пол:</strong> {Hender.Text}</p>
            <p><strong>Дата рождения:</strong> {Dr.Text}</p>
            <p><strong>Цвет волос:</strong> {Hair.Text}</p>

            <img src='{_face}' alt='Фотография заключенного' width='300'>
            <img src='{_finger}' alt='Отпечаток пальца' width='300'>

    
            <h2>Дополнительная информация</h2>
            <p><strong>Статус:</strong> {Status.Text}</p>
            <p><strong>Преступные статьи:</strong> {Criminal.Text}</p>
            <p><strong>Вес:</strong> {Weight.Text}</p>
            </body>
            </html>
            ";
            return html;
        }
        static void SaveHtmlToFile(string htmlContent)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = ".html";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, htmlContent);

                    MessageBox.Show($"Файл '{saveFileDialog.FileName}' успешно сохранен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = saveFileDialog.FileName,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
    



