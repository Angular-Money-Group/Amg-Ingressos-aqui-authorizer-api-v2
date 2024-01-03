namespace Amg_Ingressos_aqui_authorizer_api_v2.Dto
{
    public class LoginQrCodeDto
    {
        public LoginQrCodeDto()
        {
            Email = string.Empty;
            Password = string.Empty;
            IdEvent = string.Empty;
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string IdEvent { get; set; }
    }
}