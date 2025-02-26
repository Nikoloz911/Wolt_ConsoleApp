using System.Net;
using System.Net.Mail;

namespace Wolt_ConsoleApp.SMTP
{
    internal class SmtpOrder
    {
        public static void SendOrderEmail(string ToAddress, string attachmentPath)
        {
            string senderEmail = "nikalobjanidze014@gmail.com";
            string appPassword = "smyz bznq fdrx tazq";
            string subject = "Your Order Confirmation";
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
<body style='display: block; background-color: #f0f0f0; height: 480px; width: 99%; '>
    <div style='max-width: 480px; height: 400px; border-radius: 20px; background-color: #ffffff; margin: auto; width: auto; '>
    
        <div style='background-color: rgb(0, 194, 232); height: 50%; border-top-left-radius: 10px; border-top-right-radius: 10px; display: flex; align-items: center; width: 100%;'>
         
            <div style='flex: 1; padding-left: 20px; width: 50%;'>
                <h1 style='font-family: cursive; color: #fff; font-size: 35px;'>Wolt</h1>
                <p style='color: #fff; font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: 18px; width: 230px;'>Your Order Completed Successfully</p>
            </div>
      
            <div style='flex: 1; text-align: center; width: 50%;'>
                <img src='https://i.postimg.cc/4d7G1B1n/unnamed.png' alt='Wolt Logo' style='width: 150px; height: 150px;
                margin-left: 50px; margin-top: 20px;' />
            </div>
        </div>


        <div style='background-color: #ddd; color: #000; font-family: sans-serif; text-align: center; padding-top: 40px; padding-bottom: 40px; border-bottom-left-radius: 10px; border-bottom-right-radius: 10px; height: 50%;'>
            <div style='padding: 20px;'>
              //////////////////////// Order Details HERE ///////////////////////////
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
            mail.Subject = subject;
            mail.Body = htmlContent;
            mail.IsBodyHtml = true;

            mail.Attachments.Add(new Attachment(attachmentPath));

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(senderEmail, appPassword),
            };
            smtpClient.Send(mail);
        }
    }
}
