using Amg_Ingressos_aqui_authorizer_api_v2.Model;

namespace Amg_Ingressos_aqui_authorizer_api_v2.Services.Interfaces
{
    public interface IUserService
    {
        Task<MessageReturn> GetUserColabByEvent(string idEvent);
    }
}