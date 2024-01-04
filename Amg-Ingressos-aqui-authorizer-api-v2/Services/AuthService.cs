using Amg_Ingressos_aqui_authorizer_api_v2.Consts;
using Amg_Ingressos_aqui_authorizer_api_v2.Dto;
using Amg_Ingressos_aqui_authorizer_api_v2.Exceptions;
using Amg_Ingressos_aqui_authorizer_api_v2.Model;
using Amg_Ingressos_aqui_authorizer_api_v2.Repository.Interfaces;
using Amg_Ingressos_aqui_authorizer_api_v2.Services.Interfaces;
using Amg_Ingressos_aqui_authorizer_api_v2.Utils;

namespace Amg_Ingressos_aqui_authorizer_api_v2.Services
{
    public class AuthService : IAuthService
    {
        private readonly MessageReturn _messageReturn;
        private readonly ILogger<AuthService> _logger;
        private readonly ICrudRepository<User> _crudRepository;
        private readonly IUserService _userService;


        public AuthService(ILogger<AuthService> logger,
        ICrudRepository<User> crudRepository,
        IUserService userService)
        {
            _logger = logger;
            _messageReturn = new MessageReturn();
            _crudRepository = crudRepository;
            _userService = userService;
        }

        public async Task<MessageReturn> Login(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    throw new RuleException("Email é necessário.");
                if (string.IsNullOrEmpty(password))
                    throw new RuleException("Senha é necessário.");

                password = AesOperation.EncryptString(Settings.KeyEncript, password);

                var dic = new Dictionary<string, object>() { { "Contact.Email", email }, { "Password", password } };
                var dataUser = await _crudRepository.GetByFilter(dic);
                if (dataUser != null && dataUser.Any())
                {
                    string token = TokenService.GenerateToken(dataUser[0]);
                    _messageReturn.Data = token;
                    return _messageReturn;
                }
                else
                    throw new RuleException("Erro ao realizar login: Usuário não encontrado");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Format(MessageLogErrors.Login, this.GetType().Name, nameof(Login)));
                throw;
            }
        }

        public async Task<MessageReturn> LoginColab(string email, string password, string idEvent)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    throw new RuleException("Email é necessário.");
                if (string.IsNullOrEmpty(password))
                    throw new RuleException("Senha é necessário.");

                password = AesOperation.EncryptString(Settings.KeyEncript, password);

                var dic = new Dictionary<string, object>() { { "Contact.Email", email }, { "Password", password } };
                //dados de usuario na base
                var dataUser = await _crudRepository.GetByFilter(dic);

                if (dataUser == null || !dataUser.Any())
                    throw new RuleException("Erro ao realizar login: Usuário não encontrado");
                //dados de vinculo com evento
                var dataEvent = _userService.GetUserColabByEvent(idEvent).Result;

                if (dataEvent.Data == null)
                    throw new RuleException("Erro ao realizar login: Colaborador não cadastrado ao evento");
                else
                {
                    if (((List<UserDto>)dataEvent.Data).Find(u => u.Id == dataUser[0].Id) != null)
                    {
                        string token = TokenService.GenerateToken(dataUser[0]);
                        _messageReturn.Data = token;
                        return _messageReturn;
                    }
                    else
                        throw new RuleException("Erro ao realizar login: Colaborador não cadastrado ao evento");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Format(MessageLogErrors.Login, this.GetType().Name, nameof(LoginColab)));
                throw;
            }
        }
    }
}