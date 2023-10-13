﻿using EAD_WEB_API_Y4_S1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EAD_WEB_API_Y4_S1.Services;

public class TravelerService
{
    private readonly IMongoCollection<Traveler> _TravelerCollection;

    public TravelerService(IOptions<TravelerStoreDatabaseSettings> travelerStoreDatabaseSettings) 
    {
        var mongoClient = new MongoClient(
            travelerStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            travelerStoreDatabaseSettings.Value.DatabaseName);

        _TravelerCollection = mongoDatabase.GetCollection<Traveler>(
            travelerStoreDatabaseSettings.Value.TravelerCollectionName);
    }

    public async Task<List<Traveler>> GetAsync() =>
       await _TravelerCollection.Find(_ => true).ToListAsync();

    public async Task<Traveler?> GetAsync(string id) =>
        await _TravelerCollection.Find(x => x.NIC == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Traveler newTraveler) =>
        await _TravelerCollection.InsertOneAsync(newTraveler);

    public async Task UpdateAsync(string id, Traveler updatedTraveler) =>
        await _TravelerCollection.ReplaceOneAsync(x => x.NIC == id, updatedTraveler);

    public async Task RemoveAsync(string id) =>
        await _TravelerCollection.DeleteOneAsync(x => x.NIC == id);

    public async Task<Traveler?> LoginAsync(string nic, string email)
    {
        // Check if the traveler exists with the provided NIC and email
        var traveler = await _TravelerCollection.Find(x => x.NIC == nic && x.Email == email).FirstOrDefaultAsync();

        return traveler;
    }

}
