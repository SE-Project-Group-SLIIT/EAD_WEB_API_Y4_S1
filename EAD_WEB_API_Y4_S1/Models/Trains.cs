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

        [BsonElement("trainType")]
        public string TrainType { get; set; } = null!;

        [BsonElement("trainStations")]
        public List<string> TrainStations { get; set; } = new List<string>();

    }
}
