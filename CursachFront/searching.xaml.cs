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
    /// Логика взаимодействия для searching.xaml
    /// </summary>
    public partial class searching : Page
    {
        public searching()
        {
            InitializeComponent();
           
            List<Person> people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", ImagePath = "path/to/image1.jpg" },
                new Person { FirstName = "Alice", LastName = "Smith", ImagePath = "path/to/image2.jpg" },
                // Добавляем другие объекты Person
            };

            // Устанавливаем этот список в качестве источника данных для ListView
            dataListView.ItemsSource = people;
        }
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string ImagePath { get; set; }
        }

        // Создаем список людей для отображения в ListView
        List<Person> people = new List<Person>
{
    new Person { FirstName = "John", LastName = "Doe", ImagePath = "path/to/image1.jpg" },
    new Person { FirstName = "Alice", LastName = "Smith", ImagePath = "path/to/7.jpg" },
    // Добавляем другие объекты Person
};
        private void ToMoreInfo(object sender, RoutedEventArgs e)
        {
            MainWindow.ToMoreInformationEnotherframe((MainWindow)Window.GetWindow(this));
        }//адмін панель


    }

}
