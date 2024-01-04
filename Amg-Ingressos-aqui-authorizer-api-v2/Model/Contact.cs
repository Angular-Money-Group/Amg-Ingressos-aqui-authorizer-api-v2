using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Amg_Ingressos_aqui_authorizer_api_v2.Model
{
    public class Contact
    {
        public Contact()
        {
            Email = string.Empty;
            PhoneNumber = string.Empty;
        }

        /// <summary>
        /// E-mail de validação 
        /// </summary> 
        [BsonElement("Email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Número para contato 
        /// </summary>    
        [BsonElement("PhoneNumber")]
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}