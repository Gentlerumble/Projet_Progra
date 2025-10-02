using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace Projet_Progra
{
    public partial class Mail : Window
    {
        public Mail()
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

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(from, password);
                smtp.EnableSsl = true;

                MailMessage message = new MailMessage(from, to, subject, body);
                smtp.Send(message);

                tbStatus.Text = "Mail envoyé avec succès ✅";
                tbStatus.Foreground = System.Windows.Media.Brushes.Green;
            }
            catch (Exception ex)
            {
                tbStatus.Text = "Erreur : " + ex.Message;
                tbStatus.Foreground = System.Windows.Media.Brushes.Red;
            }
        }

        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            // Chercher s’il existe déjà une fenêtre MainWindow ouverte
            var main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (main != null)
            {
                main.Show(); // réaffiche la fenêtre principale
            }
            this.Close(); // ferme la fenêtre Mail
        }
    
    }
}
