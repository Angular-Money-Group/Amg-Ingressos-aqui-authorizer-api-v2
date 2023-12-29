using Amg_Ingressos_aqui_authorizer_api_v2.Model;

namespace Amg_Ingressos_aqui_authorizer_api_v2.Services.Interfaces
{
    public interface IAuthService
    {
        Task<MessageReturn> Login(string email, string password);
        Task<MessageReturn> LoginColab(string email, string password,string idEvent);
    }
}