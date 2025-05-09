using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

public static class WhatsAppService
{
    public static void EnviarMensagem(string mensagem)
    {
        const string accountSid = "";
        const string authToken = "";

        TwilioClient.Init(accountSid, authToken);

        var message = MessageResource.Create(
            from: new PhoneNumber(""),
            to: new PhoneNumber(""),
            body: mensagem
        );
    }
}
