////////////////////////////////////////////////////////////////////////////////////////////////////////

//FileName: TrainSchedule.cs

//FileType: Visual C# Source file

//Author : J.A.M.G.Jayakody

//Created On : 8/8/2023 9:56:39 AM

//Last Modified On : 10/13/2023 15:26:23 PM

//Copy Rights : N/A

//Description : Class controller for defining database related functions

////////////////////////////////////////////////////////////////////////////////////////////////////////
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
