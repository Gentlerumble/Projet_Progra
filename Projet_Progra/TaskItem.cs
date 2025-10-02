using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Projet_Progra
{
    public class TaskItem : INotifyPropertyChanged
    {
        private string title;
        private bool isDone;

        public string Title
        {
            get { return title; }
            set
            {
                if(title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public bool IsDone
        {
            get { return isDone; }
            set
            {
                if(isDone != value)
                {
                    isDone = value;
                    OnPropertyChanged(nameof(IsDone));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
