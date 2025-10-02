using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projet_Progra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenMail_Click(object sender, RoutedEventArgs e)
        {
            Mail mailWindow = new Mail();
            mailWindow.Show();
            
        }

        private void OpenToDo_Click(object sender, RoutedEventArgs e)
        {
            ToDo todoWindow = new ToDo();
            todoWindow.Show();
            
        }
    }
}