﻿using EAD_WEB_API_Y4_S1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EAD_WEB_API_Y4_S1.Services
{
    public class TicketBookingService
    {
        private readonly IMongoCollection<TicketBookings> _TicketBookingsCollection;

        public TicketBookingService(IOptions<TicketBookingsStoreDatabaseSettings> ticketBookingsStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                ticketBookingsStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                ticketBookingsStoreDatabaseSettings.Value.DatabaseName);

            _TicketBookingsCollection = mongoDatabase.GetCollection<TicketBookings>(
                ticketBookingsStoreDatabaseSettings.Value.TrainBookingCollectionName);
        }

        public async Task<List<TicketBookings>> GetAsync() =>
      await _TicketBookingsCollection.Find(_ => true).ToListAsync();

        public async Task<TicketBookings?> GetAsync(string id) =>
            await _TicketBookingsCollection.Find(x => x.BookingId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(TicketBookings newTicketBookings) =>
            await _TicketBookingsCollection.InsertOneAsync(newTicketBookings);

        public async Task UpdateAsync(string id, TicketBookings updatedTicketBookings) =>
            await _TicketBookingsCollection.ReplaceOneAsync(x => x.BookingId == id, updatedTicketBookings);

        public async Task RemoveAsync(string id) =>
            await _TicketBookingsCollection.DeleteOneAsync(x => x.BookingId == id);
    }
}
