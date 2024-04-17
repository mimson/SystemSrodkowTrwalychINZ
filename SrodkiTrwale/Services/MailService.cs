using System.Net;
using System.Net.Mail;

namespace SrodkiTrwale.Services
{
    public class MailService
    {
        public SmtpClient SmtpClient { get; set; }

        public MailService()
        {
            SmtpClient = new SmtpClient();
            SmtpClient.Port = 587;
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.Host = "smtp.gmail.com";
            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.EnableSsl = true;

            SmtpClient.Credentials = new NetworkCredential("michal.woolski@gmail.com", "rvmlkwckizjfqxus");
        }

        public void SendMail(string emailTo, string body)
        {
            MailMessage message = new MailMessage();

            message.From = new MailAddress("michal.woolski@gmail.com");
            message.To.Add(new MailAddress(emailTo));
            message.Subject = "Witamy w Firmie";
            message.IsBodyHtml = false;
            message.Body = "Witaj w firmie " + body;
            SmtpClient.Send(message);
        }
    }
}