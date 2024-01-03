namespace Amg_Ingressos_aqui_authorizer_api_v2.Dto
{
    public class LoginDto
    {
        public LoginDto()
        {
            Email = string.Empty;
            Password = string.Empty;
        }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}