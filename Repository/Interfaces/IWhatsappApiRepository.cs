using System.Threading.Tasks;
using whatsApi.Dtos;

namespace whatsApi.Repository.Interfaces
{
    public interface IWhatsappApiRepository
    {
        Task<bool> SendWhatsapp(WhatsappSendDto messageOut);
    }
}