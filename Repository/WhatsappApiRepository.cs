using whatsApi.Repository.Interfaces;
using System.Threading.Tasks;
using whatsApi.Dtos;
using Microsoft.Extensions.Configuration;

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

            var accountSid = _config.GetSection("Twilo:sid").value; 
            var authToken = _config.GetSection("Twilo:key").value; 
            TwilioClient.Init(accountSid, authToken); 
 
            var messageOptions = new CreateMessageOptions(new PhoneNumber("whatsapp:+59160621860")); 
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");    
            messageOptions.Body = messageOut.Mensage;   
 
            var message = MessageResource.Create(messageOptions); 
            
            if(message) return true;
            return false;
        }
    }
}