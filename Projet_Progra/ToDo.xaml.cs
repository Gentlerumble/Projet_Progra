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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Projet_Progra
{
    /// <summary>
    /// Logique d'interaction pour ToDo.xaml
    /// </summary>
    public partial class ToDo : Window
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }
        public ToDo()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<TaskItem>();
            DataContext = this;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbNewTask.Text))
            {
                Tasks.Add(new TaskItem { Title = tbNewTask.Text, IsDone= false });
                tbNewTask.Clear();
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (lbTasks.SelectedItem is TaskItem selected)
            {
                Tasks.Remove(selected);
            }
        }

        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            // Retrouver la fenêtre principale existante
            var main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (main != null)
            {
                main.Show(); // la réaffiche si cachée
            }
            this.Close(); // ferme la ToDo
        }


    }
}
