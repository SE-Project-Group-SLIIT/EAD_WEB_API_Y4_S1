using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EAD_WEB_API_Y4_S1.Models
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }

        [BsonElement("username")]
        public string Username { get; set; } = null!;

        [BsonElement("password")]
        public string Password { get; set; } = null!;

        [BsonElement("role")]
        public string Role { get; set; } = null!;

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("nic")]
        public string NIC { get; set; } = null !;
    }
}
