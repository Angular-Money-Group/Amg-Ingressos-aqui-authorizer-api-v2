using Amg_Ingressos_aqui_authorizer_api_v2.Consts;
using Amg_Ingressos_aqui_authorizer_api_v2.Dto;
using Amg_Ingressos_aqui_authorizer_api_v2.Model;
using Amg_Ingressos_aqui_authorizer_api_v2.Services.Interfaces;
using Newtonsoft.Json;

namespace Amg_Ingressos_aqui_authorizer_api_v2.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public async Task<MessageReturn> GetUserColabByEvent(string idEvent)
        {
            var _messageReturn = new MessageReturn();

            try
            {
                var url = Settings.UserServiceApi;
                var uri = "v1/collaborator/event/";
                HttpClient _HttpClient = new HttpClient();

                var response = await _HttpClient.GetAsync(url + uri + idEvent);
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    _messageReturn.Data = JsonConvert.DeserializeObject<List<UserDto>>(jsonContent) ?? new List<UserDto>();
                }
                else
                    _messageReturn.Message = "Erro ao obter os dados do usuário.";

                return _messageReturn;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao processar a solicitação.");
                throw;
            }
        }
    }
}