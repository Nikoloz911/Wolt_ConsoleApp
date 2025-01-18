using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Wolt_ConsoleApp.Twilio;
internal class TwilioService
{
    private readonly string _accountSid = "AC6050d2b967b8562ed0db05e3c377433f";
    private readonly string _authToken = "14d2f4cc482071168991158d4eba73c1";
    private readonly string _fromPhoneNumber = "+19783076324";

    public string SendVerificationCode(string toPhoneNumber)
    {
        var random = new Random();
        string verificationCode = random.Next(1000, 9999).ToString();

        try
        {
            TwilioClient.Init(_accountSid, _authToken);
            // Send the SMS
            var message = MessageResource.Create(
                to: new PhoneNumber(toPhoneNumber),
                from: new PhoneNumber(_fromPhoneNumber),
                body: $"Verification code is: {verificationCode}"
            );
            return verificationCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending message: {ex.Message}");
            return null;
        }
    }

}
