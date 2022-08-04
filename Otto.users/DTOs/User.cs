using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Otto.users.DTOs
{
    public class User
    {
        [BsonId]
        [JsonPropertyName("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [JsonPropertyName("userName")]
        public string Name { get; set; }

        [JsonPropertyName("userPass")]
        public string Pass { get; set; }

        [JsonPropertyName("userMail")]
        public string Mail { get; set; }

        [JsonPropertyName("userRol")]
        public string Rol { get; set; }

        [JsonPropertyName("favoritos")]
        public List<string> Favorites { get; set; }
    }
}
