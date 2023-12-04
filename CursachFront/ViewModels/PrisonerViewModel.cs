using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CursachFront.Core.Models;
using CursachFront.Core.Models.FilterUsers;
using CursachFront.Core.Services;
using CursachFront.Core.Services.Prisoners;

namespace CursachFront
{
    public class PrisonerViewModel : INotifyPropertyChanged
    {
        private readonly PrisonerService _prisonerService;
        private ObservableCollection<Prisoner> _prisoners;
        private string _country;
        private string _gang;
        private string _status;

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

        public string Gang
        {
            get { return _gang; }
            set
            {
                if (_gang != value)
                {
                    _gang = value;
                    OnPropertyChanged(nameof(Gang));
                    UpdatePrisoners();
                }
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                    UpdatePrisoners();
                }
            }
        }

        public PrisonerViewModel()
        {
            _prisonerService = new PrisonerService();
            Prisoners = new ObservableCollection<Prisoner>();
            UpdatePrisoners();
            PropertyChanged += OnPropertyChanged;
          
        }

        private void UpdatePrisoners()
        {
            var filter = new SearchFilter
            {
                Country = Country,
                Gang = Gang,
                Status = Status
            };

            Prisoners.Clear();
            foreach (var prisoner in _prisonerService.GetFilteredShort(filter))
            {
                Prisoners.Add(prisoner);
            }
        }


        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Country) || e.PropertyName == nameof(Gang) || e.PropertyName == nameof(Status))
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
