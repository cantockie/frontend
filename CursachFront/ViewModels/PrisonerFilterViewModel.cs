using global::CursachFront.Core.Models;
using global::CursachFront.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using global::CursachFront.Core.Models.FilterUsers;
using global::CursachFront.Core.Services.Prisoners;

namespace CursachFront
{
    public class PrisonerFilterViewModel : INotifyPropertyChanged
    {
        private readonly PrisonerService _prisonerService;
        private ObservableCollection<Prisoner> _prisoners;
        private string _name;
        private string _surname;
        private string _country;
        private string _crimespec;
        private string _birthday;
        private string _colorhair;
        private string _eyecolor;

        public ObservableCollection<Prisoner> Prisoners
        {
            get { return _prisoners; }
            set
            {
                if (_prisoners != value)
                {
                    _prisoners = value;
                    OnPropertyChanged(nameof(Prisoners));
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                    UpdatePrisoners();
                }
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged(nameof(Surname));
                    UpdatePrisoners();
                }
            }
        }

        public string Country
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                    OnPropertyChanged(nameof(Country));
                    UpdatePrisoners();
                }
            }
        }

        public string Crimespec
        {
            get { return _crimespec; }
            set
            {
                if (_crimespec != value)
                {
                    _crimespec = value;
                    OnPropertyChanged(nameof(Crimespec));
                    UpdatePrisoners();
                }
            }
        }

        public string Birthday
        {
            get { return _birthday; }
            set
            {
                if (_birthday != value)
                {
                    _birthday = value;
                    OnPropertyChanged(nameof(Birthday));
                    UpdatePrisoners();
                }
            }
        }

        public string ColorHair
        {
            get { return _colorhair; }
            set
            {
                if (_colorhair != value)
                {
                    _colorhair = value;
                    OnPropertyChanged(nameof(ColorHair));
                    UpdatePrisoners();
                }
            }
        }

        public string EyeColor
        {
            get { return _eyecolor; }
            set
            {
                if (_eyecolor != value)
                {
                    _eyecolor = value;
                    OnPropertyChanged(nameof(EyeColor));
                    UpdatePrisoners();
                }
            }
        }

        public PrisonerFilterViewModel()
        {
            _prisonerService = new PrisonerService();
            Prisoners = new ObservableCollection<Prisoner>();
            UpdatePrisoners();
            // Subscribe to PropertyChanged events
            PropertyChanged += OnPropertyChanged;
        }

        private void UpdatePrisoners()
        {
            var filter = new SearchFilter
            {
                Name = Name,
                Surname = Surname,
                Birthday = Birthday,
                ColorHair = ColorHair,
                EyeColor = EyeColor,
                CrimeSpec = Crimespec,
                Country = Country,
            };

            Prisoners.Clear();
            foreach (var prisoner in _prisonerService.GetFilteredAsync(filter))
            {
                Prisoners.Add(prisoner);
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Name) || e.PropertyName == nameof(Surname) || e.PropertyName == nameof(Country) ||
                e.PropertyName == nameof(Crimespec) || e.PropertyName == nameof(EyeColor) || e.PropertyName == nameof(Birthday) ||
                e.PropertyName == nameof(ColorHair))
            {
                UpdatePrisoners();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

