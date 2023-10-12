using EAD_WEB_API_Y4_S1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EAD_WEB_API_Y4_S1.Services
{
    public class TrainScheduleService
    {
        private readonly IMongoCollection<TrainSchedule> _TrainScheduleCollection;

        public TrainScheduleService(IOptions<TrainScheduleStoreDatabaseSettings> trainScheduleStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                trainScheduleStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                trainScheduleStoreDatabaseSettings.Value.DatabaseName);

            _TrainScheduleCollection = mongoDatabase.GetCollection<TrainSchedule>(
                trainScheduleStoreDatabaseSettings.Value.TrainScheduleCollectionName);
        }
        public async Task<List<TrainSchedule>> GetTrainSchedulesByStations(string station1, string station2)
        {
            var filter = Builders<TrainSchedule>.Filter.All("trainStations", new List<string> { station1, station2 });

            return await _TrainScheduleCollection.Find(filter).ToListAsync();
        }
        public async Task<List<TrainSchedule>> GetAsync() =>
           await _TrainScheduleCollection.Find(_ => true).ToListAsync();

        public async Task<TrainSchedule?> GetAsync(string id) =>
            await _TrainScheduleCollection.Find(x => x.TrainScheduleId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(TrainSchedule newTrainSchedules) =>
            await _TrainScheduleCollection.InsertOneAsync(newTrainSchedules);

        public async Task UpdateAsync(string id, TrainSchedule updatedTrainSchedules) =>
            await _TrainScheduleCollection.ReplaceOneAsync(x => x.TrainScheduleId == id, updatedTrainSchedules);

        public async Task RemoveAsync(string id) =>
            await _TrainScheduleCollection.DeleteOneAsync(x => x.TrainScheduleId == id);
    }
}
