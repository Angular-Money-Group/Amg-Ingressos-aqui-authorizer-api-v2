using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Amg_Ingressos_aqui_authorizer_api_v2.Model
{
    public class UserConfirmation
    {
        public UserConfirmation()
        {
            EmailConfirmationCode = string.Empty;
        }

        /// <summary>
        /// Confirmação de e-mail
        /// </summary>
        [Required]
        [BsonElement("EmailConfirmationCode")]
        [JsonPropertyName("emailConfirmationCode")]
        public string EmailConfirmationCode { get; set; }

        /// <summary>
        /// Codigo de confirmação de e-mail
        /// </summary>
        [Required]
        [BsonElement("EmailConfirmationExpirationDate")]
        [JsonPropertyName("emailConfirmationExpirationDate")]
        public DateTime? EmailConfirmationExpirationDate { get; set; }

        /// <summary> 
        /// flag de email verificado 
        /// </summary>
        [Required]
        [BsonElement("EmailVerified")]
        [JsonPropertyName("emailVerified")]
        public bool EmailVerified { get; set; } = false;

        /// <summary> 
        /// flag de telefone verificado 
        /// </summary>
        [Required]
        [BsonElement("PhoneVerified")]
        [JsonPropertyName("phoneVerified")]
        public bool PhoneVerified { get; set; } = false;
    }
}