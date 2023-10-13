////////////////////////////////////////////////////////////////////////////////////////////////////////

//FileName: TicketBookings.cs

//FileType: Visual C# Source file

//Author : Madiwilage I.E

//Created On : 2/10/20123 9:56:39 AM

//Last Modified On :  13/10/20123 10:53:23 AM

//Copy Rights : N/A

//Description : TicketBooking class for model

////////////////////////////////////////////////////////////////////////////////////////////////////////
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EAD_WEB_API_Y4_S1.Models
{
    public class TicketBookings
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? BookingId { get; set; }

        [BsonElement("travelerId")]
        public string? TravelerId { get; set; } 

        [BsonElement("bookingDate")]
        public DateTime BookingDate { get; set; }

        [BsonElement("travelDate")]
        public DateTime TravelDate { get; set; }

        [BsonElement("trainName")]
        public string? TrainName { get; set; }

        [BsonElement("numberOfPassengers")]
        public int NumberOfPassengers { get; set; }

        [BsonElement("status")]
        public string Status { get; set; } = null!;

    }

}
