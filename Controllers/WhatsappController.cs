using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Collections.Generic; 
using Twilio.Types;
using whatsApi.Dtos;
using whatsApi.Repository.Interfaces;
using whatsApi.Repository;


namespace Whatsapp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class WhatsappController : ControllerBase
    {
        private readonly IWhatsappApiRepository _whatsrepo;
        public WhatsappController(IWhatsappApiRepository whatsrepo)
        {
            _whatsrepo = whatsrepo;
        }


        [HttpPost]
        public async Task<IActionResult> SendWhatsapp(WhatsappSendDto messageOut)
        {
            var whatsapp = await _whatsrepo.SendWhatsapp(messageOut);
            if(Whatsapp) return Ok("suscces");
            return BadRequest("No enviado");
        }

       
        // public TwiMlResult Index(SmsRequest message)
        // {
        //     var menssagingResponse = new menssagingResponse();
        //     menssagingResponse.Menssage("Hola que tal buen dia a ti...");
        //     return TwiML(menssagingResponse); 
        // }


    }
}