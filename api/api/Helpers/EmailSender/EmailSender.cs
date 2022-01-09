using System.IO;
using System.Net;
using System.Net.Mail;

namespace api.Helpers.EmailSender {
    public static class EmailSender {
        private static readonly MailMessage Message = new MailMessage();
        private static readonly SmtpClient Client = new SmtpClient("smtp-mail.outlook.com", 587);

        private static void ConfigureClient() {
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential("jispen.inisoft@outlook.com", "jispen_inisoft");
        }

        private static void ConfigureMessage(string email, string verificationCode) {
            Message.Subject = "Potvrzení registrace v aplikaci JISPEN";
            Message.IsBodyHtml = true;
            Message.Body = File.ReadAllText("./Helpers/EmailSender/verificationTemplate.html").Replace("{code}", verificationCode);
            Message.From = new MailAddress("jispen.inisoft@outlook.com", "JISPEN");
            Message.To.Add(email);
        }

        private static void SendMessage() {
            Client.Send(Message);
        }

        public static void SendVerification(string email, string verificationCode) {
            ConfigureClient();
            ConfigureMessage(email, verificationCode);
            SendMessage();
        }
    }
}
