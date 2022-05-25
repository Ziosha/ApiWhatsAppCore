using whatsApi.Repository.Interfaces;
using System.Threading.Tasks;
using whatsApi.Dtos;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace whatsApi.Repository
{
    public class WhatsappApiRepository : IWhatsappApiRepository
    {
        private readonly IConfiguration _config;

        public WhatsappApiRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> SendWhatsapp(WhatsappSendDto messageOut)
        {

            var accountSid = _config.GetSection("Twilio:sid").Value; 
            var authToken = _config.GetSection("Twilio:key").Value; 
            TwilioClient.Init(accountSid, authToken); 
 
            var messageOptions = new CreateMessageOptions(new PhoneNumber("whatsapp:+59160621860")); 
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");    
            messageOptions.Body = messageOut.Mensage;   
 
            var message = MessageResource.Create(messageOptions); 
            
            if(message != null) return true;
            return false;
        }
    }
}