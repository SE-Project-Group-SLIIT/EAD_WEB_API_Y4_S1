﻿using EAD_WEB_API_Y4_S1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EAD_WEB_API_Y4_S1.Services
{
    public class TrainService
    {
        private readonly IMongoCollection<Trains> _TrainCollection;

        public TrainService(IOptions<TrainsStoreDatabaseSettings> trainsStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                trainsStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                trainsStoreDatabaseSettings.Value.DatabaseName);

            _TrainCollection = mongoDatabase.GetCollection<Trains>(
                trainsStoreDatabaseSettings.Value.TrainCollectionName);
        }

        public async Task<List<Trains>> GetAsync() =>
           await _TrainCollection.Find(_ => true).ToListAsync();

        public async Task<Trains?> GetAsync(string id) =>
            await _TrainCollection.Find(x => x.TrainId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Trains newTrains) =>
            await _TrainCollection.InsertOneAsync(newTrains);

        public async Task UpdateAsync(string id, Trains updatedTrains) =>
            await _TrainCollection.ReplaceOneAsync(x => x.TrainId == id, updatedTrains);

        public async Task RemoveAsync(string id) =>
            await _TrainCollection.DeleteOneAsync(x => x.TrainId == id);

    }
}
