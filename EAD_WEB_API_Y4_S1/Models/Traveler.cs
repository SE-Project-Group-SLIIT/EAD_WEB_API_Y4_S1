////////////////////////////////////////////////////////////////////////////////////////////////////////

//FileName: Traveler.cs

//FileType: Visual C# Source file

//Author : Randika Batawala

//Created On : 8/8/2023 9:56:39 AM

//Last Modified On : 10/13/2023 15:26:23 PM

//Copy Rights : N/A

//Description : Class for defining database related functions

////////////////////////////////////////////////////////////////////////////////////////////////////////
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EAD_WEB_API_Y4_S1.Models
{
    public class Traveler
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string? Id { get; set; }

        //[BsonElement("nic")]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string NIC { get; set; } = null!;

        [BsonElement("fullName")]
        public string FullName { get; set; } = null!;

        //[BsonElement("lastName")]
        //public string LastName { get; set; } = null!;

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; } = null!;

        [BsonElement("isActive")]
        public bool IsActive { get; set; } 
        //public List<Booking> Bookings { get; set; }
    }
}
