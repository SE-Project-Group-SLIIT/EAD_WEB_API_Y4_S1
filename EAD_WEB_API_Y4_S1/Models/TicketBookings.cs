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
        public string? TravelerId { get; set; } = null!;

        [BsonElement("bookingDate")]
        public DateTime BookingDate { get; set; }

        [BsonElement("travelDate")]
        public DateTime TravelDate { get; set; }

        [BsonElement("trainId")]
        public int TrainId { get; set; }

        [BsonElement("numberOfPassengers")]
        public int NumberOfPassengers { get; set; }

        [BsonElement("status")]
        public string Status { get; set; } = null!;
    }

}
