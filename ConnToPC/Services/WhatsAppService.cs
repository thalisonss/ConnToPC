using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

public static class WhatsAppService
{
    public static void EnviarMensagem(string mensagem)
    {
        const string accountSid = "ACdad4f46fa958216f4b6a79f4b334598b";
        const string authToken = "ffa8708324b4e09bd5ceccd8621fb23e";

        TwilioClient.Init(accountSid, authToken);

        var message = MessageResource.Create(
            from: new PhoneNumber("whatsapp:+14155238886"),
            to: new PhoneNumber("whatsapp:+5511988807278"),
            body: mensagem
        );
    }
}