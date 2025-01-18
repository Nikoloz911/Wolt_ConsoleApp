using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Net;
using System.Net.Mail;
namespace Wolt_ConsoleApp.SMTP;
internal class SmtpService
{
    public static void EmailSender(string ToAddress)
    {
        string senderEmail = "nikalobjanidze014@gmail.com";
        string appPassword = "azhv ydkw ccmz osax";
        string htmlContent = $@"";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(senderEmail);
        mail.To.Add(ToAddress);
        mail.Subject = ""; /// Subject
        mail.Body = htmlContent;
        mail.IsBodyHtml = true;
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            EnableSsl = true,
            Credentials = new NetworkCredential(senderEmail, appPassword),
        };
        smtpClient.Send(mail);
    }
    public static void SendOrderEmail(string ToAddress)
    {
        /// FOR ORDER
        string senderEmail = "nikalobjanidze014@gmail.com";
        string appPassword = "azhv ydkw ccmz osax";
        string htmlContent = $@"";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(senderEmail);
        mail.To.Add(ToAddress);
        mail.Subject = ""; /// Subject
        mail.Body = htmlContent;
        mail.IsBodyHtml = true;
        //mail.Attachments.Add(new Attachment("Order Invoice Path here"));
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            EnableSsl = true,
            Credentials = new NetworkCredential(senderEmail, appPassword),
        };
        smtpClient.Send(mail);
    }
}
