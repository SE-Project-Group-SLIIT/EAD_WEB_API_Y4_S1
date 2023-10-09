using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EAD_WEB_API_Y4_S1.Models
{
    public class Trains
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? TrainId { get; set; }

        [BsonElement("trainName")]
        public string TrainName { get; set; } = null!;

        [BsonElement("departureStation")]
        public string DepartureStation { get; set; } = null!;

        [BsonElement("arrivalStation")]
        public string ArrivalStation { get; set; } = null!;

        [BsonElement("departureTime")]
        public DateTime DepartureTime { get; set; }

        [BsonElement("arrivalTime")]
        public DateTime ArrivalTime { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }

        [BsonElement("isPublished")]
        public bool IsPublished { get; set; }
        //public List<Schedule> Schedules { get; set; }
    }

    //public class Schedule
    //{
    //    public int ScheduleId { get; set; }
    //    public DateTime DepartureTime { get; set; }
    //    public DateTime ArrivalTime { get; set; }
    //}
}
