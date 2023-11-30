using CursachFront.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CursachFront
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly CursachConfiguration _cursachConfiguration;

        public App()
        {
            _cursachConfiguration = CursachConfiguration.LoadFromFile();
            _cursachConfiguration.LoadData();

        }

        protected override void OnExit(ExitEventArgs e)
        {
            _cursachConfiguration.SaveToFile();
            base.OnExit(e);
        }
    }
}
