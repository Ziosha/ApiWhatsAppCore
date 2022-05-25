using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Collections.Generic; 
using Twilio.Types;
using whatsApi.Dtos;


namespace Whatsapp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class WhatsappController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> SendWhatsapp(WhatsappSendDto messageOut)
        {
            var accountSid = "[sid]; 
            var authToken = "[key]"; 
            TwilioClient.Init(accountSid, authToken); 
 
            var messageOptions = new CreateMessageOptions( 
            new PhoneNumber("whatsapp:+59160621860")); 
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");    
            messageOptions.Body = messageOut.Mensage;   
 
            var message = MessageResource.Create(messageOptions); 
            Console.WriteLine(message.Body); 
            return Ok("succes");
        }

       
        // public TwiMlResult Index(SmsRequest message)
        // {
        //     var menssagingResponse = new menssagingResponse();
        //     menssagingResponse.Menssage("Hola que tal buen dia a ti...");
        //     return TwiML(menssagingResponse); 
        // }


    }
}