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

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string from = tbFrom.Text;
                string password = pbPassword.Password;
                string to = tbTo.Text;
                string subject = tbSubject.Text;
                string body = tbBody.Text;

                MailMessage mail = new MailMessage(from, to, subject, body);

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential(from, password);
                client.EnableSsl = true;

                client.Send(mail);

                tbStatus.Text = "Mail envoyé avec succès";
                tbStatus.Foreground = System.Windows.Media.Brushes.Green;
            }
            catch (Exception ex)
            {
                tbStatus.Text = "Erreur lors de l'envoi du mail: " + ex.Message;
                tbStatus.Foreground = System.Windows.Media.Brushes.Red;
            }
        }
    }
}