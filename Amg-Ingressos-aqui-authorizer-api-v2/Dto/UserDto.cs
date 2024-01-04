using MongoDB.Bson.Serialization.Attributes;

namespace Amg_Ingressos_aqui_authorizer_api_v2.Dto
{
    [BsonIgnoreExtraElements]
    public class UserDto
    {
        public UserDto()
        {
            Id = string.Empty;
            Name = string.Empty;
            DocumentId = string.Empty;
            Email = string.Empty;
            IdAssociate = string.Empty;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string DocumentId { get; set; }
        public string Email { get; set; }
        public string IdAssociate { get; set; }
    }
}