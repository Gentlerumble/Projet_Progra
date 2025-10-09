using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projet_Progra.Helpers
{
    // Implémente ICommand pour permettre la liaison de commandes dans le MVVM.
    // Permet d'exécuter une action et de vérifier si elle peut être exécutée.
    internal class RelayCommand : ICommand
    {
        //L'action à exécuter et la fonction pour vérifier si l'action peut être exécutée. 
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        //Événement déclenché quand l'état d'eécution change
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();
        public void Execute(object parameter) => _execute();    
    }
}
