using System.Net;
using System.Net.Mail;

namespace Wolt_ConsoleApp.SMTP
{
    internal class SmtpOrder
    {
        public static void SendOrderEmail(string ToAddress, string attachmentPathTXT, string attachmentPathPDF, string customerName, string restaurantName, string creditCardNumber = null)
        {
            string senderEmail = "nikalobjanidze014@gmail.com";
            string appPassword = "APP_PASSWORD_HERE"; // APP PASSWORD
            string subject = "Your Order Confirmation";
            string[] imageUrls =
            {
                "https://i.postimg.cc/MGgVh0D6/MASTERCARD.png",
                "https://i.postimg.cc/R0Wwspwp/VISA.png"
            };
            Random random = new Random();
            string RandomizedImageUrl = imageUrls[random.Next(0, imageUrls.Length)];

            // Parse the order file to extract necessary information
            var orderInfo = ParseOrderFile(attachmentPathTXT);

            // Override with the passed parameters
            if (!string.IsNullOrEmpty(customerName))
                orderInfo.UserName = customerName;

            if (!string.IsNullOrEmpty(restaurantName))
                orderInfo.RestaurantName = restaurantName;

            if (!string.IsNullOrEmpty(creditCardNumber))
                orderInfo.CreditCardNumber = creditCardNumber;

            /// EMAIL HTML CONTENT  /// EMAIL HTML CONTENT /// EMAIL HTML CONTENT
            /// EMAIL HTML CONTENT  /// EMAIL HTML CONTENT /// EMAIL HTML CONTENT
            /// EMAIL HTML CONTENT  /// EMAIL HTML CONTENT /// EMAIL HTML CONTENT
            string htmlContent = $@"
<!DOCTYPE html>
<html lang='en'>

<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Your Order Confirmation</title>
</head>

<body style='display: block; background-color: #f0f0f0; height: 90vh; padding: 20px;'>
    <div style='max-width: 480px; border-radius: 20px; background-color: #ffffff; margin: auto;'>

    <!-- Header Section -->
<div style='background-color: rgb(0, 194, 232); padding: 20px; border-top-left-radius: 10px; border-top-right-radius: 10px; display: flex; align-items: center; width: 100%; box-sizing: border-box;'>
    <div style='flex: 0 1 auto; width: 200px;'> <!-- Adjust width here -->
        <h1 style='font-family: cursive; color: #fff; font-size: 35px; margin: 0;'>Wolt</h1>
        <p style='color: #fff; font-family: sans-serif; font-size: 16px; margin-top: 5px;'>მადლობას გიხდით შეკვეთისთვის, <strong>{orderInfo.UserName}</strong></p>
    </div>
    <div style='flex: 1; text-align: center;'>
        <img src='https://i.postimg.cc/4d7G1B1n/unnamed.png' alt='Wolt Logo' style='width: 120px; height: 120px; margin-left: 120px;' /> <!-- Added margin-left -->
    </div>
</div>


        <!-- Order Details -->
        <div style='background-color: #ddd; padding: 20px;'>
            <p style='font-size: 16px; margin: 0 0 5px;'>თქვენი ქვითარი:</p>
            <p style='font-size: 16px; margin: 5px 0; font-weight: bold;'>{orderInfo.RestaurantName}</p>
            <p style='font-size: 16px; margin: 5px 0;'>{orderInfo.OrderDate}</p>
            <p style='font-size: 16px; margin: 5px 0;'>შეკვეთის ID: {orderInfo.OrderId}</p>
            <hr style='width: 100%; margin: 10px 0;'>
        </div>

        <!-- Payment Details -->
        <div style='background-color: #ddd; padding: 20px; display: flex; justify-content: space-between; align-items: flex-start;'>
            <div style='width: 50%;'>
                <p style='font-size: 17px; font-weight: bold; margin: 0;'>ჯამი</p>
                <div style='display: flex; flex-direction: column; align-items: flex-start; margin-top: 5px;'>
                    <img src='{RandomizedImageUrl}' alt='Card Image' style='width: 40px; height: 25px; background-color: #ccc;'>
                    <p style='margin: 5px 0 0; font-size: 12px; margin-left: 10px;'>{orderInfo.CreditCardNumber}</p>
                </div>
            </div>
            <div style='text-align: right; width: 50%;'>
                <p style='font-size: 17px; font-weight: bold; margin: 0;'>{orderInfo.TotalAmount}</p>
                <p style='font-size: 14px; margin: 0;'>{orderInfo.TotalAmount}</p>
            </div>
        </div>

        <!-- Last Section -->
        <div style='background-color: #d0d0d0; padding: 20px; border-bottom-left-radius: 10px; border-bottom-right-radius: 10px; text-align: center;'>
            <p style='font-size: 14px; line-height: 1.8; margin: 0;'>თქვენი შეკვეთის დოკუმენტები თანდართულია ამ იმეილში. კითხვების შემთხვევაში, გთხოვთ დაუკავშირდეთ დახმარების გუნდს.</p>
        </div>

    </div>
</body>

</html>";
            /// EMAIL HTML CONTENT  /// EMAIL HTML CONTENT /// EMAIL HTML CONTENT
            /// EMAIL HTML CONTENT  /// EMAIL HTML CONTENT /// EMAIL HTML CONTENT
            /// EMAIL HTML CONTENT  /// EMAIL HTML CONTENT /// EMAIL HTML CONTENT

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(ToAddress);
            mail.Subject = subject;
            mail.Body = htmlContent;
            mail.IsBodyHtml = true;

            mail.Attachments.Add(new Attachment(attachmentPathTXT));
            mail.Attachments.Add(new Attachment(attachmentPathPDF));

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(senderEmail, appPassword),
            };
            smtpClient.Send(mail);
        }

        private static (string UserName, string RestaurantName, string OrderDate, string OrderId,
                      string TotalAmount, string CreditCardNumber) ParseOrderFile(string filePath)
        {
            // Default values
            string userName = "Customer";
            string restaurantName = "Restaurant";
            string orderId = "N/A";
            string orderDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            string totalAmount = "0.00";
            string creditCardNumber = "XXXX-XXXX-XXXX-1234";

            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    // Extract information from the order file
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("Order ID:"))
                        {
                            orderId = line.Replace("Order ID:", "").Trim();
                        }
                        else if (line.StartsWith("Total Amount:"))
                        {
                            totalAmount = line.Replace("Total Amount:", "").Trim();
                        }
                        else if (line.StartsWith("Order Date:"))
                        {
                            orderDate = line.Replace("Order Date:", "").Trim();
                        }
                    }

                    // Get order ID from filename if not found in file
                    if (orderId == "N/A")
                    {
                        string fileName = Path.GetFileNameWithoutExtension(filePath);
                        if (fileName.StartsWith("Order_") && fileName.Length > 6)
                        {
                            orderId = fileName.Substring(6);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing order file: {ex.Message}");
            }

            return (
                UserName: userName,
                RestaurantName: restaurantName,
                OrderDate: orderDate,
                OrderId: orderId,
                TotalAmount: totalAmount,
                CreditCardNumber: creditCardNumber
            );
        }
    }
}