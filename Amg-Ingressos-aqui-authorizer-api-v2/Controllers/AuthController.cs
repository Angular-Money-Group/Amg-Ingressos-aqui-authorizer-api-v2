using Amg_Ingressos_aqui_authorizer_api_v2.Dto;
using Amg_Ingressos_aqui_authorizer_api_v2.Exceptions;
using Amg_Ingressos_aqui_authorizer_api_v2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Amg_Ingressos_aqui_authorizer_api_v2.Controllers
{
    [Route("v3/auth")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        /// <summary>
        /// Busca os eventos
        /// </summary>
        /// <param name="filters"> filtros </param>
        /// <param name="paginationOptions"> paginacao </param>
        /// <returns>200 Lista de todos eventos</returns>
        /// <returns>204 Nenhum evento encontrado</returns>
        /// <returns>500 Erro inesperado</returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
                throw new RuleException("Email e Senha são necessários");

            var result = await _authService.Login(login.Email, login.Password);

            if (result.Message != null && result.Message.Any())
            {
                _logger.LogInformation(result.Message);
                return StatusCode(500, result.Message);
            }
            if (result.Data.ToString() == string.Empty)
                return NoContent();

            return Ok(result.Data);
        }

        /// <summary>
        /// Busca os eventos
        /// </summary>
        /// <param name="filters"> filtros </param>
        /// <param name="paginationOptions"> paginacao </param>
        /// <returns>200 Lista de todos eventos</returns>
        /// <returns>204 Nenhum evento encontrado</returns>
        /// <returns>500 Erro inesperado</returns>
        [HttpPost]
        [Route("login/colab")]
        public async Task<IActionResult> LoginColab([FromBody] LoginQrCodeDto login)
        {
            if (!ModelState.IsValid)
                throw new RuleException("Email e Senha são necessários");

            var result = await _authService.LoginColab(login.Email, login.Password, login.IdEvent);

            if (result.Message != null && result.Message.Any())
            {
                _logger.LogInformation(result.Message);
                return StatusCode(500, result.Message);
            }
            if (result.Data.ToString() == string.Empty)
                return NoContent();

            return Ok(result.Data);
        }
    }
}