using System.Threading.Tasks;
using whatsApi.Dtos;

namespace whatsApi.Repository.interfaces
{
    public interface IWhatsappApiRepository
    {
        Task<bool> SendWhatsapp(WhatsappSendDto messageOut);
    }
}