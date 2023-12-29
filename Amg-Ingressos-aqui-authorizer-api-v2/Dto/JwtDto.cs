using System.Text.Json.Serialization;

namespace Amg_Ingressos_aqui_authorizer_api_v2.Dto
{
    public class JwtDto
    {
        public JwtDto()
        {
            JwtToken = string.Empty;
        }
        
        [JsonPropertyName("jwtToken")]
        public string JwtToken { get; set; }
    }
}