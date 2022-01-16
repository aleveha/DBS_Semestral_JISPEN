using System.IO;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace api.Helpers.EmailSender {
    public class EmailSender {
        private static readonly IConfigurationRoot AppConfig =
            new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        private static readonly MailMessage Message = new MailMessage();

        private static readonly SmtpClient Client = new SmtpClient(
        AppConfig["EmailSender:Client:Host"],
        int.Parse(AppConfig["EmailSender:Client:Port"]));

        private static void ConfigureClient() {
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential(AppConfig["EmailSender:Credentials:UserName"], AppConfig["EmailSender:Credentials:Password"]);
        }

        private static void ConfigureMessage(string emailTo, string subject, string body) {
            Message.Subject = subject;
            Message.IsBodyHtml = true;
            Message.Body = body;
            Message.From = new MailAddress(AppConfig["EmailSender:Email:Address"], AppConfig["EmailSender:Email:Name"]);
            Message.To.Add(emailTo);
        }

        public static void SendEmail(string emailTo, string subject, string body) {
            ConfigureClient();
            ConfigureMessage(emailTo, subject, body);
            Client.Send(Message);
        }
    }
}
