using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EAD_WEB_API_Y4_S1.Models
{
    public class TrainSchedule
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? TrainScheduleId { get; set; }

        [BsonElement("trainName")]
        public string TrainName { get; set; } = null!;

        [BsonElement("departureStation")]
        public string DepartureStation { get; set; } = null!;

        [BsonElement("arrivalStation")]
        public string ArrivalStation { get; set; } = null!;

        [BsonElement("trainType")]
        public string TrainType { get; set; } = null!;

        [BsonElement("departureTime")]
        public DateTime DepartureTime { get; set; }

        [BsonElement("arrivalTime")]
        public DateTime ArrivalTime { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }

        [BsonElement("isPublished")]
        public bool IsPublished { get; set; }

        [BsonElement("scheduleDate")]
        public DateTime ScheduleDate { get; set; }

        [BsonElement("trainStations")]
        public List<string> TrainStations { get; set; } = new List<string>();

        [BsonElement("isCancelled")]
        public bool IsCancelled { get; set; }

    }
}
