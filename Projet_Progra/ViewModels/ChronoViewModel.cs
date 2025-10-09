using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Projet_Progra.Models;
using Projet_Progra.Helpers;
using System.Windows.Input; 

namespace Projet_Progra.ViewModels
{
    internal class ChronoViewModel : INotifyPropertyChanged
    {
        //Timer qui déclenche l'incrémentation chaque seconde
        private readonly DispatcherTimer _timer;
        //Modèle pour stocker l'état du chronomètre
        private readonly ChronoModel _model;

        public event PropertyChangedEventHandler PropertyChanged;

        public ChronoViewModel()
        {
            _model = new ChronoModel();
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += (s, e) => Incrementer();

            DemarrerCommand = new RelayCommand(Demarrer, () => !_model.EstEnCours);
            ArreterCommand = new RelayCommand(Arreter, () => _model.EstEnCours);
            ReinitialiserCommand = new RelayCommand(Reinitialiser, () => !_model.EstEnCours && _model.TempsEcoule != TimeSpan.Zero);
        }

        //Temps écoulé affiché et modifié dans la vue
        public TimeSpan TempsEcoule
        {
            get => _model.TempsEcoule;
            set
            {
                _model.TempsEcoule = value;
                OnPropertyChanged(nameof(TempsEcoule));
                //MAJ des angles des aiguilles
                OnPropertyChanged(nameof(AngleSecondes));
                OnPropertyChanged(nameof(AngleMinutes));
            }
        }

        //Angle pour l'aiguille des secondes 6°/seconde
        public double AngleSecondes => _model.TempsEcoule.Seconds * 6;
        //Angle pour l'aiguille des minutes 6°/minute + fraction de minute
        public double AngleMinutes => (_model.TempsEcoule.Minutes + (TempsEcoule.Seconds / 60.0)) * 6;

        //Commandes liées aux boutons de la vue
        public RelayCommand DemarrerCommand { get; }
        public RelayCommand ArreterCommand { get; }
        public RelayCommand ReinitialiserCommand { get; }

        private void Demarrer()
        {
            _model.EstEnCours = true;
            _timer.Start();
            //Force la MAJ de l'état des commandes
            CommandManager.InvalidateRequerySuggested();
        }

        private void Arreter()
        {
            _model.EstEnCours = false;
            _timer.Stop();
            CommandManager.InvalidateRequerySuggested();
        }

        private void Reinitialiser()
        {
            TempsEcoule = TimeSpan.Zero;
            CommandManager.InvalidateRequerySuggested();
        }

        private void Incrementer()
        {
            TempsEcoule = TempsEcoule.Add(TimeSpan.FromSeconds(1));
        }

        //Notifie la vue d'un changement de propriété
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
