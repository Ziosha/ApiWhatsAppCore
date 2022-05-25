using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; 
using whatsApi.Dtos;
using whatsApi.Repository.Interfaces;

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
            if(whatsapp) return Ok("suscces");
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