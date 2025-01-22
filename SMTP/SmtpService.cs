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
        /// EMAIL HTML CONTENT  /// EMAIL HTML CONTENT /// EMAIL HTML CONTENT
        /// EMAIL HTML CONTENT  /// EMAIL HTML CONTENT /// EMAIL HTML CONTENT
        /// EMAIL HTML CONTENT  /// EMAIL HTML CONTENT /// EMAIL HTML CONTENT
        string htmlContent = $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Registration Success</title>
</head>
<body style='margin: 100px; display: block; background-color: #f0f0f0; text-align: center; padding: 20px; height: 600px;'>
    <div style='width: 500px; height: 400px; border-radius: 20px; background-color: #ffffff; margin: auto;'>
        <!-- Header Section -->
        <div style='background-color: rgb(0, 194, 232); height: 50%; padding: 20px 10px; border-top-left-radius: 10px; border-top-right-radius: 10px; display: flex; align-items: center;'>
            <!-- Left Side Content -->
            <div style='flex: 1; padding-left: 20px;'>
                <h1 style='font-family: cursive; color: #fff; font-size: 35px;'>Wolt</h1>
                <p style='color: #fff; font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: 18px; width: 230px;'>Your Registration Completed Successfully</p>
            </div>
            <!-- Right Side Image -->
            <div style='flex: 1; text-align: center;'>
                <img src='https://i.postimg.cc/4d7G1B1n/unnamed.png' alt='Wolt Logo' style='width: 150px; height: 150px;
                margin-left: 50px; margin-top: 20px;' />
            </div>
        </div>

        <!-- Bottom Section with increased height -->
        <div style='background-color: #ddd; color: #000; font-family: sans-serif; text-align: center; padding-top: 40px; padding-bottom: 40px; border-bottom-left-radius: 10px; border-bottom-right-radius: 10px; height: 50%;'>
            <div style='padding: 20px;'>
                <p style='font-size: 20px;'>Thank you for joining Wolt! We’re excited to have you onboard.</p>
                <p style='font-size: 18px;'>Feel free to explore our platform and start making the most of our services.</p>
            </div>
        </div>
    </div>
</body>
</html>
";
        /// EMAIL HTML CONTENT  /// EMAIL HTML CONTENT /// EMAIL HTML CONTENT
        /// EMAIL HTML CONTENT  /// EMAIL HTML CONTENT /// EMAIL HTML CONTENT
        /// EMAIL HTML CONTENT  /// EMAIL HTML CONTENT /// EMAIL HTML CONTENT
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(senderEmail);
        mail.To.Add(ToAddress);
        mail.Subject = "Registration was succesfully"; /// Subject
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
